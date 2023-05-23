using Grpc.Core;
using GrpcService_Hello;

namespace GrpcService_Hello.Services
{
    public class GreeterService : Greeter.GreeterBase
    {
        private readonly ILogger<GreeterService> _logger;

        public GreeterService(ILogger<GreeterService> logger)
        {
            _logger = logger;
        }

        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            return Task.FromResult(new HelloReply
            {
                Message = "Hello Server -> " + request.Name
            });
        }

        public override Task<HelloReply> SayHelloAgain(HelloRequest request, ServerCallContext context)
        {
            return Task.FromResult(new HelloReply
            {
                Message = "Hello Again " + request.Name
            });
        }


        public override Task<CountReply> Count(CountRequest request, ServerCallContext context)
        {
            int numbers = request.Num + 1;

            return Task.FromResult(new CountReply
            {
                Message = "Count : " + numbers
            });
        }

        public override async Task CountServer( CountRequest request,
            IServerStreamWriter<CountReply> responseStream, ServerCallContext context)
        {   

            var i = request.Num;
            var cancel = context.CancellationToken.IsCancellationRequested;

            while (!cancel && (i > 0)) 
            {
                var message = $"Count : {i--} 초 지남";
                await responseStream.WriteAsync(new CountReply { Message = message });
                await Task.Delay(1000);

                if (i == 0)
                {
                    break;
                }
            }

            await responseStream.WriteAsync(new CountReply { Message = "카운터 종료" });

            
        }
    }
}