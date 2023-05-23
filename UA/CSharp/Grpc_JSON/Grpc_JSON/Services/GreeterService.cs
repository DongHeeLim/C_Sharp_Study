using Grpc.Core;
using Grpc_JSON;
using Newtonsoft.Json;
using Grpc_JSON.Helper;

namespace Grpc_JSON.Services
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

            Console.WriteLine(request);

           


            return Task.FromResult(new HelloReply
            {
                Message = request.ToString()
            });
        }

        public override async Task StreamingJson(
            IAsyncStreamReader<JsonDataRequest> requestStream,
            IServerStreamWriter<JsonDataReply> responseStream, 
            ServerCallContext context)
        {
            var i = 0;
            Target target = new Target("Server_ID", i);
            Console.WriteLine(target.Id + "  " + target.Count);

            await foreach (var request in requestStream.ReadAllAsync()) // foreach requestStream에 대한 연구가 필요
            {
                string received_data = request.Msg.ToString();

                Console.WriteLine(received_data);

                Target deserialzed_data = JsonConvert.DeserializeObject<Target>(received_data);

                
                target.Id = deserialzed_data.Id;
                target.Count= deserialzed_data.Count;

                Console.WriteLine(target.Id + "  " + target.Count);

                target.Count = deserialzed_data.Count;

                await responseStream.WriteAsync(new JsonDataReply {Msg = $"{target.Id} : {target.Count}" });
            }
        }
    }

}