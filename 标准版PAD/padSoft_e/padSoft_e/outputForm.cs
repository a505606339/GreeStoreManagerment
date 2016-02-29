using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlServerCe;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Collections;
using System.Xml;

namespace padSoft_e
{
    public partial class outputForm : Form
    {
        string sqlPath = sysFunction.exePath() + @"数据\database.sdf";
        int allNumber = 0;

        public outputForm()
        {
            InitializeComponent();
            sysFunction.ShowWindow(sysFunction.iShowHideWindow(), 1);

            this.outOpt_comboBox.Items.Clear();
            this.outOpt_comboBox.Items.Add("");
            this.outSdr_comboBox.Items.Clear();
            this.outSdr_comboBox.Items.Add("");
            this.outStr_comboBox.Items.Clear();
            this.outStr_comboBox.Items.Add("");
            clientName_textBox.Items.Clear();
            clientName_textBox.Items.Add("");
            readClientName();
            listOutOpt();
            listOutSender();
            listOutSetter();
            inAndOutBarMateInit();
            this.outNum_textBox.Focus();
            openCommScan();
        }

        private void outputForm_Load(object sender, EventArgs e)
        {
            initInOutCode();
            listBeforeNumMoney();
        }

        private void F1Enter()
        {
            this.F1Enter_button.Enabled = false;//save ,clear all data
            if (checkBox_IsMore.Checked == true)
                //saveIsMore();
                saveIsMoreNotPair();
            else
                OKEnterSave();
            this.F1Enter_button.Enabled = true;
        }
        private void F1Enter_button_Click(object sender, EventArgs e)
        {
            F1Enter();
        }
        private void F2Cannel()
        {
            this.F2Cannel_button.Enabled = false;
            sysFunction.SipShowIM(0x00);
            this.inBar_textBox.Text = "";
            this.outBar_textBox.Text = "";
            this.outTpye_textBox.SelectedIndex = -1;
            outTpye_textBox.Items.Clear();
            this.outQty_textBox.Text = "1";
            this.outMoney_textBox.Text = "0";
            this.F2Cannel_button.Enabled = true;
            blFirstEnable = true;
        }
        private void F2Cannel_button_Click(object sender, EventArgs e)
        {
            if (checkBox_IsMore.Checked)
            {
                try
                {
                    if (!string.IsNullOrEmpty(inBar_textBox.Text) ||
                        !string.IsNullOrEmpty(outBar_textBox.Text))
                    {
                        int outsumq = Convert.ToInt32(outSumQty_textBox.Text);
                        outsumq--;
                        outSumQty_textBox.Text = outsumq.ToString();
                    }
                }
                catch { }
                inBar_textBox.Text = "";
                outBar_textBox.Text = "";
                outTpye_textBox.SelectedIndex = -1;
                outTpye_textBox.Items.Clear();
                blFirstEnable = true;
            }
            else
                F2Cannel();
        }
        private void yellowScan()
        {
            this.yellowScan_button.Enabled = false;
            scanFunction.ScanPowerOn();
            scanFunction.OneKeyScan();
            this.yellowScan_button.Enabled = true;
        }
        private bool blScanEnable = true;
        private bool blFirstSaveEnable = true;
        private bool blSecondSaveEnable = true;
        private bool blFirstEnable = true;
        private string contrastInType = "";
        private string contrastOutType = "";
        private void ChangeTextScan(string text)
        {
            textBox_test.Invoke(new EventHandler(delegate
            {
                if (blScanEnable == true)
                {
                    blScanEnable = false;
                    string strBar = text.Trim();
                    if (strBar.Length >= 10)
                    {
                        string strBarcode = strBar.Trim();
                        if (repeatNumInFile(strBar) == false)
                        {
                            string strBarHead = strBarcode.Substring(0, 5);
                            string strRtnInBar = strInCompToOut(strBarHead);
                            string strRtnOutBar = strOutCompToIn(strBarHead);
                            string strRtnTpye = "";
                            if ((strRtnInBar.Length == 5) || ((strRtnOutBar.Length == 5)))
                            {
                                if (blFirstSaveEnable == true)
                                {
                                    if ((strRtnInBar.Length == 5) &&
                                        (this.inBar_textBox.Text == ""))
                                    {
                                        this.inBar_textBox.Text = strBarcode;
                                        strRtnTpye = strInBarReturnTpye(strRtnInBar);
                                        contrastInType = strRtnTpye;
                                    }
                                    else if ((strRtnOutBar.Length == 5) &&
                                        (this.outBar_textBox.Text == ""))
                                    {
                                        this.outBar_textBox.Text = strBarcode;
                                        strRtnTpye = strOutBarReturnTpye(strRtnOutBar);
                                        contrastOutType = strRtnTpye;
                                    }
                                    this.outTpye_textBox.Items.Add(strRtnTpye);
                                    outTpye_textBox.SelectedIndex = 0;
                                    scanFunction.oneBeeper();
                                    if ((this.inBar_textBox.Text.Length >= 10) &&
                                        (this.outBar_textBox.Text.Length >= 10))
                                    {
                                        sysFunction.SipShowIM(0x01);
                                        blFirstSaveEnable = false;
                                    }
                                }
                                else
                                {
                                    if (blSecondSaveEnable == true)
                                    {
                                        blSecondSaveEnable = false;
                                        this.inBar_B_textBox.Text = this.inBar_textBox.Text.Trim();
                                        this.outBar_B_textBox.Text = this.outBar_textBox.Text.Trim();
                                        this.outNum_B_textBox.Text = this.outNum_textBox.Text.Trim();
                                        this.clientName_B_textBox.Text = this.clientName_textBox.Text.Trim();
                                        this.outTpye_B_textBox.Text = this.outTpye_textBox.Text.Trim();
                                        this.outOpt_B_textBox.Text = this.outOpt_comboBox.Text;
                                        this.outSdr_B_textBox.Text = this.outSdr_comboBox.Text;
                                        this.outStr_B_textBox.Text = this.outStr_comboBox.Text;
                                        this.outQty_B_textBox.Text = this.outQty_textBox.Text.Trim();
                                        this.outMoney_B_textBox.Text = this.outMoney_textBox.Text.Trim();
                                        this.inBar_textBox.Text = "";
                                        this.outBar_textBox.Text = "";
                                        //save 
                                        saveBarcode("1");
                                        blFirstEnable = true;
                                    }
                                    if (blFirstEnable == true)
                                    {
                                        sysFunction.SipShowIM(0x00);
                                        if ((strRtnInBar.Length == 5) && (this.inBar_textBox.Text == ""))
                                        {
                                            this.inBar_textBox.Text = strBarcode;
                                            strRtnTpye = strInBarReturnTpye(strRtnInBar);
                                            contrastInType = strRtnTpye;
                                        }
                                        else if ((strRtnOutBar.Length == 5) && (this.outBar_textBox.Text == ""))
                                        {
                                            this.outBar_textBox.Text = strBarcode;
                                            strRtnTpye = strOutBarReturnTpye(strRtnOutBar);
                                            contrastOutType = strRtnTpye;
                                        }
                                        this.outTpye_textBox.Items.Add(strRtnTpye);
                                        outTpye_textBox.SelectedIndex = 0;
                                        scanFunction.oneBeeper();
                                        if ((this.inBar_textBox.Text.Length >= 10) && (this.outBar_textBox.Text.Length >= 10))
                                        {
                                            blSecondSaveEnable = true;
                                            sysFunction.SipShowIM(0x01);
                                            blFirstEnable = false;
                                        }
                                    }
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
                            MessageBox.Show("该条码已存在!");
                        }
                    }
                }
                blScanEnable = true;
            }));
        }
        private void saveBarcode(string strSaveTpye)
        {
            if ((this.inBar_textBox.Text.Length >= 10) && (this.outBar_textBox.Text.Length >= 10))
            {
                string strInBar = "";
                string strOutBar = "";
                string strTpye = "";
                string strOutNum = "";
                string strClientName = "";
                string strOutQty = "";
                string strOutMoney = "";
                string strOutStockName = "";
                string strOutSdr = "";
                string strOutStr = "";
                sysFunction.SipShowIM(0x00);
                if (strSaveTpye == "1")
                {
                    strInBar = this.inBar_B_textBox.Text.Trim();
                    strOutBar = this.outBar_B_textBox.Text.Trim();
                    strTpye = this.outTpye_B_textBox.Text.Trim();
                    strOutNum = this.outNum_B_textBox.Text.Trim();
                    strClientName = this.clientName_B_textBox.Text.Trim();
                    strOutQty = this.outQty_B_textBox.Text.Trim();
                    strOutMoney = this.outMoney_B_textBox.Text.Trim();
                    strOutStockName = this.outOpt_B_textBox.Text.Trim();
                    strOutSdr = this.outSdr_B_textBox.Text.Trim();
                    strOutStr = this.outStr_B_textBox.Text.Trim();
                }
                else if (strSaveTpye == "2")
                {
                    strInBar = this.inBar_textBox.Text.Trim();
                    strOutBar = this.outBar_textBox.Text.Trim();
                    strTpye = this.outTpye_textBox.Text.Trim();
                    strOutNum = this.outNum_textBox.Text.Trim();
                    strClientName = this.clientName_textBox.Text.Trim();
                    strOutQty = this.outQty_textBox.Text.Trim();
                    strOutMoney = this.outMoney_textBox.Text.Trim();
                    strOutStockName = this.outOpt_comboBox.Text;
                    strOutSdr = this.outSdr_comboBox.Text;
                    strOutStr = this.outStr_comboBox.Text;
                }
                string strNowDate = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string strRemark = "";
                bool pairYesOrNo = false;
                //save 
                if (!contrastInType.Equals(contrastOutType))
                {
                    string tmp1;
                    string tmp2;
                    string strInBarPair = strInBar.Substring(0, 5);
                    string strOutBarPair = strOutBar.Substring(0, 5);
                    for (int i = 0; i < strInCode.Count; i++)
                    {
                        tmp1 = strInCode[i];
                        tmp2 = strOutCode[i];
                        if (tmp1 == strInBarPair && tmp2 == strOutBarPair)
                        {
                            pairYesOrNo = true;
                            strTpye = strAirTpye[i];
                            break;
                        }
                    }
                }
                else
                    pairYesOrNo = true;
                if (pairYesOrNo)
                {
                    if (!String.IsNullOrEmpty(strInBar) || !String.IsNullOrEmpty(strInBar))
                    {
                        DBHelper dbHelper = new DBHelper();
                        int changeLine = dbHelper.insertOutTable(strInBar, strOutBar,
                        strTpye, strOutNum, strClientName, strNowDate, strOutQty,
                        strOutMoney, SingletonUser.CurrentUser.AccountName,
                        strOutSdr, strOutStr, strRemark, strOutStockName);
                        if (changeLine < 1)
                        {
                            scanFunction.twoBeeper();
                            MessageBox.Show("新增数据遇到问题,请重新扫描");
                        }
                        else
                        {
                            //sum qty 
                            string strQtyTmp = this.outSumQty_textBox.Text;
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
                                intQty = int.Parse(strOutQty);
                            }
                            catch
                            { }
                            intQty = intQty + intQtyTmp;
                            this.outSumQty_textBox.Text = intQty.ToString();
                            //sum money 
                            string strMnyTmp = this.outSumMoney_textBox.Text;
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
                                fltMny = float.Parse(strOutMoney);
                            }
                            catch
                            { }
                            fltMny = fltMny + fltMnyTmp;
                            this.outSumMoney_textBox.Text = fltMny.ToString();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("内外机不匹配,请取消重扫");
                    return;
                }
            }
            else
            {
            }
        }
        private void OKEnterSave()
        {
            if ((this.inBar_textBox.Text.Length >= 10) 
                && (this.outBar_textBox.Text.Length >= 10))
            {
                saveBarcode("2");
                scanFunction.oneBeeper();
                MessageBox.Show("保存成功");
            }
            this.inBar_B_textBox.Text = "";
            this.inBar_textBox.Text = "";
            this.outBar_B_textBox.Text = "";
            this.outBar_textBox.Text = "";
            this.outNum_B_textBox.Text = "";
            this.outNum_textBox.Text = "";
            this.clientName_B_textBox.Text = "";
            this.clientName_textBox.Text = "";
            this.outTpye_B_textBox.Text = "";
            this.outTpye_textBox.SelectedIndex = -1;
            outTpye_textBox.Items.Clear();
            this.outOpt_B_textBox.Text = "";
            this.outOpt_comboBox.SelectedIndex = 0;
            this.outSdr_B_textBox.Text = "";
            this.outSdr_comboBox.SelectedIndex = 0;
            this.outStr_B_textBox.Text = "";
            this.outStr_comboBox.SelectedIndex = 0;
            this.outQty_B_textBox.Text = "1";
            this.outMoney_B_textBox.Text = "0";
            this.outQty_textBox.Text = "1";
            this.outMoney_textBox.Text = "0";
            blFirstEnable = true;
        }
        private bool repeatNumInFile(string strData)
        {
            bool blRtn = false;
            DBHelper dbHelper = new DBHelper();
            blRtn = dbHelper.existsBarcodeOutTable(strData);
            return blRtn;
        }
        /// <summary>
        /// 检测临时表中是否存在当前扫描条码
        /// </summary>
        /// <param name="strData">当前条码</param>
        /// <returns>true为已存在</returns>
        private bool repeatTempBarcode(string strData)
        {
            DBHelper dbHelper = new DBHelper();
            bool repeatInTempTable = dbHelper.
                existsBarcodeTempInbarcode(strData,strData);
            bool repeatOutTempTable = dbHelper.
                existsBarcodeTempOutbarcode(strData, strData);
            if (repeatInTempTable || repeatOutTempTable)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 检测批量时,暂存在InAndOutBarMate类中的数据是否已经存在 
        /// </summary>
        /// <param name="strData">检测的条码</param>
        /// <returns>true为已存在</returns>
        private bool repeatInAndOutBarMate(string strData)
        {
            bool blRtn = false;
            List<string> tmpInScanList = inAndOutBarMate.scanInBarList;
            foreach (string scan in tmpInScanList)
            {
                string[] scanlist = scan.Split('\t');
                if (scanlist[0] == strData)
                {
                    scanFunction.twoBeeper();
                    MessageBox.Show("此商品编号已存在！");
                    blRtn = true;
                    break;
                }
            }
            if (!blRtn)
            {
                List<string> tmpOutScanList = inAndOutBarMate.scanOutBarList;
                foreach (string scan in tmpOutScanList)
                {
                    string[] scanlist = scan.Split('\t');
                    if (scanlist[1] == strData)
                    {
                        scanFunction.twoBeeper();
                        MessageBox.Show("此商品编号已存在！");
                        blRtn = true;
                        break;
                    }
                }
            }
            return blRtn;
        }

        private void addComboxItems(string strRtnInBar, string strRtnOutBar, string strBarHead)
        {
            if (strRtnInBar.Length == 5)
            {
                for (int i = 0; i < strAirTpye.Count; i++)
                {
                    if (strInCode[i] == strBarHead)
                    {
                        outTpye_textBox.Items.Add(strAirTpye[i]);
                    }
                }
            }
            if (strRtnOutBar.Length == 5)
            {
                for (int i = 0; i < strAirTpye.Count; i++)
                {
                    if (strOutCode[i] == strBarHead)
                    {
                        outTpye_textBox.Items.Add(strAirTpye[i]);
                    }
                }
            }
        }

        private bool openCommScan()
        {
            try
            {
                if (serialPort1.IsOpen)
                {
                    this.serialPort1.Close();
                }
                this.serialPort1.DataReceived += new System.IO.Ports
                    .SerialDataReceivedEventHandler(mycommScan_DataReceived);
                serialPort1.Open();
                if (serialPort1.IsOpen)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        private void closeCommScan()
        {
            this.serialPort1.Close();
        }
        private void mycommScan_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            Thread.Sleep(10); //读取速度太慢，加Sleep延长读取时间, 不可缺少//500:2047   1000:2047

            byte[] readBuffer = new byte[this.serialPort1.BytesToRead];

            this.serialPort1.Read(readBuffer, 0, readBuffer.Length);

            string txt = System.Text.Encoding.Default.GetString(readBuffer, 0, readBuffer.Length);

            if (checkedIsTAndF && txt.Trim().Length >= 10)
            {
                isMore(txt);
            }
            else if (txt.Trim().Length >= 10)
            {
                ChangeTextScan(txt);
            }
        }
        private void yellowScan_button_Click(object sender, EventArgs e)
        {
            yellowScan();
        }
        private void listOutOpt()
        {
            string strExePath = sysFunction.exePath();
            string strFilePath = strExePath + "\\config\\optTable.ini";
            if (File.Exists(strFilePath))
            {
                using (StreamReader reader = new StreamReader(strFilePath,
                    System.Text.Encoding.GetEncoding("utf-8"), false))
                {
                    while (reader.Peek() > -1)
                    {
                        string strTmp = reader.ReadLine();
                        if (strTmp != "")
                        {
                            this.outOpt_comboBox.Items.Add(strTmp);
                        }
                    }
                }
            }
        }
        private void listOutSender()
        {
            string strExePath = sysFunction.exePath();
            string strFilePath = strExePath + "\\config\\sdrTable.ini";
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
                            this.outSdr_comboBox.Items.Add(strTmp);
                        }
                    }
                }
            }
        }
        private void listOutSetter()
        {
            string strExePath = sysFunction.exePath();
            string strFilePath = strExePath + "\\config\\strTable.ini";
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
                            this.outStr_comboBox.Items.Add(strTmp);
                        }
                    }
                }
            }
        }
        //对暂存数组做初始化,以添加上临时入库出库数据 
        //防止重复
        private void inAndOutBarMateInit()
        {
            string tempInTablePath = sysFunction.exePath() + @"\数据\内机临时表.txt";
            string tempOutTablePath = sysFunction.exePath() + @"\数据\外机临时表.txt";
            if (File.Exists(tempInTablePath))
            {
                StreamReader sr = new StreamReader(tempInTablePath);
                string allInTempData = sr.ReadToEnd();
                sr.Close();
                if (allInTempData.Length > 1)
                {
                    string[] listData = Regex.Split(allInTempData,
                        "\r\n", RegexOptions.IgnoreCase);
                    if (listData.Length > 0)
                    {
                        foreach (string items in listData)
                        {
                            if (items.Length >= 10)
                                inAndOutBarMate.scanInBarListSet(items);
                        }
                    }
                }
            }
            if (File.Exists(tempOutTablePath))
            {
                StreamReader sr = new StreamReader(tempOutTablePath);
                string allOutTempData = sr.ReadToEnd();
                sr.Close();
                if (allOutTempData.Length > 1)
                {
                    string[] listData = Regex.Split(allOutTempData,
                        "\r\n", RegexOptions.IgnoreCase);
                    if (listData.Length > 0)
                    {
                        foreach (string items in listData)
                        {
                            if (items.Length >= 10)
                                inAndOutBarMate.scanOutBarListSet(items);
                        }
                    }
                }
            }
        }
        private void readClientName()
        {
            string strExePath = sysFunction.exePath();
            string strFilePath = strExePath + "\\config\\clientTable.ini";
            if (File.Exists(strFilePath))
            {
                StreamReader sr = new StreamReader(strFilePath, UTF8Encoding.UTF8, false);
                while (sr.Peek() > -1)
                {
                    string strTmp = sr.ReadLine();
                    if (strTmp != "")
                        clientName_textBox.Items.Add(strTmp);
                }
            }
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
            }//
        }
        
        private void listBeforeNumMoney()
        {
            SqlCeConnection connet = new SqlCeConnection("Data Source =" + sqlPath); ;
            connet.Open();
            DBHelper dbHelper = new DBHelper();
            SqlCeCommand command = new SqlCeCommand();
            SqlCeDataAdapter adapter = new SqlCeDataAdapter();
            string selectCount = "select count(*) from OutTable";
            DataTable allCount = new DataTable();
            command.CommandText = selectCount;
            command.Connection = connet;
            adapter.SelectCommand = command;
            adapter.Fill(allCount);
            outSumQty_textBox.Text = allCount.Rows[0][0].ToString();
            if (!String.IsNullOrEmpty(outSumQty_textBox.Text.Trim()))
                allNumber = Convert.ToInt32(outSumQty_textBox.Text.Trim());
            connet.Close();
        }
        private void outputForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                F1Enter();
            }
            else if (e.KeyCode == Keys.F2)
            {
                F2Cannel_button_Click(null, null);
            }
            else if (e.KeyCode == Keys.F6)
            {
                yellowScan();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                closeForm();
            }
            else if (e.KeyCode == Keys.F5)
            {
                btnOutDataList_Click(null, null);
            }
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
                    this.outNum_textBox.Focus();
                    e.Handled = true;
                    this.outNum_textBox.SelectAll();
                }
                else if (this.outNum_textBox.Focused)
                {
                    this.outTpye_textBox.Focus();
                    e.Handled = true;
                }
                else if (this.outTpye_textBox.Focused)
                {
                    this.clientName_textBox.Focus();
                    e.Handled = true;
                }
                else if (this.clientName_textBox.Focused)
                {
                    this.outOpt_comboBox.Focus();
                    e.Handled = true;
                }
                else if (this.outOpt_comboBox.Focused)
                {
                    this.outSdr_comboBox.Focus();
                    e.Handled = true;
                }
                else if (this.outSdr_comboBox.Focused)
                {
                    this.outStr_comboBox.Focus();
                    e.Handled = true;
                }
                else if (this.outStr_comboBox.Focused)
                {
                    this.outQty_textBox.Focus();
                    e.Handled = true;
                    this.outQty_textBox.SelectAll();
                }
                else if (this.outQty_textBox.Focused)
                {
                    this.outMoney_textBox.Focus();
                    e.Handled = true;
                    this.outMoney_textBox.SelectAll();
                }
                else if (this.outMoney_textBox.Focused)
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
                    this.outMoney_textBox.Focus();
                    e.Handled = true;
                    this.outMoney_textBox.SelectAll();
                }
                else if (this.outMoney_textBox.Focused)
                {
                    this.outQty_textBox.Focus();
                    e.Handled = true;
                    this.outQty_textBox.SelectAll();
                }
                else if (this.outQty_textBox.Focused)
                {
                    this.outStr_comboBox.Focus();
                    e.Handled = true;
                }
                else if (this.outStr_comboBox.Focused)
                {
                    this.outSdr_comboBox.Focus();
                    e.Handled = true;
                }
                else if (this.outSdr_comboBox.Focused)
                {
                    this.outOpt_comboBox.Focus();
                    e.Handled = true;
                }
                else if (this.outOpt_comboBox.Focused)
                {
                    this.clientName_textBox.Focus();
                    e.Handled = true;
                }
                else if (this.clientName_textBox.Focused)
                {
                    this.outTpye_textBox.Focus();
                    e.Handled = true;
                }
                else if (this.outTpye_textBox.Focused)
                {
                    this.outNum_textBox.Focus();
                    e.Handled = true;
                    this.outNum_textBox.SelectAll();
                }
                else if (this.outNum_textBox.Focused)
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

        #region 点击了批量选项

        private bool checkedIsTAndF = false;
        InAndOutBarMate inAndOutBarMate = new InAndOutBarMate();
        List<string> noSave = new List<string>();
        /// <summary>
        /// 处理获取的条码,并把它存到临时列表中
        /// </summary>
        /// <param name="barText">获取的条码</param>
        private void isMore(string barText)
        {
            textBox_test.Invoke(new EventHandler(delegate
            {
                if (repeatNumInFile(barText) || repeatTempBarcode(barText))
                //|| repeatInAndOutBarMate(barText))
                {
                    scanFunction.twoBeeper();
                    MessageBox.Show("该条码已经存在");
                }
                else
                {
                    if (barText != inBar_textBox.Text && barText != outBar_textBox.Text)
                    {
                        //第一次传来时的条码是内机或外机,做标识 
                        string strBarHead = barText.Substring(0, 5);
                        int thisinbarindex = strInCode.IndexOf(strBarHead);
                        int thisoutbarindex = strOutCode.IndexOf(strBarHead);
                        barText = barText.Trim();
                        if (inBar_textBox.Text == "" && outBar_textBox.Text == "")//第一次开始批量录入
                        {

                            if (thisinbarindex >= 0)
                            {
                                outTpye_textBox.Items.Clear();
                                addComboxItems(strBarHead, "", strBarHead);
                                inBar_textBox.Text = barText;
                                outTpye_textBox.SelectedIndex = 0;
                                //outTpye_textBox.Text = strAirTpye[thisinbarindex];
                                outBar_textBox.Text = "";
                                //try
                                //{
                                //    int sum = Convert.ToInt32(outSumQty_textBox.Text);
                                //    sum++;
                                //    outSumQty_textBox.Text = sum.ToString();
                                //}
                                //catch
                                //{
                                //    outSumQty_textBox.Text = "1";
                                //}
                                if (outTpye_textBox.Items.Count > 1)
                                {
                                    scanFunction.oneBeeper();
                                    Thread.Sleep(100);
                                    scanFunction.oneBeeper();
                                    Thread.Sleep(100);
                                    scanFunction.oneBeeper();
                                }
                                else
                                    scanFunction.oneBeeper();
                            }
                            else if (thisoutbarindex >= 0)
                            {
                                outTpye_textBox.Items.Clear();
                                addComboxItems("", strBarHead, strBarHead);
                                inBar_textBox.Text = "";
                                outBar_textBox.Text = barText;
                                outTpye_textBox.SelectedIndex = 0;
                                //try
                                //{
                                //    int sum = Convert.ToInt32(outSumQty_textBox.Text);
                                //    sum++;
                                //    outSumQty_textBox.Text = sum.ToString();
                                //}
                                //catch
                                //{
                                //    outSumQty_textBox.Text = "1";
                                //}
                                //outTpye_textBox.Text = strAirTpye[thisoutbarindex];
                                if (outTpye_textBox.Items.Count > 1)
                                {
                                    scanFunction.oneBeeper();
                                    Thread.Sleep(100);
                                    scanFunction.oneBeeper();
                                    Thread.Sleep(100);
                                    scanFunction.oneBeeper();
                                }
                                else
                                    scanFunction.oneBeeper();
                            }
                            else
                            {
                                scanFunction.twoBeeper();
                                MessageBox.Show("未在配置表中查找到该机型,请检查型号条码配置表");
                            }
                        }
                        else
                        {
                            int inBarIndex = -1;
                            int outBarIndex = -1;
                            int thisInbarIndex = strInCode
                                .IndexOf(barText.Substring(0, 5));//当前扫描的是内或外
                            int thisOutbarIndex = strOutCode
                                .IndexOf(barText.Substring(0, 5));
                            if (!String.IsNullOrEmpty(inBar_textBox.Text.Trim()))
                            {
                                inBarIndex = strInCode
                                    .IndexOf(inBar_textBox.Text.Trim()
                                    .Substring(0, 5));//截取特征码并获取是否存在匹配表内
                            }
                            if (!String.IsNullOrEmpty(outBar_textBox.Text.Trim()))
                            {
                                outBarIndex = strOutCode
                                    .IndexOf(outBar_textBox.Text.Trim().Substring(0, 5));
                            }
                            if (barText.Length >= 13)
                            {
                                if (thisInbarIndex >= 0)//假如当前扫描条码为内机条码 
                                {
                                    if (!String.IsNullOrEmpty(
                                        outBar_textBox.Text.Trim()))//上次扫描为外机条码
                                    {
                                        saveTemporaryData(inBar_textBox.Text.Trim(),
                                            outBar_textBox.Text.Trim(),
                                            outTpye_textBox.Text.Trim(),
                                            outNum_textBox.Text.Trim(),
                                            clientName_textBox.Text.Trim(),
                                            System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                                            outQty_textBox.Text.Trim(),
                                            outMoney_textBox.Text.Trim(),
                                            outOpt_comboBox.Text.Trim(),
                                            outSdr_comboBox.Text.Trim(),
                                            outStr_comboBox.Text.Trim(),
                                            "");
                                        outTpye_textBox.Items.Clear();
                                        addComboxItems(strBarHead, "", strBarHead);
                                        inBar_textBox.Text = barText.Trim();
                                        outBar_textBox.Text = "";
                                        outTpye_textBox.SelectedIndex = 0;
                                        if (outTpye_textBox.Items.Count > 1)
                                        {
                                            scanFunction.oneBeeper();
                                            Thread.Sleep(100);
                                            scanFunction.oneBeeper();
                                            Thread.Sleep(100);
                                            scanFunction.oneBeeper();
                                        }
                                        else
                                            scanFunction.oneBeeper();
                                    }
                                    else//上次扫描也是内机条码
                                    {
                                        saveTemporaryData(inBar_textBox.Text.Trim(),
                                            outBar_textBox.Text.Trim(),
                                            outTpye_textBox.Text.Trim(),
                                            outNum_textBox.Text.Trim(),
                                            clientName_textBox.Text.Trim(),
                                            System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                                            outQty_textBox.Text.Trim(),
                                            outMoney_textBox.Text.Trim(),
                                            outOpt_comboBox.Text.Trim(),
                                            outSdr_comboBox.Text.Trim(),
                                            outStr_comboBox.Text.Trim(),
                                            "");
                                        outTpye_textBox.Items.Clear();
                                        addComboxItems(strBarHead, "", strBarHead);
                                        inBar_textBox.Text = barText.Trim();
                                        outBar_textBox.Text = "";
                                        outTpye_textBox.SelectedIndex = 0;
                                        if (outTpye_textBox.Items.Count > 1)
                                        {
                                            scanFunction.oneBeeper();
                                            Thread.Sleep(100);
                                            scanFunction.oneBeeper();
                                            Thread.Sleep(100);
                                            scanFunction.oneBeeper();
                                        }
                                        else
                                            scanFunction.oneBeeper();
                                    }
                                }
                                else if (thisOutbarIndex >= 0)//当前扫描条码为外机条码
                                {
                                    saveTemporaryData(inBar_textBox.Text.Trim(),
                                            outBar_textBox.Text.Trim(),
                                            outTpye_textBox.Text.Trim(),
                                            outNum_textBox.Text.Trim(),
                                            clientName_textBox.Text.Trim(),
                                            System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                                            outQty_textBox.Text.Trim(),
                                            outMoney_textBox.Text.Trim(),
                                            outOpt_comboBox.Text.Trim(),
                                            outSdr_comboBox.Text.Trim(),
                                            outStr_comboBox.Text.Trim(),
                                            "");
                                    outTpye_textBox.Items.Clear();
                                    addComboxItems("", strBarHead, strBarHead);
                                    inBar_textBox.Text = "";
                                    outBar_textBox.Text = barText.Trim();
                                    outTpye_textBox.SelectedIndex = 0;
                                    if (outTpye_textBox.Items.Count > 1)
                                    {
                                        scanFunction.oneBeeper();
                                        Thread.Sleep(100);
                                        scanFunction.oneBeeper();
                                        Thread.Sleep(100);
                                        scanFunction.oneBeeper();
                                    }
                                    else
                                        scanFunction.oneBeeper();
                                }
                                else
                                {
                                    scanFunction.oneBeeper();
                                    MessageBox.Show("未在配置表中查找到该机型,请检查型号条码配置表");
                                }
                            }
                            else
                                MessageBox.Show("获取的条码长度异常");

                        }
                    }
                    else
                    {
                        scanFunction.twoBeeper();
                        MessageBox.Show("条码已存在");
                    }
                }
            }));
        }

        private void saveTemporaryData(string inbarcode, string outbarcode,
            string type, string outNumber, string clientName, string dateTime,
            string outQty, string outMoney, string outOpt, string outSdr,
            string outStr, string remark,string stockName)
        {
            if (!String.IsNullOrEmpty(inbarcode) ||
                !String.IsNullOrEmpty(outbarcode))
            {
                DBHelper dbHelper = new DBHelper();
                if (!String.IsNullOrEmpty(inbarcode))
                {
                    dbHelper.InsertTempInTable(inbarcode, outbarcode, type,outNumber,clientName,
                        dateTime,outQty,outMoney,outOpt,outSdr,outStr,remark,stockName);
                }
                if (!String.IsNullOrEmpty(outbarcode))
                {
                    dbHelper.InsertTempOutTable(inbarcode, outbarcode, type);
                }
            }
        }

        //将数组中的条码数据写入临时的记事本 
        private void saveIsMoreNotPair()
        {
            if (!string.IsNullOrEmpty(inBar_textBox.Text.Trim()) ||
                !string.IsNullOrEmpty(outBar_textBox.Text.Trim()))
            {
                saveTemporaryData(inBar_textBox.Text.Trim(),
                    outBar_textBox.Text.Trim(),
                    outTpye_textBox.Text.Trim(),
                    outNum_textBox.Text.Trim(),
                    clientName_textBox.Text.Trim(),
                    System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    outQty_textBox.Text.Trim(),
                    outMoney_textBox.Text.Trim(),
                    SingletonUser.CurrentUser.AccountName,
                    outSdr_comboBox.Text.Trim(),
                    outStr_comboBox.Text.Trim(),
                    "", outOpt_comboBox.Text.Trim());
                scanFunction.oneBeeper();
                //clearTextBox();
                outTpye_textBox.SelectedIndex = -1;
                outTpye_textBox.Items.Clear();
                clientName_textBox.SelectedIndex = -1;
                clientName_textBox.Text = "";
                outNum_textBox.Text = "";
                outNum_B_textBox.Text = "";
                inBar_textBox.Text = "";
                outBar_textBox.Text = "";
                MessageBox.Show("保存成功");
            }
            else
                MessageBox.Show("未检测到任何数据,请检查");
        }

        private void clearTextBox()
        {
            outMoney_textBox.Text = "0";
            outQty_textBox.Text = "1";
        }

        private void checkBox_IsMore_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBox_IsMore.Checked)
            {
                checkBox_IsMore.Enabled = false;
                F1Enter_button.Text = "保存(F1键)";
                checkedIsTAndF = true;
            }
        }

        #endregion

        private void btnOutDataList_Click(object sender, EventArgs e)
        {
            if (checkedIsTAndF)
            {
                pairedForm pairedForm = new pairedForm();
                pairedForm.ShowDialog();
            }
            else
            {
                OutDataListForm outDataListForm = new OutDataListForm();
                outDataListForm.ShowDialog();
            }
        }

    }
}