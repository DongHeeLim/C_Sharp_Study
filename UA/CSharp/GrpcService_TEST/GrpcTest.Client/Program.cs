using Grpc.Core;
using Grpc.Net.Client;
using GrpcService_TEST;


class Program
{
    static async Task Main(string[] args)
    {
        // 채널 생성 (연결)
        using var channel = GrpcChannel.ForAddress("https://localhost:7037");
        Console.WriteLine("Channel : " + channel);

        // 서비스와 연결할 client 객체 생성
        var client = new Tester.TesterClient(channel);
        Console.WriteLine("client : : " + client);

        
        //단항 호출 Unary Call
        var reply = await client.SayHelloUnaryAsync(new HelloRequest { Name = "UnaryClient" });
        Console.WriteLine("UnaryClient : " + reply.Message);

        var cts = new CancellationTokenSource(TimeSpan.FromSeconds(5)); // TimeOut : 이 시간 만큼 후에 Cancel, 
        
        // 서버 -> 클라이언트
        using var streamingCallFromServer = client.SayHelloServerStreaming(new HelloRequest { Name = "ServerStreaming" }, cancellationToken: cts.Token);

        // 클라이언트 -> 서버
        using var streamingCallToServer = client.SayHelloClientStreaming();

        // 양방향
        using var bidirectionalCall = client.SayHelloBidirectionalStreaming();

        
        try 
        {
            await foreach (var streamData in streamingCallFromServer.ResponseStream.ReadAllAsync(cancellationToken : cts.Token))
            { 
                Console.WriteLine($"Streaming : {streamData.Message}");
            }

            
            Console.WriteLine("====================================================");
            await Task.Delay(1000);

            

            for (int i = 0; i < 10; i++)
            {
                //await streamingCallToServer.RequestStream.WriteAsync(new HelloRequest { Name = "ClientStreaming" });
                await streamingCallToServer.RequestStream.WriteAsync(new HelloRequest { Name = "ClientStreaming" }); // 시간 의미가 없음, 연산 시간은 가능

            }
            await streamingCallToServer.RequestStream.CompleteAsync();

            var response = await streamingCallToServer;
            Console.WriteLine($"{response.Message}");

            Console.WriteLine("====================================================");
            await Task.Delay(1000);



            var bidirectionalEndFlag = false;
            var readTask = Task.Run(async () =>
            {
                await foreach (var responseFromServer in bidirectionalCall.ResponseStream.ReadAllAsync()) // 서버에서 온 것 읽기
                {
                    Console.WriteLine($"{responseFromServer.Message}");
                    //string str = "Hello bidirection";
                    //Int16 num = Convert.ToInt16(responseFromServer.Message.Substring(responseFromServer.Message.IndexOf(':'), 4));
                    //Console.WriteLine(num);
                    //if (num > 10) bidirectionalEndFlag = true;
                }
            });


            while (true)
            { 
                //var result = Console.ReadLine();
                //if (string.IsNullOrEmpty(result)) 
                //{
                //    break;
                //}

                await bidirectionalCall.RequestStream.WriteAsync(new HelloRequest { Name = "bidirection" });
                await Task.Delay(1000);

                if (bidirectionalEndFlag) break;
            }

            Console.WriteLine("Disconnecting");

            await bidirectionalCall.RequestStream.CompleteAsync();
            //await readTask;

        }
        catch (Exception ex) 
        {
        }

    }
}


