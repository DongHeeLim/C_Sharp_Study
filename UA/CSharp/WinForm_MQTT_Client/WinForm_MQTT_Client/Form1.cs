using System.Reflection.Metadata;
using WinForm_MQTT_Client.Helpers;
using static WinForm_MQTT_Client.Publisher;

namespace WinForm_MQTT_Client
{
    public partial class Form1 : Form
    {
        private  Publisher publisher;
        private Subscriber subscriber;
        StringHandler stringObject = StringHandler.Instance();
        
        public Form1()
        {
            InitializeComponent();
            //form1 = this;


            //richTextBox1.Text += "";

            // 객체 생성
            
            publisher = new Publisher();
            subscriber = new Subscriber();
            // 이벤트 추가
            stringObject.ItemStr += new StringHandler.StrAddHandler(addRichText);

        }

        // 이벤트 함수 구현
        private void addRichText(string str) 
        {   
            // 여기서 this 는 class Form1 을 의미함
            this.richTextBox1.Text += str + "\n";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var publish_topic = Task.Run(async () => await publisher.Publish_Application_Message("test/Vector/angle", "20"));
                Thread.Sleep(100);
                var subscribe_topic = Task.Run(async () => await subscriber.Handle_Received_Applicaiton_Message("test/Vector/angle"));
            }
            catch (Exception ex) 
            {
                stringObject.AddText(ex.ToString());
            }
            
        }
    }
}