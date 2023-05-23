using Grpc.Core;
using Grpc_File_Test;

using Grpc.Core.Interceptors;
using Microsoft.AspNetCore.Authentication.OAuth;

namespace Grpc_File_Test.Services
{

    public class CalcService : Calculator.CalculatorBase
    {
        private readonly ILogger<CalcService> _logger;
        public CalcService(ILogger<CalcService> logger)
        {
            _logger = logger;
        }

        public override Task<GetResponse> Get(GetRequest request, ServerCallContext context) 
        {
            Int32 temp = 0;
            temp = request.Result + 1;

            return Task.FromResult(new GetResponse 
            {
                Message = "GetResponse -> " + request.Id + "[" + temp + "]"
            });
        }
    }
}