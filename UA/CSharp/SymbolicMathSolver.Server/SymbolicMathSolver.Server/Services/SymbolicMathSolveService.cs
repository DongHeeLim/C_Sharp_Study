using Grpc.Core;
using SymbolicMathSolver.Server;

namespace SymbolicMathSolver.Server.Services
{
    public class SymbolicMathSolveService : Solver.SolverBase
    {
        private readonly ILogger<SymbolicMathSolveService> _logger;
        public SymbolicMathSolveService(ILogger<SymbolicMathSolveService> logger)
        {
            _logger = logger;
        }


        public override Task<FindOverlapPointsReply> FindOverlapPoints(
            FindOverlapPointsRequest request, ServerCallContext context) 
        {

            

            return Task.FromResult(new FindOverlapPointsReply { OverlapPoints = { new Vector2D {X=1, Y=3 } } });
        }

        //public override async Task FindOverlapPoints(
        //    IAsyncStreamReader<FindOverlapPointsRequest> requestStream,
        //    IServerStreamWriter<FindOverlapPointsReply> responseStream,
        //    ServerCallContext context)
        //{
        //    await foreach (var request in requestStream.ReadAllAsync()) 
        //    {
        //        await responseStream.WriteAsync(
        //            new FindOverlapPointsReply { OverlapPoints = { request.Circle1.X, request.Circle2} });
        //    }

        //}
    }
}