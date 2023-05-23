using System.Threading;

namespace WinForm_Task
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Working()
        {
            Action<object?> action = (object? obj) =>{ richTextBox1.Text +=  Task.CurrentId + obj?.ToString() + Thread.CurrentThread.ManagedThreadId + ": action\n" ; };

            Task t1 = new Task(() =>
            {
                textBox1.Text = ""; for (int i = 0; i <= 10; i++)
                {
                    richTextBox1.Text += i.ToString() + ": t1\n";
                }
            });

            t1.Start();
            t1.Wait();
            //richTextBox1.Text = ;

            Task t2 = Task.Run(() => { richTextBox1.Text += "T2 thread\n"; });
            t2.Wait();

            Task t3 = Task.Factory.StartNew(action, "-- T3 --"); // obj -> "--T3"
            t3.Wait();


            Task<int> t4 = Task.Run<int>(()=>ShowNum());
            Thread.Sleep(1000);
            int result = t4.Result;
            richTextBox1.Text += result;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            Working();


        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private int ShowNum() 
        {
            richTextBox1.Text += "T4";

            return 9;
        }
    }
}