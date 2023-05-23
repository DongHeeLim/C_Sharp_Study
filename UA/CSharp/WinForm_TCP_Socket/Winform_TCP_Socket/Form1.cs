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

        // 구현 메서드
        private int TcpConnection(String server, Int32 _port) 
        {
            

            try
            {
                
                //richTextBox1.Text += "TCP 연결 시도\n";
                //client = new TcpClient(server, _port);
                //stream = client.GetStream();             

                richTextBox1.Text += "시작 전 :" + isTcpRun + "\n";
                while (isTcpRun)
                {
                    client = new TcpClient(server, _port);
                    stream = client.GetStream();
                    //TcpClient client = new TcpClient(server, _port);
                    //NetworkStream stream = client.GetStream();

                    //// 서버에 Binding 할 준비
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
                    String sendData = "연결?\n";  // "\n" 약속
                    Byte[] sendBuffer = System.Text.Encoding.UTF8.GetBytes(sendData);    // 서버로 보내는 데이터
                    Byte[] recvBuffer = new byte[256];
                    String responseData = String.Empty;
                    DateTime lastTime = DateTime.Now;
                    DateTime timeOut = DateTime.Now;

                    // 딜레이 발생, 연결하기
                    
                    richTextBox1.Text += "TCP 연결 시작\n";
              
                    // 사실 Cancellation 으로 while을 탈출하기 때문에 isTcpRun 은 필요없을듯
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

                                // 서버("연결!") 
                                if (responseData.IndexOf("연결!") != -1)
                                {
                                    timeOut = DateTime.Now; // 연결이 확인되었으니까 타임아웃 갱신
                                }

                                richTextBox1.Text += count++ + " : " + responseData + "\n";
                            }


                            DateTime currentTime = DateTime.Now;
                            if ((currentTime - lastTime).TotalMilliseconds > 1000)
                            {
                                lastTime = currentTime;
                                // 클라이언트 -> 서버 : 데이터 전송
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
                            // thread 종료됨, client.Connected 해제됨
                            richTextBox1.Text += "Board Reset Exception:" + e + "\n";   // 보드 리셋 버튼 눌렀을 때
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
                richTextBox1.Text += "--------Reset 버튼을 눌러주세요----------\n";     // USB 재연결 -> 미해결
                //Dispose();
                return -1;
            }

            return 0;
        }
        
        // 실행 메서드
        private async Task TcpConnectionAsync(String server, Int32 _port) 
        {
            richTextBox1.Text += "스레드 시작\n";

            var task = await Task.Run<int>( () => TcpConnection(server, _port));     // 실제 작업                                                                                        

            //if (!_token.IsCancellationRequested)         // 취소 작업 없을 시
            //{
            //    richTextBox1.Text += "스레드 작업 완료\n";
            //}
            

            richTextBox1.Text += "스레드 종료\n";
            isTcpRun = false;
            var button_task = Task.Run(() => change_button1_color());
            //stream.Close();
            //client.Close();
            count = 0;


        }


        // 동작
        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // toggle 
                if (isTcpRun)
                {
                    isTcpRun = false;
                    button1.Text = "TCP 연결";
                    button1.ForeColor = Color.Black;
                    button1.BackColor = Color.GreenYellow;
                    richTextBox1.Text += "TCP 연결 종료\n";
                }
                else 
                {
                    isTcpRun = true;
                    button1.Text = "TCP 해제";
                    button1.BackColor = Color.IndianRed;
                    button1.ForeColor = Color.White;

                    string server_ip = setIp(default_ip);   // ip 초기화
                    await TcpConnectionAsync(server_ip, port);



                }               
                
            }
            catch (Exception)
            {

            }
            
        }


        private async Task change_button1_color()
        {
            button1.Text = "TCP 대기중";
            button1.ForeColor = Color.Black;
            button1.BackColor = Color.Yellow;
            await Task.Delay(1000);
            button1.Text = "TCP 연결";
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