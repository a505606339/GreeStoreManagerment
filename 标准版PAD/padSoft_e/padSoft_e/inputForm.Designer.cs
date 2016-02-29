namespace padSoft_e
{
    partial class inputForm
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
            this.components = new System.ComponentModel.Container();
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.redEsc_button = new System.Windows.Forms.Button();
            this.F2Cannel_button = new System.Windows.Forms.Button();
            this.yellowScan_button = new System.Windows.Forms.Button();
            this.F1Enter_button = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.inBar_textBox = new System.Windows.Forms.TextBox();
            this.outBar_textBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.inNum_textBox = new System.Windows.Forms.TextBox();
            this.inName_textBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.inStockName_comboBox = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.inQty_textBox = new System.Windows.Forms.TextBox();
            this.inMoney_textBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.inSumQty_textBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.inSumMoney_textBox = new System.Windows.Forms.TextBox();
            this.inBar_B_textBox = new System.Windows.Forms.TextBox();
            this.outBar_B_textBox = new System.Windows.Forms.TextBox();
            this.inNum_B_textBox = new System.Windows.Forms.TextBox();
            this.inName_B_textBox = new System.Windows.Forms.TextBox();
            this.inTpye_B_textBox = new System.Windows.Forms.TextBox();
            this.inOpt_B_textBox = new System.Windows.Forms.TextBox();
            this.inQty_B_textBox = new System.Windows.Forms.TextBox();
            this.inMoney_B_textBox = new System.Windows.Forms.TextBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.textBox_test = new System.Windows.Forms.TextBox();
            this.inTpye_textBox = new System.Windows.Forms.ComboBox();
            this.btnScanBarcodeView = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // redEsc_button
            // 
            this.redEsc_button.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular);
            this.redEsc_button.ForeColor = System.Drawing.Color.Red;
            this.redEsc_button.Location = new System.Drawing.Point(135, 240);
            this.redEsc_button.Name = "redEsc_button";
            this.redEsc_button.Size = new System.Drawing.Size(89, 22);
            this.redEsc_button.TabIndex = 57;
            this.redEsc_button.Text = "返回(红键)";
            this.redEsc_button.Click += new System.EventHandler(this.redEsc_button_Click);
            // 
            // F2Cannel_button
            // 
            this.F2Cannel_button.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular);
            this.F2Cannel_button.ForeColor = System.Drawing.Color.Black;
            this.F2Cannel_button.Location = new System.Drawing.Point(135, 212);
            this.F2Cannel_button.Name = "F2Cannel_button";
            this.F2Cannel_button.Size = new System.Drawing.Size(89, 22);
            this.F2Cannel_button.TabIndex = 56;
            this.F2Cannel_button.Text = "取消(F2键)";
            this.F2Cannel_button.Click += new System.EventHandler(this.F2Cannel_button_Click);
            // 
            // yellowScan_button
            // 
            this.yellowScan_button.BackColor = System.Drawing.Color.Yellow;
            this.yellowScan_button.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular);
            this.yellowScan_button.ForeColor = System.Drawing.Color.Black;
            this.yellowScan_button.Location = new System.Drawing.Point(18, 240);
            this.yellowScan_button.Name = "yellowScan_button";
            this.yellowScan_button.Size = new System.Drawing.Size(89, 22);
            this.yellowScan_button.TabIndex = 55;
            this.yellowScan_button.Text = "扫描(黄键)";
            this.yellowScan_button.Click += new System.EventHandler(this.yellowScan_button_Click);
            // 
            // F1Enter_button
            // 
            this.F1Enter_button.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular);
            this.F1Enter_button.ForeColor = System.Drawing.Color.Blue;
            this.F1Enter_button.Location = new System.Drawing.Point(18, 212);
            this.F1Enter_button.Name = "F1Enter_button";
            this.F1Enter_button.Size = new System.Drawing.Size(89, 22);
            this.F1Enter_button.TabIndex = 54;
            this.F1Enter_button.Text = "确认(F1键)";
            this.F1Enter_button.Click += new System.EventHandler(this.F1Enter_button_Click);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular);
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(3, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 22);
            this.label3.Text = "内机条码";
            // 
            // inBar_textBox
            // 
            this.inBar_textBox.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular);
            this.inBar_textBox.Location = new System.Drawing.Point(91, 3);
            this.inBar_textBox.Name = "inBar_textBox";
            this.inBar_textBox.Size = new System.Drawing.Size(143, 22);
            this.inBar_textBox.TabIndex = 60;
            // 
            // outBar_textBox
            // 
            this.outBar_textBox.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular);
            this.outBar_textBox.Location = new System.Drawing.Point(91, 29);
            this.outBar_textBox.Name = "outBar_textBox";
            this.outBar_textBox.Size = new System.Drawing.Size(143, 22);
            this.outBar_textBox.TabIndex = 61;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular);
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(3, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 22);
            this.label1.Text = "外机条码";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular);
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(3, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 22);
            this.label2.Text = "单据单号";
            // 
            // inNum_textBox
            // 
            this.inNum_textBox.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular);
            this.inNum_textBox.Location = new System.Drawing.Point(91, 55);
            this.inNum_textBox.Name = "inNum_textBox";
            this.inNum_textBox.Size = new System.Drawing.Size(144, 22);
            this.inNum_textBox.TabIndex = 66;
            this.inNum_textBox.TextChanged += new System.EventHandler(this.inNum_textBox_TextChanged);
            // 
            // inName_textBox
            // 
            this.inName_textBox.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular);
            this.inName_textBox.Location = new System.Drawing.Point(91, 81);
            this.inName_textBox.Name = "inName_textBox";
            this.inName_textBox.Size = new System.Drawing.Size(144, 23);
            this.inName_textBox.TabIndex = 67;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular);
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(3, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 22);
            this.label4.Text = "单据名称";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular);
            this.label5.ForeColor = System.Drawing.Color.Blue;
            this.label5.Location = new System.Drawing.Point(3, 109);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 22);
            this.label5.Text = "空调类型";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular);
            this.label6.ForeColor = System.Drawing.Color.Blue;
            this.label6.Location = new System.Drawing.Point(20, 136);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 22);
            this.label6.Text = "仓库名";
            // 
            // inStockName_comboBox
            // 
            this.inStockName_comboBox.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular);
            this.inStockName_comboBox.Location = new System.Drawing.Point(91, 133);
            this.inStockName_comboBox.Name = "inStockName_comboBox";
            this.inStockName_comboBox.Size = new System.Drawing.Size(144, 24);
            this.inStockName_comboBox.TabIndex = 75;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular);
            this.label7.ForeColor = System.Drawing.Color.Blue;
            this.label7.Location = new System.Drawing.Point(12, 162);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 22);
            this.label7.Text = "数量";
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular);
            this.label8.ForeColor = System.Drawing.Color.Blue;
            this.label8.Location = new System.Drawing.Point(126, 162);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 22);
            this.label8.Text = "金额";
            // 
            // inQty_textBox
            // 
            this.inQty_textBox.Enabled = false;
            this.inQty_textBox.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular);
            this.inQty_textBox.Location = new System.Drawing.Point(47, 160);
            this.inQty_textBox.Name = "inQty_textBox";
            this.inQty_textBox.Size = new System.Drawing.Size(67, 22);
            this.inQty_textBox.TabIndex = 80;
            this.inQty_textBox.Text = "1";
            // 
            // inMoney_textBox
            // 
            this.inMoney_textBox.Enabled = false;
            this.inMoney_textBox.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular);
            this.inMoney_textBox.Location = new System.Drawing.Point(161, 160);
            this.inMoney_textBox.Name = "inMoney_textBox";
            this.inMoney_textBox.Size = new System.Drawing.Size(73, 22);
            this.inMoney_textBox.TabIndex = 81;
            this.inMoney_textBox.Text = "0";
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular);
            this.label9.ForeColor = System.Drawing.Color.Blue;
            this.label9.Location = new System.Drawing.Point(-1, 185);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 22);
            this.label9.Text = "总数量";
            // 
            // inSumQty_textBox
            // 
            this.inSumQty_textBox.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular);
            this.inSumQty_textBox.Location = new System.Drawing.Point(47, 184);
            this.inSumQty_textBox.Name = "inSumQty_textBox";
            this.inSumQty_textBox.ReadOnly = true;
            this.inSumQty_textBox.Size = new System.Drawing.Size(67, 22);
            this.inSumQty_textBox.TabIndex = 84;
            this.inSumQty_textBox.Text = "0";
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular);
            this.label10.ForeColor = System.Drawing.Color.Blue;
            this.label10.Location = new System.Drawing.Point(112, 186);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(91, 22);
            this.label10.Text = "总金额";
            // 
            // inSumMoney_textBox
            // 
            this.inSumMoney_textBox.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular);
            this.inSumMoney_textBox.Location = new System.Drawing.Point(161, 184);
            this.inSumMoney_textBox.Name = "inSumMoney_textBox";
            this.inSumMoney_textBox.ReadOnly = true;
            this.inSumMoney_textBox.Size = new System.Drawing.Size(73, 22);
            this.inSumMoney_textBox.TabIndex = 87;
            this.inSumMoney_textBox.Text = "0";
            // 
            // inBar_B_textBox
            // 
            this.inBar_B_textBox.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular);
            this.inBar_B_textBox.Location = new System.Drawing.Point(27, 3);
            this.inBar_B_textBox.Name = "inBar_B_textBox";
            this.inBar_B_textBox.Size = new System.Drawing.Size(58, 22);
            this.inBar_B_textBox.TabIndex = 99;
            this.inBar_B_textBox.Visible = false;
            // 
            // outBar_B_textBox
            // 
            this.outBar_B_textBox.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular);
            this.outBar_B_textBox.Location = new System.Drawing.Point(27, 29);
            this.outBar_B_textBox.Name = "outBar_B_textBox";
            this.outBar_B_textBox.Size = new System.Drawing.Size(58, 22);
            this.outBar_B_textBox.TabIndex = 100;
            this.outBar_B_textBox.Visible = false;
            // 
            // inNum_B_textBox
            // 
            this.inNum_B_textBox.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular);
            this.inNum_B_textBox.Location = new System.Drawing.Point(27, 55);
            this.inNum_B_textBox.Name = "inNum_B_textBox";
            this.inNum_B_textBox.Size = new System.Drawing.Size(58, 22);
            this.inNum_B_textBox.TabIndex = 101;
            this.inNum_B_textBox.Visible = false;
            // 
            // inName_B_textBox
            // 
            this.inName_B_textBox.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular);
            this.inName_B_textBox.Location = new System.Drawing.Point(27, 82);
            this.inName_B_textBox.Name = "inName_B_textBox";
            this.inName_B_textBox.Size = new System.Drawing.Size(58, 22);
            this.inName_B_textBox.TabIndex = 102;
            this.inName_B_textBox.Visible = false;
            // 
            // inTpye_B_textBox
            // 
            this.inTpye_B_textBox.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular);
            this.inTpye_B_textBox.Location = new System.Drawing.Point(27, 109);
            this.inTpye_B_textBox.Name = "inTpye_B_textBox";
            this.inTpye_B_textBox.Size = new System.Drawing.Size(58, 22);
            this.inTpye_B_textBox.TabIndex = 103;
            this.inTpye_B_textBox.Visible = false;
            // 
            // inOpt_B_textBox
            // 
            this.inOpt_B_textBox.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular);
            this.inOpt_B_textBox.Location = new System.Drawing.Point(27, 135);
            this.inOpt_B_textBox.Name = "inOpt_B_textBox";
            this.inOpt_B_textBox.Size = new System.Drawing.Size(58, 22);
            this.inOpt_B_textBox.TabIndex = 104;
            this.inOpt_B_textBox.Visible = false;
            // 
            // inQty_B_textBox
            // 
            this.inQty_B_textBox.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular);
            this.inQty_B_textBox.Location = new System.Drawing.Point(34, 198);
            this.inQty_B_textBox.Name = "inQty_B_textBox";
            this.inQty_B_textBox.Size = new System.Drawing.Size(58, 22);
            this.inQty_B_textBox.TabIndex = 105;
            this.inQty_B_textBox.Text = "0";
            this.inQty_B_textBox.Visible = false;
            // 
            // inMoney_B_textBox
            // 
            this.inMoney_B_textBox.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular);
            this.inMoney_B_textBox.Location = new System.Drawing.Point(174, 198);
            this.inMoney_B_textBox.Name = "inMoney_B_textBox";
            this.inMoney_B_textBox.Size = new System.Drawing.Size(58, 22);
            this.inMoney_B_textBox.TabIndex = 106;
            this.inMoney_B_textBox.Text = "0";
            this.inMoney_B_textBox.Visible = false;
            // 
            // serialPort1
            // 
            this.serialPort1.PortName = "COM2";
            // 
            // textBox_test
            // 
            this.textBox_test.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular);
            this.textBox_test.Location = new System.Drawing.Point(3, 270);
            this.textBox_test.Name = "textBox_test";
            this.textBox_test.Size = new System.Drawing.Size(10, 22);
            this.textBox_test.TabIndex = 117;
            this.textBox_test.Visible = false;
            // 
            // inTpye_textBox
            // 
            this.inTpye_textBox.Location = new System.Drawing.Point(91, 107);
            this.inTpye_textBox.Name = "inTpye_textBox";
            this.inTpye_textBox.Size = new System.Drawing.Size(143, 23);
            this.inTpye_textBox.TabIndex = 150;
            // 
            // btnScanBarcodeView
            // 
            this.btnScanBarcodeView.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular);
            this.btnScanBarcodeView.Location = new System.Drawing.Point(20, 267);
            this.btnScanBarcodeView.Name = "btnScanBarcodeView";
            this.btnScanBarcodeView.Size = new System.Drawing.Size(206, 22);
            this.btnScanBarcodeView.TabIndex = 161;
            this.btnScanBarcodeView.Text = "查看已扫条码(F5)";
            this.btnScanBarcodeView.Click += new System.EventHandler(this.btnScanBarcodeView_Click_1);
            // 
            // inputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(238, 295);
            this.Controls.Add(this.btnScanBarcodeView);
            this.Controls.Add(this.inTpye_textBox);
            this.Controls.Add(this.textBox_test);
            this.Controls.Add(this.inMoney_B_textBox);
            this.Controls.Add(this.inQty_B_textBox);
            this.Controls.Add(this.inOpt_B_textBox);
            this.Controls.Add(this.inTpye_B_textBox);
            this.Controls.Add(this.inName_B_textBox);
            this.Controls.Add(this.inNum_B_textBox);
            this.Controls.Add(this.outBar_B_textBox);
            this.Controls.Add(this.inBar_B_textBox);
            this.Controls.Add(this.inQty_textBox);
            this.Controls.Add(this.inSumQty_textBox);
            this.Controls.Add(this.inSumMoney_textBox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.inMoney_textBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.inStockName_comboBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.inName_textBox);
            this.Controls.Add(this.inNum_textBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.outBar_textBox);
            this.Controls.Add(this.inBar_textBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.redEsc_button);
            this.Controls.Add(this.F2Cannel_button);
            this.Controls.Add(this.yellowScan_button);
            this.Controls.Add(this.F1Enter_button);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label9);
            this.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "inputForm";
            this.Text = " ";
            this.Load += new System.EventHandler(this.inputForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.inputForm_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button redEsc_button;
        private System.Windows.Forms.Button F2Cannel_button;
        private System.Windows.Forms.Button yellowScan_button;
        private System.Windows.Forms.Button F1Enter_button;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox inBar_textBox;
        private System.Windows.Forms.TextBox outBar_textBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox inNum_textBox;
        private System.Windows.Forms.TextBox inName_textBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox inStockName_comboBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox inQty_textBox;
        private System.Windows.Forms.TextBox inMoney_textBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox inSumQty_textBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox inSumMoney_textBox;
        private System.Windows.Forms.TextBox inBar_B_textBox;
        private System.Windows.Forms.TextBox outBar_B_textBox;
        private System.Windows.Forms.TextBox inNum_B_textBox;
        private System.Windows.Forms.TextBox inName_B_textBox;
        private System.Windows.Forms.TextBox inTpye_B_textBox;
        private System.Windows.Forms.TextBox inOpt_B_textBox;
        private System.Windows.Forms.TextBox inQty_B_textBox;
        private System.Windows.Forms.TextBox inMoney_B_textBox;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.TextBox textBox_test;
        private System.Windows.Forms.ComboBox inTpye_textBox;
        private System.Windows.Forms.Button btnScanBarcodeView;
    }
}