namespace padSoft_e
{
    partial class InDateListForm
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
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.panel1 = new System.Windows.Forms.Panel();
            this.listView1 = new System.Windows.Forms.ListView();
            this.btnGoToPage = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lab_allpage = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textboxPage = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.listView1);
            this.panel1.Location = new System.Drawing.Point(3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(232, 243);
            // 
            // listView1
            // 
            this.listView1.Dock = System.Windows.Forms.DockStyle.Top;
            this.listView1.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular);
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(232, 243);
            this.listView1.TabIndex = 89;
            // 
            // btnGoToPage
            // 
            this.btnGoToPage.Location = new System.Drawing.Point(132, 26);
            this.btnGoToPage.Name = "btnGoToPage";
            this.btnGoToPage.Size = new System.Drawing.Size(72, 20);
            this.btnGoToPage.TabIndex = 102;
            this.btnGoToPage.Text = "跳到该页";
            this.btnGoToPage.Click += new System.EventHandler(this.btnGoToPage_Click);
            // 
            // btnClose
            // 
            this.btnClose.ForeColor = System.Drawing.Color.Red;
            this.btnClose.Location = new System.Drawing.Point(33, 26);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(72, 20);
            this.btnClose.TabIndex = 101;
            this.btnClose.Text = "返回";
            this.btnClose.Click += new System.EventHandler(this.button3_Click);
            // 
            // lab_allpage
            // 
            this.lab_allpage.Location = new System.Drawing.Point(131, 3);
            this.lab_allpage.Name = "lab_allpage";
            this.lab_allpage.Size = new System.Drawing.Size(32, 20);
            this.lab_allpage.Text = "0";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(122, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(11, 20);
            this.label4.Text = "/";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(184, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(35, 17);
            this.button2.TabIndex = 96;
            this.button2.Text = ">>";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(24, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(35, 17);
            this.button1.TabIndex = 90;
            this.button1.Text = "<<";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(160, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 20);
            this.label2.Text = "页";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.OldLace;
            this.panel2.Controls.Add(this.btnGoToPage);
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Controls.Add(this.lab_allpage);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.textboxPage);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(0, 246);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(238, 49);
            // 
            // textboxPage
            // 
            this.textboxPage.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.textboxPage.Location = new System.Drawing.Point(84, 3);
            this.textboxPage.Name = "textboxPage";
            this.textboxPage.Size = new System.Drawing.Size(35, 19);
            this.textboxPage.TabIndex = 91;
            this.textboxPage.Text = "0";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(64, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 20);
            this.label1.Text = "第";
            // 
            // InDateListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(238, 295);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InDateListForm";
            this.Text = "InDateListForm";
            this.Load += new System.EventHandler(this.InDateListForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.InDateListForm_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        protected System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button btnGoToPage;
        private System.Windows.Forms.Button btnClose;
        protected System.Windows.Forms.Label lab_allpage;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        protected System.Windows.Forms.TextBox textboxPage;
        private System.Windows.Forms.Label label1;
    }
}