using Grpc.Core;
using GrpcService_TEST;
using Microsoft.AspNetCore.WebUtilities;
using System.Xml.Linq;

namespace GrpcService_TEST.Services
{
    public class TesterService : Tester.TesterBase
    {
        //private readonly IGreeter _greeter;

        //public TesterService(IGreeter greeter)
        //{
        //    _greeter = greeter;
        //}

        private readonly ILogger<TesterService> _logger;

        public TesterService(ILogger<TesterService> logger)
        {
            _logger = logger;
        }


        public override Task<HelloReply> SayHelloUnary(HelloRequest request, ServerCallContext context)
        {
            //_logger.LogInformation($"Creating greeting to {request.Name}");
            var message = $"Hello {request.Name}";

            //var message = _greeter.Greet(request.Name);
            return Task.FromResult(new HelloReply{ Message = message });
        }

        //public override async Task SayHelloServerStreaming(HelloRequest request,
        public override async Task SayHelloServerStreaming(HelloRequest request,
            IServerStreamWriter<HelloReply> responseStream, ServerCallContext context)
        {
            var i = 0;

            var cancel = context.CancellationToken.IsCancellationRequested; // �۵��Ǹ� True
            while (!cancel && (i < 3))  // �ð��� 5�� �̸�, Cancel -> 1�Ǹ� ����
            {
                //var message = _greeter.Greet($"{request.Name} {++i}");
                var message = $"Hello {request.Name} {++i}";    // ����� 1����
                await responseStream.WriteAsync(new HelloReply { Message = message });

                await Task.Delay(1000); // i �� 1�ʸ��� ������
                //Console.WriteLine($"[Cancellation] : {cancel}");
            }
        }

        //public override async Task<HelloReply> SayHelloClientStreaming(
        public override async Task<HelloReply> SayHelloClientStreaming(
            IAsyncStreamReader<HelloRequest> requestStream, ServerCallContext context)
        {
            var names = new List<string>();
            var i = 0;

            await foreach (var request in requestStream.ReadAllAsync())
            {
                // names List �� �߰�
                names.Add(++i + ") " + request.Name); // �ð� �ɸ��� �κ�

                if (i >= 5)
                {
                    break;
                }
            }

            //var message = _greeter.Greet(string.Join(", ", names));
            var message = string.Join("\r\n", names);

            
            return new HelloReply { Message = message };

        }

        public override async Task SayHelloBidirectionalStreaming(   
            IAsyncStreamReader<HelloRequest> requestStream, // �񵿱�� �б�
            IServerStreamWriter<HelloReply> responseStream, // �������� �ۼ�
            ServerCallContext context)
        {

            var i = 0;
            await foreach (var request in requestStream.ReadAllAsync()) // Ŭ���̾�Ʈ�κ��� �б�
            {
                await responseStream.WriteAsync(
                    //new HelloReply { Message = _greeter.Greet(request.Name) });
                new HelloReply { Message = $"Hello {request.Name}:{++i}" }); // Ŭ���̾�Ʈ�� �����ϱ�
            }

            
        }
    }
}