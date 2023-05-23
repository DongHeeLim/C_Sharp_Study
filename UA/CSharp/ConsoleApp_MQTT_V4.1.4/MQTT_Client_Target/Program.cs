using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Extensions.ManagedClient;
using System.Text;
using System.Text.Json;

var client = new MqttFactory().CreateManagedMqttClient();

var clientId = "light1";
var server = "localhost";
var builder = new MqttClientOptionsBuilder()
    .WithClientId(clientId)
    .WithTcpServer(server)
    .Build();

var options = new ManagedMqttClientOptionsBuilder()
    .WithAutoReconnectDelay(TimeSpan.FromSeconds(10))
    .WithClientOptions(builder)
    .Build();

client.ConnectedAsync += Client_ConnectedAsync;
client.DisconnectedAsync += Client_DisconnectedAsync;
client.ConnectingFailedAsync += Client_ConnectingFailedAsync;
client.ApplicationMessageReceivedAsync += Client_ApplicationMessageReceivedAsync;


Console.WriteLine($"{clientId} - MQTT Broker {server}");
await client.StartAsync(options);


while (true)
{

    //Console.WriteLine("Topic example : home/led/light1");

    
    var topic = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(topic)) topic = $"home/led/{clientId}";
    
    Console.WriteLine("Message : ");
    var message = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(message))
    {
        var json = JsonSerializer.Serialize(new { message, sent = DateTime.UtcNow });
        await client.EnqueueAsync(topic, json);
        SpinWait.SpinUntil(() => client.PendingApplicationMessagesCount == 0, 10);  // 연결이 끊겨서 보류 개수에 따라 멈춤
        Console.WriteLine($"Pending Message = {client.PendingApplicationMessagesCount}");   // 보류 중
        // 브로커와 재연결이 되면 브로커 쪽으로 보류중인 데이터 전부 전송, 그 이후로는 연결 X
    }
    else 
    {
        Console.WriteLine("Message cannot be empty. Please re-enter");
    }

}



Task Client_ConnectedAsync(MqttClientConnectedEventArgs arg)
{
    Console.WriteLine("Connected");

    return Task.CompletedTask;
}

Task Client_DisconnectedAsync(MqttClientDisconnectedEventArgs arg)
{
    Console.WriteLine("Disconnected");

    return Task.CompletedTask;
}


Task Client_ConnectingFailedAsync(ConnectingFailedEventArgs arg)
{
    Console.WriteLine("Connection failed check network or broker!");

    return Task.CompletedTask;
}

Task Client_ApplicationMessageReceivedAsync(MqttApplicationMessageReceivedEventArgs arg)
{
    var topic = arg?.ApplicationMessage?.Topic;
    var payloadText = Encoding.UTF8.GetString(arg?.ApplicationMessage?.Payload ?? Array.Empty<byte>());

    Console.WriteLine($"Received => Topic : {topic}, Payload : {payloadText}");

    return Task.CompletedTask;
}