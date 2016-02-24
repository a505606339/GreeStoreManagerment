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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgv_inStorage = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.winFormPager1 = new Tony.Controls.Winform.WinFormPager();
            this.contextMenuStripdgv = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.修改数据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.airType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.receiptsNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.receiptsName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.opt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stockName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.删除数据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_inStorage)).BeginInit();
            this.panel2.SuspendLayout();
            this.contextMenuStripdgv.SuspendLayout();
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
            this.panel3.Size = new System.Drawing.Size(761, 411);
            this.panel3.TabIndex = 5;
            // 
            // dgv_inStorage
            // 
            this.dgv_inStorage.AllowUserToAddRows = false;
            this.dgv_inStorage.AllowUserToDeleteRows = false;
            this.dgv_inStorage.AllowUserToResizeRows = false;
            this.dgv_inStorage.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgv_inStorage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_inStorage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_inStorage.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UID,
            this.airType,
            this.number,
            this.price,
            this.receiptsNumber,
            this.receiptsName,
            this.opt,
            this.date,
            this.remark,
            this.stockName});
            this.dgv_inStorage.ContextMenuStrip = this.contextMenuStripdgv;
            this.dgv_inStorage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_inStorage.Location = new System.Drawing.Point(0, 0);
            this.dgv_inStorage.MultiSelect = false;
            this.dgv_inStorage.Name = "dgv_inStorage";
            this.dgv_inStorage.RowHeadersVisible = false;
            this.dgv_inStorage.RowTemplate.Height = 23;
            this.dgv_inStorage.Size = new System.Drawing.Size(761, 411);
            this.dgv_inStorage.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SeaShell;
            this.panel2.Controls.Add(this.winFormPager1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 411);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(761, 56);
            this.panel2.TabIndex = 4;
            // 
            // winFormPager1
            // 
            this.winFormPager1.BackColor = System.Drawing.Color.SeaShell;
            this.winFormPager1.BtnTextNext = "下页";
            this.winFormPager1.BtnTextPrevious = "上页";
            this.winFormPager1.DisplayStyle = Tony.Controls.Winform.WinFormPager.DisplayStyleEnum.图片;
            this.winFormPager1.Location = new System.Drawing.Point(65, 6);
            this.winFormPager1.Name = "winFormPager1";
            this.winFormPager1.PageSize = 20;
            this.winFormPager1.RecordCount = 0;
            this.winFormPager1.Size = new System.Drawing.Size(625, 31);
            this.winFormPager1.TabIndex = 3;
            this.winFormPager1.TextImageRalitions = Tony.Controls.Winform.WinFormPager.TextImageRalitionEnum.图片显示在文字前方;
            this.winFormPager1.PageIndexChanged += new Tony.Controls.Winform.WinFormPager.EventHandler(this.winFormPager1_PageIndexChanged);
            // 
            // contextMenuStripdgv
            // 
            this.contextMenuStripdgv.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.修改数据ToolStripMenuItem,
            this.删除数据ToolStripMenuItem});
            this.contextMenuStripdgv.Name = "contextMenuStripdgv";
            this.contextMenuStripdgv.Size = new System.Drawing.Size(153, 70);
            // 
            // 修改数据ToolStripMenuItem
            // 
            this.修改数据ToolStripMenuItem.Name = "修改数据ToolStripMenuItem";
            this.修改数据ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.修改数据ToolStripMenuItem.Text = "修改数据";
            this.修改数据ToolStripMenuItem.Click += new System.EventHandler(this.修改数据ToolStripMenuItem_Click);
            // 
            // UID
            // 
            this.UID.DataPropertyName = "UID";
            this.UID.HeaderText = "ID";
            this.UID.Name = "UID";
            this.UID.Visible = false;
            // 
            // airType
            // 
            this.airType.DataPropertyName = "空调型号";
            this.airType.HeaderText = "空调型号";
            this.airType.Name = "airType";
            // 
            // number
            // 
            this.number.DataPropertyName = "数量";
            this.number.HeaderText = "数量";
            this.number.Name = "number";
            // 
            // price
            // 
            this.price.DataPropertyName = "入库金额";
            this.price.HeaderText = "入库金额";
            this.price.Name = "price";
            // 
            // receiptsNumber
            // 
            this.receiptsNumber.DataPropertyName = "单据单号";
            this.receiptsNumber.HeaderText = "单据单号";
            this.receiptsNumber.Name = "receiptsNumber";
            // 
            // receiptsName
            // 
            this.receiptsName.DataPropertyName = "单据名称";
            this.receiptsName.HeaderText = "单据名称";
            this.receiptsName.Name = "receiptsName";
            // 
            // opt
            // 
            this.opt.DataPropertyName = "入库员";
            this.opt.HeaderText = "入库员";
            this.opt.Name = "opt";
            // 
            // date
            // 
            this.date.DataPropertyName = "入库时间";
            this.date.HeaderText = "入库时间";
            this.date.Name = "date";
            // 
            // remark
            // 
            this.remark.DataPropertyName = "入库备注";
            this.remark.HeaderText = "备注";
            this.remark.Name = "remark";
            // 
            // stockName
            // 
            this.stockName.DataPropertyName = "仓库名称";
            this.stockName.HeaderText = "仓库名称";
            this.stockName.Name = "stockName";
            // 
            // 删除数据ToolStripMenuItem
            // 
            this.删除数据ToolStripMenuItem.ForeColor = System.Drawing.Color.Red;
            this.删除数据ToolStripMenuItem.Name = "删除数据ToolStripMenuItem";
            this.删除数据ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.删除数据ToolStripMenuItem.Text = "删除数据";
            this.删除数据ToolStripMenuItem.Click += new System.EventHandler(this.删除数据ToolStripMenuItem_Click);
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
            this.contextMenuStripdgv.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgv_inStorage;
        private Tony.Controls.Winform.WinFormPager winFormPager1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripdgv;
        private System.Windows.Forms.ToolStripMenuItem 修改数据ToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn UID;
        private System.Windows.Forms.DataGridViewTextBoxColumn airType;
        private System.Windows.Forms.DataGridViewTextBoxColumn number;
        private System.Windows.Forms.DataGridViewTextBoxColumn price;
        private System.Windows.Forms.DataGridViewTextBoxColumn receiptsNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn receiptsName;
        private System.Windows.Forms.DataGridViewTextBoxColumn opt;
        private System.Windows.Forms.DataGridViewTextBoxColumn date;
        private System.Windows.Forms.DataGridViewTextBoxColumn remark;
        private System.Windows.Forms.DataGridViewTextBoxColumn stockName;
        private System.Windows.Forms.ToolStripMenuItem 删除数据ToolStripMenuItem;


    }
}