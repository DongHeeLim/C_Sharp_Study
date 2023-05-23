using MQTTnet.Server;
using MQTTnet;
using System.Text;  // Encoding

// Broker

var options = new MqttServerOptionsBuilder()
    .WithDefaultEndpoint()
    .Build();

var server = new MqttFactory().CreateMqttServer(options);

server.InterceptingPublishAsync += Server_InterceptingPublishAsync;

Console.WriteLine("Start MQTT Server");
await server.StartAsync();
Console.WriteLine("Press any key to stop");
Console.ReadKey();

Task Server_InterceptingPublishAsync(InterceptingPublishEventArgs arg)
{
    var payload = arg.ApplicationMessage?.Payload == null ? null : Encoding.UTF8.GetString(arg.ApplicationMessage?.Payload);

    Console.WriteLine(
        "TimeStamp : {0} -- Message: ClientId = {1}, Topic = {2}, Payload = {3}, Qos = {4}, Retain-Flag = {5}",
        DateTime.Now,
        arg.ClientId,
        arg.ApplicationMessage?.Topic,
        payload,
        arg.ApplicationMessage?.QualityOfServiceLevel,
        arg.ApplicationMessage?.Retain);

    return Task.CompletedTask;
}