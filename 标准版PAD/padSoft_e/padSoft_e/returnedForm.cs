using System;
using System.IO;
using System.Threading;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlServerCe;

namespace padSoft_e
{
    public partial class returnedForm : Form
    {
        string sqlPath = sysFunction.exePath() + @"数据\database.sdf";
        public returnedForm()
        {
            InitializeComponent();
            initListview();//初始化listview
            //获取所有的内机条码和外机条码以及类型,组成数组
            opt_comboBox.Items.Clear();
            opt_comboBox.Items.Add("");
            clientName_textbox.Items.Clear();
            clientName_textbox.Items.Add("");
            OpeNameInit();
            clientNameInit();
            Remark_textBox.Focus();
            openCommScan();
        }
        //初始化listvie
        private void initListview()
        {
            //init listview
            returned_listView.Left = 3;//3, 238
            returned_listView.Top = 220;//255
            returned_listView.Width = 236;
            returned_listView.Height = 100;//65
            returned_listView.FullRowSelect = true;
            returned_listView.View = View.Details;
            returned_listView.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            this.returned_listView.Columns.Add("内机条码", 100, HorizontalAlignment.Left);
            this.returned_listView.Columns.Add("外机条码", 100, HorizontalAlignment.Left);
            this.returned_listView.Columns.Add("空调类型", 100, HorizontalAlignment.Center);
            this.returned_listView.Columns.Add("备注", 60, HorizontalAlignment.Center);
            this.returned_listView.Columns.Add("客户名称", 100, HorizontalAlignment.Center);
            this.returned_listView.Columns.Add("操作员", 60, HorizontalAlignment.Center);
            this.returned_listView.Columns.Add("退货时间", 100, HorizontalAlignment.Center);
            this.returned_listView.View = View.Details;
        }

        private void returnedForm_Load(object sender, EventArgs e)
        {
            initInOutCode();
            listBeforeData();//遍历退货文件,为listview填充已存在数据
        }

        //遍历退货文件,为listview填充已存在数据 
        private void listBeforeData()
        {
            DBHelper dbHelper = new DBHelper();
            DataTable dt = dbHelper.selectAllReturnedTable();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    listviewBeforeData(dr[0].ToString(),
                        dr[1].ToString(),
                        dr[2].ToString(),
                        dr[3].ToString(),
                        dr[4].ToString(),
                        dr[5].ToString(),
                        dr[6].ToString());
                }
            }
        }
        //获取内机条码,外机条码和两个条码对应的产品型号组成列表
        public List<string> strInCode = new List<string>();//内机条码标识列表
        public List<string> strOutCode = new List<string>();//外机条码标识列表
        public List<string> strAirTpye = new List<string>();//型号列表
        public void initInOutCode()
        {
            DBHelper dbHelper = new DBHelper();
            DataTable dt = dbHelper.selectAllToPairedTable();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    strInCode.Add(dr[1].ToString());
                    strOutCode.Add(dr[2].ToString());
                    strAirTpye.Add(dr[3].ToString());
                }
            }
        }

        private bool openCommScan()
        {
            if (serialPort1.IsOpen)
            {
                this.serialPort1.Close();
            }
            this.serialPort1.DataReceived +=
                new System.IO.Ports.SerialDataReceivedEventHandler(mycommScan_DataReceived);
            try
            {
                serialPort1.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if (serialPort1.IsOpen)
                return true;
            else
                return false;
        }

        private void mycommScan_DataReceived(object sender,
            System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            Thread.Sleep(10); //读取速度太慢，加Sleep延长读取时间, 不可缺少//500:2047   1000:2047

            byte[] readBuffer = new byte[this.serialPort1.BytesToRead];

            this.serialPort1.Read(readBuffer, 0, readBuffer.Length);

            string txt = System.Text.Encoding.
                Default.GetString(readBuffer, 0, readBuffer.Length);

            if (txt.Length > 3)
                ChangeTextScan(txt);
        }


        private string inType = "";
        private string outType = "";
        private void ChangeTextScan(string text)//在此对内外机做匹配,当不为两条时禁止保存,类型不同禁止保存
        {
            text = text.Trim();
            int inLocation = strInCode.
                IndexOf(text.Substring(0, 5));//内机所匹配条码的位置,给类型位置做准备
            int outLocation = strOutCode.
                IndexOf(text.Substring(0, 5));//外机所匹配条码的位置 

            foreach (string inbar in strInCode)//遍历内机数组,有匹配返回
            {
                if (inLocation == -1)//不为内机
                    break;
                if (inbar.Equals("") || String.IsNullOrEmpty(inbar))
                    break;
                else
                {
                    try
                    {
                        if (inbar.Equals(text.Substring(0, 5)))
                        {
                            //MessageBox.Show("为内机条码" + inbar + "原:" + text);
                            //MessageBox.Show("位置为" + inLocation.ToString());
                            //MessageBox.Show("型号" + strAirTpye[inLocation]);
                            inType = strAirTpye[inLocation];
                            textInTextBox(text, 1);
                            scanFunction.oneBeeper();
                            break;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("出错,内机条码匹配失败" + ex);
                        break;
                    }
                }
            }
            foreach (string outbar in strOutCode)//遍历外机数组,有匹配返回 
            {
                if (outLocation == -1)
                    break;
                if (outbar.Equals("") || String.IsNullOrEmpty(outbar))
                    break;
                else
                {
                    try
                    {
                        if (outbar.Equals(text.Substring(0, 5)))
                        {
                            //MessageBox.Show("为外机条码" + outbar + "原:" + text);
                            //MessageBox.Show("位置为" + outLocation.ToString());
                            //MessageBox.Show("型号" + strAirTpye[outLocation]);
                            outType = strAirTpye[outLocation];
                            textInTextBox(text, 2);
                            scanFunction.oneBeeper();
                            break;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("出错,外机条码匹配失败" + ex);
                        break;
                    }
                }
            }
        }
        /// <summary>
        /// 跨线程调用控件方法 
        /// </summary>
        /// <param name="text">给textbox的值</param>
        /// <param name="flag">内外机标识</param>
        delegate void SetTextBox(string text, int flag);
        private void textInTextBox(string text, int flag)
        {
            if (flag == 1)
            {
                if (inBar_textBox.InvokeRequired)
                {
                    SetTextBox stb = new SetTextBox(textInTextBox);
                    inBar_textBox.Invoke(stb, text, flag);
                }
                else
                {
                    inBar_textBox.Text = text;
                }
            }
            if (flag == 2)
            {
                if (outBar_textBox.InvokeRequired)
                {
                    SetTextBox stb = new SetTextBox(textInTextBox);
                    outBar_textBox.Invoke(stb, text, flag);
                }
                else
                {
                    outBar_textBox.Text = text;
                }
            }
        }

        private void OKEnterSave()
        {
            DBHelper dbHelper = new DBHelper();
            string inbarCondition = inBar_textBox.Text.Trim().Substring(0, 5);
            string outbarCondition = outBar_textBox.Text.Trim().Substring(0, 5);
            if (inBar_textBox.Text.Equals("") || String.IsNullOrEmpty(inBar_textBox.Text)
                || outBar_textBox.Text.Equals("") || String.IsNullOrEmpty(inBar_textBox.Text))
            {
                scanFunction.twoBeeper();
                MessageBox.Show("内机或外机未扫,请检查", "温馨提示");
                return;
            }
            if (!dbHelper.existsBarcodePaired(inbarCondition,outbarCondition))
            {
                scanFunction.twoBeeper();
                MessageBox.Show("内外机不匹配,请检查", "温馨提示");
                return;
            }
            else
            {
                if (repeatNumInFile(inBar_textBox.Text.Trim()))
                {
                    MessageBox.Show("条码已经存在");
                    return;
                }
                DataTable dt = dbHelper.selectPairedByCondiction(inbarCondition, outbarCondition);
                string returnData = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                dbHelper.insertReturnedTable(inBar_textBox.Text.Trim(),
                    outBar_textBox.Text.Trim(), dt.Rows[0][3].ToString(),
                    Remark_textBox.Text.Trim(), clientName_textbox.Text.Trim(),
                    opt_comboBox.Text, returnData);
                ListViewItem lvi = new ListViewItem();
                lvi.Text = inBar_textBox.Text.Trim();
                lvi.SubItems.Add(outBar_textBox.Text.Trim());
                lvi.SubItems.Add(inType.Trim());
                lvi.SubItems.Add(Remark_textBox.Text.Trim());
                lvi.SubItems.Add(clientName_textbox.Text.Trim());
                lvi.SubItems.Add(opt_comboBox.Text.ToString());
                lvi.SubItems.Add(returnData);
                returned_listView.Items.Insert(0, lvi);
                inBar_textBox.Text = "";
                outBar_textBox.Text = "";
                inType = "";
                outType = "";
                Remark_textBox.Text = "";
                clientName_textbox.Text = "";
                opt_comboBox.SelectedIndex = 0;
            }
        }

        private void OpeNameInit()
        {
            string strExePath = sysFunction.exePath();
            string strFilePath = strExePath + "\\config\\optTable.ini";
            if (File.Exists(strFilePath))
            {
                StreamReader sr = new StreamReader(
                    strFilePath, System.Text.Encoding.GetEncoding("utf-8"), false);
                while (sr.Peek() > -1)
                {
                    string stp = sr.ReadLine();
                    if (!stp.Equals(""))
                    {
                        opt_comboBox.Items.Add(stp);
                    }
                }
            }
        }

        private void clientNameInit()
        {
            string strExePath = sysFunction.exePath();
            string strFilePath = strExePath + "\\config\\clientTable.ini";
            if (File.Exists(strFilePath))
            {
                StreamReader sr = new StreamReader(
                    strFilePath, System.Text.Encoding.GetEncoding("utf-8"), false);
                while (sr.Peek() > -1)
                {
                    string stp = sr.ReadLine();
                    if (!stp.Equals(""))
                    {
                        clientName_textbox.Items.Add(stp);
                    }
                }
            }
        }

        private bool repeatNumInFile(string strData)
        {
            DBHelper dbHelper = new DBHelper();
            bool sign = dbHelper.
                existsBarcodeReturned(strData, strData);
            return sign;
        }

        public string strInBarReturnTpye(string strInBar)
        {
            string strTpye = "";
            string strTable = "";
            for (int i = 0; i < strInCode.Count; i++)
            {
                strTable = strInCode[i];
                if (strTable == strInBar)
                {
                    strTpye = strAirTpye[i];
                    break;
                }
            }
            return strTpye;
        }
        public string strOutBarReturnTpye(string strOutBar)
        {
            string strTpye = "";
            string strTable = "";
            for (int i = 0; i < strInCode.Count; i++)
            {
                strTable = strOutCode[i];
                if (strTable == strOutBar)
                {
                    strTpye = strAirTpye[i];
                    break;
                }
            }
            return strTpye;
        }

        private void listviewBeforeData(string strInBar, string strOutBar,
            string strTpye, string strRemark, string strOpeNumName,
            string strClientName, string strReturnedDate)
        {
            ListViewItem lv = new ListViewItem();
            lv.Text = strInBar;
            lv.SubItems.Add(strOutBar);
            lv.SubItems.Add(strTpye);
            lv.SubItems.Add(strRemark);
            lv.SubItems.Add(strOpeNumName);
            lv.SubItems.Add(strClientName);
            lv.SubItems.Add(strReturnedDate);
            this.returned_listView.Items.Insert(0, lv);
        }

        private void F2Cannel()
        {

        }

        private void yellowScan()
        {
            this.yellowScan_button.Enabled = false;
            scanFunction.ScanPowerOn();
            scanFunction.OneKeyScan();
            this.yellowScan_button.Enabled = true;
        }
        private void closeForm()
        {
            this.redEsc_button.Enabled = false;
            if (serialPort1.IsOpen)
                closeCommScan();
            this.Close();
        }
        private void closeCommScan()//
        {
            this.serialPort1.Close();
        }
        private void F1Enter()
        {
            this.F1Enter_button.Enabled = false;//save ,clear all data
            OKEnterSave();
            scanFunction.oneBeeper();
            this.F1Enter_button.Enabled = true;
        }

        #region 四个按钮
        private void F1Enter_button_Click(object sender, EventArgs e)
        {
            F1Enter();
        }

        private void yellowScanButton_Click(object sender, EventArgs e)
        {
            yellowScan();
        }


        private void F2Cannel_button_Click(object sender, EventArgs e)
        {
            F2Cannel_button.Enabled = false;
            sysFunction.SipShowIM(0x00);
            inBar_textBox.Text = "";
            outBar_textBox.Text = "";
            Remark_textBox.Text = "";
            opt_comboBox.SelectedIndex = 0;
            F2Cannel_button.Enabled = true;
        }

        private void redEsc_button_Click(object sender, EventArgs e)
        {
            closeForm();
        }
        #endregion

        private void returnedForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                F1Enter();
            else if (e.KeyCode == Keys.F2)
                F2Cannel();
            else if (e.KeyCode == Keys.F6)
                yellowScan();
            else if (e.KeyCode == Keys.Escape)
                closeForm();
            if (e.KeyCode == Keys.Down)
            {
                if (this.inBar_textBox.Focused)
                {
                    this.outBar_textBox.Focus();
                    e.Handled = true;
                    this.outBar_textBox.SelectAll();
                }
                else if (this.outBar_textBox.Focused)
                {
                    this.Remark_textBox.Focus();
                    e.Handled = true;
                    this.Remark_textBox.SelectAll();
                }
                else if (this.Remark_textBox.Focused)
                {
                    this.clientName_textbox.Focus();
                    e.Handled = true;
                }
                else if (this.clientName_textbox.Focused)
                {
                    this.opt_comboBox.Focus();
                    e.Handled = true;
                }
                else if (this.opt_comboBox.Focused)
                {
                    this.opt_comboBox.Focus();
                    e.Handled = true;
                }
                else if (this.opt_comboBox.Focused)
                {
                    this.F1Enter_button.Focus();
                    e.Handled = true;
                }
                else if (this.F1Enter_button.Focused)
                {
                    this.F2Cannel_button.Focus();
                    e.Handled = true;
                }
                else if (this.F2Cannel_button.Focused)
                {
                    this.yellowScan_button.Focus();
                    e.Handled = true;
                }
                else if (this.yellowScan_button.Focused)
                {
                    this.redEsc_button.Focus();
                    e.Handled = true;
                }
            }
            if (e.KeyCode == Keys.Up)
            {
                if (this.redEsc_button.Focused)
                {
                    this.yellowScan_button.Focus();
                    e.Handled = true;
                }
                else if (this.yellowScan_button.Focused)
                {
                    this.F2Cannel_button.Focus();
                    e.Handled = true;
                }
                else if (this.F2Cannel_button.Focused)
                {
                    this.F1Enter_button.Focus();
                    e.Handled = true;
                }
                else if (this.F1Enter_button.Focused)
                {
                    this.opt_comboBox.Focus();
                    e.Handled = true;
                }
                else if (this.opt_comboBox.Focused)
                {
                    this.clientName_textbox.Focus();
                    e.Handled = true;
                }
                else if (this.clientName_textbox.Focused)
                {
                    this.Remark_textBox.Focus();
                    e.Handled = true;
                    this.Remark_textBox.SelectAll();
                }
                else if (this.Remark_textBox.Focused)
                {
                    this.outBar_textBox.Focus();
                    e.Handled = true;
                    outBar_textBox.SelectAll();
                }
                else if (this.outBar_textBox.Focused)
                {
                    this.inBar_textBox.Focus();
                    e.Handled = true;
                    inBar_textBox.SelectAll();
                }
                else if (inBar_textBox.Focused)
                {
                    inBar_textBox.Focus();
                    e.Handled = true;
                    inBar_textBox.SelectAll();
                }
            }
        }


    }
}