namespace WinForm_MQTT_Adafruit
{
    partial class FeedForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSubscribe = new System.Windows.Forms.Button();
            this.txtTopic = new System.Windows.Forms.TextBox();
            this.btnPublish = new System.Windows.Forms.Button();
            this.txtStream = new System.Windows.Forms.RichTextBox();
            this.panelFeed = new System.Windows.Forms.Panel();
            this.txtData = new System.Windows.Forms.TextBox();
            this.btnToggle = new System.Windows.Forms.Button();
            this.panelFeed.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSubscribe
            // 
            this.btnSubscribe.Location = new System.Drawing.Point(501, 90);
            this.btnSubscribe.Name = "btnSubscribe";
            this.btnSubscribe.Size = new System.Drawing.Size(213, 34);
            this.btnSubscribe.TabIndex = 0;
            this.btnSubscribe.Text = "Subscribe";
            this.btnSubscribe.UseVisualStyleBackColor = true;
            // 
            // txtTopic
            // 
            this.txtTopic.Location = new System.Drawing.Point(72, 97);
            this.txtTopic.Name = "txtTopic";
            this.txtTopic.Size = new System.Drawing.Size(349, 23);
            this.txtTopic.TabIndex = 1;
            // 
            // btnPublish
            // 
            this.btnPublish.Location = new System.Drawing.Point(365, 244);
            this.btnPublish.Name = "btnPublish";
            this.btnPublish.Size = new System.Drawing.Size(213, 34);
            this.btnPublish.TabIndex = 0;
            this.btnPublish.Text = "Send";
            this.btnPublish.UseVisualStyleBackColor = true;
            // 
            // txtStream
            // 
            this.txtStream.Location = new System.Drawing.Point(15, 15);
            this.txtStream.Name = "txtStream";
            this.txtStream.Size = new System.Drawing.Size(563, 218);
            this.txtStream.TabIndex = 2;
            this.txtStream.Text = "";
            // 
            // panelFeed
            // 
            this.panelFeed.Controls.Add(this.txtData);
            this.panelFeed.Controls.Add(this.txtStream);
            this.panelFeed.Controls.Add(this.btnToggle);
            this.panelFeed.Controls.Add(this.btnPublish);
            this.panelFeed.Location = new System.Drawing.Point(54, 231);
            this.panelFeed.Name = "panelFeed";
            this.panelFeed.Size = new System.Drawing.Size(712, 298);
            this.panelFeed.TabIndex = 3;
            // 
            // txtData
            // 
            this.txtData.Location = new System.Drawing.Point(15, 255);
            this.txtData.Name = "txtData";
            this.txtData.Size = new System.Drawing.Size(316, 23);
            this.txtData.TabIndex = 3;
            // 
            // btnToggle
            // 
            this.btnToggle.Location = new System.Drawing.Point(584, 143);
            this.btnToggle.Name = "btnToggle";
            this.btnToggle.Size = new System.Drawing.Size(125, 35);
            this.btnToggle.TabIndex = 0;
            this.btnToggle.Text = "Toggle";
            this.btnToggle.UseVisualStyleBackColor = true;
            // 
            // FeedForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 541);
            this.Controls.Add(this.panelFeed);
            this.Controls.Add(this.txtTopic);
            this.Controls.Add(this.btnSubscribe);
            this.Name = "FeedForm";
            this.Text = "FeedForm";
            this.panelFeed.ResumeLayout(false);
            this.panelFeed.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnSubscribe;
        private TextBox txtTopic;
        private Button btnPublish;
        private RichTextBox txtStream;
        private Panel panelFeed;
        private TextBox txtData;
        private Button btnToggle;
    }
}