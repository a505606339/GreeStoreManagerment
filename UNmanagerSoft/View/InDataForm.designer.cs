namespace UNmanagerSoft.View
{
    partial class InDataForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.inDatePanel = new System.Windows.Forms.Panel();
            this.inDataGridView = new System.Windows.Forms.DataGridView();
            this.airtype = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inbarcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.outbarcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.danju = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mingcheng = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.opt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pannel_inUpdate = new System.Windows.Forms.Panel();
            this.dateTimePickerInDate = new System.Windows.Forms.DateTimePicker();
            this.txt_outBarcode = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.combox_InUpdateOpt = new System.Windows.Forms.ComboBox();
            this.btn_inUpdateSave = new System.Windows.Forms.Button();
            this.btn_inUpdateCancel = new System.Windows.Forms.Button();
            this.txt_remark = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_money = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_number = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_receiptsName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_receiptsNumber = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_type = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_inBarcode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.picbox_inUpdate = new System.Windows.Forms.PictureBox();
            this.panelSum = new System.Windows.Forms.Panel();
            this.textboxAllPrice = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textboxAllCount = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.inDatePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inDataGridView)).BeginInit();
            this.panel1.SuspendLayout();
            this.pannel_inUpdate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbox_inUpdate)).BeginInit();
            this.panelSum.SuspendLayout();
            this.SuspendLayout();
            // 
            // inDatePanel
            // 
            this.inDatePanel.Controls.Add(this.inDataGridView);
            this.inDatePanel.Controls.Add(this.panel1);
            this.inDatePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inDatePanel.Location = new System.Drawing.Point(0, 0);
            this.inDatePanel.Name = "inDatePanel";
            this.inDatePanel.Size = new System.Drawing.Size(761, 467);
            this.inDatePanel.TabIndex = 14;
            // 
            // inDataGridView
            // 
            this.inDataGridView.AllowUserToAddRows = false;
            this.inDataGridView.AllowUserToDeleteRows = false;
            this.inDataGridView.AllowUserToResizeRows = false;
            this.inDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.inDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 12F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.inDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.inDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.inDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.airtype,
            this.number,
            this.price,
            this.inbarcode,
            this.outbarcode,
            this.danju,
            this.mingcheng,
            this.opt,
            this.remark});
            this.inDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inDataGridView.Location = new System.Drawing.Point(0, 0);
            this.inDataGridView.Name = "inDataGridView";
            this.inDataGridView.RowHeadersVisible = false;
            this.inDataGridView.RowTemplate.Height = 23;
            this.inDataGridView.Size = new System.Drawing.Size(761, 370);
            this.inDataGridView.TabIndex = 13;
            this.inDataGridView.SelectionChanged += new System.EventHandler(this.inDataGridView_SelectionChanged);
            // 
            // airtype
            // 
            this.airtype.DataPropertyName = "空调型号";
            this.airtype.HeaderText = "空调型号";
            this.airtype.Name = "airtype";
            this.airtype.Width = 200;
            // 
            // number
            // 
            this.number.DataPropertyName = "数量";
            this.number.HeaderText = "数量";
            this.number.Name = "number";
            // 
            // price
            // 
            this.price.DataPropertyName = "金额";
            this.price.HeaderText = "金额";
            this.price.Name = "price";
            // 
            // inbarcode
            // 
            this.inbarcode.DataPropertyName = "内机条码";
            this.inbarcode.HeaderText = "内机条码";
            this.inbarcode.Name = "inbarcode";
            // 
            // outbarcode
            // 
            this.outbarcode.DataPropertyName = "外机条码";
            this.outbarcode.HeaderText = "外机条码";
            this.outbarcode.Name = "outbarcode";
            // 
            // danju
            // 
            this.danju.DataPropertyName = "单据单号";
            this.danju.HeaderText = "单据单号";
            this.danju.Name = "danju";
            // 
            // mingcheng
            // 
            this.mingcheng.DataPropertyName = "单据名称";
            this.mingcheng.HeaderText = "单据名称";
            this.mingcheng.Name = "mingcheng";
            // 
            // opt
            // 
            this.opt.DataPropertyName = "操作员";
            this.opt.HeaderText = "操作员";
            this.opt.Name = "opt";
            // 
            // remark
            // 
            this.remark.DataPropertyName = "备注";
            this.remark.HeaderText = "备注";
            this.remark.Name = "remark";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pannel_inUpdate);
            this.panel1.Controls.Add(this.picbox_inUpdate);
            this.panel1.Controls.Add(this.panelSum);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 370);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(761, 97);
            this.panel1.TabIndex = 12;
            // 
            // pannel_inUpdate
            // 
            this.pannel_inUpdate.Controls.Add(this.dateTimePickerInDate);
            this.pannel_inUpdate.Controls.Add(this.txt_outBarcode);
            this.pannel_inUpdate.Controls.Add(this.label11);
            this.pannel_inUpdate.Controls.Add(this.combox_InUpdateOpt);
            this.pannel_inUpdate.Controls.Add(this.btn_inUpdateSave);
            this.pannel_inUpdate.Controls.Add(this.btn_inUpdateCancel);
            this.pannel_inUpdate.Controls.Add(this.txt_remark);
            this.pannel_inUpdate.Controls.Add(this.label10);
            this.pannel_inUpdate.Controls.Add(this.label9);
            this.pannel_inUpdate.Controls.Add(this.label8);
            this.pannel_inUpdate.Controls.Add(this.txt_money);
            this.pannel_inUpdate.Controls.Add(this.label7);
            this.pannel_inUpdate.Controls.Add(this.txt_number);
            this.pannel_inUpdate.Controls.Add(this.label6);
            this.pannel_inUpdate.Controls.Add(this.txt_receiptsName);
            this.pannel_inUpdate.Controls.Add(this.label5);
            this.pannel_inUpdate.Controls.Add(this.txt_receiptsNumber);
            this.pannel_inUpdate.Controls.Add(this.label4);
            this.pannel_inUpdate.Controls.Add(this.txt_type);
            this.pannel_inUpdate.Controls.Add(this.label2);
            this.pannel_inUpdate.Controls.Add(this.txt_inBarcode);
            this.pannel_inUpdate.Controls.Add(this.label1);
            this.pannel_inUpdate.Location = new System.Drawing.Point(3, 3);
            this.pannel_inUpdate.Name = "pannel_inUpdate";
            this.pannel_inUpdate.Size = new System.Drawing.Size(755, 91);
            this.pannel_inUpdate.TabIndex = 12;
            this.pannel_inUpdate.Visible = false;
            // 
            // dateTimePickerInDate
            // 
            this.dateTimePickerInDate.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dateTimePickerInDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerInDate.Location = new System.Drawing.Point(398, 58);
            this.dateTimePickerInDate.Name = "dateTimePickerInDate";
            this.dateTimePickerInDate.Size = new System.Drawing.Size(255, 21);
            this.dateTimePickerInDate.TabIndex = 25;
            // 
            // txt_outBarcode
            // 
            this.txt_outBarcode.Enabled = false;
            this.txt_outBarcode.Location = new System.Drawing.Point(232, 3);
            this.txt_outBarcode.Name = "txt_outBarcode";
            this.txt_outBarcode.Size = new System.Drawing.Size(100, 21);
            this.txt_outBarcode.TabIndex = 24;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(173, 8);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 12);
            this.label11.TabIndex = 23;
            this.label11.Text = "外机条码：";
            // 
            // combox_InUpdateOpt
            // 
            this.combox_InUpdateOpt.FormattingEnabled = true;
            this.combox_InUpdateOpt.Location = new System.Drawing.Point(70, 32);
            this.combox_InUpdateOpt.Name = "combox_InUpdateOpt";
            this.combox_InUpdateOpt.Size = new System.Drawing.Size(100, 20);
            this.combox_InUpdateOpt.TabIndex = 22;
            // 
            // btn_inUpdateSave
            // 
            this.btn_inUpdateSave.Location = new System.Drawing.Point(663, 27);
            this.btn_inUpdateSave.Name = "btn_inUpdateSave";
            this.btn_inUpdateSave.Size = new System.Drawing.Size(86, 29);
            this.btn_inUpdateSave.TabIndex = 21;
            this.btn_inUpdateSave.Text = "保存";
            this.btn_inUpdateSave.UseVisualStyleBackColor = true;
            this.btn_inUpdateSave.Click += new System.EventHandler(this.btn_inUpdateSave_Click);
            // 
            // btn_inUpdateCancel
            // 
            this.btn_inUpdateCancel.Location = new System.Drawing.Point(663, 62);
            this.btn_inUpdateCancel.Name = "btn_inUpdateCancel";
            this.btn_inUpdateCancel.Size = new System.Drawing.Size(86, 28);
            this.btn_inUpdateCancel.TabIndex = 20;
            this.btn_inUpdateCancel.Text = "取消";
            this.btn_inUpdateCancel.UseVisualStyleBackColor = true;
            this.btn_inUpdateCancel.Click += new System.EventHandler(this.btn_inUpdateCancel_Click);
            // 
            // txt_remark
            // 
            this.txt_remark.Location = new System.Drawing.Point(71, 61);
            this.txt_remark.Name = "txt_remark";
            this.txt_remark.Size = new System.Drawing.Size(260, 21);
            this.txt_remark.TabIndex = 19;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(32, 66);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 12);
            this.label10.TabIndex = 18;
            this.label10.Text = "备注：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(337, 62);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 16;
            this.label9.Text = "入库时间：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(21, 35);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 14;
            this.label8.Text = "操作员：";
            // 
            // txt_money
            // 
            this.txt_money.Location = new System.Drawing.Point(232, 30);
            this.txt_money.Name = "txt_money";
            this.txt_money.Size = new System.Drawing.Size(100, 21);
            this.txt_money.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(197, 35);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 12;
            this.label7.Text = "金额：";
            // 
            // txt_number
            // 
            this.txt_number.Location = new System.Drawing.Point(379, 31);
            this.txt_number.Name = "txt_number";
            this.txt_number.Size = new System.Drawing.Size(100, 21);
            this.txt_number.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(338, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "数量：";
            // 
            // txt_receiptsName
            // 
            this.txt_receiptsName.Location = new System.Drawing.Point(553, 31);
            this.txt_receiptsName.Name = "txt_receiptsName";
            this.txt_receiptsName.Size = new System.Drawing.Size(100, 21);
            this.txt_receiptsName.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(493, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "单据名称：";
            // 
            // txt_receiptsNumber
            // 
            this.txt_receiptsNumber.Location = new System.Drawing.Point(553, 3);
            this.txt_receiptsNumber.Name = "txt_receiptsNumber";
            this.txt_receiptsNumber.Size = new System.Drawing.Size(100, 21);
            this.txt_receiptsNumber.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(493, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "单据单号：";
            // 
            // txt_type
            // 
            this.txt_type.Location = new System.Drawing.Point(378, 3);
            this.txt_type.Name = "txt_type";
            this.txt_type.Size = new System.Drawing.Size(100, 21);
            this.txt_type.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(340, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "型号：";
            // 
            // txt_inBarcode
            // 
            this.txt_inBarcode.Enabled = false;
            this.txt_inBarcode.Location = new System.Drawing.Point(71, 3);
            this.txt_inBarcode.Name = "txt_inBarcode";
            this.txt_inBarcode.Size = new System.Drawing.Size(100, 21);
            this.txt_inBarcode.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "内机条码：";
            // 
            // picbox_inUpdate
            // 
            this.picbox_inUpdate.BackgroundImage = global::UNmanagerSoft.Properties.Resources.inUpdate;
            this.picbox_inUpdate.Location = new System.Drawing.Point(12, 6);
            this.picbox_inUpdate.Name = "picbox_inUpdate";
            this.picbox_inUpdate.Size = new System.Drawing.Size(76, 85);
            this.picbox_inUpdate.TabIndex = 11;
            this.picbox_inUpdate.TabStop = false;
            this.picbox_inUpdate.Click += new System.EventHandler(this.picbox_inUpdate_Click);
            // 
            // panelSum
            // 
            this.panelSum.Controls.Add(this.textboxAllPrice);
            this.panelSum.Controls.Add(this.label12);
            this.panelSum.Controls.Add(this.textboxAllCount);
            this.panelSum.Controls.Add(this.label3);
            this.panelSum.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelSum.Location = new System.Drawing.Point(601, 0);
            this.panelSum.Name = "panelSum";
            this.panelSum.Size = new System.Drawing.Size(160, 97);
            this.panelSum.TabIndex = 13;
            // 
            // textboxAllPrice
            // 
            this.textboxAllPrice.Location = new System.Drawing.Point(55, 43);
            this.textboxAllPrice.Name = "textboxAllPrice";
            this.textboxAllPrice.ReadOnly = true;
            this.textboxAllPrice.Size = new System.Drawing.Size(100, 21);
            this.textboxAllPrice.TabIndex = 3;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label12.Location = new System.Drawing.Point(6, 47);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 2;
            this.label12.Text = "总金额：";
            // 
            // textboxAllCount
            // 
            this.textboxAllCount.Location = new System.Drawing.Point(55, 8);
            this.textboxAllCount.Name = "textboxAllCount";
            this.textboxAllCount.ReadOnly = true;
            this.textboxAllCount.Size = new System.Drawing.Size(100, 21);
            this.textboxAllCount.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label3.Location = new System.Drawing.Point(6, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "总数量：";
            // 
            // InDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 467);
            this.Controls.Add(this.inDatePanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "InDataForm";
            this.Text = "InSelectFrom";
            this.Load += new System.EventHandler(this.InDataForm_Load);
            this.inDatePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.inDataGridView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.pannel_inUpdate.ResumeLayout(false);
            this.pannel_inUpdate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbox_inUpdate)).EndInit();
            this.panelSum.ResumeLayout(false);
            this.panelSum.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel inDatePanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox picbox_inUpdate;
        private System.Windows.Forms.DataGridView inDataGridView;
        private System.Windows.Forms.Panel pannel_inUpdate;
        private System.Windows.Forms.TextBox txt_number;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_receiptsName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_receiptsNumber;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_type;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_inBarcode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox combox_InUpdateOpt;
        private System.Windows.Forms.Button btn_inUpdateSave;
        private System.Windows.Forms.Button btn_inUpdateCancel;
        private System.Windows.Forms.TextBox txt_remark;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_money;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_outBarcode;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panelSum;
        private System.Windows.Forms.TextBox textboxAllPrice;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textboxAllCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePickerInDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn airtype;
        private System.Windows.Forms.DataGridViewTextBoxColumn number;
        private System.Windows.Forms.DataGridViewTextBoxColumn price;
        private System.Windows.Forms.DataGridViewTextBoxColumn inbarcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn outbarcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn danju;
        private System.Windows.Forms.DataGridViewTextBoxColumn mingcheng;
        private System.Windows.Forms.DataGridViewTextBoxColumn opt;
        private System.Windows.Forms.DataGridViewTextBoxColumn remark;

    }
}