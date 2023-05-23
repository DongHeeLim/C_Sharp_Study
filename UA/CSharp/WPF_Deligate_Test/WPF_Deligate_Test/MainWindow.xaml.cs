using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_Deligate_Test
{
    public delegate void DataGetEventHandler(string data);
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, Interface
    {
        // Type 정의
        public delegate void RunDelegate(int i);
        public delegate int DelFunction(int a, int b);

        
        public DataGetEventHandler DataSendEvent;
        

        // Delegate 선언
        public delegate void MyEventHandler(object sender, EventArgs e);
        // Event 선언
        public event MyEventHandler myEvent;


        // 같은 파일 내 클래스 선언
        ClassA classA = new ClassA();


        public MainWindow()
        {
            InitializeComponent();

            // 적용
            DelFunction delFunction;
            delFunction = new DelFunction(function);

            txtBox.Text += delFunction(3, 4) + "\n";
 
            classA.myButton += myButton_Click;
            

        }

        private void myButton_Click(object sender, EventArgs e)
        {
            txtBlk.Text = "커스텀 버튼 누름\n";
            
            DataSendEvent("커스텀 데이터");

        }

        public void evenTest()
        { 
            if (myEvent != null) 
            {
                myEvent(this, new EventArgs());
            }
        }
    



        // 사용할 Type 구현
        public int function(int a, int b)
        {
            return a * b;
        }

        private void RunThis(int value)
        {
            txtBox.Text += value.ToString();
        }

        private void RunThat(int value)
        {
            txtBlk.Text += value.ToString();
        }

        public void SendText()
        {
            RunDelegate run = new RunDelegate(RunThis);

            run(777);

            run = RunThat;

            run(222);
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            
            classA.myButtonEvent();

            if (myEvent != null)
            {
                txtBlk.Text += "Event Send\n";

            }
            else 
            {
                txtBlk.Text += "Event Not loaded\n";
            }
        }

        public void setData(string Data)
        {
            txtBlk.Text = Data;
        }
    }

    public class ClassA
    {
        public delegate void ButtonEventHandler(object sender, EventArgs e);

        public event ButtonEventHandler? myButton;

        public void myButtonEvent()
        {
            if (myButton != null)
            { 
                myButton(this, new EventArgs());
            }
        }
    
    }
}
