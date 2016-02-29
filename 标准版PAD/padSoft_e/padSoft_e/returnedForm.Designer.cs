namespace padSoft_e
{
    partial class returnedForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.label1 = new System.Windows.Forms.Label();
            this.inBar_textBox = new System.Windows.Forms.TextBox();
            this.outBar_textBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Remark_textBox = new System.Windows.Forms.TextBox();
            this.F1Enter_button = new System.Windows.Forms.Button();
            this.F2Cannel_button = new System.Windows.Forms.Button();
            this.yellowScan_button = new System.Windows.Forms.Button();
            this.redEsc_button = new System.Windows.Forms.Button();
            this.returned_listView = new System.Windows.Forms.ListView();
            this.opt_comboBox = new System.Windows.Forms.ComboBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.clientName_textbox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular);
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(7, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 20);
            this.label1.Text = "内机条码";
            // 
            // inBar_textBox
            // 
            this.inBar_textBox.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular);
            this.inBar_textBox.Location = new System.Drawing.Point(78, 3);
            this.inBar_textBox.Name = "inBar_textBox";
            this.inBar_textBox.Size = new System.Drawing.Size(152, 23);
            this.inBar_textBox.TabIndex = 1;
            // 
            // outBar_textBox
            // 
            this.outBar_textBox.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular);
            this.outBar_textBox.Location = new System.Drawing.Point(78, 31);
            this.outBar_textBox.Name = "outBar_textBox";
            this.outBar_textBox.Size = new System.Drawing.Size(152, 23);
            this.outBar_textBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular);
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(7, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 20);
            this.label2.Text = "外机条码";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular);
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(22, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 20);
            this.label3.Text = "操作员";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular);
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(7, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 20);
            this.label4.Text = "退货备注";
            // 
            // Remark_textBox
            // 
            this.Remark_textBox.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular);
            this.Remark_textBox.Location = new System.Drawing.Point(78, 59);
            this.Remark_textBox.Name = "Remark_textBox";
            this.Remark_textBox.Size = new System.Drawing.Size(152, 23);
            this.Remark_textBox.TabIndex = 9;
            // 
            // F1Enter_button
            // 
            this.F1Enter_button.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular);
            this.F1Enter_button.ForeColor = System.Drawing.Color.Blue;
            this.F1Enter_button.Location = new System.Drawing.Point(22, 146);
            this.F1Enter_button.Name = "F1Enter_button";
            this.F1Enter_button.Size = new System.Drawing.Size(89, 26);
            this.F1Enter_button.TabIndex = 11;
            this.F1Enter_button.Text = "确认(F1键)";
            this.F1Enter_button.Click += new System.EventHandler(this.F1Enter_button_Click);
            // 
            // F2Cannel_button
            // 
            this.F2Cannel_button.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular);
            this.F2Cannel_button.Location = new System.Drawing.Point(135, 146);
            this.F2Cannel_button.Name = "F2Cannel_button";
            this.F2Cannel_button.Size = new System.Drawing.Size(89, 26);
            this.F2Cannel_button.TabIndex = 12;
            this.F2Cannel_button.Text = "取消(F2键)";
            this.F2Cannel_button.Click += new System.EventHandler(this.F2Cannel_button_Click);
            // 
            // yellowScan_button
            // 
            this.yellowScan_button.BackColor = System.Drawing.Color.Yellow;
            this.yellowScan_button.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular);
            this.yellowScan_button.Location = new System.Drawing.Point(22, 178);
            this.yellowScan_button.Name = "yellowScan_button";
            this.yellowScan_button.Size = new System.Drawing.Size(89, 26);
            this.yellowScan_button.TabIndex = 13;
            this.yellowScan_button.Text = "扫描(黄键)";
            this.yellowScan_button.Click += new System.EventHandler(this.yellowScanButton_Click);
            // 
            // redEsc_button
            // 
            this.redEsc_button.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular);
            this.redEsc_button.ForeColor = System.Drawing.Color.Red;
            this.redEsc_button.Location = new System.Drawing.Point(135, 178);
            this.redEsc_button.Name = "redEsc_button";
            this.redEsc_button.Size = new System.Drawing.Size(89, 26);
            this.redEsc_button.TabIndex = 14;
            this.redEsc_button.Text = "返回(红键)";
            this.redEsc_button.Click += new System.EventHandler(this.redEsc_button_Click);
            // 
            // returned_listView
            // 
            this.returned_listView.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular);
            this.returned_listView.Location = new System.Drawing.Point(3, 210);
            this.returned_listView.Name = "returned_listView";
            this.returned_listView.Size = new System.Drawing.Size(232, 82);
            this.returned_listView.TabIndex = 19;
            // 
            // opt_comboBox
            // 
            this.opt_comboBox.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular);
            this.opt_comboBox.Location = new System.Drawing.Point(78, 115);
            this.opt_comboBox.Name = "opt_comboBox";
            this.opt_comboBox.Size = new System.Drawing.Size(152, 23);
            this.opt_comboBox.TabIndex = 20;
            // 
            // serialPort1
            // 
            this.serialPort1.PortName = "COM2";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular);
            this.label5.ForeColor = System.Drawing.Color.Blue;
            this.label5.Location = new System.Drawing.Point(7, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 20);
            this.label5.Text = "客户名称";
            // 
            // clientName_textbox
            // 
            this.clientName_textbox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.clientName_textbox.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular);
            this.clientName_textbox.Location = new System.Drawing.Point(78, 87);
            this.clientName_textbox.Name = "clientName_textbox";
            this.clientName_textbox.Size = new System.Drawing.Size(152, 23);
            this.clientName_textbox.TabIndex = 40;
            // 
            // returnedForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(238, 295);
            this.Controls.Add(this.clientName_textbox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.opt_comboBox);
            this.Controls.Add(this.returned_listView);
            this.Controls.Add(this.redEsc_button);
            this.Controls.Add(this.yellowScan_button);
            this.Controls.Add(this.F2Cannel_button);
            this.Controls.Add(this.F1Enter_button);
            this.Controls.Add(this.Remark_textBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.outBar_textBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.inBar_textBox);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "returnedForm";
            this.Text = "returnedForm";
            this.Load += new System.EventHandler(this.returnedForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.returnedForm_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox inBar_textBox;
        private System.Windows.Forms.TextBox outBar_textBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Remark_textBox;
        private System.Windows.Forms.Button F1Enter_button;
        private System.Windows.Forms.Button F2Cannel_button;
        private System.Windows.Forms.Button yellowScan_button;
        private System.Windows.Forms.Button redEsc_button;
        private System.Windows.Forms.ListView returned_listView;
        private System.Windows.Forms.ComboBox opt_comboBox;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox clientName_textbox;
    }
}