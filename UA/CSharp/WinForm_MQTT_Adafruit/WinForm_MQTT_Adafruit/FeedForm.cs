﻿using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Subscribing;
using MQTTnet.Formatter;
using MQTTnet.Protocol;
using MQTTnet.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForm_MQTT_Adafruit
{
    public partial class FeedForm : Form
    {
        public IMqttClient Client { get; private set; }



        public FeedForm(IMqttClient client)
        {
            Client = client;
            InitializeComponent();

           

            //System.Func`2[MQTTnet.Client.MqttClientOptions,System.String]
            txtTopic.Text = $"{Client.Options.Credentials.Username}/f/";

            panelFeed.Hide();
            Height -= panelFeed.Height;

            btnSubscribe.Click += async (o, e) => await BtnSubscribe_Click(o, e);
            btnPublish.Click += async (o, e) => await BtnPublish_Click(o, e);
            btnToggle.Click += async(o, e) => await BtnToggle_Click(o, e);

        }


        private async Task BtnSubscribe_Click(object? sender, EventArgs e) 
        {
            try
            {
                btnSubscribe.Enabled = false;
                txtTopic.Enabled= false;

                var subscribeFilter = new MqttTopicFilterBuilder().WithTopic(txtTopic.Text).Build();

                var result = (await Client.SubscribeAsync(subscribeFilter)).Items[0];



                switch (result.ResultCode)
                {
                    case MqttClientSubscribeResultCode.GrantedQoS0:
                    case MqttClientSubscribeResultCode.GrantedQoS1:
                    case MqttClientSubscribeResultCode.GrantedQoS2:
                        panelFeed.Show();
                        Height += panelFeed.Height;

                

                        Client.UseApplicationMessageReceivedHandler(me =>
                        {
                            var msg = me.ApplicationMessage;
                            var data = Encoding.UTF8.GetString(msg.Payload);

                            Invoke((Action)(() =>
                            {
                                txtStream.AppendText($"{msg.Topic} : {data}\n");
                            }));
                        });

                        break;


                    default:
                        throw new Exception(result.ResultCode.ToString());
                }
            }
            catch (Exception ex)
            {
                txtTopic.Enabled= true;
                btnSubscribe.Enabled = true;
                this.Error(ex);
                
            }
        }


        private async Task BtnPublish_Click(object? sender, EventArgs e) 
        {
            try
            {
                btnPublish.Enabled = false;

                var data = txtData.Text.Trim();

                if (string.IsNullOrEmpty(data))
                {
                    throw new Exception("Data cannot be empty.");
                }
                else
                { 
                    await Client.PublishAsync(txtTopic.Text, data);
                }
            }
            catch (Exception ex)
            {
                this.Error(ex);
            }

            btnPublish.Enabled = true;     
        }

        private bool ToggleStatus { get; set; }

        private async Task BtnToggle_Click(object? sender, EventArgs e)
        {
            try
            {
                btnToggle.Enabled = false;

                await Client.PublishAsync(
                        txtTopic.Text,
                        (ToggleStatus = !ToggleStatus) ? "On" : "Off"
                    );
            }
            catch (Exception ex)
            {
                this.Error(ex);
            }
            btnToggle.Enabled = true;
        }

    }
}
