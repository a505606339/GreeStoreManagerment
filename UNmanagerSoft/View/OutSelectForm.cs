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
    public partial class OutSelectForm : Form
    {
        public event ReturnDataSouce datasouce;
        public OutSelectForm()
        {
            InitializeComponent();
        }

        private void button_outQuerryEnter_Click(object sender, EventArgs e)
        {
            RadioButton rb = null;
            foreach (Control c in panel_outControls.Controls)
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
                if (rb.Text == "出库时间")
                {
                    string before = dateTimePicker_outFromDate
                        .Value.ToString("yyyy-MM-dd 00:00:00");
                    string after = dateTimePicker_outToDate
                        .Value.ToString("yyyy-MM-dd 23:59:59");
                    sqlStr = "select * from 出库表 where 出库时间 >= '"
                        + before + "'" + " and 出库时间 <= '" + after + "'";
                }
                else
                {
                    sqlStr = "select * from 出库表";
                    switch (rb.Text)
                    {
                        case "全部数据":
                            break;
                        case "内机条码":
                            sqlStr += " where 内机条码 = '"
                                + comboBox_outInBarcode.Text + "'";
                            break;
                        case "外机条码":
                            sqlStr += " where 外机条码 = '"
                                + comboBox_outOutBarcode.Text + "'";
                            break;
                        case "型号":
                            sqlStr += " where 空调型号 = '"
                                + comboBox_outType.Text + "'";
                            break;
                        case "出库单号":
                            sqlStr += " where 出库单号 = '"
                                + comboBox_outReceiptsNumber.Text + "'";
                            break;
                        case "客户名称":
                            sqlStr += " where 客户名称 = '"
                                + textBox_outClientNum.Text + "'";
                            break;
                        case "操作员":
                            sqlStr += " where 操作员 = '"
                                + comboBox_outOptName.Text + "'";
                            break;
                        case "送货员":
                            sqlStr += " where 送货员 = '"
                                + comboBox_outOptName.Text + "'";
                            break;
                        case "安装员":
                            sqlStr += " where 安装员 = '"
                                + comboBox_outOptName.Text + "'";
                            break;
                    }
                }
                OutStorageWrapper outstorageWrapper = new OutStorageWrapper();
                DataTable dt = outstorageWrapper.selectDBCommand(sqlStr);
                datasouce(dt);
                this.Close();
            }
        }

        private void button_outQuerryEsc_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
