using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UNmanagerSoft.Business_LL;
using UNmanagerSoft.DAL;

namespace UNmanagerSoft.View
{
    public partial class OutDataForm : Form
    {
        OutEntity outEntity = new OutEntity();
        ReturnedEntity reEntity = new ReturnedEntity();
        OutStorageWrapper outStorageWrapper = new OutStorageWrapper();
        public bool updateButton = true;
        public bool retuenedButton = true;
        OperaterWapper optWapper = new OperaterWapper();
        SetterWapper serWapper = new SetterWapper();
        DeliveryWapper derWapper = new DeliveryWapper();
        public OutDataForm()
        {
            InitializeComponent();
        }

        private void OutDataForm_Load(object sender, EventArgs e)
        {
            picbox_outUpdate.Visible = updateButton;
            picbox_reReturned.Visible = retuenedButton;
            if (!updateButton)
            {
                picbox_reReturned.Location = picbox_outUpdate.Location;
            }
            OutSelectForm outSelectForm = new OutSelectForm();
            outSelectForm.datasouce += new ReturnDataSouce(outSelectForm_datasouce);
            outSelectForm.ShowDialog();
            initALLCountAndPrice();
            DataTable dt = optWapper.operaterSelect();
            foreach (DataRow dr in dt.Rows)
            {
                comboBoxOpt.Items.Add(dr[0]);
                comboBoxReturnOpt.Items.Add(dr[0]);
            }
            dt = derWapper.deliverySelect();
            foreach (DataRow dr in dt.Rows)
            {
                comboBoxder.Items.Add(dr[0]);
            }
            dt = serWapper.setterSelect();
            foreach (DataRow dr in dt.Rows)
            {
                comboBoxSer.Items.Add(dr[0]);
            }
        }

        private void initALLCountAndPrice()
        {
            int allCount = 0;
            double allPrice = 0;
            DataTable dt = outStorageWrapper.SelectCountAndPriceWithOutTable();
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
            textboxAllcount.Text = allCount.ToString();
            textboxAllPrice.Text = allPrice.ToString();
        }

        void outSelectForm_datasouce(DataTable dt)
        {
            dataGroupView_out.DataSource = dt;
        }

        private void dataGroupView_out_SelectionChanged(object sender, EventArgs e)
        {
            if(panel_outUpdateControls.Visible)
            {
                if (dataGroupView_out.CurrentRow != null)
                {
                    int rowindex = dataGroupView_out.CurrentRow.Index;
                    outEntity.InBarcode = dataGroupView_out.Rows[rowindex]
                        .Cells[0].Value.ToString();
                    outEntity.OutBarcode = dataGroupView_out.Rows[rowindex]
                        .Cells[1].Value.ToString();
                    outEntity.Type = dataGroupView_out.Rows[rowindex]
                        .Cells[2].Value.ToString();
                    outEntity.OutOrderNum = dataGroupView_out.Rows[rowindex]
                        .Cells[3].Value.ToString();
                    outEntity.ClientName = dataGroupView_out.Rows[rowindex]
                        .Cells[4].Value.ToString();
                    outEntity.Outdate = dataGroupView_out.Rows[rowindex]
                        .Cells[5].Value.ToString();
                    outEntity.Number = dataGroupView_out.Rows[rowindex]
                        .Cells[6].Value.ToString();
                    outEntity.Money = dataGroupView_out.Rows[rowindex]
                        .Cells[7].Value.ToString();
                    outEntity.Operators = dataGroupView_out.Rows[rowindex]
                        .Cells[8].Value.ToString();
                    outEntity.Deliver = dataGroupView_out.Rows[rowindex]
                        .Cells[9].Value.ToString();
                    outEntity.Install = dataGroupView_out.Rows[rowindex]
                        .Cells[10].Value.ToString();
                    outEntity.Remark = dataGroupView_out.Rows[rowindex]
                        .Cells[11].Value.ToString();

                    fillUpdateTextBox();
                }
            }
            if (panel_returnedControls.Visible)
            {
                //根据点击的出库列获取到退货需要的信息 
                if (dataGroupView_out.CurrentRow != null)
                {
                    int rowindex = dataGroupView_out.CurrentRow.Index;
                    reEntity.InBarcode = dataGroupView_out.Rows[rowindex]
                        .Cells[0].Value.ToString();
                    reEntity.OutBarcode = dataGroupView_out.Rows[rowindex]
                        .Cells[1].Value.ToString();
                    reEntity.type = dataGroupView_out.Rows[rowindex]
                        .Cells[2].Value.ToString();
                    reEntity.remark = "";
                    reEntity.clientName = dataGroupView_out.Rows[rowindex]
                        .Cells[4].Value.ToString();
                    reEntity.optName = dataGroupView_out.Rows[rowindex]
                        .Cells[8].Value.ToString();
                    reEntity.dateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
                    
                    fillRetuenedTextBox();
                }
            }
        }

        private void picbox_outUpdate_Click(object sender, EventArgs e)
        {
            panel_outUpdateControls.Visible = true;
            panelSum.Visible = false;
            //picbox_reReturned.Visible = false;
            panel_outUpdateControls.Dock = DockStyle.Fill;
        }

        private void btn_outUpdateSave_Click(object sender, EventArgs e)
        {
            if (dataGroupView_out.CurrentRow.Index >= 0)
            {
                OutEntity newoutEntity = new OutEntity();
                newoutEntity.InBarcode = txt_barcode.Text;
                newoutEntity.OutBarcode = txt_outbarcode.Text;
                newoutEntity.ClientName = txt_clientName.Text;
                newoutEntity.Deliver = comboBoxder.Text;
                newoutEntity.Install = comboBoxSer.Text;
                newoutEntity.Money = txt_money.Text;
                newoutEntity.Number = txt_number.Text;
                newoutEntity.Operators = comboBoxOpt.Text;
                newoutEntity.OutOrderNum = txt_outOrderNum.Text;
                newoutEntity.Remark = txt_remark.Text;
                newoutEntity.Type = txt_type.Text;

                int returnFlag = outStorageWrapper.updateDBCommand(newoutEntity);
                if (returnFlag > 0)
                {
                    string selectStr = "select * from 出库表";
                    try
                    {
                        dataGroupView_out.DataSource =
                            outStorageWrapper.selectDBCommand(selectStr);
                    }
                    catch
                    {
                        throw;
                    }
                    MessageBox.Show("更改成功");
                }
                else
                {
                    MessageBox.Show("更改出现错误,请检查");
                }
            }
            else
            {
                MessageBox.Show("请先从数据列表中选择需要更改的行");
            }
        }

        private void btn_outUpdateCancel_Click(object sender, EventArgs e)
        {
            panel_outUpdateControls.Visible = false;
            panel_outUpdateControls.Dock = DockStyle.None;
            panelSum.Visible = true;
        }

        private void fillUpdateTextBox()
        {
            txt_barcode.Text = outEntity.InBarcode;
            comboBoxder.Text = outEntity.Deliver;
            comboBoxSer.Text = outEntity.Install;
            txt_outbarcode.Text = outEntity.OutBarcode;
            txt_money.Text = outEntity.Money;
            txt_number.Text = outEntity.Number;
            txt_outOrderNum.Text = outEntity.OutOrderNum;
            comboBoxOpt.Text = outEntity.Operators;
            txt_remark.Text = outEntity.Remark;
            txt_type.Text = outEntity.Type;
            txt_clientName.Text = outEntity.ClientName;
        }

        private void fillRetuenedTextBox()
        {
            txt_returnInBarcode.Text = reEntity.InBarcode;
            txt_returnOutBarcode.Text = reEntity.OutBarcode;
            txt_returnType.Text = reEntity.type;
            txt_remark.Text = reEntity.remark;
            txt_returnClientName.Text = reEntity.clientName;
            comboBoxReturnOpt.Text = reEntity.optName;
            txt_returnOutdate.Text = reEntity.dateTime;
        }

        private void picbox_reReturned_Click(object sender, EventArgs e)
        {
            panel_returnedControls.Visible = true;
            panelSum.Visible = false;
            panel_returnedControls.Dock = DockStyle.Fill;
        }

        private void btn_returnCancel_Click(object sender, EventArgs e)
        {
            panel_returnedControls.Visible = false;
            panel_returnedControls.Dock = DockStyle.None;
            panelSum.Visible = true;
        }

        private void btn_returnSave_Click(object sender, EventArgs e)
        {//
            ReturnedWrapper returnedWrapper = new ReturnedWrapper();
            if(reEntity != null)
            {
                int flag = returnedWrapper.MannulreturnedDBCommand(reEntity);
                if (flag > 0)
                {
                    string selectStr = "select * from 退货表";
                    DataTable dt = returnedWrapper.selectDBCommand(selectStr);
                    dataGroupView_out.DataSource = dt;
                    MessageBox.Show("商品退货已成功,请查看退货后数据","退货成功");
                }
                if (flag == 0)
                {
                    MessageBox.Show("未更新数据,请检查产品是否已退货");
                }
                if(flag < 0)
                {
                    MessageBox.Show("更新过程出错,请检查数据是否异常");
                }
            }
        }
    }
}
