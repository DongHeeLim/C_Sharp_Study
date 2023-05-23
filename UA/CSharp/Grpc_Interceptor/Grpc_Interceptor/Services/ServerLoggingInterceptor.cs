using Grpc.Core;
using Grpc.Core.Interceptors;
using System.Formats.Asn1;

// Client -> Server 요청, Server 중간 서비스가 가로챔
namespace Grpc_Interceptor.Services
{
    public class ServerLoggingInterceptor : Interceptor
    {
        private readonly ILogger _logger;

        public ServerLoggingInterceptor(ILogger<ServerLoggingInterceptor> logger) 
        {
            _logger = logger;
        }



        public override async Task<TResponse> UnaryServerHandler<TRequest, TResponse>(   // async 에 대한 interceptor
            TRequest request,
            ServerCallContext context,
            UnaryServerMethod<TRequest, TResponse> continuation) 
        {
            _logger.LogInformation($"Starting receiving call. Type: {MethodType.Unary}. " + $"Method: {context.Method}");  
            
            try
            {
                return await continuation(request, context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error thrown by {context.Method}");
                throw;
            }
        
        }
    }
}
