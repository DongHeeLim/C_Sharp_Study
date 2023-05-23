using Google.Protobuf.WellKnownTypes;
using GrpcClient;
using GrpcProtos_Standard20;
using System;
using System.Linq;

// 16년도 글이라서 살짝 신뢰가 안감
namespace Console_Grpc_Net7
{
    class Program
    {
        static void Main(string[] args) 
        {
            Console.Write("Enter your name> ");
            var name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                name = "anonymous";
            }

            Console.WriteLine($"Joined as {name}");
            Console.WriteLine("Press 'Esc' to exit.");

            using var chatServiceClient = new ChatServiceClient();
            var consoleLock = new object();

            // subscribe (asynchronous)
            Task _ = chatServiceClient.ChatLogs()
                .ForEachAsync((x) =>    // System.Linq.Async
                {
                    // if the user is writing something, wait until it finishes.
                    lock (consoleLock)
                    {
                        Console.WriteLine($"{x.At.ToDateTime().ToString("HH:mm:ss")} {x.Name}: {x.Content}");
                    }
                });

            while (true)
            {
                var key = Console.ReadKey();

                if (key.Key == ConsoleKey.Escape) { break; } // exit

                // A key input starts writing mode
                lock (consoleLock)
                {
                    var content = key.KeyChar + Console.ReadLine();

                    chatServiceClient.Write(new ChatLog
                    {
                        Name = name,
                        Content = content,
                        At = Timestamp.FromDateTime(DateTime.Now.ToUniversalTime()),
                    }).Wait();
                }
            }
        }
    
    }

}
