using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;
using System.Runtime.InteropServices;   // Dll Import

namespace _220412_Winform
{



    public partial class FormMainmenu : Form
    {
        // Fields
        private IconButton currentBtn;
        private Panel leftBorderBtn;
        private Form currentChildForm;

        // Class
        public class MyMath
        {

            public static int Abs (int input) 
            {
                if (input < 0) { return -input; }
                else { return input; }
            }
            public static double Abs(double input)
            {
                if (input < 0) { return -input; }
                else { return input; }
            }
        }

        public class Form1_State
        { 
            private bool loginFlag = false;

            public bool LoginFlag { get { return loginFlag; } set { loginFlag = value; } }
        }

        // Construct
        public FormMainmenu()
        {
            InitializeComponent();

            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 60);
            panelMenu.Controls.Add(leftBorderBtn);

            //Form
            this.Text = String.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true; // prevent flicker
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;


            Form1_State state = new Form1_State();
            if (state.LoginFlag == false) 
            {
                
            }

        }

        // Structs
        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(215, 105, 160);
            public static Color color2 = Color.FromArgb(249, 118, 176);
            public static Color color3 = Color.FromArgb(253, 138, 114);
            //public static Color color4 = Color.FromArgb(95, 77, 221);
            //public static Color color4 = Color.FromArgb(0, 0, 50);
           
            public static Color color4 = Color.FromArgb(65, 255, 15);
            public static Color color5 = Color.FromArgb(249, 88, 155);
            public static Color color6 = Color.FromArgb(24, 161, 251);
        }

        // Methods
        private void ActivateButtnon(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableButton();

                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(65, 255, 15);
                currentBtn.ForeColor = Color.Black;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = Color.Black;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;

                // left border button;
                leftBorderBtn.BackColor = Color.Black;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();

                // Icon Current Child Form
                iconCurrentChildForm.IconChar = currentBtn.IconChar;
                iconCurrentChildForm.IconColor = color;

                // label Title Child Form
                labelTitleChildForm.Text = currentBtn.Text;
                labelTitleChildForm.ForeColor = color;
               

            }
        }

        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(15, 15, 15);
                currentBtn.ForeColor = Color.FromArgb(65, 255, 15);
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.FromArgb(65, 255, 15);
                currentBtn.TextImageRelation= TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign= ContentAlignment.MiddleLeft;

            }
        
        }

        private void OpenChildForm(Form childForm)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelDesktop.Controls.Add(childForm);
            panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            //labelTitleChildForm.Text = childForm.Text;
        }

        private void configBtn_Click(object sender, EventArgs e)
        {
            ActivateButtnon(sender, RGBColors.color4);
            OpenChildForm(new FormConfiguration());
        }

        private void toolBtn_Click(object sender, EventArgs e)
        {
            ActivateButtnon(sender, RGBColors.color4);
            OpenChildForm(new FormTools());
        }

        private void monitoringBtn_Click(object sender, EventArgs e)
        {
            ActivateButtnon(sender, RGBColors.color4);
            OpenChildForm(new FormMonitoring());
        }

        private void controlBtn_Click(object sender, EventArgs e)
        {
            ActivateButtnon(sender, RGBColors.color4);
            OpenChildForm(new FormControl());
        }

        private void scheduleBtn_Click(object sender, EventArgs e)
        {
            ActivateButtnon(sender, RGBColors.color4);
            OpenChildForm(new FormSchedule());
        }

        private void ImportExportBtn_Click(object sender, EventArgs e)
        {
            ActivateButtnon(sender, RGBColors.color4);
            OpenChildForm(new FormImportExport());
        }


        private void logoPicture_Click(object sender, EventArgs e)
        {
            //currentChildForm.Close();
            Reset();
        }
        private void logolbl_Click(object sender, EventArgs e)
        {
           // currentChildForm.Close();
            Reset();
        }

        private void Reset()
        { 
            DisableButton();
            leftBorderBtn.Visible = false;
            iconCurrentChildForm.IconChar = IconChar.Home;
            iconCurrentChildForm.IconColor = Color.FromArgb(65, 255, 15);
            labelTitleChildForm.Text = "HOME";
            labelTitleChildForm.ForeColor = Color.FromArgb(65, 255, 15);

        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelMenu_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
