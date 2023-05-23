using Grpc.Core.Interceptors;
using Grpc.Net.Client;
using Grpc_Client;
using Grpc_Interceptor;
using Microsoft.Extensions.Logging;
using Grpc_Client.ClientInterceptor;    // ClientLoggingInterceptor 있는 폴더
using System.Threading.Channels;

class Program
{

    static async Task Main(string[] args)
    {


        var loggerFactory = LoggerFactory.Create(logging =>
        {
            logging.SetMinimumLevel(LogLevel.Debug);
        });

        using var channel = GrpcChannel.ForAddress("https://localhost:7179", new GrpcChannelOptions { LoggerFactory = loggerFactory });
        var invoker = channel.Intercept(new ClientLoggingInterceptor(loggerFactory));
        var client = new Greeter.GreeterClient(invoker);

        var replyAsync = await client.SayHelloAsync(new HelloRequest { Name = "LIM" });
        //var reply = client.SayHello(new HelloRequest { Name = "Dong" });

        Console.WriteLine($"Async Greeting {replyAsync.Message}");
        //Console.WriteLine($"Blocking Greeting {reply.Message}");

    }
}


