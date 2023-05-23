using System;
using System.IO;    // File.ReadAllText
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Grpc.Core;
//using NatNetML;
using Grpc.Core.Interceptors;
using Google.Protobuf.WellKnownTypes;
using GrpcProtos_Standard20;



// Framework 4.8
namespace GrpcClient
{
    public class ChatServiceClient : IDisposable
    {
        private readonly Chat.ChatClient m_client;
        private readonly Channel m_channel;
        private readonly CancellationTokenSource m_cts = new CancellationTokenSource();
        private bool disposedValue;

        public ChatServiceClient()
        {
            var secure = false;

            if (secure)
            {
                var serverCACert = File.ReadAllText(@"C:\localhost_server.crt");
                var clientCert = File.ReadAllText(@"C:\localhost_client.crt");
                var clientKey = File.ReadAllText(@"C:\localhost_clientkey.pem");
                var keyPair = new KeyCertificatePair(clientCert, clientKey);

                var credentials = new SslCredentials(serverCACert);
                m_channel = new Channel("localhost", 50052, credentials);
                m_client = new Chat.ChatClient(
                    m_channel.
                    Intercept(new ClientIdInjector()).
                    Intercept(new HeadersInjector()));

            }
            else
            {
                // create insecure channel
                m_channel = new Channel("localhost", 50052, ChannelCredentials.Insecure);
                m_client = new Chat.ChatClient(
                    m_channel
                    .Intercept(new ClientIdInjector()) // 2nd
                    .Intercept(new HeadersInjector())); // 1st
            }
        }

        public async Task Write(ChatLog chatLog)
        {
            await m_client.WriteAsync(chatLog);
        }

        public IAsyncEnumerable<ChatLog> ChatLogs()
        {
            var call = m_client.Subscribe(new Empty(), cancellationToken: m_cts.Token);

            // I do not want to expose gRPC such as IAsyncStreamReader or AsyncServerStreamingCall.
            // I also do not want to bother user of this class with asking to dispose the call object.

            return call.ResponseStream
                .ToAsyncEnumerable()
                .Finally(() => call.Dispose());
        }

        protected virtual void Dispose(bool disposing) 
        {
            if (!disposedValue)
            {
                if (disposing) 
                {
                    m_cts.Cancel(); // without cancel active calls, ShutdownAsync() never completes...
                    m_channel.ShutdownAsync().Wait();
                }
                
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
