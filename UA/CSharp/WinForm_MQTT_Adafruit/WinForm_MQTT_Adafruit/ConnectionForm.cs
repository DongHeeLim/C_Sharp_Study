using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Connecting;
using MQTTnet.Client.Options;
using MQTTnet.Formatter;
using System.Text;

namespace WinForm_MQTT_Adafruit
{
    public partial class ConnectionForm : Form
    {
        string defaultHost = "io.adafruit.com";
        int defaultPort = 1883;
        string defaultUsername = "CoolDong";
        string aioKey = "aio_aqVn48IT8Jw4ojr7RP6X9ulGtAVb";

        public ConnectionForm()
        {
            InitializeComponent();

            txtHost.Text = defaultHost;
            txtPort.Text = defaultPort.ToString();
            txtUsername.Text = defaultUsername;
            txtPassword.Text = aioKey;


            // 이벤트 추가
            btnConnect.Click += async (o, e) =>
            {
                await BtnConnect_ClickAsync(o, e);
            };
        }

        // 이벤트 핸들러
        private async Task BtnConnect_ClickAsync(object? sender, EventArgs e)
        {
            try
            {
                btnConnect.Enabled = false;

                var factory = new MqttFactory();
                var client = factory.CreateMqttClient();
                

                var options = new MqttClientOptionsBuilder()
                    .WithTcpServer(txtHost.Text, int.Parse(txtPort.Text))
                    .WithCredentials(txtUsername.Text, txtPassword.Text)
                    .WithProtocolVersion(MqttProtocolVersion.V311)
                    .Build();

                var auth = await client.ConnectAsync(options);
                

                if (auth.ResultCode != MqttClientConnectResultCode.Success)
                {
                    throw new Exception(auth.ResultCode.ToString());
                }
                else 
                {
                    using (var feedFrm = new FeedForm(client))
                    {
                        try
                        {
                            Hide();
                            feedFrm.ShowDialog(this);
                        }
                        catch (Exception ex) 
                        {
                            this.Error(ex);
                        }

                        Close();
                    }
                }

            }
            catch (Exception ex)
            {
                this.Error(ex);
                btnConnect.Enabled = true;
                
            }
        }
    }
}