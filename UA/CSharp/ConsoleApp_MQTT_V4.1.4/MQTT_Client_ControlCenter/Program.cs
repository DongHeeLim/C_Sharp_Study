using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Extensions.ManagedClient;
using MQTTnet.Packets;
using System.Text;

var client = new MqttFactory().CreateManagedMqttClient();

var clientId = "ControlCenter";
var server = "localhost";
var builder = new MqttClientOptionsBuilder()
    .WithClientId(clientId)
    .WithTcpServer(server)
    .Build();

var options = new ManagedMqttClientOptionsBuilder()
    .WithAutoReconnectDelay(TimeSpan.FromSeconds(10))    // Reconnect
    .WithClientOptions(builder)
    .Build();

var sample_topic = new MqttTopicFilterBuilder()
    .WithTopic("home/led/light1")
    .Build();

var sample_topic2 = new MqttTopicFilterBuilder()
    .WithTopic("home/led/light2")
    .Build();

client.ConnectedAsync += Client_ConnectedAsync;
client.DisconnectedAsync += Client_DisconnectedAsync;
client.ConnectingFailedAsync+= Client_ConnectingFailedAsync;
client.ApplicationMessageReceivedAsync += Client_ApplicationMessageReceivedAsync;


var topicFilters = new List<MqttTopicFilter> { sample_topic, sample_topic2 };
await client.SubscribeAsync(topicFilters);

Console.WriteLine($"{clientId} - MQTT Broker {server}");
await client.StartAsync(options);
Console.WriteLine("Press any key to stop receive message");
Console.ReadKey();  // 이거 없으면 안돌아감, 다른 것들이 비동기라서

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

    Console.WriteLine( $"Received => Topic : {topic}, Payload : {payloadText}");

    return Task.CompletedTask;
}

