namespace padSoft_e
{
    partial class uploadForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

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
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.redEsc_button = new System.Windows.Forms.Button();
            this.link_button = new System.Windows.Forms.Button();
            this.upload_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ipAddr_textBox = new System.Windows.Forms.TextBox();
            this.textBox_rssi = new System.Windows.Forms.TextBox();
            this.textBox_input = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer();
            this.test_textBox = new System.Windows.Forms.TextBox();
            this.btn_upPair = new System.Windows.Forms.Button();
            this.upProgressBar = new System.Windows.Forms.ProgressBar();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // redEsc_button
            // 
            this.redEsc_button.Enabled = false;
            this.redEsc_button.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.redEsc_button.ForeColor = System.Drawing.Color.Red;
            this.redEsc_button.Location = new System.Drawing.Point(18, 226);
            this.redEsc_button.Name = "redEsc_button";
            this.redEsc_button.Size = new System.Drawing.Size(195, 38);
            this.redEsc_button.TabIndex = 6;
            this.redEsc_button.Text = "红键__返回";
            this.redEsc_button.Click += new System.EventHandler(this.redEsc_button_Click);
            // 
            // link_button
            // 
            this.link_button.Enabled = false;
            this.link_button.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.link_button.Location = new System.Drawing.Point(18, 92);
            this.link_button.Name = "link_button";
            this.link_button.Size = new System.Drawing.Size(195, 38);
            this.link_button.TabIndex = 22;
            this.link_button.Text = "F1键__连接服务器";
            this.link_button.Click += new System.EventHandler(this.link_button_Click);
            // 
            // upload_button
            // 
            this.upload_button.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.upload_button.Location = new System.Drawing.Point(18, 137);
            this.upload_button.Name = "upload_button";
            this.upload_button.Size = new System.Drawing.Size(195, 38);
            this.upload_button.TabIndex = 23;
            this.upload_button.Text = "上传数据";
            this.upload_button.Click += new System.EventHandler(this.upload_button_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(18, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 20);
            this.label1.Text = "输入电脑IP地址";
            // 
            // ipAddr_textBox
            // 
            this.ipAddr_textBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular);
            this.ipAddr_textBox.ForeColor = System.Drawing.Color.Blue;
            this.ipAddr_textBox.Location = new System.Drawing.Point(95, 51);
            this.ipAddr_textBox.Multiline = true;
            this.ipAddr_textBox.Name = "ipAddr_textBox";
            this.ipAddr_textBox.Size = new System.Drawing.Size(118, 23);
            this.ipAddr_textBox.TabIndex = 26;
            this.ipAddr_textBox.Text = "192.168.1.200";
            this.ipAddr_textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox_rssi
            // 
            this.textBox_rssi.BackColor = System.Drawing.Color.Black;
            this.textBox_rssi.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular);
            this.textBox_rssi.ForeColor = System.Drawing.Color.White;
            this.textBox_rssi.Location = new System.Drawing.Point(143, 5);
            this.textBox_rssi.Multiline = true;
            this.textBox_rssi.Name = "textBox_rssi";
            this.textBox_rssi.Size = new System.Drawing.Size(70, 20);
            this.textBox_rssi.TabIndex = 27;
            this.textBox_rssi.Text = "22:22:22";
            // 
            // textBox_input
            // 
            this.textBox_input.BackColor = System.Drawing.Color.Black;
            this.textBox_input.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular);
            this.textBox_input.ForeColor = System.Drawing.Color.White;
            this.textBox_input.Location = new System.Drawing.Point(18, 5);
            this.textBox_input.Multiline = true;
            this.textBox_input.Name = "textBox_input";
            this.textBox_input.Size = new System.Drawing.Size(20, 20);
            this.textBox_input.TabIndex = 60;
            this.textBox_input.Text = "1";
            this.textBox_input.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // test_textBox
            // 
            this.test_textBox.Location = new System.Drawing.Point(18, 55);
            this.test_textBox.Multiline = true;
            this.test_textBox.Name = "test_textBox";
            this.test_textBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.test_textBox.Size = new System.Drawing.Size(32, 19);
            this.test_textBox.TabIndex = 62;
            this.test_textBox.Text = "textBox1";
            this.test_textBox.Visible = false;
            // 
            // btn_upPair
            // 
            this.btn_upPair.Enabled = false;
            this.btn_upPair.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.btn_upPair.Location = new System.Drawing.Point(18, 181);
            this.btn_upPair.Name = "btn_upPair";
            this.btn_upPair.Size = new System.Drawing.Size(195, 38);
            this.btn_upPair.TabIndex = 64;
            this.btn_upPair.Text = "上传配置表";
            this.btn_upPair.Click += new System.EventHandler(this.btn_upPair_Click);
            // 
            // upProgressBar
            // 
            this.upProgressBar.Location = new System.Drawing.Point(71, 272);
            this.upProgressBar.Name = "upProgressBar";
            this.upProgressBar.Size = new System.Drawing.Size(142, 20);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(2, 274);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 20);
            this.label3.Text = "上传进度:";
            // 
            // uploadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(238, 295);
            this.Controls.Add(this.upProgressBar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_upPair);
            this.Controls.Add(this.test_textBox);
            this.Controls.Add(this.textBox_input);
            this.Controls.Add(this.textBox_rssi);
            this.Controls.Add(this.ipAddr_textBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.upload_button);
            this.Controls.Add(this.link_button);
            this.Controls.Add(this.redEsc_button);
            this.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "uploadForm";
            this.Text = "uploadForm";
            this.Closed += new System.EventHandler(this.uploadForm_Closed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.uploadForm_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button redEsc_button;
        private System.Windows.Forms.Button link_button;
        private System.Windows.Forms.Button upload_button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ipAddr_textBox;
        private System.Windows.Forms.TextBox textBox_rssi;
        private System.Windows.Forms.TextBox textBox_input;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox test_textBox;
        private System.Windows.Forms.Button btn_upPair;
        private System.Windows.Forms.ProgressBar upProgressBar;
        private System.Windows.Forms.Label label3;
    }
}