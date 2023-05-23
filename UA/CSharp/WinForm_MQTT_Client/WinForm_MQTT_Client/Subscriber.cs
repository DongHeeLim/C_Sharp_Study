using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinForm_MQTT_Client.Helpers;  // DumpToConsole()
using MQTTnet.Packets;


namespace WinForm_MQTT_Client
{
    internal class Subscriber
    {
        private string mqttTCPServer = "broker.hivemq.com";
        StringHandler stringObject = StringHandler.Instance();

        public async Task Handle_Received_Applicaiton_Message(string _topic) 
        {
            var mqttFactory = new MqttFactory();
            //var objectextension = new ObjectExtension();

            

            using (var mqttClient = mqttFactory.CreateMqttClient()) 
            {
                var mqttClientOptions = new MqttClientOptionsBuilder()
                    .WithTcpServer(mqttTCPServer)
                    .Build();

                mqttClient.ApplicationMessageReceivedAsync += e =>
                {
                    e.DumpToConsole();

                    stringObject.AddText("Received application message.");


                    return Task.CompletedTask;
                };

                await mqttClient.ConnectAsync(mqttClientOptions, CancellationToken.None);

                var mqttSubscribeOptions = mqttFactory.CreateSubscribeOptionsBuilder()
                    .WithTopicFilter(
                        f =>
                        {
                            f.WithTopic(_topic);
                            f.WithQualityOfServiceLevel(MQTTnet.Protocol.MqttQualityOfServiceLevel.ExactlyOnce);
                        })
                    .Build();
                

                var subscribeResult = await mqttClient.SubscribeAsync(mqttSubscribeOptions, CancellationToken.None);


              

                var subscribeResult2 = subscribeResult.Items;

                var target = subscribeResult2;


                stringObject.AddText("");
                

                 

                //var targetPayload = Encoding.UTF8.GetString();
                //mqttClient.UseApplicationMessageReceivedHandler(e =>
                //{
                //    Console.WriteLine("### RECEIVED APPLICATION MESSAGE ###");
                //    Console.WriteLine($"+ Topic = {e.ApplicationMessage.Topic}");
                //    Console.WriteLine($"+ Payload = {Encoding.UTF8.GetString(e.ApplicationMessage.Payload)}");
                //    Console.WriteLine($"+ QoS = {e.ApplicationMessage.QualityOfServiceLevel}");
                //    Console.WriteLine($"+ Retain = {e.ApplicationMessage.Retain}");
                //    Console.WriteLine();

                //    Task.Run(() => mqttClient.PublishAsync("hello/world"));
                //});


                stringObject.AddText(_topic);

                stringObject.AddText("MQTT client subscribed to topic.");



            }
        }




        public async Task Send_Response(string _topic) 
        {
            var mqttFactory = new MqttFactory();

            using (var mqttClient = mqttFactory.CreateMqttClient())
            {
                mqttClient.ApplicationMessageReceivedAsync += delegate (MqttApplicationMessageReceivedEventArgs args)
                {
                    args.ReasonCode = MqttApplicationMessageReceivedReasonCode.ImplementationSpecificError;
                    args.ResponseReasonString = "That did not work!";

                    args.ResponseUserProperties.Add(new MqttUserProperty("My", "Data"));

                    return Task.CompletedTask;
                };

                var mqttClientOptions = new MqttClientOptionsBuilder().WithTcpServer(mqttTCPServer).Build();

                await mqttClient.ConnectAsync(mqttClientOptions, CancellationToken.None);

                var mqttSubscribeOptions = mqttFactory.CreateSubscribeOptionsBuilder()
                    .WithTopicFilter(
                        f =>
                        {
                            f.WithTopic(_topic);
                        })
                    .Build();

                var response = await mqttClient.SubscribeAsync(mqttSubscribeOptions, CancellationToken.None);
                stringObject.AddText("MQTT client subsribed to topic.");
                response.DumpToConsole();

            }
        }


        public async Task Subsribe_Multiple_Topics(List<string> _topics)
        {
            var mqttFactory = new MqttFactory();

            using (var mqttClient = mqttFactory.CreateMqttClient())
            {

                var mqttClientOptions = new MqttClientOptionsBuilder().WithTcpServer(mqttTCPServer).Build();

                await mqttClient.ConnectAsync(mqttClientOptions, CancellationToken.None);




                var mqttSubscribeOptions = mqttFactory.CreateSubscribeOptionsBuilder()
                    .WithTopicFilter(
                        f =>
                        {
                            f.WithTopic(_topics[0]);
                        })
                    .Build();

                if (_topics[1] != null)
                {
                    for (int i = 1; i < _topics.Count; i++)
                    {
                        mqttSubscribeOptions = mqttFactory.CreateSubscribeOptionsBuilder()
                       .WithTopicFilter(
                           f =>
                           {
                               f.WithTopic(_topics[i]);
                           })
                       .Build();

                    }
                }



                var response = await mqttClient.SubscribeAsync(mqttSubscribeOptions, CancellationToken.None);
                stringObject.AddText("MQTT client subsribed to topic.");
                response.DumpToConsole();
            }
        }


        public async Task Subscribe_Topic(string _topic) 
        {
            var mqttFactory = new MqttFactory();

            using (var mqttClient = mqttFactory.CreateMqttClient())
            {
                var mqttClientOptions = new MqttClientOptionsBuilder().WithTcpServer(mqttTCPServer).Build();

                await mqttClient.ConnectAsync(mqttClientOptions, CancellationToken.None);

                var mqttSubscribeOptions = mqttFactory.CreateSubscribeOptionsBuilder()
                    .WithTopicFilter(
                        f =>
                        {
                            f.WithTopic(_topic);
                        })
                    .Build();

                var response = await mqttClient.SubscribeAsync(mqttSubscribeOptions, CancellationToken.None);

                Console.WriteLine("MQTT client subscribed to topic.");

                // The response contains additional data sent by the server after subscribing.
                response.DumpToConsole();
            }
        }


    }
}
