using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlServerCe;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Xml;

namespace padSoft_e
{
    public partial class inputForm : Form
    {
        string sqlPath = sysFunction.exePath() + @"数据\database.sdf";
        int allNumber = 0;
        public inputForm()
        {
            InitializeComponent();
            //initListview();
            openCommScan();
            this.inStockName_comboBox.Items.Clear();
            this.inStockName_comboBox.Items.Add("");
            listInStockName();
            this.inNum_textBox.Focus();
        }

        private void F1Enter()
        {   
            this.F1Enter_button.Enabled = false;//save ,clear all data 
            OKEnterSave();
        }
        private void F1Enter_button_Click(object sender, EventArgs e)
        {
            F1Enter();
        }
        private void F2Cannel()
        {
            try
            {
                if (!string.IsNullOrEmpty(inBar_textBox.Text) ||
                    !string.IsNullOrEmpty(outBar_textBox.Text))
                {
                    int outsumq = Convert.ToInt32(inSumQty_textBox.Text);
                    outsumq--;
                    inSumQty_textBox.Text = outsumq.ToString();
                }
            }
            catch { }
            this.F2Cannel_button.Enabled = false;
            //sysFunction.SipShowIM(0x00);
            this.inBar_textBox.Text = "";
            this.inBar_B_textBox.Text = "";
            this.outBar_textBox.Text = "";
            this.outBar_B_textBox.Text = "";
            //this.inNum_textBox.Text = "";
            this.inNum_B_textBox.Text = "";
            //this.inName_textBox.Text = "";
            this.inName_B_textBox.Text = "";
            inTpye_B_textBox.Text = "";
            inTpye_textBox.SelectedIndex = -1;
            //this.inOpt_comboBox.SelectedIndex = 0;
            this.inOpt_B_textBox.Text = "";
            this.F2Cannel_button.Enabled = true;
            blFirstEnable = true;
        }
        private void F2Cannel_button_Click(object sender, EventArgs e)
        {
            F2Cannel();
        }
        private void yellowScan()
        {
            this.yellowScan_button.Enabled = false;
            scanFunction.ScanPowerOn();
            scanFunction.OneKeyScan();
            this.yellowScan_button.Enabled = true;
        }
        private void yellowScan_button_Click(object sender, EventArgs e)
        {
            yellowScan();
        }

        private bool blScanEnable = true;
        private bool blFirstEnable = true;
        private void ChangeTextScan(string text)
        {
            textBox_test.Invoke(new EventHandler(delegate
            {
                if (text.Trim() != inBar_textBox.Text &&
                    text.Trim() != outBar_textBox.Text &&
                    text.Trim() != inBar_B_textBox.Text &&
                    text.Trim() != outBar_B_textBox.Text)
                {
                    bool numadd = false;
                    if (blScanEnable == true)
                    {
                        blScanEnable = false;
                        string strBar = text.Trim();
                        //MessageBox.Show(strBar );
                        if (strBar.Length >= 10)
                        {
                            string strBarcode = strBar.Trim();
                            if (!repeatNumInFile(strBar))
                            {
                                string strBarHead = strBarcode.Substring(0, 5);
                                string strRtnInBar = strInCompToOut(strBarHead);
                                string strRtnOutBar = strOutCompToIn(strBarHead);
                                string strRtnTpye = "";
                                if ((strRtnInBar.Length == 5) || ((strRtnOutBar.Length == 5)))
                                {
                                    if (blFirstEnable == true)
                                    {
                                        //blFirstEnable = false;
                                        inTpye_textBox.Items.Clear();
                                        addComboxItems(strRtnInBar, strRtnOutBar, strBarHead);
                                        if (strRtnInBar.Length == 5)
                                        {
                                            this.inBar_textBox.Text = strBarcode;
                                            this.inTpye_textBox.SelectedIndex = 0;
                                        }
                                        else if (strRtnOutBar.Length == 5)
                                        {
                                            this.outBar_textBox.Text = strBarcode;
                                            this.inTpye_textBox.SelectedIndex = 0;
                                        }
                                        if (inTpye_textBox.Items.Count > 1)
                                        {
                                            scanFunction.oneBeeper();
                                            Thread.Sleep(100);
                                            scanFunction.oneBeeper();
                                            Thread.Sleep(100);
                                            scanFunction.oneBeeper();
                                        }
                                        else
                                            scanFunction.oneBeeper();
                                        numadd = true;
                                        blFirstEnable = false;
                                    }
                                    else
                                    {
                                        this.inBar_B_textBox.Text = this.inBar_textBox.Text;
                                        this.outBar_B_textBox.Text = this.outBar_textBox.Text;
                                        this.inNum_B_textBox.Text = this.inNum_textBox.Text;
                                        this.inName_B_textBox.Text = this.inName_textBox.Text;
                                        this.inTpye_B_textBox.Text = this.inTpye_textBox.Text;
                                        this.inOpt_B_textBox.Text = this.inStockName_comboBox.Text;
                                        this.inQty_B_textBox.Text = this.inQty_textBox.Text;
                                        this.inMoney_B_textBox.Text = this.inMoney_textBox.Text;
                                        sysFunction.SipShowIM(0x01);
                                        numadd = true;
                                        if (strRtnInBar.Length == 5)
                                        {
                                            this.inBar_textBox.Text = strBarcode;
                                            this.outBar_textBox.Text = "";
                                        }
                                        else if (strRtnOutBar.Length == 5)
                                        {
                                            this.inBar_textBox.Text = "";
                                            this.outBar_textBox.Text = strBarcode;
                                        }
                                        saveBarcode("1");
                                        inTpye_textBox.Items.Clear();
                                        addComboxItems(strRtnInBar, strRtnOutBar, strBarHead);
                                        if (inTpye_textBox.Items.Count > 1)
                                        {
                                            scanFunction.oneBeeper();
                                            Thread.Sleep(100);
                                            scanFunction.oneBeeper();
                                            Thread.Sleep(100);
                                            scanFunction.oneBeeper();
                                        }
                                        else
                                            scanFunction.oneBeeper();
                                        inTpye_textBox.SelectedIndex = 0;
                                    }
                                }
                                else
                                {
                                    scanFunction.twoBeeper();
                                    MessageBox.Show("未在配置表中查找到该机型,请检查型号条码配置表");
                                }
                            }
                            else
                            {
                                scanFunction.twoBeeper();
                                MessageBox.Show("商品已存在!");
                            }
                            if (numadd)
                            {
                                //sum qty
                                string strQtyTmp = this.inSumQty_textBox.Text;
                                int intQtyTmp = 0;
                                try
                                {
                                    intQtyTmp = int.Parse(strQtyTmp);
                                }
                                catch
                                { }
                                int intQty = 0;
                                try
                                {
                                    intQty = 1;
                                }
                                catch
                                { }
                                intQty = intQty + intQtyTmp;
                                this.inSumQty_textBox.Text = intQty.ToString();
                                //sum money
                                string strMnyTmp = this.inSumMoney_textBox.Text;
                                float fltMnyTmp = 0;
                                try
                                {
                                    fltMnyTmp = float.Parse(strMnyTmp);
                                }
                                catch
                                { }
                                float fltMny = 0;
                                try
                                {
                                    fltMny = 0;
                                }
                                catch
                                { }
                                fltMny = fltMny + fltMnyTmp;
                                this.inSumMoney_textBox.Text = fltMny.ToString();
                            }
                        }
                    }
                    blScanEnable = true;
                }
                else
                {
                    scanFunction.twoBeeper();
                    MessageBox.Show("条码已存在");
                }
            }));
        }

        private void addComboxItems(string strRtnInBar, string strRtnOutBar, string strBarHead)
        {
            if (strRtnOutBar.Length == 5)
            {
                for (int i = 0; i < strAirTpye.Count; i++)
                {
                    if (strOutCode[i] == strBarHead)
                    {
                        inTpye_textBox.Items.Add(strAirTpye[i]);
                    }
                }
            }
            if (strRtnInBar.Length == 5)
            {
                for (int i = 0; i < strAirTpye.Count; i++)
                {
                    if (strInCode[i] == strBarHead)
                    {
                        inTpye_textBox.Items.Add(strAirTpye[i]);
                    }
                }
            }
        }   

        private void saveBarcode(string strSaveTpye)
        {
            string strInBar = "";
            string strOutBar = "";
            string strInNum = "";
            string strInNumName = "";
            string strInTpye = "";
            string strStockName = "";
            string strQty = "";
            string strMoney = "";
            sysFunction.SipShowIM(0x00);
            DBHelper dbHelper = new DBHelper();
            if (strSaveTpye == "1")
            {
                strInBar = this.inBar_B_textBox.Text.Trim();
                strOutBar = this.outBar_B_textBox.Text.Trim();
                strInNum = this.inNum_B_textBox.Text.Trim();
                strInNumName = this.inName_B_textBox.Text.Trim();
                strInTpye = this.inTpye_B_textBox.Text.Trim();
                strStockName = this.inOpt_B_textBox.Text.Trim();
                strQty = this.inQty_B_textBox.Text.Trim();
                strMoney = this.inMoney_B_textBox.Text.Trim();
                //如果检测到按了保存后已经是存在的条码,则跳出
                if (strInBar == "")//假如inbar为空,说明是外机,则遍历外机码是否存在
                {
                    if (dbHelper.existsBarcodeInTable(strOutBar))
                    {
                        scanFunction.twoBeeper();
                        MessageBox.Show("此商品编号已存在");
                        return;
                    }
                }
                else if (strOutBar == "")//outbar为空,则为内机,遍历内机码是否存在
                {
                    if (dbHelper.existsBarcodeInTable(strInBar))
                    {
                        scanFunction.twoBeeper();
                        MessageBox.Show("此商品编号已存在");
                        return;
                    }
                }
            }
            else if (strSaveTpye == "2")//OK 
            {
                strInBar = this.inBar_textBox.Text.Trim();
                strOutBar = this.outBar_textBox.Text.Trim();
                strInNum = this.inNum_textBox.Text.Trim();
                strInNumName = this.inName_textBox.Text.Trim();
                strInTpye = this.inTpye_textBox.Text.Trim();
                strStockName = this.inStockName_comboBox.Text;
                strQty = this.inQty_textBox.Text.Trim();
                strMoney = this.inMoney_textBox.Text.Trim();
                //如果检测到按了保存后已经是存在的条码,则跳出
                if (strInBar == "")//假如inbar为空,说明是外机,则遍历外机码是否存在
                {
                    if (dbHelper.existsBarcodeInTable(strOutBar))
                    {
                        scanFunction.twoBeeper();
                        MessageBox.Show("此商品编号已存在");
                        return;
                    }
                }
                else if (strOutBar == "")//outbar为空,则为内机,遍历内机码是否存在  
                {
                    if (dbHelper.existsBarcodeInTable(strInBar))
                    {
                        scanFunction.twoBeeper();
                        MessageBox.Show("此商品编号已存在");
                        return;
                    }
                }
            }
            string strNowDate = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string strRemark = "";
            //save 
            if (strInBar.Length >= 10 || strOutBar.Length >= 10)
            {
                int affectRow = dbHelper.insertInTable(strInBar, strOutBar, strInTpye,
                    strInNum, strInNumName, strNowDate, strQty, strMoney,
                    SingletonUser.CurrentUser.AccountName, strRemark, strStockName);
                if (affectRow < 1)
                {
                    scanFunction.twoBeeper();
                    MessageBox.Show("新增数据遇到问题,请重新扫描");
                }
            }
        }

        private void OKEnterSave()
        {
            if ((this.inBar_textBox.Text.Length >= 10) || (this.outBar_textBox.Text.Length >= 10))
            {
                saveBarcode("2");
                scanFunction.oneBeeper();
                MessageBox.Show("保存成功");
            }
            this.inBar_B_textBox.Text = "";
            this.inBar_textBox.Text = "";
            this.outBar_B_textBox.Text = "";
            this.outBar_textBox.Text = "";
            this.inNum_B_textBox.Text = "";
            this.inNum_textBox.Text = "";
            this.inName_B_textBox.Text = "";
            this.inName_textBox.Text = "";
            this.inTpye_B_textBox.Text = "";
            this.inTpye_textBox.SelectedIndex = -1;
            this.inOpt_B_textBox.Text = "";
            this.inStockName_comboBox.SelectedIndex = 0;
            this.inQty_B_textBox.Text = "0";
            this.inQty_textBox.Text = "1";
            this.inMoney_B_textBox.Text = "0";
            this.inMoney_textBox.Text = "0";
            F1Enter_button.Enabled = true;
            blFirstEnable = true;
        }

        /******** comm ********/
        private bool openCommScan()
        {
            if (serialPort1.IsOpen)
            {
                this.serialPort1.Close();
            }
            //  textChanged += new UpdateTextEventHandler(ChangeTextBt);
            this.serialPort1.DataReceived += new System
                .IO.Ports.SerialDataReceivedEventHandler(mycommScan_DataReceived);
            try
            {
                serialPort1.Open();
            }
            catch (Exception ex)
            {
                //comm = new SerialPort();  
                MessageBox.Show(ex.Message);
            }
            if (serialPort1.IsOpen)
                return true;
            else
                return false;
        }
        private void closeCommScan()
        {
            this.serialPort1.Close();
        }
        private void mycommScan_DataReceived(object sender,
            System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            Thread.Sleep(10); //读取速度太慢，加Sleep延长读取时间, 不可缺少//500:2047   1000:2047

            byte[] readBuffer = new byte[this.serialPort1.BytesToRead];

            this.serialPort1.Read(readBuffer, 0, readBuffer.Length);

            string txt = System.Text.Encoding.Default.GetString(readBuffer, 0, readBuffer.Length);

            ChangeTextScan(txt);
        }

        private bool repeatNumInFile(string strData)
        {
            bool blRtn = false;
            DBHelper dbHelper = new DBHelper();
            blRtn = dbHelper.existsBarcodeInTable(strData);
            return blRtn;
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
        public string strInCompToOut(string strInBarCode)
        {
            string strOutBarCode = "";
            string strTable = "";
            for (int i = 0; i < strInCode.Count; i++)
            {
                strTable = strInCode[i];
                if (strTable == strInBarCode)
                {
                    strOutBarCode = strInCode[i];
                    break;
                }
            }
            return strOutBarCode;
        }
        public string strOutCompToIn(string strOutBarCode)
        {
            string strInBarCode = "";
            string strTable = "";
            for (int i = 0; i < strOutCode.Count; i++)
            {
                strTable = strOutCode[i];
                if (strTable == strOutBarCode)
                {
                    strInBarCode = strOutCode[i];
                    break;
                }
            }
            return strInBarCode;
        }
        public List<string> strInCode = new List<string>();
        public List<string> strOutCode = new List<string>();
        public List<string> strAirTpye = new List<string>();
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
        //沿用以前的写法 实际读取仓库名
        private void listInStockName()
        {
            string strExePath = sysFunction.exePath();
            string strFilePath = strExePath + "\\config\\optTable.ini";
            if (File.Exists(strFilePath))
            {
                using (StreamReader reader = new StreamReader(
                    strFilePath, System.Text.Encoding.GetEncoding("utf-8"), false))
                {
                    while (reader.Peek() > -1)
                    {
                        string strTmp = reader.ReadLine();
                        if (strTmp != "")
                        {
                            this.inStockName_comboBox.Items.Add(strTmp);
                        }
                    }
                }
            }
        }
        
        private void listBeforeNumMoney()
        {
            SqlCeConnection connet = new SqlCeConnection("Data Source =" + sqlPath);
            connet.Open();
            SqlCeCommand command = new SqlCeCommand();
            SqlCeDataAdapter adapter = new SqlCeDataAdapter();
            string selectCount = "select count(*) from InTable";
            DataTable allCount = new DataTable();
            command.CommandText = selectCount;
            command.Connection = connet;
            adapter.SelectCommand = command;
            adapter.Fill(allCount);
            inSumQty_textBox.Text = allCount.Rows[0][0].ToString();
            if (!String.IsNullOrEmpty(inSumQty_textBox.Text.Trim()))
                allNumber = Convert.ToInt32(inSumQty_textBox.Text.Trim());
            connet.Close();
        }
        private void inputForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                F1Enter();
            else if (e.KeyCode == Keys.F2)
                F2Cannel_button_Click(null, null);
            else if (e.KeyCode == Keys.F6)
                yellowScan();
            else if (e.KeyCode == Keys.Escape)
                closeForm();
            else if (e.KeyCode == Keys.F5)
                btnScanBarcodeView_Click_1(null, null);
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
                    this.inNum_textBox.Focus();
                    e.Handled = true;
                    this.inNum_textBox.SelectAll();
                }
                else if (this.inNum_textBox.Focused)
                {
                    this.inName_textBox.Focus();
                    e.Handled = true;
                    this.inName_textBox.SelectAll();
                }
                else if (this.inName_textBox.Focused)
                {
                    this.inTpye_textBox.Focus();
                    e.Handled = true;
                    this.inName_textBox.SelectAll();
                }
                else if (this.inTpye_textBox.Focused)
                {
                    this.inStockName_comboBox.Focus();
                    e.Handled = true;
                }
                else if (this.inStockName_comboBox.Focused)
                {
                    this.inQty_textBox.Focus();
                    e.Handled = true;
                    this.inQty_textBox.SelectAll();
                }
                else if (this.inQty_textBox.Focused)
                {
                    this.inMoney_textBox.Focus();
                    e.Handled = true;
                    this.inMoney_textBox.SelectAll();
                }
                else if (this.inMoney_textBox.Focused)
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
                    this.inMoney_textBox.Focus();
                    e.Handled = true;
                    this.inMoney_textBox.SelectAll();
                }
                else if (this.inMoney_textBox.Focused)
                {
                    this.inQty_textBox.Focus();
                    e.Handled = true;
                    this.inQty_textBox.SelectAll();
                }
                else if (this.inQty_textBox.Focused)
                {
                    this.inStockName_comboBox.Focus();
                    e.Handled = true;
                }
                else if (this.inStockName_comboBox.Focused)
                {
                    this.inTpye_textBox.Focus();
                    e.Handled = true;
                }
                else if (this.inTpye_textBox.Focused)
                {
                    this.inName_textBox.Focus();
                    e.Handled = true;
                    this.inName_textBox.SelectAll();
                }
                else if (this.inName_textBox.Focused)
                {
                    this.inNum_textBox.Focus();
                    e.Handled = true;
                    this.inNum_textBox.SelectAll();
                }
                else if (this.inNum_textBox.Focused)
                {
                    this.outBar_textBox.Focus();
                    e.Handled = true;
                    this.outBar_textBox.SelectAll();
                }
                else if (this.outBar_textBox.Focused)
                {
                    this.inBar_textBox.Focus();
                    e.Handled = true;
                    this.inBar_textBox.SelectAll();
                }
            }
        }
        private void closeForm()
        {
            //connet.Close();
            this.redEsc_button.Enabled = false;
            if (serialPort1.IsOpen)
                closeCommScan();
            this.Close();
        }
        private void redEsc_button_Click(object sender, EventArgs e)
        {
            closeForm();
        }

        private void inNum_textBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnScanBarcodeView_Click(object sender, EventArgs e)
        {

        }

        private void inputForm_Load(object sender, EventArgs e)
        {
            initInOutCode();
            listBeforeNumMoney();
            //listBeforeData();
        }

        private void btnScanBarcodeView_Click_1(object sender, EventArgs e)
        {
            InDateListForm inDateView = new InDateListForm();
            inDateView.ShowDialog();
        }
    }
}