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
    public partial class StorageSelectForm : Form
    {
        List<string> tagList = new List<string>();
        public event ReturnDataSouce datasouce;
        string inDateTimeSQL = "";
        string outDateTimeSQL = "";
        public StorageSelectForm()
        {
            InitializeComponent();
            checkedBoxEventLoad();
        }

        private void btn_StorageSelect_Click(object sender, EventArgs e)
        {
            StorageWrapper storageWrapper = new StorageWrapper();
            DataTable dt = new DataTable();
            StringBuilder sqlStr = new StringBuilder();
            //sqlStr.Append("select * from 库存表 where 1=1");
            sqlStr.Append("select top 20 * from 库存表 where 1=1");
            foreach (var field in tagList)
            {
                switch (field)
                {
                    case "单据单号":
                        sqlStr.Append(" and (" + field + " = '" +
                            txt_receiptsNumber.Text.Trim() + "')");
                        break;
                    case "出库单号":
                        sqlStr.Append(" and (" + field + " = '" +
                            txt_outOrderNumber.Text.Trim() + "')");
                        break;
                    case "单据名称":
                        sqlStr.Append(" and (" + field + " = '" +
                            txt_inReceiptsName.Text.Trim() + "')");
                        break;
                    case "客户名称":
                        sqlStr.Append(" and (" + field + " = '" +
                            txt_clientName.Text.Trim() + "')");
                        break;
                    case "空调型号":
                        sqlStr.Append(" and (" + field + " = '" +
                            txt_type.Text.Trim() + "')");
                        break;
                    case "操作员":
                        sqlStr.Append(" and (" + field + " = '" +
                            txt_opt.Text.Trim() + "')");
                        break;
                    case "送货员":
                        sqlStr.Append(" and (" + field + " = '" +
                            txt_deliver.Text.Trim() + "')");
                        break;
                    case "安装员":
                        sqlStr.Append(" and (" + field + " = '" +
                            txt_install.Text.Trim() + "')");
                        break;
                    case "条码":
                        sqlStr.Append(" and (" + field + " = '" +
                            txt_outbarcode.Text.Trim() + "')");
                        break;
                    case "内外型号":
                        sqlStr.Append(" and (" + field + " = '" +
                            comboBoxInOrOut.Text.Trim() + "')");
                        break;
                }
            }
            if(!String.IsNullOrEmpty(inDateTimeSQL))
            {
                sqlStr.Append(inDateTimeSQL);
            }
            if (!String.IsNullOrEmpty(outDateTimeSQL))
            {
                sqlStr.Append(outDateTimeSQL);
            }
            dt = storageWrapper.selectDBCommand(sqlStr.ToString());
            datasouce(dt);
            this.Close();
        }

        private void btn_StorageCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkedBox_changed(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            if (cb.Checked)
            {
                if (cb.Text == "入库时间")
                {
                    inDateTimeSQL = "and (入库时间 between '"
                        + dateTimePicker_InstorageBefore.Value
                        .ToString("yyyy-MM-dd 00:00:00")
                        + "' and '" + dateTimePicker_InstorageAfter.Value
                        .ToString("yyyy-MM-dd 23:59:59") + "')";
                }
                else if (cb.Text == "出库时间")
                {
                    outDateTimeSQL = "and (出库时间 between '"
                        + dateTimePicker_OutstorageBefore.Value
                        .ToString("yyyy-MM-dd 00:00:00")
                        + "' and '" + dateTimePicker_OutstorageAfter.Value
                        .ToString("yyyy-MM-dd 23:59:59") + "')";
                }
                else
                {
                    tagList.Add(cb.Tag.ToString());
                }
            }
            else
            {
                tagList.Remove(cb.Tag.ToString());
                if (cb.Text == "入库时间")
                {
                    inDateTimeSQL = "";
                }
                if (cb.Text == "出库时间")
                {
                    outDateTimeSQL = "";
                }
            }
        }

        private void checkedBoxEventLoad()
        {
            foreach (Control c in panel_StorageSelect.Controls)
            {
                if (c is CheckBox)
                {
                    CheckBox cb = c as CheckBox;
                    cb.CheckedChanged += new EventHandler(checkedBox_changed);
                }
            }
        }
    }
}
