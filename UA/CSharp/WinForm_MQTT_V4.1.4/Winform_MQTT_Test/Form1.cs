//#define LOCAL

using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Extensions.ManagedClient;
using MQTTnet.Formatter;
using MQTTnet.Packets;
using MQTTnet.Protocol;
using MQTTnet.Server;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Winform_MQTT_Test
{
    public partial class Form1 : Form
    {
        private IManagedMqttClient? managedMqttClient;

        string defaultHost = "io.adafruit.com";
        int defaultPort = 1883; 
        string defaultUsername = "CoolDong";
        string aioKey = "aio_aqVn48IT8Jw4ojr7RP6X9ulGtAVb";
        int count = 0;


        public Form1()
        {
            InitializeComponent();

            ConnectServerAsync();

            // default
            textBox1.Text = "0";
            textBox2.Text = "0";
            textBox3.Text = "0";

        }


        private async void ConnectServerAsync()
        {
           
            var mqttClient = new MqttFactory().CreateMqttClient();

            // 연결 정보
            var builder = new MqttClientOptionsBuilder()
                .WithClientId("Controler")
                .WithProtocolVersion(MqttProtocolVersion.V311)
#if LOCAL
                .WithTcpServer("localhost", defaultPort)
#else
                .WithTcpServer(defaultHost, defaultPort)
                .WithCredentials(defaultUsername , aioKey)
#endif
                .Build();

            var managedOptions = new ManagedMqttClientOptionsBuilder()
                .WithAutoReconnectDelay(TimeSpan.FromSeconds(10))       // 재연결 설정 시간
                .WithClientOptions(builder)
                .Build();

            var led_topic = new MqttTopicFilterBuilder()
                .WithTopic("CoolDong/f/home.led")
                .Build();

            this.managedMqttClient = new MqttFactory().CreateManagedMqttClient();
            this.managedMqttClient.ConnectedAsync += ClientConnected;
            this.managedMqttClient.DisconnectedAsync += ClientDisconnected;
            this.managedMqttClient.ApplicationMessageReceivedAsync += OnSubscriberMessageReceived;

            var topicFilters = new List<MqttTopicFilter> { led_topic };
            await this.managedMqttClient.SubscribeAsync(topicFilters);
            await this.managedMqttClient.StartAsync(managedOptions);

        }



        private void button1_Click(object sender, EventArgs e)
        {

            Dictionary<string, double>? angle = new Dictionary<string, double>();
            SetAngleData(angle, Double.Parse(textBox1.Text), Double.Parse(textBox2.Text), Double.Parse(textBox3.Text));
            //send_data("CoolDong/f/home.led", count++.ToString());
            send_data("CoolDong/f/zig.vector", DictionaryToJSON(angle));
        }

        public async void send_data(string topic, string message) 
        {
            var payload = Encoding.UTF8.GetBytes(message);
            var send = new MqttApplicationMessageBuilder()
                .WithTopic(topic)
                .WithPayload(payload)
                .WithQualityOfServiceLevel(MqttQualityOfServiceLevel.AtLeastOnce)
                .WithRetainFlag()
                .Build();
           

            if (this.managedMqttClient != null)
            {
                richTextBox1.Text += "time to send\n";
                await this.managedMqttClient.EnqueueAsync(send);
                SpinWait.SpinUntil(() => managedMqttClient.PendingApplicationMessagesCount == 0, 100);
                richTextBox1.Text += $"Pending Message Count = {managedMqttClient.PendingApplicationMessagesCount}\n";
            }
        }


        // For Server
        private Task ValidateConnectionAsync(ValidatingConnectionEventArgs args)
        {
            throw new NotImplementedException();
        }

        private Task ClientConnected(MqttClientConnectedEventArgs _)
        {
            //richTextBox1.Text += "Connected\n";
            lblStatus.Text = "Connected\n";
            return Task.CompletedTask;
        }

        private Task ClientDisconnected(MqttClientDisconnectedEventArgs _)
        {
            //richTextBox1.Text += "Disconnected\n";
            lblStatus.Text = "Disconnected\n";
            return Task.CompletedTask;
        }


        private Task OnSubscriberMessageReceived(MqttApplicationMessageReceivedEventArgs arg)
        {
            var topic = arg?.ApplicationMessage?.Topic;
            var payloadText = Encoding.UTF8.GetString(arg?.ApplicationMessage?.Payload ?? Array.Empty<byte>());

            richTextBox1.Text += $"Received => Topic : {topic}, Payload : {payloadText}\n";

            return Task.CompletedTask;
        }

        private string DictionaryToJSON(IDictionary<string, double> dict)
        {
            //var x = dict.Select(d => string.Format("\" ) )
            string? str = JsonSerializer.Serialize(dict);
            if (str != null)
            {
                richTextBox1.Text += str + "\n";
            }
            else 
            {
                str = "Not Serialized";
            }

            return str;
        }

        private bool DictionaryKeyTest(IDictionary<string, double> dict, List<string> keys)
        {
            double defaultValue = 0.0;

            // 해당 Key 가 있을 경우 
            for (int i = 0; i < keys.Count; i++)
            {
                if (dict.ContainsKey(keys[i]))
                {
                    // 혹시 모를  Error 방지용
                    dict[keys[i]] = dict[keys[i]].ToString() == null ? defaultValue : Double.Parse(dict[keys[i]].ToString());
                    //richTextBox1.Text += dict[keys[i]] + "<- \n";
                }
                else
                {
                    // 해당 키가 없을 경우
                    return false;
                }
            }
           
            return true;
        }

        private List<double> SetAngleData(IDictionary<string, double> dict, double x, double y, double z)
        {
            List<string> angleKeys = new List<string>() { "X", "Y", "Z" };
            List<double> result = new List<double>();

            dict[angleKeys[0]] = x;
            dict[angleKeys[1]] = y;
            dict[angleKeys[2]] = z;
            result.Add(x);
            result.Add(y);
            result.Add(z);

            if (DictionaryKeyTest(dict, angleKeys) && dict.Count == 3)
            {
                richTextBox1.Text += "Complete to set angle\n";
            }
            else 
            {
                richTextBox1.Text += "Failed to set angle\n";
            }

            return result;
        }
    }
}