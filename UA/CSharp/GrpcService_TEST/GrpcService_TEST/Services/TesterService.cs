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

            var cancel = context.CancellationToken.IsCancellationRequested; // 작동되면 True
            while (!cancel && (i < 3))  // 시간이 5초 미만, Cancel -> 1되면 종료
            {
                //var message = _greeter.Greet($"{request.Name} {++i}");
                var message = $"Hello {request.Name} {++i}";    // 출력은 1부터
                await responseStream.WriteAsync(new HelloReply { Message = message });

                await Task.Delay(1000); // i 가 1초마다 증가함
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
                // names List 에 추가
                names.Add(++i + ") " + request.Name); // 시간 걸리는 부분

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
            IAsyncStreamReader<HelloRequest> requestStream, // 비동기식 읽기
            IServerStreamWriter<HelloReply> responseStream, // 서버에서 작성
            ServerCallContext context)
        {

            var i = 0;
            await foreach (var request in requestStream.ReadAllAsync()) // 클라이언트로부터 읽기
            {
                await responseStream.WriteAsync(
                    //new HelloReply { Message = _greeter.Greet(request.Name) });
                new HelloReply { Message = $"Hello {request.Name}:{++i}" }); // 클라이언트로 응답하기
            }

            
        }
    }
}