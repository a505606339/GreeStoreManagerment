namespace UNmanagerSoft.View
{
    partial class WarehouseForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgv_inStorage = new System.Windows.Forms.DataGridView();
            this.airtype = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inorout = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.barcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inprice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.danhao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.danming = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.opt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.indate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.outdanhao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clientName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.outprice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.outopt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.der = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.outdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inremark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.outremark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.winFormPager1 = new Tony.Controls.Winform.WinFormPager();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_inStorage)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(761, 467);
            this.panel1.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgv_inStorage);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(761, 405);
            this.panel3.TabIndex = 5;
            // 
            // dgv_inStorage
            // 
            this.dgv_inStorage.AllowUserToAddRows = false;
            this.dgv_inStorage.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgv_inStorage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_inStorage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_inStorage.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.airtype,
            this.inorout,
            this.number,
            this.barcode,
            this.inprice,
            this.danhao,
            this.danming,
            this.opt,
            this.indate,
            this.outdanhao,
            this.clientName,
            this.outprice,
            this.outopt,
            this.der,
            this.ser,
            this.outdate,
            this.inremark,
            this.outremark});
            this.dgv_inStorage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_inStorage.Location = new System.Drawing.Point(0, 0);
            this.dgv_inStorage.Name = "dgv_inStorage";
            this.dgv_inStorage.RowHeadersVisible = false;
            this.dgv_inStorage.RowTemplate.Height = 23;
            this.dgv_inStorage.Size = new System.Drawing.Size(761, 405);
            this.dgv_inStorage.TabIndex = 2;
            // 
            // airtype
            // 
            this.airtype.DataPropertyName = "空调型号";
            this.airtype.HeaderText = "空调型号";
            this.airtype.Name = "airtype";
            this.airtype.Width = 200;
            // 
            // inorout
            // 
            this.inorout.DataPropertyName = "内外型号";
            this.inorout.HeaderText = "内外型号";
            this.inorout.Name = "inorout";
            // 
            // number
            // 
            this.number.DataPropertyName = "数量";
            this.number.HeaderText = "数量";
            this.number.Name = "number";
            // 
            // barcode
            // 
            this.barcode.DataPropertyName = "条码";
            this.barcode.HeaderText = "条码";
            this.barcode.Name = "barcode";
            // 
            // inprice
            // 
            this.inprice.DataPropertyName = "入库金额";
            this.inprice.HeaderText = "入库金额";
            this.inprice.Name = "inprice";
            // 
            // danhao
            // 
            this.danhao.DataPropertyName = "单据单号";
            this.danhao.HeaderText = "单据单号";
            this.danhao.Name = "danhao";
            // 
            // danming
            // 
            this.danming.DataPropertyName = "单据名称";
            this.danming.HeaderText = "单据名称";
            this.danming.Name = "danming";
            // 
            // opt
            // 
            this.opt.DataPropertyName = "入库员";
            this.opt.HeaderText = "入库员";
            this.opt.Name = "opt";
            // 
            // indate
            // 
            this.indate.DataPropertyName = "入库时间";
            this.indate.HeaderText = "入库时间";
            this.indate.Name = "indate";
            // 
            // outdanhao
            // 
            this.outdanhao.DataPropertyName = "出库单号";
            this.outdanhao.HeaderText = "出库单号";
            this.outdanhao.Name = "outdanhao";
            // 
            // clientName
            // 
            this.clientName.DataPropertyName = "客户名称";
            this.clientName.HeaderText = "客户名称";
            this.clientName.Name = "clientName";
            // 
            // outprice
            // 
            this.outprice.DataPropertyName = "出库金额";
            this.outprice.HeaderText = "出库金额";
            this.outprice.Name = "outprice";
            // 
            // outopt
            // 
            this.outopt.DataPropertyName = "出库员";
            this.outopt.HeaderText = "出库员";
            this.outopt.Name = "outopt";
            // 
            // der
            // 
            this.der.DataPropertyName = "送货员";
            this.der.HeaderText = "送货员";
            this.der.Name = "der";
            // 
            // ser
            // 
            this.ser.DataPropertyName = "安装员";
            this.ser.HeaderText = "安装员";
            this.ser.Name = "ser";
            // 
            // outdate
            // 
            this.outdate.DataPropertyName = "出库时间";
            this.outdate.HeaderText = "出库时间";
            this.outdate.Name = "outdate";
            // 
            // inremark
            // 
            this.inremark.DataPropertyName = "入库备注";
            this.inremark.HeaderText = "入库备注";
            this.inremark.Name = "inremark";
            // 
            // outremark
            // 
            this.outremark.DataPropertyName = "出库备注";
            this.outremark.HeaderText = "出库备注";
            this.outremark.Name = "outremark";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SeaShell;
            this.panel2.Controls.Add(this.winFormPager1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 405);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(761, 62);
            this.panel2.TabIndex = 4;
            // 
            // winFormPager1
            // 
            this.winFormPager1.BackColor = System.Drawing.Color.SeaShell;
            this.winFormPager1.BtnTextNext = "下页";
            this.winFormPager1.BtnTextPrevious = "上页";
            this.winFormPager1.DisplayStyle = Tony.Controls.Winform.WinFormPager.DisplayStyleEnum.图片;
            this.winFormPager1.Location = new System.Drawing.Point(59, 6);
            this.winFormPager1.Name = "winFormPager1";
            this.winFormPager1.PageSize = 20;
            this.winFormPager1.RecordCount = 0;
            this.winFormPager1.Size = new System.Drawing.Size(625, 31);
            this.winFormPager1.TabIndex = 3;
            this.winFormPager1.TextImageRalitions = Tony.Controls.Winform.WinFormPager.TextImageRalitionEnum.图片显示在文字前方;
            this.winFormPager1.PageIndexChanged += new Tony.Controls.Winform.WinFormPager.EventHandler(this.winFormPager1_PageIndexChanged);
            // 
            // WarehouseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 467);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "WarehouseForm";
            this.Text = "WarehouseForm";
            this.Load += new System.EventHandler(this.WarehouseForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_inStorage)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgv_inStorage;
        private Tony.Controls.Winform.WinFormPager winFormPager1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn airtype;
        private System.Windows.Forms.DataGridViewTextBoxColumn inorout;
        private System.Windows.Forms.DataGridViewTextBoxColumn number;
        private System.Windows.Forms.DataGridViewTextBoxColumn barcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn inprice;
        private System.Windows.Forms.DataGridViewTextBoxColumn danhao;
        private System.Windows.Forms.DataGridViewTextBoxColumn danming;
        private System.Windows.Forms.DataGridViewTextBoxColumn opt;
        private System.Windows.Forms.DataGridViewTextBoxColumn indate;
        private System.Windows.Forms.DataGridViewTextBoxColumn outdanhao;
        private System.Windows.Forms.DataGridViewTextBoxColumn clientName;
        private System.Windows.Forms.DataGridViewTextBoxColumn outprice;
        private System.Windows.Forms.DataGridViewTextBoxColumn outopt;
        private System.Windows.Forms.DataGridViewTextBoxColumn der;
        private System.Windows.Forms.DataGridViewTextBoxColumn ser;
        private System.Windows.Forms.DataGridViewTextBoxColumn outdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn inremark;
        private System.Windows.Forms.DataGridViewTextBoxColumn outremark;


    }
}