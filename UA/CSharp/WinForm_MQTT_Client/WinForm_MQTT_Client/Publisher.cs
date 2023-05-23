using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using MQTTnet;
using MQTTnet.Client;
using WinForm_MQTT_Client.Helpers;

namespace WinForm_MQTT_Client
{
   
    public class Publisher
    {
 
       
        private string mqttTCPServer = "broker.hivemq.com";

        public async Task Publish_Application_Message(string _topic, string _payload)
        {
            var mqttFactory = new MqttFactory();
            var stringObject = StringHandler.Instance();

            using (var mqttClient = mqttFactory.CreateMqttClient()) 
            {
                var mqttClientOptions = new MqttClientOptionsBuilder()
                    .WithTcpServer(mqttTCPServer)
                    .Build();

                await mqttClient.ConnectAsync(mqttClientOptions, CancellationToken.None);

                var applicationMessage = new MqttApplicationMessageBuilder()
                    .WithTopic(_topic)
                    .WithPayload(_payload)
                    .Build();

                var publishResult = await mqttClient.PublishAsync(applicationMessage, CancellationToken.None);

                if (publishResult.IsSuccess)
                {
                    stringObject.AddText(publishResult.ReasonCode.ToString());
                }
                else 
                {
                    stringObject.AddText("Fail to publish payload");
                }

                await mqttClient.DisconnectAsync();

                stringObject.AddText(_payload);
            }

        }

        public async Task Publish_Multiple_Application_Messages(List<string> _topic, List<string> _payload) 
        {
            var mqttFactory = new MqttFactory();
            var stringObject = StringHandler.Instance();

            using (var mqttClient = mqttFactory.CreateMqttClient()) 
            {
                var mqttClientOptions = new MqttClientOptionsBuilder()
                    .WithTcpServer(mqttTCPServer)
                    .Build();

                await mqttClient.ConnectAsync(mqttClientOptions, CancellationToken.None);

                var applicationMessage = new MqttApplicationMessageBuilder()
                    .WithTopic(_topic[0])
                    .WithPayload(_payload[0])
                    .Build();
                stringObject.AddText(_payload[0]);

                for (int i = 1; i < _payload.Count; i++)
                {
                    applicationMessage = new MqttApplicationMessageBuilder()
                    .WithTopic(_topic[i])
                    .WithPayload(_payload[i])
                    .Build();

                    await mqttClient.PublishAsync(applicationMessage, CancellationToken.None);
                    stringObject.AddText(_payload[i]);
                }              
                await mqttClient.DisconnectAsync();

            }
        }


        public void Send_Request(string str) 
        {
            //stringObject.AddText(str);
        }


    }
}
