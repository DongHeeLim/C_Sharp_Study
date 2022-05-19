using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Winform_Lable_LinkLable
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            int height = 23;

            Label label = new Label()
            {
                Text = "LABEL_TEXT",
                Location = new Point(10, 10),
                Height = height
            };
            LinkLabel linkLabel = new LinkLabel()
            {
                Text = "LABEL_TEXT",
                Location = new Point(10, 50),
                Height = height
            };

            linkLabel.Click += LinkLabel_Click; // add event 

            Controls.Add(label);
            Controls.Add(linkLabel);
        }

        private void LinkLabel_Click(object? sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(new ProcessStartInfo
            {
                FileName = "https://www.kopo.ac.kr/robot/index.do",
                UseShellExecute = true
            });

            System.Diagnostics.Process.Start("notepad.exe", "D:/C_FileSystem/test.txt");  
        }
    }
}
