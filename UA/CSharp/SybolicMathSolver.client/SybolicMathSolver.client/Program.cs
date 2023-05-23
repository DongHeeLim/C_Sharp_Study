using Grpc.Core;
using Grpc.Net.Client;
using SymbolicMathSolver.client;
// using System.Threading.Tasks;


class Program
{
    static async Task Main(string[] arge) 
    {
        using var channel = GrpcChannel.ForAddress("http://localhost:5000");

        var client = new Solver.SolverClient(channel);  // proto 파일 Service 이름

        Console.WriteLine("Channel : " + channel);
        Console.WriteLine("Client  : " + client);

        Circle circle1 = new Circle();
        Circle circle2 = new Circle();

        Dictionary<char, double> c1_point = new Dictionary<char, double>();
        Dictionary<char, double> c2_point = new Dictionary<char, double>();


        c1_point.Add('x', 0);
        c1_point.Add('y', 0);
        c1_point.Add('r', 2);

        c2_point.Add('x', 2);
        c2_point.Add('y', 2);
        c2_point.Add('r', 2);

        circle1.X = c1_point['x'];
        circle1.Y = c1_point['y'];
        circle1.R = c1_point['r'];

        circle2.X = c2_point['x'];
        circle2.Y = c2_point['y'];
        circle2.R = c2_point['r'];


        var reply = await client.FindOverlapPointsAsync(
            new FindOverlapPointsRequest { Circle1 = circle1, Circle2 =  circle2 });

        Console.WriteLine("X: " + reply.OverlapPoints);

    }

}
