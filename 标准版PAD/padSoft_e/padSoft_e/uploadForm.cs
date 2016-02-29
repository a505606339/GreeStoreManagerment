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
using System.Net;
using System.Net.Sockets;

namespace padSoft_e
{
    public partial class uploadForm : Form
    {
        string sqlPath = sysFunction.exePath() + @"����\database.sdf";
        SqlCeConnection connet;
        public uploadForm()
        {
            InitializeComponent();
            sysFunction.ShowWindow(sysFunction.iShowHideWindow(), 1);
            this.textBox_rssi.Text = "��������";
            wifiFunction.powerOnWiFi();
            this.ipAddr_textBox.Text = sysFunction.readTcpIpAddrNum();
            this.timer1.Interval = 6000;
            this.timer1.Enabled = true;
            this.upload_button.Enabled = false;
            this.redEsc_button.Enabled = false;
        }

        private void uploadDataButton()
        {
            this.upload_button.Enabled = false;
            uploadData();
            this.upload_button.Enabled = true;
        }
        private void upload_button_Click(object sender, EventArgs e)
        {
            uploadDataButton();
        }
        private bool blInOk = false;
        private bool nullInUp = false;
        private bool blOutOk = false;
        private bool nullOutUp = false;
        private bool blReOk = false;
        private bool nullReUp = false;
        private void uploadData()
        {
            DBHelper dbHelper = new DBHelper();
            //this.upload_button.Enabled = false;
            //btn_uploadPair.Enabled = false;
            if (blLinkServerOk == true)
            {
                string strExePath = sysFunction.exePath();
                string strInFilePath = strExePath + "\\����\\database.sdf";
                string inText = "";
                string outText = "";
                string reText = "";
                StringBuilder insb = new StringBuilder();
                StringBuilder outsb = new StringBuilder();
                StringBuilder resb = new StringBuilder();
                //  int intTime = 0;
                //��ȡ�ļ���ʼ
                if (File.Exists(strInFilePath))
                {
                    /*
                     * �������
                     * 
                    */
                    try
                    {
                        
                        DataTable indt = dbHelper.selectAllDataToIntable();
                        if (indt.Rows.Count > 0)
                        {
                            foreach (DataRow dr in indt.Rows)
                            {
                                insb.Append(dr[1] + "|" + dr[2] + "|" + dr[3] + "|" +
                                    dr[4] + "|" + dr[5] + "|" + dr[6] + "|" + dr[7] +
                                    "|" + dr[8] + "|" + dr[9] + "|" + dr[10] + "|" + dr[11] + "\r\n");
                            }
                            inText = insb.Length.ToString() + "#" + "in" + "#" + insb.ToString();
                            byte[] inbuffer = Encoding.UTF8.GetBytes(inText);
                            myCon.Send(inbuffer, inbuffer.Length, SocketFlags.None);
                            blInOk = true;
                            nullInUp = false;
                            Thread.Sleep(2000);
                        }
                        else
                        {
                            nullInUp = true;
                        }
                        upProgressBarValueAdd(30);
                    }
                    catch (Exception e)
                    {
                        blInOk = false;
                    }
                    /*
                     * �������� 
                     * 
                    */
                    try
                    {
                        DataTable outdt = dbHelper.selectAllDataToOuttable();
                        if (outdt.Rows.Count > 0)
                        {
                            foreach (DataRow dr in outdt.Rows)
                            {
                                outsb.Append(dr[1] + "|" + dr[2] + "|" + dr[3] + "|" +
                                    dr[4] + "|" + dr[5] + "|" + dr[6] + "|" + dr[7] +
                                    "|" + dr[8] + "|" + dr[9] + "|" + dr[10] + "|"+ dr[11] +
                                    "|" + dr[12] + "|" + dr[13] + "\r\n");
                            }
                            outText = outsb.Length.ToString() + "#" + "out" + "#" + outsb.ToString();
                            byte[] outbuffer = Encoding.UTF8.GetBytes(outText);
                            myCon.Send(outbuffer, outbuffer.Length, SocketFlags.None);
                            blOutOk = true;
                            nullOutUp = false;
                            Thread.Sleep(2000);
                            //
                        }
                        else
                        {
                            nullOutUp = true;
                        }
                        upProgressBarValueAdd(30);
                    }
                    catch
                    {
                        blOutOk = false; 
                    }
                    /*
                    * �˻����� 
                    */
                    try
                    {
                        DataTable redt = dbHelper.selectAllReturnedTable();
                        if (redt.Rows.Count > 0)
                        {
                            foreach (DataRow dr in redt.Rows)
                            {
                                resb.Append(dr[1] + "|" + dr[2] + "|" + dr[3] + "|" +
                                    dr[4] + "|" + dr[5] + "|" + dr[6] + "|" + dr[7] + "\r\n");
                            }
                            reText = resb.Length.ToString() + "#" + "re" + "#" + resb.ToString();
                            byte[] rebuffer = Encoding.UTF8.GetBytes(reText);
                            myCon.Send(rebuffer, rebuffer.Length, SocketFlags.None);
                            blReOk = true;
                            nullReUp = false;
                            Thread.Sleep(2000);
                        }
                        else
                        {
                            nullReUp = true;
                        }
                        upProgressBarValueAdd(40);
                    }
                    catch
                    {
                        blReOk = false;
                    }
                    if (blInOk)
                    {
                        try
                        {
                            string name = DateTime.Now.ToString("yyyyMMddhhmmss") + "_���.txt";
                            backup(insb.ToString(), name);
                            dbHelper.clearIn();
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show("��ⱸ��������������ݳ����쳣:" + ex.Message);
                        }
                    }
                    if (blOutOk)
                    {
                        try
                        {
                            string name = DateTime.Now.ToString("yyyyMMddhhmmss") + "_����.txt";
                            backup(outsb.ToString(), name);
                            dbHelper.clearOut();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("���ⱸ��������������ݳ����쳣:" + ex.Message);
                        }
                    }
                    if (blReOk)
                    {
                        try
                        {
                            string name = DateTime.Now.ToString("yyyyMMddhhmmss") + "_�˻�.txt";
                            backup(resb.ToString(), name);
                            dbHelper.clearReturned();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("�˻�����������������ݳ����쳣:" + ex.Message);
                        }
                    }
                }
            }
            //else 
            //    MessageBox.Show("�������ӵ���", "��ܰ��ʾ");
            //this.upload_button.Enabled = true;
            //btn_uploadPair.Enabled = true;
        }

        private void backup(string writeBackupString, string name)
        {
            string path = sysFunction.exePath() + "��������\\" + name;
            if (writeBackupString.Length > 2)
            {
                using (StreamWriter sw = new StreamWriter(path, false, Encoding.UTF8))
                {
                    sw.Write(writeBackupString);
                }
            }
        }

        private string strIpAddr = "";
        private void linkServer()
        {
            this.link_button.Enabled = false;
            if (this.link_button.Text == "F1��__���ӷ�����")
            {
                this.link_button.ForeColor = Color.Red;
                this.link_button.Text = "F1��__�Ͽ�������";
                strIpAddr = this.ipAddr_textBox.Text;
                startLinkServer();
                closeflag = true;
                this.upload_button.Enabled = true;
                this.btn_upPair.Enabled = true;
            }
            else if (this.link_button.Text == "F1��__�Ͽ�������")
            {
                this.link_button.ForeColor = Color.Black;
                this.link_button.Text = "F1��__���ӷ�����";
                this.upload_button.Enabled = false;
                this.btn_upPair.Enabled = false;
                closeflag = false;
                if (blThread == true)
                {
                    this.upload_button.Enabled = false;
                    try
                    {
                        //threadLinkServer.Abort();
                        closeflag = false;
                        threadRece.Abort();
                        myCon.Shutdown(SocketShutdown.Both);
                        myCon.Close();
                    }
                    catch
                    {
                        MessageBox.Show("�ѶϿ�");
                    }
                }
            }
            this.link_button.Enabled = true;
        }
        private void link_button_Click(object sender, EventArgs e)
        {
            linkServer();
        }
        //Thread threadLinkServer=null;
        private bool blThread = false;
        private void startLinkServer()
        {
            try
            {
                //threadLinkServer = new Thread(tryLinkServer);
                blThread = true;
                tryLinkServer();
            }
            catch
            {
                MessageBox.Show("Wifi��δ���ӻ�����δ����,��Ͽ����Ӻ�ȴ�5������");
            }
            
            //try
            //{
            //    threadLinkServer.Start();
            //}
            //catch
            //{ }
        }
        private Socket myCon=null;
        private void tryLinkServer()
        {
            try
            {
                if (strIpAddr.Length >= 4)
                {
                    IPAddress ip = IPAddress.Parse(strIpAddr);
                    IPEndPoint ipe = new IPEndPoint(ip, 2080);
                    myCon = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    myCon.Connect(ipe);
                    //string sendStr = "Ok connect";
                    //byte[] bs = Encoding.ASCII.GetBytes(sendStr);
                    //myCon.Send(bs, bs.Length, 0);
                    //Thread.Sleep(10);
                    threadRece = new Thread(receInfor);
                    threadRece.IsBackground = true;
                    sysFunction.saveTcpIpAddrNum(this.ipAddr_textBox.Text.Trim());
                    threadRece.Start();
                    blLinkServerOk = true;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Wifi��δ���ӣ���ȴ���Ͽ����Ӻ�ȴ�5������");
                closeForm();
            }
        }
        Thread threadRece = null;
        private static bool paiOk = false;
        private static bool cliOk = false;
        StringBuilder sb = new StringBuilder();
        byte[] recvBytes = new byte[1024 * 2 * 100];
        bool closeflag = true;
        
        private void receInfor()
        {
            lock (this)
            {
                while (true)
                {
                    if (closeflag)
                    {
                        try
                        {
                            int intBytes = 0;
                            intBytes = myCon.Receive(recvBytes, recvBytes.Length, 0);//uuuuuuuuuuuuu
                            string receStr = Encoding.UTF8.GetString(recvBytes, 0, intBytes);
                            ////////�������� 
                            if (receStr.IndexOf("paircode:") >= 0)
                                paiOk = true;
                            if (receStr.IndexOf("clientName:") >= 0)
                                cliOk = true;
                            if (paiOk == true)
                            {
                                sb.Append(receStr);
                                if (sb.ToString().IndexOf("#pairEnd") > 0)
                                {
                                    ChangeTextThread(sb.ToString());
                                    sb = new StringBuilder();
                                    recvBytes = new byte[1024 * 2 * 100];
                                    paiOk = false;
                                    MessageBox.Show("��Ա��������");
                                }
                            }
                            if (cliOk == true)
                            {
                                sb.Append(receStr);
                                if (sb.ToString().IndexOf("#endClient") > 0)
                                {
                                    ChangeTextThread(sb.ToString());
                                    sb = new StringBuilder();
                                    recvBytes = new byte[1024 * 2 * 100];
                                    cliOk = false;
                                }
                            }
                            //////
                            if (receStr.Length >= 1 && paiOk == false)
                            {
                                ChangeTextThread(receStr);
                            }
                        }
                        catch (SocketException se)
                        {
                            MessageBox.Show("δ���ӵ�����,����WIFI�Ƿ��");
                            Thread.CurrentThread.Abort();
                            this.closeForm();
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        private void ChangeTextThread(string strText)
        {
            this.test_textBox.Invoke(new EventHandler(delegate
            {
                this.test_textBox.Text = strText;
                int intData = strText.IndexOf("receDataInOutOK");
                int intDataR = strText.IndexOf("receDataReOK");
                if (intData >= 0 && intDataR < 0)
                {
                    //MessageBox.Show("Test00");                   
                    try
                    {
                        copyInFile();
                        copyOutFile();
                        clearInFile();
                        clearOutFile();
                        string strTmp = sysFunction.exePath() + "\\��������\\";
                        MessageBox.Show("������ļ��ɹ��ϴ�,�ϴ������ݣ�" 
                            + strTmp + "���ѱ��ݣ��붨ʱ��գ�ռ���ֳֻ��ռ�", "��ܰ��ʾ");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
                //�˻�
                int intRedata = strText.IndexOf("receDataReOK");
                if (intRedata >= 0)
                {
                    try
                    {
                        copyReturnedFile();
                        clearReturnedFile();
                        string strTmp = sysFunction.exePath() + "\\��������\\";
                        MessageBox.Show("�˻��ļ��ɹ��ϴ�,�ϴ������ݣ�" 
                            + strTmp + "���ѱ��ݣ��붨ʱ��գ�ռ���ֳֻ��ռ�", "��ܰ��ʾ");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
                //// paircode 
                int intPaircode = strText.IndexOf("paircode:");
                int intPairEnd = strText.IndexOf("#pairEnd");
                if ((intPaircode == 0) && (intPairEnd >= 0))
                {

                    if (strText.Length - 17 >= 1)
                    {
                        string strPaircode = strText.Substring(9, strText.Length - 17);
                        sysFunction.savePairCodeTable(strPaircode);
                        string sendStr = "recePairOk";
                        byte[] bs = Encoding.ASCII.GetBytes(sendStr);
                        myCon.Send(bs, bs.Length, 0);
                        Thread.Sleep(10);
                    }
                }
                int intOpt = strText.IndexOf("optTable:");
                int intOptEnd = strText.IndexOf("#optEnd");
                if ((intOpt == 0) && (intOptEnd >= 0))
                {
                    if (strText.Length - 16 >= 1)
                    {
                        string strPaircode = strText.Substring(9, strText.Length - 16);
                        sysFunction.saveOptTable(strPaircode);
                        string sendStr = "receOptOk";
                        byte[] bs = Encoding.ASCII.GetBytes(sendStr);
                        myCon.Send(bs, bs.Length, 0);
                        Thread.Sleep(10);
                    }
                }
                int intSdr = strText.IndexOf("sdrTable:");
                int intsdrEnd = strText.IndexOf("#sdrEnd");
                if ((intSdr == 0) && (intsdrEnd >= 0))
                {
                    if (strText.Length - 16 >= 1)
                    {
                        string strPaircode = strText.Substring(9, strText.Length - 16);
                        sysFunction.saveSdrTable(strPaircode);
                        string sendStr = "receSdrOk";
                        byte[] bs = Encoding.ASCII.GetBytes(sendStr);
                        myCon.Send(bs, bs.Length, 0);
                        Thread.Sleep(10);
                    }
                }
                int intStr = strText.IndexOf("strTable:");
                int intstrEnd = strText.IndexOf("#strEnd");
                if ((intStr == 0) && (intstrEnd >= 0))
                {
                    if (strText.Length - 16 >= 1)
                    {
                        string strPaircode = strText.Substring(9, strText.Length - 16);
                        sysFunction.saveStrTable(strPaircode);
                        string sendStr = "receStrOk";
                        byte[] bs = Encoding.ASCII.GetBytes(sendStr);
                        myCon.Send(bs, bs.Length, 0);
                        Thread.Sleep(10);
                    }
                }
                //client
                int intClient = strText.IndexOf("clientName:");
                int intClientEnd = strText.IndexOf("#endClient");
                if ((intClient == 0) && (intClientEnd >= 0))
                {
                    if (strText.Length - 21 >= 1)
                    {
                        string strPaircode = strText.Substring(11, strText.Length - 23);
                        sysFunction.saveClientTable(strPaircode);
                        string sendStr = "rececliOk";
                        byte[] bs = Encoding.ASCII.GetBytes(sendStr);
                        myCon.Send(bs, bs.Length, 0);
                        Thread.Sleep(10);
                    }
                }
            }));
        }
        string strDateCopy = System.DateTime.Now.ToString("yyyyMMdd_hhmmss");
        private void copyOutFile()
        {
            string  sourceFilePath = sysFunction.exePath() +@"\����\����ǼǱ�.txt";
            string destFileName = sysFunction.exePath() + @"\��������\����ǼǱ�_" + strDateCopy + ".txt";           
            File.Copy(sourceFilePath, destFileName, true);
        }
        private void copyInFile()
        {
            string sourceFilePath = sysFunction.exePath() + @"\����\���ǼǱ�.txt";        
            string destFileName = sysFunction.exePath() + @"\��������\���ǼǱ�_" + strDateCopy + ".txt";
            try
            {
                File.Copy(sourceFilePath, destFileName);
            }
            catch
            { }           
        }
        private void copyReturnedFile()
        {
            string sourceFilePath = sysFunction.exePath() + @"\����\�˻��ǼǱ�.txt";
            string destFileName = sysFunction.exePath() + @"\��������\�˻��ǼǱ�_" + strDateCopy + ".txt";
            try
            {
                File.Copy(sourceFilePath, destFileName);
            }
            catch
            { }

        }
        public static void clearInFile()
        {
            string strExePath = sysFunction.exePath();
            string strInFilePath = strExePath + "\\����\\���ǼǱ�.txt";
            UTF8Encoding utf8 = new UTF8Encoding(false);
            StreamWriter Writer = new StreamWriter(strInFilePath, false, utf8);
            Writer.WriteLine("");
            Writer.Close();
        }
        public static void clearOutFile()
        {
            string strExePath = sysFunction.exePath();
            string strOutFilePath = strExePath + "\\����\\����ǼǱ�.txt";
            UTF8Encoding utf8 = new UTF8Encoding(false);
            StreamWriter Writer2 = new StreamWriter(strOutFilePath, false, utf8);
            Writer2.WriteLine("");
            Writer2.Close();
        }
        public static void clearReturnedFile()
        {
            string strExePath = sysFunction.exePath();
            string strReFilePath = strExePath + "\\����\\�˻��ǼǱ�.txt";
            UTF8Encoding utf8 = new UTF8Encoding(false);
            StreamWriter Writer3 = new StreamWriter(strReFilePath, false, utf8);
            Writer3.WriteLine("");
            Writer3.Close();
        }
        public void TISServerClose()
        {
            this.upload_button .Enabled = false;
            if (blLinkServerOk == true)
            {
                myCon.Shutdown(SocketShutdown.Both);
                myCon.Close();
                blLinkServerOk = false;
            }
        }
        private bool blLinkServerOk = false;
        private bool blSaveIp = false;
        private bool blHadIp = false;
        private void timer1_Tick(object sender, EventArgs e)
        {
            //wifi
            blHadIp = sysFunction.ipAddrIfEmpty();
            if (blHadIp == true)
            {
                if (this.link_button.Enabled == false )
                    this.link_button.Enabled = true;
                this.textBox_rssi.Text = "WiFi Ok";
                link_button.Enabled = true;
                redEsc_button.Enabled = true;
                timer1.Enabled = false;
            }
            //else
            //{
            //    this.link_button.Enabled = false ;
            //    this.textBox_rssi.Text = "��������";
            //}
            //if (blLinkServerOk == true)
            //{
            //    if (this.upload_button.Enabled == false)
            //        this.upload_button.Enabled = true;
            //    if (blSaveIp == false)
            //    {
            //        sysFunction.saveTcpIpAddrNum(this.ipAddr_textBox .Text .Trim ());
            //        blSaveIp = true;
            //    }
            //}
        }
        //key down     
        bool blCapital = false;
        bool blNum = false;
        bool blLow = false;
        private void uploadForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
            {
                if (blCapital == true)
                {
                    blCapital = false;
                    blNum = true;
                    blLow = false;
                    this.textBox_input.Text = "1";
                }
                else if (blNum == true)
                {
                    blCapital = false;
                    blNum = false;
                    blLow = true;
                    this.textBox_input.Text = "a";
                }
            }
            if ((e.KeyCode == Keys.Capital) && (blNum == false))
            {
                blCapital = true;
                blNum = false;
                blLow = false;
                this.textBox_input.Text = "A";
            }
            if (e.KeyCode == Keys.F1)
            {
                if(link_button.Enabled)
                    linkServer();
            }
                
            //if (e.KeyCode == Keys.F1)
            //    uploadDataButton();
            if (e.KeyCode == Keys.Escape)
            {
                closeForm();
            }
            if (e.KeyCode == Keys.Down)
            {
                if (this.ipAddr_textBox .Focused)
                {   
                    this.link_button .Focus();
                    e.Handled = true;
                }
                else if (this.link_button.Focused)
                {
                    this.upload_button  .Focus();
                    e.Handled = true;
                }
                else if (this.upload_button.Focused)
                {
                    this.redEsc_button.Focus();
                    e.Handled = true;
                }
            }
            if (e.KeyCode == Keys.Up)
            {
                if (this.redEsc_button.Focused)
                {
                    this.upload_button.Focus();
                    e.Handled = true;
                }
                else if (this.upload_button.Focused)
                {
                    this.link_button .Focus();
                    e.Handled = true;
                }
                else if (this.link_button.Focused)
                {
                    this.ipAddr_textBox .Focus();
                    e.Handled = true;
                    this.ipAddr_textBox.SelectAll();
                }
            }
        }
        private void closeForm()
        {
            wifiFunction.powerOffWifi();
            this.redEsc_button.Enabled = false;
            this.timer1.Enabled = false;
            closeflag = false;
            try
            {
                //sysFunction.ShowWindow(sysFunction.iShowHideWindow(), 1);
                if (blThread == true)
                {
                    //threadLinkServer.Abort();
                    //threadLinkServer.Join();
                    closeflag = false;
                    threadRece.Abort();
                    myCon.Shutdown(SocketShutdown.Both);
                    myCon.Close();
                }
                if (blLinkServerOk == true)
                    TISServerClose();
                //wifiFunction.powerOffWifi();
            }
            catch
            { }
            this.Close();
        }
        private void redEsc_button_Click(object sender, EventArgs e)
        {
            closeForm();
        }

        private void btn_upPair_Click(object sender, EventArgs e)
        {
            btn_upPair.Enabled = false;
            upload_button.Enabled = false;
            string dataString = "";
            string strInFilePath = sysFunction.exePath() + "\\config\\newPair.txt";
            if (File.Exists(strInFilePath))
            {
                using (StreamReader sr = new StreamReader(strInFilePath,
                            System.Text.Encoding.GetEncoding("utf-8"), false))
                {
                    byte[] sendbytes = System.Text.Encoding.UTF8.GetBytes("newpair#");
                    int successSendBtyes = myCon.Send(sendbytes, sendbytes.Length, 0);

                    while ((dataString = sr.ReadLine()) != null)
                    {
                        if (dataString.Length > 0)
                        {
                            string strInSender = "";
                            strInSender = dataString + "\r\n";
                            sendbytes = System.Text.Encoding.UTF8.GetBytes(strInSender);
                            successSendBtyes = myCon.Send(sendbytes, sendbytes.Length, 0);
                        }
                    }
                    sendbytes = System.Text.Encoding.UTF8.GetBytes("#pairEnd");
                    myCon.Send(sendbytes, sendbytes.Length, 0);
                }
            }
            else
            {
                MessageBox.Show("δ���ҵ��������ñ�");
            }
            btn_upPair.Enabled = true;
            upload_button.Enabled = true;
        }

        //�������Ľ��ȿ���
        private void upProgressBarValueAdd(int addValue)
        {
            textBox_input.Invoke(new EventHandler(delegate
            {
                upProgressBar.Value += addValue;
                if (upProgressBar.Value == 100)
                {
                    MessageBox.Show("�����ϴ������,��鿴���Զ���ʾ");
                }
            }));
        }

        private void uploadForm_Closed(object sender, EventArgs e)
        {
            wifiFunction.powerOffWifi();
            this.timer1.Enabled = false;
            try
            {
                if (blThread == true)
                {
                    closeflag = false;
                    myCon.Close();
                    threadRece.Abort();
                }
                if (blLinkServerOk == true)
                    TISServerClose();
                wifiFunction.powerOffWifi();
            }
            catch
            { }
            this.Close();
        }
    }
}