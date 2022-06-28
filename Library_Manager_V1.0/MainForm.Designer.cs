namespace Library_Manager_V1._0
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.도서관리ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.사용자관리ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.libraryStatus_grb = new System.Windows.Forms.GroupBox();
            this.overDuelbl_num = new System.Windows.Forms.Label();
            this.checkOutlbl_num = new System.Windows.Forms.Label();
            this.UserNumberlbl_num = new System.Windows.Forms.Label();
            this.totalBookslbl_num = new System.Windows.Forms.Label();
            this.overDuelbl = new System.Windows.Forms.Label();
            this.checkOutlbl = new System.Windows.Forms.Label();
            this.UserNumberlbl = new System.Windows.Forms.Label();
            this.totalBookslbl = new System.Windows.Forms.Label();
            this.checkInOut_grb = new System.Windows.Forms.GroupBox();
            this.iconButton3 = new FontAwesome.Sharp.IconButton();
            this.iconButton2 = new FontAwesome.Sharp.IconButton();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.UserIDlbl = new System.Windows.Forms.Label();
            this.bookNamelbl = new System.Windows.Forms.Label();
            this.Isbnlbl = new System.Windows.Forms.Label();
            this.bookStatus1 = new Library_Manager_V1._0.Interfaces.BookStatus();
            this.userStatus1 = new Library_Manager_V1._0.Interfaces.UserStatus();
            this.menuStrip1.SuspendLayout();
            this.libraryStatus_grb.SuspendLayout();
            this.checkInOut_grb.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.도서관리ToolStripMenuItem,
            this.사용자관리ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 도서관리ToolStripMenuItem
            // 
            this.도서관리ToolStripMenuItem.Name = "도서관리ToolStripMenuItem";
            this.도서관리ToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.도서관리ToolStripMenuItem.Text = "도서 관리";
            // 
            // 사용자관리ToolStripMenuItem
            // 
            this.사용자관리ToolStripMenuItem.Name = "사용자관리ToolStripMenuItem";
            this.사용자관리ToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.사용자관리ToolStripMenuItem.Text = "사용자 관리";
            // 
            // libraryStatus_grb
            // 
            this.libraryStatus_grb.Controls.Add(this.overDuelbl_num);
            this.libraryStatus_grb.Controls.Add(this.checkOutlbl_num);
            this.libraryStatus_grb.Controls.Add(this.UserNumberlbl_num);
            this.libraryStatus_grb.Controls.Add(this.totalBookslbl_num);
            this.libraryStatus_grb.Controls.Add(this.overDuelbl);
            this.libraryStatus_grb.Controls.Add(this.checkOutlbl);
            this.libraryStatus_grb.Controls.Add(this.UserNumberlbl);
            this.libraryStatus_grb.Controls.Add(this.totalBookslbl);
            this.libraryStatus_grb.Location = new System.Drawing.Point(12, 27);
            this.libraryStatus_grb.Name = "libraryStatus_grb";
            this.libraryStatus_grb.Size = new System.Drawing.Size(258, 144);
            this.libraryStatus_grb.TabIndex = 1;
            this.libraryStatus_grb.TabStop = false;
            this.libraryStatus_grb.Text = "도서관 현황";
            // 
            // overDuelbl_num
            // 
            this.overDuelbl_num.AutoSize = true;
            this.overDuelbl_num.Location = new System.Drawing.Point(138, 113);
            this.overDuelbl_num.Name = "overDuelbl_num";
            this.overDuelbl_num.Size = new System.Drawing.Size(39, 15);
            this.overDuelbl_num.TabIndex = 6;
            this.overDuelbl_num.Text = "label8";
            // 
            // checkOutlbl_num
            // 
            this.checkOutlbl_num.AutoSize = true;
            this.checkOutlbl_num.Location = new System.Drawing.Point(138, 83);
            this.checkOutlbl_num.Name = "checkOutlbl_num";
            this.checkOutlbl_num.Size = new System.Drawing.Size(39, 15);
            this.checkOutlbl_num.TabIndex = 5;
            this.checkOutlbl_num.Text = "label7";
            // 
            // UserNumberlbl_num
            // 
            this.UserNumberlbl_num.AutoSize = true;
            this.UserNumberlbl_num.Location = new System.Drawing.Point(138, 50);
            this.UserNumberlbl_num.Name = "UserNumberlbl_num";
            this.UserNumberlbl_num.Size = new System.Drawing.Size(39, 15);
            this.UserNumberlbl_num.TabIndex = 4;
            this.UserNumberlbl_num.Text = "label6";
            // 
            // totalBookslbl_num
            // 
            this.totalBookslbl_num.AutoSize = true;
            this.totalBookslbl_num.Location = new System.Drawing.Point(138, 19);
            this.totalBookslbl_num.Name = "totalBookslbl_num";
            this.totalBookslbl_num.Size = new System.Drawing.Size(39, 15);
            this.totalBookslbl_num.TabIndex = 2;
            this.totalBookslbl_num.Text = "label5";
            // 
            // overDuelbl
            // 
            this.overDuelbl.AutoSize = true;
            this.overDuelbl.Location = new System.Drawing.Point(6, 113);
            this.overDuelbl.Name = "overDuelbl";
            this.overDuelbl.Size = new System.Drawing.Size(115, 15);
            this.overDuelbl.TabIndex = 3;
            this.overDuelbl.Text = "연체 중인 도서의 수";
            // 
            // checkOutlbl
            // 
            this.checkOutlbl.AutoSize = true;
            this.checkOutlbl.Location = new System.Drawing.Point(6, 83);
            this.checkOutlbl.Name = "checkOutlbl";
            this.checkOutlbl.Size = new System.Drawing.Size(115, 15);
            this.checkOutlbl.TabIndex = 2;
            this.checkOutlbl.Text = "대출 중인 도서의 수";
            // 
            // UserNumberlbl
            // 
            this.UserNumberlbl.AutoSize = true;
            this.UserNumberlbl.Location = new System.Drawing.Point(6, 50);
            this.UserNumberlbl.Name = "UserNumberlbl";
            this.UserNumberlbl.Size = new System.Drawing.Size(59, 15);
            this.UserNumberlbl.TabIndex = 1;
            this.UserNumberlbl.Text = "사용자 수";
            // 
            // totalBookslbl
            // 
            this.totalBookslbl.AutoSize = true;
            this.totalBookslbl.Location = new System.Drawing.Point(6, 19);
            this.totalBookslbl.Name = "totalBookslbl";
            this.totalBookslbl.Size = new System.Drawing.Size(75, 15);
            this.totalBookslbl.TabIndex = 0;
            this.totalBookslbl.Text = "현재 도서 수";
            // 
            // checkInOut_grb
            // 
            this.checkInOut_grb.Controls.Add(this.iconButton3);
            this.checkInOut_grb.Controls.Add(this.iconButton2);
            this.checkInOut_grb.Controls.Add(this.iconButton1);
            this.checkInOut_grb.Controls.Add(this.textBox3);
            this.checkInOut_grb.Controls.Add(this.textBox2);
            this.checkInOut_grb.Controls.Add(this.textBox1);
            this.checkInOut_grb.Controls.Add(this.UserIDlbl);
            this.checkInOut_grb.Controls.Add(this.bookNamelbl);
            this.checkInOut_grb.Controls.Add(this.Isbnlbl);
            this.checkInOut_grb.Location = new System.Drawing.Point(466, 37);
            this.checkInOut_grb.Name = "checkInOut_grb";
            this.checkInOut_grb.Size = new System.Drawing.Size(322, 134);
            this.checkInOut_grb.TabIndex = 3;
            this.checkInOut_grb.TabStop = false;
            this.checkInOut_grb.Text = "대여/반납";
            // 
            // iconButton3
            // 
            this.iconButton3.IconChar = FontAwesome.Sharp.IconChar.None;
            this.iconButton3.IconColor = System.Drawing.Color.Black;
            this.iconButton3.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton3.Location = new System.Drawing.Point(224, 94);
            this.iconButton3.Name = "iconButton3";
            this.iconButton3.Size = new System.Drawing.Size(75, 23);
            this.iconButton3.TabIndex = 8;
            this.iconButton3.Text = "iconButton3";
            this.iconButton3.UseVisualStyleBackColor = true;
            // 
            // iconButton2
            // 
            this.iconButton2.IconChar = FontAwesome.Sharp.IconChar.None;
            this.iconButton2.IconColor = System.Drawing.Color.Black;
            this.iconButton2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton2.Location = new System.Drawing.Point(224, 54);
            this.iconButton2.Name = "iconButton2";
            this.iconButton2.Size = new System.Drawing.Size(75, 23);
            this.iconButton2.TabIndex = 7;
            this.iconButton2.Text = "iconButton2";
            this.iconButton2.UseVisualStyleBackColor = true;
            // 
            // iconButton1
            // 
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.None;
            this.iconButton1.IconColor = System.Drawing.Color.Black;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.Location = new System.Drawing.Point(224, 19);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(75, 23);
            this.iconButton1.TabIndex = 6;
            this.iconButton1.Text = "iconButton1";
            this.iconButton1.UseVisualStyleBackColor = true;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(92, 95);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 23);
            this.textBox3.TabIndex = 5;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(92, 54);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 23);
            this.textBox2.TabIndex = 4;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(92, 16);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 23);
            this.textBox1.TabIndex = 3;
            // 
            // UserIDlbl
            // 
            this.UserIDlbl.AutoSize = true;
            this.UserIDlbl.Location = new System.Drawing.Point(6, 103);
            this.UserIDlbl.Name = "UserIDlbl";
            this.UserIDlbl.Size = new System.Drawing.Size(59, 15);
            this.UserIDlbl.TabIndex = 2;
            this.UserIDlbl.Text = "사용자 ID";
            // 
            // bookNamelbl
            // 
            this.bookNamelbl.AutoSize = true;
            this.bookNamelbl.Location = new System.Drawing.Point(6, 54);
            this.bookNamelbl.Name = "bookNamelbl";
            this.bookNamelbl.Size = new System.Drawing.Size(59, 15);
            this.bookNamelbl.TabIndex = 1;
            this.bookNamelbl.Text = "도서 이름";
            // 
            // Isbnlbl
            // 
            this.Isbnlbl.AutoSize = true;
            this.Isbnlbl.Location = new System.Drawing.Point(6, 19);
            this.Isbnlbl.Name = "Isbnlbl";
            this.Isbnlbl.Size = new System.Drawing.Size(29, 15);
            this.Isbnlbl.TabIndex = 0;
            this.Isbnlbl.Text = "Isbn";
            // 
            // bookStatus1
            // 
            this.bookStatus1.Location = new System.Drawing.Point(12, 177);
            this.bookStatus1.Name = "bookStatus1";
            this.bookStatus1.Size = new System.Drawing.Size(776, 158);
            this.bookStatus1.TabIndex = 4;
            // 
            // userStatus1
            // 
            this.userStatus1.Location = new System.Drawing.Point(12, 341);
            this.userStatus1.Name = "userStatus1";
            this.userStatus1.Size = new System.Drawing.Size(776, 97);
            this.userStatus1.TabIndex = 5;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.userStatus1);
            this.Controls.Add(this.bookStatus1);
            this.Controls.Add(this.checkInOut_grb);
            this.Controls.Add(this.libraryStatus_grb);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Library Manager";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.libraryStatus_grb.ResumeLayout(false);
            this.libraryStatus_grb.PerformLayout();
            this.checkInOut_grb.ResumeLayout(false);
            this.checkInOut_grb.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 도서관리ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 사용자관리ToolStripMenuItem;
        private System.Windows.Forms.GroupBox libraryStatus_grb;
        private System.Windows.Forms.Label overDuelbl_num;
        private System.Windows.Forms.Label checkOutlbl_num;
        private System.Windows.Forms.Label UserNumberlbl_num;
        private System.Windows.Forms.Label totalBookslbl_num;
        private System.Windows.Forms.Label overDuelbl;
        private System.Windows.Forms.Label checkOutlbl;
        private System.Windows.Forms.Label UserNumberlbl;
        private System.Windows.Forms.Label totalBookslbl;
        private System.Windows.Forms.GroupBox checkInOut_grb;
        private FontAwesome.Sharp.IconButton iconButton3;
        private FontAwesome.Sharp.IconButton iconButton2;
        private FontAwesome.Sharp.IconButton iconButton1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label UserIDlbl;
        private System.Windows.Forms.Label bookNamelbl;
        private System.Windows.Forms.Label Isbnlbl;
        private Interfaces.BookStatus bookStatus1;
        private Interfaces.UserStatus userStatus1;
    }
}
