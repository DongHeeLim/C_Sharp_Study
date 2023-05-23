using System;
using System.Threading;
using System.Net.Sockets;
using System.Timers;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Winform_TCP_Socket
{
    public partial class Form1 : Form
    {
        TcpClient client;
        NetworkStream stream;
        bool isTcpRun = false;
        //String server_ip = "192.168.1.201";
        String default_ip = "192.168.1.238";
        //String server_ip = "192.168.43.127";
        //Int32 port = 5341;
        Int32 port = 60000;
        CancellationTokenSource cts = new CancellationTokenSource();
        //static AutoResetEvent _restart = new AutoResetEvent(false);
        static Int32 count = 0;
        List<System.Windows.Forms.TextBox> textBoxes = new List<System.Windows.Forms.TextBox>();
        
        public Form1()
        {
            InitializeComponent();
            button1.BackColor = Color.GreenYellow;
            textBoxes.Add(textBox1);
            textBoxes.Add(textBox2);
            textBoxes.Add(textBox3);
            textBoxes.Add(textBox4);

            string[] ips = default_ip.Split('.');

            for (int i = 0; i < 4; i++)
            {
                textBoxes[i].Text = ips[i];
            }
        }

        // ���� �޼���
        private int TcpConnection(String server, Int32 _port) 
        {
            

            try
            {
                
                //richTextBox1.Text += "TCP ���� �õ�\n";
                //client = new TcpClient(server, _port);
                //stream = client.GetStream();             

                richTextBox1.Text += "���� �� :" + isTcpRun + "\n";
                while (isTcpRun)
                {
                    client = new TcpClient(server, _port);
                    stream = client.GetStream();
                    //TcpClient client = new TcpClient(server, _port);
                    //NetworkStream stream = client.GetStream();

                    //// ������ Binding �� �غ�
                    //if (client.Connected)
                    //{

                    //    richTextBox1.Text += "Alread connected\n";
                    //}
                    //else 
                    //{
                    //    richTextBox1.Text += "Ready to make socket\n";
                    //    client = new TcpClient(server, _port);
                    //    stream = client.GetStream();
                    //}



                    richTextBox1.Text += "Client connect to [ " + server + ":" + _port + " ]\n";


                    // string -> Byte array
                    String sendData = "����?\n";  // "\n" ���
                    Byte[] sendBuffer = System.Text.Encoding.UTF8.GetBytes(sendData);    // ������ ������ ������
                    Byte[] recvBuffer = new byte[256];
                    String responseData = String.Empty;
                    DateTime lastTime = DateTime.Now;
                    DateTime timeOut = DateTime.Now;

                    // ������ �߻�, �����ϱ�
                    
                    richTextBox1.Text += "TCP ���� ����\n";
              
                    // ��� Cancellation ���� while�� Ż���ϱ� ������ isTcpRun �� �ʿ������
                    while (isTcpRun && client.Connected)
                    {
                        try 
                        {
                            if ((DateTime.Now - timeOut).TotalMilliseconds > 10000)
                            {
                                richTextBox1.Text += "------Lost Server Connection------\n";                               
                                break;
                            }


                            if (stream.DataAvailable)
                            {

                                Int32 bytes = stream.Read(recvBuffer, 0, recvBuffer.Length);
                                responseData = System.Text.Encoding.UTF8.GetString(recvBuffer, 0, bytes);

                                // ����("����!") 
                                if (responseData.IndexOf("����!") != -1)
                                {
                                    timeOut = DateTime.Now; // ������ Ȯ�εǾ����ϱ� Ÿ�Ӿƿ� ����
                                }

                                richTextBox1.Text += count++ + " : " + responseData + "\n";
                            }


                            DateTime currentTime = DateTime.Now;
                            if ((currentTime - lastTime).TotalMilliseconds > 1000)
                            {
                                lastTime = currentTime;
                                // Ŭ���̾�Ʈ -> ���� : ������ ����
                                stream.Write(sendBuffer, 0, sendBuffer.Length); // byte array, start, end
                                richTextBox1.Text += "[Client -> Server] : " + sendData;
                            }


                            //if (_token.IsCancellationRequested == true)
                            //{
                            //    richTextBox1.Text += "Cancel Requested";
                            //    break;
                            //}
                        }
                        catch(Exception e) 
                        {
                            // thread �����, client.Connected ������
                            richTextBox1.Text += "Board Reset Exception:" + e + "\n";   // ���� ���� ��ư ������ ��
                            break;
                        }                    
                       
                    }

                    stream.Close();
                    client.Close();                   

                    return 1;
                }

            }
            catch (ArgumentNullException e)
            {
                richTextBox1.Text += "ArgumentNullException:" + e + "\n";
                return -1;
            }
            catch (SocketException e)
            {
                richTextBox1.Text += "SocketException: " + e + "\n";
                richTextBox1.Text += "--------Reset ��ư�� �����ּ���----------\n";     // USB �翬�� -> ���ذ�
                //Dispose();
                return -1;
            }

            return 0;
        }
        
        // ���� �޼���
        private async Task TcpConnectionAsync(String server, Int32 _port) 
        {
            richTextBox1.Text += "������ ����\n";

            var task = await Task.Run<int>( () => TcpConnection(server, _port));     // ���� �۾�                                                                                        

            //if (!_token.IsCancellationRequested)         // ��� �۾� ���� ��
            //{
            //    richTextBox1.Text += "������ �۾� �Ϸ�\n";
            //}
            

            richTextBox1.Text += "������ ����\n";
            isTcpRun = false;
            var button_task = Task.Run(() => change_button1_color());
            //stream.Close();
            //client.Close();
            count = 0;


        }


        // ����
        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // toggle 
                if (isTcpRun)
                {
                    isTcpRun = false;
                    button1.Text = "TCP ����";
                    button1.ForeColor = Color.Black;
                    button1.BackColor = Color.GreenYellow;
                    richTextBox1.Text += "TCP ���� ����\n";
                }
                else 
                {
                    isTcpRun = true;
                    button1.Text = "TCP ����";
                    button1.BackColor = Color.IndianRed;
                    button1.ForeColor = Color.White;

                    string server_ip = setIp(default_ip);   // ip �ʱ�ȭ
                    await TcpConnectionAsync(server_ip, port);



                }               
                
            }
            catch (Exception)
            {

            }
            
        }


        private async Task change_button1_color()
        {
            button1.Text = "TCP �����";
            button1.ForeColor = Color.Black;
            button1.BackColor = Color.Yellow;
            await Task.Delay(1000);
            button1.Text = "TCP ����";
            button1.BackColor = Color.GreenYellow;
        }

        private string setIp(String ip) 
        {
            ip = "";

            for (int i = 0; i < 4; i++)
            {

                if (i < 3)
                {
                    ip += textBoxes[i].Text + ".";                    
                }
                else 
                {
                    ip += textBoxes[i].Text;
                }
                //richTextBox1.Text += i + " : " + ip + "\n";
            }
            //richTextBox1.Text += "IP address :" + ip + "\n";

            return ip;
        }



    }
}