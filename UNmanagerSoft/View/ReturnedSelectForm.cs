using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UNmanagerSoft.DAL;

namespace UNmanagerSoft.View
{
    public partial class ReturnedSelectForm : Form
    {
        public event ReturnDataSouce datasouse;
        public ReturnedSelectForm()
        {
            InitializeComponent();
        }
        
        private void button_ReturnedSelect_Click(object sender, EventArgs e)
        {
            RadioButton rb = null;
            foreach (Control c in panel_returnedSelectControls.Controls)
            {
                if (c is RadioButton)
                {
                    rb = c as RadioButton;
                    if (rb.Checked)
                    {
                        break;
                    }
                }
            }
            if (rb != null)
            {
                string sqlStr = "";
                if (rb.Text == "日期")
                {
                    string before = dateTimePicker_ReturnedBefore
                        .Value.ToString("yyyy-MM-dd 00:00:00");
                    string after = dateTimePicker_ReturnedAfter
                        .Value.ToString("yyyy-MM-dd 23:59:59");
                    sqlStr = "select * from 退货表 where 退货时间 >= '"
                        + before + "'" + " and 退货时间 <= '" + after + "'";
                }
                else
                {
                    sqlStr = "select * from 退货表";
                    switch (rb.Text)
                    {
                        case "全部数据":
                            break;
                        case "内机条码":
                            sqlStr += " where 内机条码 = '"
                                + textBox_ReturnedInBar.Text + "'";
                            break;
                        case "外机条码":
                            sqlStr += " where 外机条码 = '"
                                + textBox_ReturnedOutBar.Text + "'";
                            break;
                        case "类型":
                            sqlStr += " where 操作员 = '"
                                + comboBox_ReturnOptName.Text + "'";
                            break;
                        case "型号":
                            sqlStr += " where 出货单号 = '"
                                + textBox_ReturnedOutOrderNum.Text + "'";
                            break;
                        case "出库单号":
                            sqlStr += " where 客户姓名 = '"
                                + textBox_ReturnClientName.Text + "'";
                            break;
                    }
                }
                ReturnedWrapper returnedWrapper = new ReturnedWrapper();
                DataTable dt = returnedWrapper.selectDBCommand(sqlStr);
                datasouse(dt);
                this.Close();
            }
        }

        private void button_ReturnedCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
