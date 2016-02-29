namespace padSoft_e
{
    partial class loginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(loginForm));
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.redEsc_button = new System.Windows.Forms.Button();
            this.F1Login_button = new System.Windows.Forms.Button();
            this.loginName_textBox = new System.Windows.Forms.TextBox();
            this.loginPw_textBox = new System.Windows.Forms.TextBox();
            this.textBox_input = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.SuspendLayout();
            // 
            // redEsc_button
            // 
            this.redEsc_button.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.redEsc_button.ForeColor = System.Drawing.Color.Red;
            this.redEsc_button.Location = new System.Drawing.Point(119, 115);
            this.redEsc_button.Name = "redEsc_button";
            this.redEsc_button.Size = new System.Drawing.Size(104, 33);
            this.redEsc_button.TabIndex = 4;
            this.redEsc_button.Text = "红键__退出";
            this.redEsc_button.Click += new System.EventHandler(this.redEsc_button_Click);
            // 
            // F1Login_button
            // 
            this.F1Login_button.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.F1Login_button.ForeColor = System.Drawing.Color.Black;
            this.F1Login_button.Location = new System.Drawing.Point(16, 115);
            this.F1Login_button.Name = "F1Login_button";
            this.F1Login_button.Size = new System.Drawing.Size(94, 33);
            this.F1Login_button.TabIndex = 5;
            this.F1Login_button.Text = "F1键_登入";
            this.F1Login_button.Click += new System.EventHandler(this.F1Login_button_Click);
            // 
            // loginName_textBox
            // 
            this.loginName_textBox.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular);
            this.loginName_textBox.Location = new System.Drawing.Point(96, 35);
            this.loginName_textBox.Multiline = true;
            this.loginName_textBox.Name = "loginName_textBox";
            this.loginName_textBox.Size = new System.Drawing.Size(96, 22);
            this.loginName_textBox.TabIndex = 55;
            this.loginName_textBox.Text = "金力电器";
            // 
            // loginPw_textBox
            // 
            this.loginPw_textBox.Location = new System.Drawing.Point(96, 83);
            this.loginPw_textBox.Multiline = true;
            this.loginPw_textBox.Name = "loginPw_textBox";
            this.loginPw_textBox.Size = new System.Drawing.Size(96, 21);
            this.loginPw_textBox.TabIndex = 56;
            // 
            // textBox_input
            // 
            this.textBox_input.BackColor = System.Drawing.Color.Black;
            this.textBox_input.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular);
            this.textBox_input.ForeColor = System.Drawing.Color.White;
            this.textBox_input.Location = new System.Drawing.Point(209, 3);
            this.textBox_input.Multiline = true;
            this.textBox_input.Name = "textBox_input";
            this.textBox_input.Size = new System.Drawing.Size(20, 20);
            this.textBox_input.TabIndex = 59;
            this.textBox_input.Text = "1";
            this.textBox_input.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(238, 295);
            // 
            // loginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(238, 295);
            this.Controls.Add(this.textBox_input);
            this.Controls.Add(this.loginName_textBox);
            this.Controls.Add(this.loginPw_textBox);
            this.Controls.Add(this.F1Login_button);
            this.Controls.Add(this.redEsc_button);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "loginForm";
            this.Text = "loginForm";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.loginForm_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button redEsc_button;
        private System.Windows.Forms.Button F1Login_button;
        private System.Windows.Forms.TextBox loginName_textBox;
        private System.Windows.Forms.TextBox loginPw_textBox;
        private System.Windows.Forms.TextBox textBox_input;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}