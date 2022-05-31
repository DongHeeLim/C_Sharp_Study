using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Winform_Delegate
{
    public partial class Form1 : Form
    {
        private TextBox textBox;

        public Form1()
        {
            InitializeComponent();

            Button button = new Button();
            button.Text = "버어튼";
            button.Width = 100;
            button.Height = 36;
            button.Click += delegate (object? sender, EventArgs args)
            {
                MessageBox.Show("무명 델리게이트를 사용한 이벤트 연결");
            };
            button.Click += (sender, args) =>
            {
                MessageBox.Show("람다를 사용한 이벤트 연결");
            };
            button.Click += Button_Click;

            


            textBox = new TextBox();
            textBox.Width = 100;
            textBox.Height = 40;
            Point point = new Point(5, 50);
            textBox.Location = point;

            Controls.Add(button);
            Controls.Add(textBox);


        }

        private void Button_Click(object? sender, EventArgs e)
        {   
            // (파일 형식에 보이는 글자) | 필터링
            saveFileDialog1.Filter = "텍스트 파일 (*.txt)|*.txt|파워포인트(*.pptx)|*.pptx";
            saveFileDialog1.ShowDialog();
            File.WriteAllText(saveFileDialog1.FileName, textBox.Text);
        }
    }
}
