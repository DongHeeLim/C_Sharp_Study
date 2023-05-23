using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grpc.Core;
using Grpc.Core.Interceptors;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Grpc_Client.ClientInterceptor
{
    public class ClientLoggingInterceptor : Interceptor   //상속을 통해 Interceptor 껍데기 가져오기, internal -> public
    {
        private ILogger<ClientLoggingInterceptor> _logger;
   
        public ClientLoggingInterceptor(ILoggerFactory loggerFactory)
        {
            
            _logger = loggerFactory.CreateLogger<ClientLoggingInterceptor>();

        }




        public override AsyncUnaryCall<TResponse> AsyncUnaryCall<TRequest, TResponse>(       // async 에 대한 interceptor
            TRequest request,
            ClientInterceptorContext<TRequest, TResponse> context, 
            AsyncUnaryCallContinuation<TRequest, TResponse> continuation)
        {
            
            _logger.LogInformation($"Starting call Type: {context.Method.Type}. " + $"Method : {context.Method.Name}.");
            //_logger.LogDebug($"Starting receiving call. Type: {context.Method.Type}. " + $"Method: {context.Method.Name}");
            Console.WriteLine($"Starting call Type: {context.Method.Type}. " + $"Method : {context.Method.Name}.");


            return continuation(request, context);
        }

        // 재정의 하여 구현
        public override TResponse BlockingUnaryCall<TRequest, TResponse>(
            TRequest request, 
            ClientInterceptorContext<TRequest, TResponse> context, 
            BlockingUnaryCallContinuation<TRequest, TResponse> continuation)
        {
            //_logger.LogInformation($"{nameof(BlockingUnaryCall)}");

            return base.BlockingUnaryCall(request, context, continuation);
        }
    }
}
