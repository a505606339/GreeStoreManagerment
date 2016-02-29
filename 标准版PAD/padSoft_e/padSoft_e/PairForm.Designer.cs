namespace padSoft_e
{
    partial class PairForm
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
            this.listView_pair = new System.Windows.Forms.ListView();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_PairSelect_ = new System.Windows.Forms.Button();
            this.btn_PairSave = new System.Windows.Forms.Button();
            this.text_type = new System.Windows.Forms.TextBox();
            this.text_outbarcode = new System.Windows.Forms.TextBox();
            this.text_inbarcode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.btnGotoPage = new System.Windows.Forms.Button();
            this.textboxPage = new System.Windows.Forms.TextBox();
            this.labAllPage = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lab444 = new System.Windows.Forms.Label();
            this.btnRight = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listView_pair
            // 
            this.listView_pair.Location = new System.Drawing.Point(5, 174);
            this.listView_pair.Name = "listView_pair";
            this.listView_pair.Size = new System.Drawing.Size(229, 117);
            this.listView_pair.TabIndex = 22;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular);
            this.button2.ForeColor = System.Drawing.Color.Red;
            this.button2.Location = new System.Drawing.Point(38, 115);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(82, 24);
            this.button2.TabIndex = 21;
            this.button2.Text = "返回_红键";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular);
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(128, 115);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 24);
            this.button1.TabIndex = 20;
            this.button1.Text = "取消_F4";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_PairSelect_
            // 
            this.btn_PairSelect_.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular);
            this.btn_PairSelect_.Location = new System.Drawing.Point(38, 86);
            this.btn_PairSelect_.Name = "btn_PairSelect_";
            this.btn_PairSelect_.Size = new System.Drawing.Size(82, 24);
            this.btn_PairSelect_.TabIndex = 19;
            this.btn_PairSelect_.Text = "搜索_F1";
            this.btn_PairSelect_.Click += new System.EventHandler(this.btn_PairSelect_Click);
            // 
            // btn_PairSave
            // 
            this.btn_PairSave.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular);
            this.btn_PairSave.Location = new System.Drawing.Point(128, 86);
            this.btn_PairSave.Name = "btn_PairSave";
            this.btn_PairSave.Size = new System.Drawing.Size(82, 24);
            this.btn_PairSave.TabIndex = 18;
            this.btn_PairSave.Text = "保存_F2";
            this.btn_PairSave.Click += new System.EventHandler(this.btn_PairSave_Click);
            // 
            // text_type
            // 
            this.text_type.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular);
            this.text_type.Location = new System.Drawing.Point(87, 59);
            this.text_type.Name = "text_type";
            this.text_type.Size = new System.Drawing.Size(132, 22);
            this.text_type.TabIndex = 17;
            // 
            // text_outbarcode
            // 
            this.text_outbarcode.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular);
            this.text_outbarcode.Location = new System.Drawing.Point(87, 32);
            this.text_outbarcode.MaxLength = 5;
            this.text_outbarcode.Name = "text_outbarcode";
            this.text_outbarcode.Size = new System.Drawing.Size(132, 23);
            this.text_outbarcode.TabIndex = 16;
            // 
            // text_inbarcode
            // 
            this.text_inbarcode.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular);
            this.text_inbarcode.Location = new System.Drawing.Point(87, 4);
            this.text_inbarcode.MaxLength = 5;
            this.text_inbarcode.Name = "text_inbarcode";
            this.text_inbarcode.Size = new System.Drawing.Size(132, 23);
            this.text_inbarcode.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular);
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(42, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 20);
            this.label3.Text = "型号:";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular);
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(12, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 20);
            this.label2.Text = "外机条码:";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular);
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(12, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 20);
            this.label1.Text = "内机条码:";
            // 
            // serialPort1
            // 
            this.serialPort1.PortName = "COM2";
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // btnGotoPage
            // 
            this.btnGotoPage.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular);
            this.btnGotoPage.Location = new System.Drawing.Point(194, 144);
            this.btnGotoPage.Name = "btnGotoPage";
            this.btnGotoPage.Size = new System.Drawing.Size(37, 24);
            this.btnGotoPage.TabIndex = 35;
            this.btnGotoPage.Text = "跳转";
            this.btnGotoPage.Click += new System.EventHandler(this.btnGotoPage_Click);
            // 
            // textboxPage
            // 
            this.textboxPage.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.textboxPage.Location = new System.Drawing.Point(41, 148);
            this.textboxPage.Name = "textboxPage";
            this.textboxPage.Size = new System.Drawing.Size(51, 19);
            this.textboxPage.TabIndex = 34;
            this.textboxPage.Text = "0";
            // 
            // labAllPage
            // 
            this.labAllPage.Location = new System.Drawing.Point(101, 147);
            this.labAllPage.Name = "labAllPage";
            this.labAllPage.Size = new System.Drawing.Size(35, 20);
            this.labAllPage.Text = "0";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(92, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(11, 20);
            this.label4.Text = "/";
            // 
            // lab444
            // 
            this.lab444.Location = new System.Drawing.Point(134, 148);
            this.lab444.Name = "lab444";
            this.lab444.Size = new System.Drawing.Size(21, 20);
            this.lab444.Text = "页";
            // 
            // btnRight
            // 
            this.btnRight.Location = new System.Drawing.Point(161, 144);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(27, 23);
            this.btnRight.TabIndex = 33;
            this.btnRight.Text = ">>";
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // btnLeft
            // 
            this.btnLeft.Location = new System.Drawing.Point(8, 145);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(27, 23);
            this.btnLeft.TabIndex = 32;
            this.btnLeft.Text = "<<";
            this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
            // 
            // PairForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(238, 295);
            this.Controls.Add(this.btnGotoPage);
            this.Controls.Add(this.textboxPage);
            this.Controls.Add(this.labAllPage);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lab444);
            this.Controls.Add(this.btnRight);
            this.Controls.Add(this.btnLeft);
            this.Controls.Add(this.listView_pair);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_PairSelect_);
            this.Controls.Add(this.btn_PairSave);
            this.Controls.Add(this.text_type);
            this.Controls.Add(this.text_outbarcode);
            this.Controls.Add(this.text_inbarcode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PairForm";
            this.Text = "配置表管理";
            this.Load += new System.EventHandler(this.PairForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PairForm_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView_pair;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_PairSelect_;
        private System.Windows.Forms.Button btn_PairSave;
        private System.Windows.Forms.TextBox text_type;
        private System.Windows.Forms.TextBox text_outbarcode;
        private System.Windows.Forms.TextBox text_inbarcode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button btnGotoPage;
        private System.Windows.Forms.TextBox textboxPage;
        private System.Windows.Forms.Label labAllPage;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lab444;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.Button btnLeft;
    }
}