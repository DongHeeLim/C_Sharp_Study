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

            // ��ü ����
            
            publisher = new Publisher();
            subscriber = new Subscriber();
            // �̺�Ʈ �߰�
            stringObject.ItemStr += new StringHandler.StrAddHandler(addRichText);

        }

        // �̺�Ʈ �Լ� ����
        private void addRichText(string str) 
        {   
            // ���⼭ this �� class Form1 �� �ǹ���
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