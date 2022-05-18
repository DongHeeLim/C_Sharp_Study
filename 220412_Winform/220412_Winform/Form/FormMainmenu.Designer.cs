namespace _220412_Winform
{
    partial class FormMainmenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMainmenu));
            this.panelMenu = new System.Windows.Forms.Panel();
            this.ImportExportBtn = new FontAwesome.Sharp.IconButton();
            this.scheduleBtn = new FontAwesome.Sharp.IconButton();
            this.controlBtn = new FontAwesome.Sharp.IconButton();
            this.monitoringBtn = new FontAwesome.Sharp.IconButton();
            this.toolBtn = new FontAwesome.Sharp.IconButton();
            this.configBtn = new FontAwesome.Sharp.IconButton();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.logolbl = new System.Windows.Forms.Label();
            this.logoPicture = new System.Windows.Forms.PictureBox();
            this.panelTitleBar = new System.Windows.Forms.Panel();
            this.labelTitleChildForm = new System.Windows.Forms.Label();
            this.iconCurrentChildForm = new FontAwesome.Sharp.IconPictureBox();
            this.panelShadow = new System.Windows.Forms.Panel();
            this.panelDesktop = new System.Windows.Forms.Panel();
            this.panelMenu.SuspendLayout();
            this.panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPicture)).BeginInit();
            this.panelTitleBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconCurrentChildForm)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.panelMenu.Controls.Add(this.ImportExportBtn);
            this.panelMenu.Controls.Add(this.scheduleBtn);
            this.panelMenu.Controls.Add(this.controlBtn);
            this.panelMenu.Controls.Add(this.monitoringBtn);
            this.panelMenu.Controls.Add(this.toolBtn);
            this.panelMenu.Controls.Add(this.configBtn);
            this.panelMenu.Controls.Add(this.panelLogo);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(255)))), ((int)(((byte)(15)))));
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(182, 450);
            this.panelMenu.TabIndex = 3;
            this.panelMenu.Paint += new System.Windows.Forms.PaintEventHandler(this.panelMenu_Paint);
            // 
            // ImportExportBtn
            // 
            this.ImportExportBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.ImportExportBtn.FlatAppearance.BorderSize = 0;
            this.ImportExportBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ImportExportBtn.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ImportExportBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(255)))), ((int)(((byte)(15)))));
            this.ImportExportBtn.IconChar = FontAwesome.Sharp.IconChar.ExternalLinkAlt;
            this.ImportExportBtn.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(255)))), ((int)(((byte)(15)))));
            this.ImportExportBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ImportExportBtn.IconSize = 36;
            this.ImportExportBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ImportExportBtn.Location = new System.Drawing.Point(0, 383);
            this.ImportExportBtn.Name = "ImportExportBtn";
            this.ImportExportBtn.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.ImportExportBtn.Size = new System.Drawing.Size(182, 60);
            this.ImportExportBtn.TabIndex = 7;
            this.ImportExportBtn.Text = "Import/Export";
            this.ImportExportBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ImportExportBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ImportExportBtn.UseVisualStyleBackColor = true;
            this.ImportExportBtn.Click += new System.EventHandler(this.ImportExportBtn_Click);
            // 
            // scheduleBtn
            // 
            this.scheduleBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.scheduleBtn.FlatAppearance.BorderSize = 0;
            this.scheduleBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.scheduleBtn.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.scheduleBtn.IconChar = FontAwesome.Sharp.IconChar.Calendar;
            this.scheduleBtn.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(255)))), ((int)(((byte)(15)))));
            this.scheduleBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.scheduleBtn.IconSize = 36;
            this.scheduleBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.scheduleBtn.Location = new System.Drawing.Point(0, 323);
            this.scheduleBtn.Name = "scheduleBtn";
            this.scheduleBtn.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.scheduleBtn.Size = new System.Drawing.Size(182, 60);
            this.scheduleBtn.TabIndex = 6;
            this.scheduleBtn.Text = "Schedule";
            this.scheduleBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.scheduleBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.scheduleBtn.UseVisualStyleBackColor = true;
            this.scheduleBtn.Click += new System.EventHandler(this.scheduleBtn_Click);
            // 
            // controlBtn
            // 
            this.controlBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.controlBtn.FlatAppearance.BorderSize = 0;
            this.controlBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.controlBtn.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.controlBtn.IconChar = FontAwesome.Sharp.IconChar.ArrowAltCircleRight;
            this.controlBtn.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(255)))), ((int)(((byte)(15)))));
            this.controlBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.controlBtn.IconSize = 36;
            this.controlBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.controlBtn.Location = new System.Drawing.Point(0, 263);
            this.controlBtn.Name = "controlBtn";
            this.controlBtn.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.controlBtn.Size = new System.Drawing.Size(182, 60);
            this.controlBtn.TabIndex = 5;
            this.controlBtn.Text = "Control";
            this.controlBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.controlBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.controlBtn.UseVisualStyleBackColor = true;
            this.controlBtn.Click += new System.EventHandler(this.controlBtn_Click);
            // 
            // monitoringBtn
            // 
            this.monitoringBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.monitoringBtn.FlatAppearance.BorderSize = 0;
            this.monitoringBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.monitoringBtn.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.monitoringBtn.IconChar = FontAwesome.Sharp.IconChar.MobileAlt;
            this.monitoringBtn.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(255)))), ((int)(((byte)(15)))));
            this.monitoringBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.monitoringBtn.IconSize = 36;
            this.monitoringBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.monitoringBtn.Location = new System.Drawing.Point(0, 203);
            this.monitoringBtn.Name = "monitoringBtn";
            this.monitoringBtn.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.monitoringBtn.Size = new System.Drawing.Size(182, 60);
            this.monitoringBtn.TabIndex = 4;
            this.monitoringBtn.Text = "Monitoring";
            this.monitoringBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.monitoringBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.monitoringBtn.UseVisualStyleBackColor = true;
            this.monitoringBtn.Click += new System.EventHandler(this.monitoringBtn_Click);
            // 
            // toolBtn
            // 
            this.toolBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolBtn.FlatAppearance.BorderSize = 0;
            this.toolBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.toolBtn.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.toolBtn.IconChar = FontAwesome.Sharp.IconChar.Tools;
            this.toolBtn.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(255)))), ((int)(((byte)(15)))));
            this.toolBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.toolBtn.IconSize = 36;
            this.toolBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolBtn.Location = new System.Drawing.Point(0, 143);
            this.toolBtn.Name = "toolBtn";
            this.toolBtn.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.toolBtn.Size = new System.Drawing.Size(182, 60);
            this.toolBtn.TabIndex = 3;
            this.toolBtn.Text = "Tools";
            this.toolBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolBtn.UseVisualStyleBackColor = true;
            this.toolBtn.Click += new System.EventHandler(this.toolBtn_Click);
            // 
            // configBtn
            // 
            this.configBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.configBtn.FlatAppearance.BorderSize = 0;
            this.configBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.configBtn.Font = new System.Drawing.Font("Consolas", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.configBtn.IconChar = FontAwesome.Sharp.IconChar.PenSquare;
            this.configBtn.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(255)))), ((int)(((byte)(15)))));
            this.configBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.configBtn.IconSize = 36;
            this.configBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.configBtn.Location = new System.Drawing.Point(0, 83);
            this.configBtn.Name = "configBtn";
            this.configBtn.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.configBtn.Size = new System.Drawing.Size(182, 60);
            this.configBtn.TabIndex = 2;
            this.configBtn.Text = "Configuration";
            this.configBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.configBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.configBtn.UseVisualStyleBackColor = true;
            this.configBtn.Click += new System.EventHandler(this.configBtn_Click);
            // 
            // panelLogo
            // 
            this.panelLogo.Controls.Add(this.logolbl);
            this.panelLogo.Controls.Add(this.logoPicture);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(182, 83);
            this.panelLogo.TabIndex = 1;
            this.panelLogo.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // logolbl
            // 
            this.logolbl.AutoSize = true;
            this.logolbl.Font = new System.Drawing.Font("맑은 고딕", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.logolbl.Location = new System.Drawing.Point(54, 22);
            this.logolbl.Name = "logolbl";
            this.logolbl.Size = new System.Drawing.Size(92, 37);
            this.logolbl.TabIndex = 1;
            this.logolbl.Text = "Drone";
            this.logolbl.Click += new System.EventHandler(this.logolbl_Click);
            // 
            // logoPicture
            // 
            this.logoPicture.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.logoPicture.Image = ((System.Drawing.Image)(resources.GetObject("logoPicture.Image")));
            this.logoPicture.Location = new System.Drawing.Point(3, 14);
            this.logoPicture.Name = "logoPicture";
            this.logoPicture.Size = new System.Drawing.Size(176, 60);
            this.logoPicture.TabIndex = 0;
            this.logoPicture.TabStop = false;
            this.logoPicture.Click += new System.EventHandler(this.logoPicture_Click);
            // 
            // panelTitleBar
            // 
            this.panelTitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.panelTitleBar.Controls.Add(this.labelTitleChildForm);
            this.panelTitleBar.Controls.Add(this.iconCurrentChildForm);
            this.panelTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitleBar.Location = new System.Drawing.Point(182, 0);
            this.panelTitleBar.Name = "panelTitleBar";
            this.panelTitleBar.Size = new System.Drawing.Size(618, 59);
            this.panelTitleBar.TabIndex = 4;
            this.panelTitleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTitleBar_MouseDown);
            // 
            // labelTitleChildForm
            // 
            this.labelTitleChildForm.AutoSize = true;
            this.labelTitleChildForm.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelTitleChildForm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(255)))), ((int)(((byte)(15)))));
            this.labelTitleChildForm.Location = new System.Drawing.Point(52, 22);
            this.labelTitleChildForm.Name = "labelTitleChildForm";
            this.labelTitleChildForm.Size = new System.Drawing.Size(70, 25);
            this.labelTitleChildForm.TabIndex = 1;
            this.labelTitleChildForm.Text = "HOME";
            // 
            // iconCurrentChildForm
            // 
            this.iconCurrentChildForm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.iconCurrentChildForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.iconCurrentChildForm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(255)))), ((int)(((byte)(15)))));
            this.iconCurrentChildForm.IconChar = FontAwesome.Sharp.IconChar.Home;
            this.iconCurrentChildForm.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(255)))), ((int)(((byte)(15)))));
            this.iconCurrentChildForm.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconCurrentChildForm.IconSize = 37;
            this.iconCurrentChildForm.Location = new System.Drawing.Point(16, 16);
            this.iconCurrentChildForm.Name = "iconCurrentChildForm";
            this.iconCurrentChildForm.Size = new System.Drawing.Size(48, 37);
            this.iconCurrentChildForm.TabIndex = 0;
            this.iconCurrentChildForm.TabStop = false;
            // 
            // panelShadow
            // 
            this.panelShadow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(2)))), ((int)(((byte)(2)))));
            this.panelShadow.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelShadow.Location = new System.Drawing.Point(182, 59);
            this.panelShadow.Name = "panelShadow";
            this.panelShadow.Size = new System.Drawing.Size(618, 10);
            this.panelShadow.TabIndex = 5;
            // 
            // panelDesktop
            // 
            this.panelDesktop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.panelDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDesktop.Location = new System.Drawing.Point(182, 69);
            this.panelDesktop.Name = "panelDesktop";
            this.panelDesktop.Size = new System.Drawing.Size(618, 381);
            this.panelDesktop.TabIndex = 6;
            // 
            // FormMainmenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelDesktop);
            this.Controls.Add(this.panelShadow);
            this.Controls.Add(this.panelTitleBar);
            this.Controls.Add(this.panelMenu);
            this.Name = "FormMainmenu";
            this.Text = "Form1";
            this.panelMenu.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            this.panelLogo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPicture)).EndInit();
            this.panelTitleBar.ResumeLayout(false);
            this.panelTitleBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconCurrentChildForm)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelMenu;
        private FontAwesome.Sharp.IconButton ImportExportBtn;
        private FontAwesome.Sharp.IconButton scheduleBtn;
        private FontAwesome.Sharp.IconButton controlBtn;
        private FontAwesome.Sharp.IconButton monitoringBtn;
        private FontAwesome.Sharp.IconButton toolBtn;
        private FontAwesome.Sharp.IconButton configBtn;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Label logolbl;
        private System.Windows.Forms.PictureBox logoPicture;
        private System.Windows.Forms.Panel panelTitleBar;
        private FontAwesome.Sharp.IconPictureBox iconCurrentChildForm;
        private System.Windows.Forms.Label labelTitleChildForm;
        private System.Windows.Forms.Panel panelShadow;
        private System.Windows.Forms.Panel panelDesktop;
    }
}
