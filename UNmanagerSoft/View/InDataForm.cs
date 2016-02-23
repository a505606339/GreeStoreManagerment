using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Data.OleDb;
using System.Text;
using System.Windows.Forms;
using UNmanagerSoft.Business_LL;
using UNmanagerSoft.DAL;
using UNmanagerSoft.Utility;

namespace UNmanagerSoft.View
{
    public partial class InDataForm : Form
    {
        InEntity instorage = new InEntity();
        OperaterWapper optWapper = new OperaterWapper();
        InStorageWrapper inStorageWapper = new InStorageWrapper();
        public InDataForm()
        {
            InitializeComponent();
        }

        private void InDataForm_Load(object sender, EventArgs e)
        {
            InSelectForm inSelectForm = new InSelectForm();
            inSelectForm.datasouce += new ReturnDataSouce(inSelectForm_datasouce);
            inSelectForm.ShowDialog();
            initALLCountAndPrice();
            DataTable dt = optWapper.operaterSelect();
            foreach (DataRow dr in dt.Rows)
            {
                combox_InUpdateOpt.Items.Add(dr[0]);
            }
        }

        void inSelectForm_datasouce(DataTable dt)
        {
            this.inDataGridView.DataSource = dt;
        }

        private void initALLCountAndPrice()
        {
            int allCount = 0;
            double allPrice = 0;
            DataTable dt = inStorageWapper.SelectCountAndPriceWithInTable();
            if (dt != null)
            {
                if (dt.Columns.Count >= 2)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        string count = dr[0].ToString();
                        string price = dr[1].ToString();
                        if (!String.IsNullOrEmpty(count))
                        {
                            try
                            {
                                allCount += Convert.ToInt32(count);
                            }
                            catch
                            {
                                allCount += 1;
                            }
                        }
                        if (!String.IsNullOrEmpty(price))
                        {
                            try
                            {
                                allPrice += Convert.ToDouble(price);
                            }
                            catch
                            {
                                allPrice += 0;
                            }
                        }
                    }
                }
            }
            textboxAllCount.Text = allCount.ToString();
            textboxAllPrice.Text = allPrice.ToString();
        }

        private void picbox_inUpdate_Click(object sender, EventArgs e)
        {
            pannel_inUpdate.Visible = true;
            panelSum.Visible = false;
            pannel_inUpdate.Dock = DockStyle.Fill;
            fillUpdateTextBox();
        }

        private void inDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            int rowindex = inDataGridView.CurrentRow.Index;
            instorage.inbarcode = inDataGridView.Rows[rowindex]
                .Cells[0].Value.ToString();
            instorage.outbarcode = inDataGridView.Rows[rowindex]
                .Cells[1].Value.ToString();
            instorage.type = inDataGridView.Rows[rowindex]
                .Cells[2].Value.ToString();
            instorage.receiptsNumber = inDataGridView.Rows[rowindex]
                .Cells[3].Value.ToString();
            instorage.receiptsName = inDataGridView.Rows[rowindex]
                .Cells[4].Value.ToString();
            instorage.inDate = inDataGridView.Rows[rowindex]
                .Cells[5].Value.ToString();
            instorage.inNumber = inDataGridView.Rows[rowindex]
                .Cells[6].Value.ToString();
            instorage.inMoney = inDataGridView.Rows[rowindex]
                .Cells[7].Value.ToString();
            instorage.operators = inDataGridView.Rows[rowindex]
                .Cells[8].Value.ToString();
            instorage.remark = inDataGridView.Rows[rowindex]
                .Cells[9].Value.ToString();

            fillUpdateTextBox();
        }

        private void fillUpdateTextBox()
        {
            txt_inBarcode.Text = instorage.inbarcode;
            txt_outBarcode.Text = instorage.outbarcode;
            txt_type.Text = instorage.type;
            txt_receiptsNumber.Text = instorage.receiptsNumber;
            txt_receiptsName.Text = instorage.receiptsName;
            try
            {
                dateTimePickerInDate.Value = Convert.ToDateTime(instorage.inDate);
            }
            catch
            {
                dateTimePickerInDate.Value = DateTime.Now;
            }
            txt_number.Text = instorage.inNumber;
            txt_money.Text = instorage.inMoney;
            txt_remark.Text = instorage.remark;
            combox_InUpdateOpt.Text = instorage.operators;
        }

        private void btn_inUpdateSave_Click(object sender, EventArgs e)
        {
            InEntity newInstorage = new InEntity();
            newInstorage.inbarcode = txt_inBarcode.Text;
            newInstorage.outbarcode = txt_outBarcode.Text;
            newInstorage.inDate = dateTimePickerInDate.Value.ToString();
            newInstorage.inMoney = txt_money.Text;
            newInstorage.inNumber = txt_number.Text;
            newInstorage.operators = combox_InUpdateOpt.Text;
            newInstorage.receiptsName = txt_receiptsName.Text;
            newInstorage.receiptsNumber = txt_receiptsNumber.Text;
            newInstorage.remark = txt_remark.Text;
            newInstorage.type = txt_type.Text;
            int returnflag = inStorageWapper.updateDBCommand(newInstorage);
            if (returnflag > 0)
            {
                string selectStr = "select * from 入库表";
                try
                {
                    inDataGridView.DataSource = inStorageWapper.selectDBCommand(selectStr);
                }
                catch
                {
                    throw;
                }
                MessageBox.Show("保存成功");
            }
            else
            {
                MessageBox.Show("更新出现问题,请检查输入是否正确");
            }
        }

        private void btn_inUpdateCancel_Click(object sender, EventArgs e)
        {
            pannel_inUpdate.Visible = false;
            panelSum.Visible = true;
        }
    }
}
