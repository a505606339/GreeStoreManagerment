namespace padSoft_e
{
    partial class mainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.redEsc_button = new System.Windows.Forms.Button();
            this.upload_button = new System.Windows.Forms.Button();
            this.outMana_button = new System.Windows.Forms.Button();
            this.inputMana_button = new System.Windows.Forms.Button();
            this.returned_button = new System.Windows.Forms.Button();
            this.button_Paired = new System.Windows.Forms.Button();
            this.btn_pair = new System.Windows.Forms.Button();
            this.picboxInput = new System.Windows.Forms.PictureBox();
            this.picboxOutput = new System.Windows.Forms.PictureBox();
            this.picboxReturned = new System.Windows.Forms.PictureBox();
            this.picboxPaired = new System.Windows.Forms.PictureBox();
            this.picboxUpload = new System.Windows.Forms.PictureBox();
            this.picboxPairManage = new System.Windows.Forms.PictureBox();
            this.picboxClose = new System.Windows.Forms.PictureBox();
            this.SuspendLayout();
            // 
            // redEsc_button
            // 
            this.redEsc_button.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.redEsc_button.ForeColor = System.Drawing.Color.Red;
            this.redEsc_button.Location = new System.Drawing.Point(3, 288);
            this.redEsc_button.Name = "redEsc_button";
            this.redEsc_button.Size = new System.Drawing.Size(38, 12);
            this.redEsc_button.TabIndex = 5;
            this.redEsc_button.Text = "红键__退出";
            this.redEsc_button.Visible = false;
            // 
            // upload_button
            // 
            this.upload_button.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.upload_button.Location = new System.Drawing.Point(47, 252);
            this.upload_button.Name = "upload_button";
            this.upload_button.Size = new System.Drawing.Size(36, 12);
            this.upload_button.TabIndex = 8;
            this.upload_button.Text = "3键__上传数据";
            this.upload_button.Visible = false;
            // 
            // outMana_button
            // 
            this.outMana_button.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.outMana_button.Location = new System.Drawing.Point(3, 270);
            this.outMana_button.Name = "outMana_button";
            this.outMana_button.Size = new System.Drawing.Size(38, 12);
            this.outMana_button.TabIndex = 7;
            this.outMana_button.Text = "2键__出库管理";
            this.outMana_button.Visible = false;
            // 
            // inputMana_button
            // 
            this.inputMana_button.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.inputMana_button.Location = new System.Drawing.Point(47, 288);
            this.inputMana_button.Name = "inputMana_button";
            this.inputMana_button.Size = new System.Drawing.Size(27, 12);
            this.inputMana_button.TabIndex = 6;
            this.inputMana_button.Text = "1键__入库管理";
            this.inputMana_button.Visible = false;
            // 
            // returned_button
            // 
            this.returned_button.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.returned_button.Location = new System.Drawing.Point(4, 236);
            this.returned_button.Name = "returned_button";
            this.returned_button.Size = new System.Drawing.Size(38, 10);
            this.returned_button.TabIndex = 9;
            this.returned_button.Text = "4键__退货";
            this.returned_button.Visible = false;
            // 
            // button_Paired
            // 
            this.button_Paired.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.button_Paired.Location = new System.Drawing.Point(3, 252);
            this.button_Paired.Name = "button_Paired";
            this.button_Paired.Size = new System.Drawing.Size(39, 12);
            this.button_Paired.TabIndex = 10;
            this.button_Paired.Text = "5键__批量检查";
            this.button_Paired.Visible = false;
            // 
            // btn_pair
            // 
            this.btn_pair.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.btn_pair.Location = new System.Drawing.Point(47, 270);
            this.btn_pair.Name = "btn_pair";
            this.btn_pair.Size = new System.Drawing.Size(27, 12);
            this.btn_pair.TabIndex = 12;
            this.btn_pair.Text = "6键添加配置表";
            this.btn_pair.Visible = false;
            // 
            // picboxInput
            // 
            this.picboxInput.BackColor = System.Drawing.Color.White;
            this.picboxInput.Image = ((System.Drawing.Image)(resources.GetObject("picboxInput.Image")));
            this.picboxInput.Location = new System.Drawing.Point(34, 8);
            this.picboxInput.Name = "picboxInput";
            this.picboxInput.Size = new System.Drawing.Size(64, 64);
            this.picboxInput.DoubleClick += new System.EventHandler(this.inputMana_button_Click);
            this.picboxInput.Click += new System.EventHandler(this.picboxInput_Click);
            // 
            // picboxOutput
            // 
            this.picboxOutput.Image = ((System.Drawing.Image)(resources.GetObject("picboxOutput.Image")));
            this.picboxOutput.Location = new System.Drawing.Point(137, 8);
            this.picboxOutput.Name = "picboxOutput";
            this.picboxOutput.Size = new System.Drawing.Size(64, 64);
            this.picboxOutput.DoubleClick += new System.EventHandler(this.outMana_button_Click);
            this.picboxOutput.Click += new System.EventHandler(this.picboxOutput_Click);
            // 
            // picboxReturned
            // 
            this.picboxReturned.Image = ((System.Drawing.Image)(resources.GetObject("picboxReturned.Image")));
            this.picboxReturned.Location = new System.Drawing.Point(34, 82);
            this.picboxReturned.Name = "picboxReturned";
            this.picboxReturned.Size = new System.Drawing.Size(64, 64);
            this.picboxReturned.DoubleClick += new System.EventHandler(this.returnedbutton_Click);
            this.picboxReturned.Click += new System.EventHandler(this.picboxReturned_Click);
            // 
            // picboxPaired
            // 
            this.picboxPaired.Image = ((System.Drawing.Image)(resources.GetObject("picboxPaired.Image")));
            this.picboxPaired.Location = new System.Drawing.Point(137, 82);
            this.picboxPaired.Name = "picboxPaired";
            this.picboxPaired.Size = new System.Drawing.Size(64, 64);
            this.picboxPaired.DoubleClick += new System.EventHandler(this.button_Paired_Click);
            this.picboxPaired.Click += new System.EventHandler(this.picboxPaired_Click);
            // 
            // picboxUpload
            // 
            this.picboxUpload.Image = ((System.Drawing.Image)(resources.GetObject("picboxUpload.Image")));
            this.picboxUpload.Location = new System.Drawing.Point(137, 156);
            this.picboxUpload.Name = "picboxUpload";
            this.picboxUpload.Size = new System.Drawing.Size(64, 64);
            this.picboxUpload.DoubleClick += new System.EventHandler(this.upload_button_Click);
            this.picboxUpload.Click += new System.EventHandler(this.picboxUpload_Click);
            // 
            // picboxPairManage
            // 
            this.picboxPairManage.Image = ((System.Drawing.Image)(resources.GetObject("picboxPairManage.Image")));
            this.picboxPairManage.Location = new System.Drawing.Point(34, 156);
            this.picboxPairManage.Name = "picboxPairManage";
            this.picboxPairManage.Size = new System.Drawing.Size(64, 64);
            this.picboxPairManage.DoubleClick += new System.EventHandler(this.btn_pair_Click);
            this.picboxPairManage.Click += new System.EventHandler(this.picboxPairManage_Click);
            // 
            // picboxClose
            // 
            this.picboxClose.Image = ((System.Drawing.Image)(resources.GetObject("picboxClose.Image")));
            this.picboxClose.Location = new System.Drawing.Point(137, 230);
            this.picboxClose.Name = "picboxClose";
            this.picboxClose.Size = new System.Drawing.Size(64, 64);
            this.picboxClose.DoubleClick += new System.EventHandler(this.redEsc_button_Click);
            this.picboxClose.Click += new System.EventHandler(this.picboxClose_Click);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(238, 303);
            this.Controls.Add(this.picboxClose);
            this.Controls.Add(this.picboxPairManage);
            this.Controls.Add(this.picboxUpload);
            this.Controls.Add(this.picboxPaired);
            this.Controls.Add(this.picboxReturned);
            this.Controls.Add(this.picboxOutput);
            this.Controls.Add(this.picboxInput);
            this.Controls.Add(this.btn_pair);
            this.Controls.Add(this.button_Paired);
            this.Controls.Add(this.returned_button);
            this.Controls.Add(this.upload_button);
            this.Controls.Add(this.outMana_button);
            this.Controls.Add(this.inputMana_button);
            this.Controls.Add(this.redEsc_button);
            this.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "mainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mainForm_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button redEsc_button;
        private System.Windows.Forms.Button upload_button;
        private System.Windows.Forms.Button outMana_button;
        private System.Windows.Forms.Button inputMana_button;
        private System.Windows.Forms.Button returned_button;
        private System.Windows.Forms.Button button_Paired;
        private System.Windows.Forms.Button btn_pair;
        private System.Windows.Forms.PictureBox picboxInput;
        private System.Windows.Forms.PictureBox picboxOutput;
        private System.Windows.Forms.PictureBox picboxReturned;
        private System.Windows.Forms.PictureBox picboxPaired;
        private System.Windows.Forms.PictureBox picboxUpload;
        private System.Windows.Forms.PictureBox picboxPairManage;
        private System.Windows.Forms.PictureBox picboxClose;
    }
}

