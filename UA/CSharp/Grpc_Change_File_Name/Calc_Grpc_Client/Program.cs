// See https://aka.ms/new-console-template for more information

using Grpc.Net.Client;
using Grpc_File_Test;

class Calc_Grpc_Client  
{

    static async Task Main(string[] args) 
    {
        using var channel = GrpcChannel.ForAddress("http://localhost:5232");
        Console.WriteLine("Channel : " + channel);
        var client = new Calculator.CalculatorClient(channel);

        var reply = client.Get(new GetRequest { Id = "UA", Result = 3 });
        Console.WriteLine(reply.Message);

        try
        {
            Console.Write("Context : ");
            string context;
            while ((context = Console.ReadLine()) != null)
            {
                Console.Write("Context : ");
            }
        }
        catch (Exception ex)
        {

        }
    }
}


