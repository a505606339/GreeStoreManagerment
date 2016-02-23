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
    public delegate void ReturnDataSouce(DataTable dt);
    public partial class InSelectForm : Form
    {
        public event ReturnDataSouce datasouce;
        private InStorageWrapper inStorageWapper = new InStorageWrapper();
        public InSelectForm()
        {
            InitializeComponent();
        }
        
        private void button_inQuerryEnter_Click(object sender, EventArgs e)
        {
            InEntity instorage = new InEntity();
            RadioButton rb = null;
            foreach (Control c in panel_inControls.Controls)
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
                    string before = dateTimePicker_inFromDate
                        .Value.ToString("yyyy-MM-dd 00:00:00");
                    string after = dateTimePicker_inToDate.Value
                        .ToString("yyyy-MM-dd 23:59:59");
                    sqlStr = "select * from 入库表 where 入库时间 >= '"
                        + before + "'" + " and 入库时间 <= '" + after + "'";
                }
                else
                {
                    sqlStr = "select * from 入库表";
                    switch (rb.Text)
                    {
                        case "全部数据":
                            break;
                        case "内机条码":
                            if (comboBox_inInBarcode.Text == "")
                            {
                                sqlStr += " where 外机条码 = ''";
                                break;
                            }
                            else
                            {
                                sqlStr += " where 内机条码 = '"
                                 + comboBox_inInBarcode.Text + "'";
                                break; 
                            }
                        case "外机条码":
                            if (comboBox_inOutBarcode.Text == "")
                            {
                                sqlStr += " where 内机条码 = ''";
                                break;
                            }
                            else
                            {
                                sqlStr += " where 外机条码 = '"
                                + comboBox_inOutBarcode.Text + "'";
                                break;
                            }
                        case "型号":
                            sqlStr += " where 空调型号 = '"
                                + comboBox_inTpye.Text + "'";
                            break;
                        case "单据单号":
                            sqlStr += " where 单据单号 = '" 
                                + comboBox_inReceiptsNumber.Text + "'";
                            break;
                        case "单据名称":
                            sqlStr += " where 单据名称 = '" 
                                + comboBox_inReceiptsName.Text + "'";
                            break;
                        case "操作员":
                            sqlStr += " where 操作员 = '" 
                                + comboBox_inOptName.Text + "'";
                            break;
                    }
                }
                DataTable dt = inStorageWapper.selectDBCommand(sqlStr);
                datasouce(dt);
                this.Close();
            }
        }

        private void button_inQuerryEsc_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
