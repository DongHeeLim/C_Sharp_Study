// See https://aka.ms/new-console-template for more information
using System.Threading.Tasks;
using Grpc.Net.Client;
using GrpcService_Hello;
using Grpc.Core;    // ReadAllAsync
using System.Data;
using System.Threading.Channels;

class Program 
{
    static async Task Main(string[] args)
    {
        // The port number must match the port of the gRPC server.
        //using var channel = GrpcChannel.ForAddress("https://localhost:7134");
        //using var channel = GrpcChannel.ForAddress("http://localhost:5043");
        //using var channel = GrpcChannel.ForAddress("http://192.168.1.177:50051");   // virtualbox - ubuntu server address
        //using var channel = GrpcChannel.ForAddress("http://192.168.1.176:50051");  //  this project server
        using var channel = GrpcChannel.ForAddress("http://localhost:50051");  //  this project server


       
        var client = new Greeter.GreeterClient(channel);

        Console.WriteLine(channel + " : " + client);

        //var reply = client.SayHello(new HelloRequest { Name = "Csharp Client" });

        var reply = await client.SayHelloAsync(
                          new HelloRequest { Name = "Csharp Client" });

        Console.WriteLine("Greeting: " + reply.Message);

        var replyAgain = await client.SayHelloAgainAsync(
                          new HelloRequest { Name = "Csharp Again" });

        Console.WriteLine("Greeting: " + replyAgain.Message);




        var counter_reply = await client.CountAsync(new CountRequest { Num = 3 });

        Console.WriteLine(counter_reply.Message);

        var cts = new CancellationTokenSource(TimeSpan.FromSeconds(60)); // TimeOut : 이 시간 만큼 후에 Cancel, 
        using var minute_count = client.CountServer(new CountRequest { Num = 5 }, cancellationToken: cts.Token);

        await foreach (var streamData in minute_count.ResponseStream.ReadAllAsync(cancellationToken: cts.Token))
        {
            Console.WriteLine($"Streaming : {streamData.Message}");
        }


    }
}


