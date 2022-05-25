using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Winform_Group_Box
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            int width = 100;
            int height = 23;
            int margin = 3;

            GroupBox groupBox1 = new GroupBox()
            {
                Text = "Plant",
                Location = new Point(margin, margin),
                Size = new Size(width + margin * 2, height * 3 + margin * 2)
            };
            GroupBox groupBox2 = new GroupBox()
            {
                Text = "Fish",
                Location = new Point(width + margin * 5, margin),
                Size = new Size(width + margin * 2, height * 3 + margin * 2)
            };

            RadioButton radioButton1 = new RadioButton()
            {
                Text = "각사나무",
                Width = width,
                Height = height,
                Location = new Point(margin, height * 1 + margin),
            };
            RadioButton radioButton2 = new RadioButton()
            {
                Text = "소나무",
                Width = width,
                Height = height,
                Location = new Point(margin, height * 2 + margin),
            };
            RadioButton radioButton3 = new RadioButton()
            {
                Text = "대포복어",
                Width = width,
                Height = height,
                Location = new Point(margin, height * 1 + margin),
            };
            RadioButton radioButton4 = new RadioButton()
            {
                Text = "가시고기",
                Width = width,
                Height = height,
                Location = new Point(margin, height * 2 + margin),
            };

            Button button = new Button()
            {
                Text = "Click",
                Width = width,
                Height = height,
                Location = new Point(margin, height * 3 + margin * 4)
            };

            button.Click += Button_Click;

            groupBox1.Controls.Add(radioButton1);
            groupBox1.Controls.Add(radioButton2);
            groupBox2.Controls.Add(radioButton3);
            groupBox2.Controls.Add(radioButton4);

            Controls.Add(groupBox1);
            Controls.Add(groupBox2);
            Controls.Add(button);



        }

        private void Button_Click(object? sender, EventArgs e)
        {
            List<string> list = new List<string>();

            int cnt = 0;
            foreach (var item in Controls)  // groupBox
            {
                if (item is GroupBox)       // radioButton
                {
                    foreach (var innerItem in ((GroupBox)item).Controls)    // innerItem in radioButton
                    {

                        RadioButton radioButton = innerItem as RadioButton;
                        if (radioButton != null && radioButton.Checked)
                        {
                            cnt++;
                            //MessageBox.Show(cnt.ToString() + radioButton.Text);
                            list.Add(radioButton.Text);
                        }



                    }

                }

            }
            if (cnt == 2) 
            {
                MessageBox.Show(String.Join(", ", list));
            }
            else 
            {
                MessageBox.Show("아직 누르지 않은 버튼이 있습니다.");
            }
            
        }
    }
}
