using System.Threading.Tasks;
using Grpc.Net.Client;
using Grpc.Core;
using JSON_Client;
using Newtonsoft.Json;


public class Target
{
    //private string id;
    //private int count;

    public string Id { get; set; } = "Not Selected";
    public int Count { get; set; } = 0;

    public Target(string id, int count) 
    {
        Id = id;
        Count = count;
    }

    ~Target() { }
}

class Program {

    static async Task Main(string[] arge) {
        using var channel = GrpcChannel.ForAddress("https://localhost:7214"); // 포트 변경 필수

        var client = new Greeter.GreeterClient(channel);   // Client 용
        var reply = await client.SayHelloAsync(
                          new HelloRequest { Name = "123" });
        Console.WriteLine("Greeting: " + reply.Message);

        // streaming JSon
        using var sendJson = client.StreamingJson();


        var i = 0;

        Target target = new Target("UAR", i);
        Console.WriteLine($"{target.Id} {target.Count}");


        string serialize_target = "Not Serialized";




        try {

            var readTask = Task.Run(async () =>
            {
                await foreach (var responseFromServer in sendJson.ResponseStream.ReadAllAsync()) // 서버에서 온 것 읽기
                {
                    Console.WriteLine($"{responseFromServer.Msg}");
                    //string str = "Hello bidirection";
                    //Int16 num = Convert.ToInt16(responseFromServer.Message.Substring(responseFromServer.Message.IndexOf(':'), 4));
                    //Console.WriteLine(num);
                    //if (num > 10) bidirectionalEndFlag = true;
                }
            });


            while (true)
            {

                target.Count = i++;
                serialize_target = JsonConvert.SerializeObject(target);
                Console.WriteLine(serialize_target);
                await sendJson.RequestStream.WriteAsync(new JsonDataRequest { Msg = serialize_target });
                await Task.Delay(1000);

                if (i > 20) break;

            }

            Console.WriteLine("Disconnected");
            await sendJson.RequestStream.CompleteAsync();

        }
        catch (Exception ex)
        {
        }

    }
}



