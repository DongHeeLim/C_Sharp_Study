using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Winform_Check_Box
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            int width = 100;
            int height = 23;
            int margin = 3;

            CheckBox checkBox1 = new CheckBox()
            {
                Text = "향릉",
                Width = width,
                Height = height,
                Location = new Point(10, height * 0 + margin)
            };
            CheckBox checkBox2 = new CheckBox()
            {
                Text = "행추",
                Width = width,
                Height = height,
                Location = new Point(10, height * 1 + margin)
            };
            CheckBox checkBox3 = new CheckBox()
            {
                Text = "베넷",
                Width = width,
                Height = height,
                Location = new Point(10, height * 2 + margin)
            };

            Button button = new Button()
            {
                Text = "Click",
                Width = width,
                Height = height,
                Location = new Point(10, height * 3 + margin)
            };

            button.Click += Button_Click;

            Controls.Add(checkBox1);
            Controls.Add(checkBox2);
            Controls.Add(checkBox3);
            Controls.Add(button);

        }

        private void Button_Click(object? sender, EventArgs e)
        {
            List<string> list = new List<string>();

            foreach (var item in Controls) 
            {
                if (item is CheckBox) 
                {
                    CheckBox checkBox = (CheckBox)item;
                    if (checkBox.Checked) 
                    {
                        list.Add(checkBox.Text);
                    }
                
                }
            }
            MessageBox.Show(String.Join(", ", list));
        }
    }
}
