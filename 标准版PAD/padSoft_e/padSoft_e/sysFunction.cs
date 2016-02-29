using System.Data;
using System.Drawing;
using System.Text;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using System.Data.SqlServerCe;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Reflection;

namespace padSoft_e
{
    class sysFunction
    {
        public static void savePairCodeTable(string strLoginName)
        {
            string sqlPath = "Data Source =" + sysFunction.exePath() + @"数据\database.sdf";
            SqlCeConnection connet = new SqlCeConnection(sqlPath);
            connet.Open();
            SqlCeTransaction tran = connet.BeginTransaction();
            SqlCeCommand command = new SqlCeCommand();
            command.Connection = connet;
            command.Transaction = tran;
            string[] pairList = Regex.Split(strLoginName, "\r\n");
            int x = pairList.Length;
            try
            {
                foreach (string pair in pairList)
                {
                    string[] pairs = pair.Split('#');
                    if (pairs.Length > 2)
                    {
                        command.CommandText = "insert into PairedTable(inBarcode,outBarcode,pairType)"+
                            " values('" + pairs[0] + "','" + pairs[1] + "','" + pairs[2] + "')";
                        command.ExecuteNonQuery();
                    }
                }
                tran.Commit();
            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw ex;
            }
            finally
            {
                connet.Close();
            }
        }
        public static void saveOptTable(string strLoginName)
        {
            string strTmpNumQty = "";
            string strExePath = sysFunction.exePath();
            string strWhPdaYieldNumFile = strExePath + @"\config\optTable.ini";
            UTF8Encoding utf8 = new UTF8Encoding(false);
            using (StreamWriter Writer = new StreamWriter(strWhPdaYieldNumFile, false, utf8))
            {
                Writer.WriteLine(strLoginName);
                Writer.Close();
            }
        }
        public static void saveSdrTable(string strLoginName)
        {
            string strTmpNumQty = "";
            string strExePath = sysFunction.exePath();
            string strWhPdaYieldNumFile = strExePath + @"\config\sdrTable.ini";
            UTF8Encoding utf8 = new UTF8Encoding(false);
            using (StreamWriter Writer = new StreamWriter(strWhPdaYieldNumFile, false, utf8))
            {
                Writer.WriteLine(strLoginName);
                Writer.Close();
            }
        }
        public static void saveStrTable(string strLoginName)
        {
            string strTmpNumQty = "";
            string strExePath = sysFunction.exePath();
            string strWhPdaYieldNumFile = strExePath + @"\config\strTable.ini";
            UTF8Encoding utf8 = new UTF8Encoding(false);
            using (StreamWriter Writer = new StreamWriter(strWhPdaYieldNumFile, false, utf8))
            {
                Writer.WriteLine(strLoginName);
                Writer.Close();
            }
        }
        public static void saveClientTable(string strClientName)
        {
            string strExePath = sysFunction.exePath();
            string strWhPdaYieldNumFile = strExePath + @"\config\clientTable.ini";
            UTF8Encoding utf8 = new UTF8Encoding(false);
            using (StreamWriter Writer = new StreamWriter(strWhPdaYieldNumFile, false, utf8))
            {
                Writer.WriteLine(strClientName);
                Writer.Close();
            }
        }
        public static void saveTcpIpAddrNum(string strTcpIpAddrNum)
        {
            string strTmpNumQty = "";
            string strExePath = sysFunction.exePath();
            string strWhPdaYieldNumFile = strExePath + @"\config\tcpip.txt";
            UTF8Encoding utf8 = new UTF8Encoding(false);
            using (StreamWriter Writer = new StreamWriter(strWhPdaYieldNumFile, false, utf8))
            {
                Writer.WriteLine(strTcpIpAddrNum);
                Writer.Close();
            }
        }
        public static string readTcpIpAddrNum()
        {
            string strLoginName = "";
            string strExePath = sysFunction.exePath();
            string strWhPdaYieldNumFile = strExePath + @"\config\tcpip.txt";
            if (File.Exists(strWhPdaYieldNumFile))
            {
                using (StreamReader reader = new StreamReader(strWhPdaYieldNumFile, System.Text.Encoding.GetEncoding("utf-8"), false))
                {
                    string strTmp = reader.ReadLine();
                    if (strTmp.Length >= 2)
                        strLoginName = strTmp;
                    reader.Close();
                }
            }
            return strLoginName;
        }
        public static string readPairCodeTable()
        {
            string strTmpNumQty = "";
            string strExePath = sysFunction.exePath();
            string strWhPdaYieldNumFile = strExePath + @"\config\paircodeTable.txt";
            if (File.Exists(strWhPdaYieldNumFile))
            {
                using (StreamReader reader = new StreamReader(strWhPdaYieldNumFile, System.Text.Encoding.GetEncoding("utf-8"), false))
                {
                    string strTmp = reader.ReadToEnd();
                    if (strTmp.Length >= 2)
                        strTmpNumQty = strTmp;
                    reader.Close();
                }
            }
            return strTmpNumQty;
        }
        //btForm myBt = new btForm();
        public static  string readFtpServerIpAddr()
        {
            string strTmpNumQty = "";
            string strExePath = exePath();
            string strWhPdaYieldNumFile = strExePath + @"\config\FtpServerIpAddr.txt";
            if (File.Exists(strWhPdaYieldNumFile))
            {
                using (StreamReader reader = new StreamReader(strWhPdaYieldNumFile, System.Text.Encoding.GetEncoding("utf-8"), false))
                {
                    strTmpNumQty = reader.ReadLine();
                    reader.Close();
                }
            }
            return strTmpNumQty;
        }
        public static string readLastLoginName()
        {
            string strLoginName = "";
            string strExePath = sysFunction.exePath();
            string strWhPdaYieldNumFile = strExePath + @"\config\loginName.ini";
            if (File.Exists(strWhPdaYieldNumFile))
            {
                using (StreamReader reader = new StreamReader(strWhPdaYieldNumFile, System.Text.Encoding.GetEncoding("utf-8"), false))
                {
                    string strTmp = reader.ReadLine();
                    if (strTmp.Length >= 2)
                        strLoginName = strTmp;
                    reader.Close();
                }
            }
            return strLoginName;
        }
        public static string readPw()
        {
            string strLoginName = "";
            string strExePath = sysFunction.exePath();
            string strWhPdaYieldNumFile = strExePath + @"\config\loginPw.ini";
            if (File.Exists(strWhPdaYieldNumFile))
            {
                using (StreamReader reader = new StreamReader(strWhPdaYieldNumFile, System.Text.Encoding.GetEncoding("utf-8"), false))
                {
                    string strTmp = reader.ReadLine();
                    if (strTmp.Length >= 2)
                        strLoginName = strTmp;
                    reader.Close();
                }
            }
            return strLoginName;
        }
        public static void saveLoginName(string strLoginName)
        {
            string strTmpNumQty = "";
            string strExePath = sysFunction.exePath();
            string strWhPdaYieldNumFile = strExePath + @"\config\loginName.ini";
            UTF8Encoding utf8 = new UTF8Encoding(false);
            using (StreamWriter Writer = new StreamWriter(strWhPdaYieldNumFile, false, utf8))
            {
                Writer.WriteLine(strLoginName);
                Writer.Close();
            }
        }
        public static string readSysterm()
        {
            string strLoginName = "";
            string strExePath = sysFunction.exePath();
            string strWhPdaYieldNumFile = strExePath + @"\config\systerm.txt";
            if (File.Exists(strWhPdaYieldNumFile))
            {
                using (StreamReader reader = new StreamReader(strWhPdaYieldNumFile, System.Text.Encoding.GetEncoding("utf-8"), false))
                {
                    string strTmp = reader.ReadLine();
                    if (strTmp.Length >= 2)
                        strLoginName = strTmp;
                    reader.Close();
                }
            }
            return strLoginName;
        }
        public static void saveSysterm(string strSysterm)
        {
            string strTmpNumQty = "";
            string strExePath = sysFunction.exePath();
            string strWhPdaYieldNumFile = strExePath + @"\config\systerm.txt";
            UTF8Encoding utf8 = new UTF8Encoding(false);
            using (StreamWriter Writer = new StreamWriter(strWhPdaYieldNumFile, false, utf8))
            {
                Writer.WriteLine(strSysterm);
                Writer.Close();
            }
        }
        public static string readScanOrderNum()
        {
            string strLoginName = "";
            string strExePath = sysFunction.exePath();
            string strWhPdaYieldNumFile = strExePath + @"\config\scanOrderNum.txt";
            if (File.Exists(strWhPdaYieldNumFile))
            {
                using (StreamReader reader = new StreamReader(strWhPdaYieldNumFile, System.Text.Encoding.GetEncoding("utf-8"), false))
                {
                    string strTmp = reader.ReadLine();
                    if (strTmp.Length >= 2)
                        strLoginName = strTmp;
                    reader.Close();
                }
            }
            return strLoginName;
        }
        public static void saveScanOrderNum(string strSysterm)
        {
            string strTmpNumQty = "";
            string strExePath = sysFunction.exePath();
            string strWhPdaYieldNumFile = strExePath + @"\config\scanOrderNum.txt";
            UTF8Encoding utf8 = new UTF8Encoding(false);
            using (StreamWriter Writer = new StreamWriter(strWhPdaYieldNumFile, false, utf8))
            {
                Writer.WriteLine(strSysterm);
                Writer.Close();
            }
        }

        //list scan last time
        public static string listScanLastTime()
        {
            string strTmpNumQty = "";
            string strExePath = exePath();
            string strWhPdaYieldNumFile = strExePath + @"\config\saveScanLastTime.txt";
            if (File.Exists(strWhPdaYieldNumFile))
            {
                using (StreamReader reader = new StreamReader(strWhPdaYieldNumFile, System.Text.Encoding.GetEncoding("utf-8"), false))
                {
                    strTmpNumQty = reader.ReadLine();
                    reader.Close();
                }
            }
            return strTmpNumQty;
        }
        // save scan last time
        public static  void saveScanLastTime(string strScan)
        {
            string strExePath = exePath();
            string strWhPdaYieldNumFile = strExePath + @"\config\saveScanLastTime.txt";
            UTF8Encoding utf8 = new UTF8Encoding(false);
            using (StreamWriter Writer = new StreamWriter(strWhPdaYieldNumFile, false, utf8))
            {
                Writer.WriteLine(strScan);
                Writer.Close();
            }
        }

        // save last inventory order num
        private void saveLastInvOrderNum(string strOrderNum)
        {
            string strTmpNumQty = "";
            string strExePath = exePath();
            string strWhPdaYieldNumFile = strExePath + @"\config\LastInvOrderNum.txt";
            UTF8Encoding utf8 = new UTF8Encoding(false);
            using (StreamWriter Writer = new StreamWriter(strWhPdaYieldNumFile, false, utf8))
            {
                Writer.WriteLine(strOrderNum);
                Writer.Close();
            }
        }

        //list first inventory order num
        public static string listFirstInventory()
        {
            string strTmpNumQty = "";
            string strExePath = exePath();
            string strWhPdaYieldNumFile = strExePath + @"\config\firstInventory.txt";
            if (File.Exists(strWhPdaYieldNumFile))
            {
                using (StreamReader reader = new StreamReader(strWhPdaYieldNumFile, System.Text.Encoding.GetEncoding("utf-8"), false))
                {
                    strTmpNumQty = reader.ReadLine();
                    reader.Close();
                }
            }
            return strTmpNumQty;
        }
        // save first inventory order num
        public static  void saveFirstInventory(string strFirst)
        {
            string strTmpNumQty = "";
            string strExePath = exePath();
            string strWhPdaYieldNumFile = strExePath + @"\config\firstInventory.txt";
            UTF8Encoding utf8 = new UTF8Encoding(false);
            using (StreamWriter Writer = new StreamWriter(strWhPdaYieldNumFile, false, utf8))
            {
                strTmpNumQty = strFirst;
                Writer.WriteLine(strTmpNumQty);
                Writer.Close();
            }
        }
        public static bool blBtForm = false;

        public static string strCabinetPPw = "";

        public static string exePath()
        {
            //string strExePath = "";
            string aurl = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase.ToString()) + "\\";
            return aurl;
        }

        public static bool ipAddrIfEmpty()
        {
            System.Net.IPHostEntry myIp = System.Net.Dns.GetHostByName(System.Net.Dns.GetHostName());
            System.Net.IPAddress[] ipList = myIp.AddressList;
            string ipInfo = ipList[0].ToString();
            if ((ipInfo == "127.0.0.1") || (ipInfo == "0.0.0.0"))
                return false;
            else
                return true;   
        }

        // show hide window       
        public static int iShowHideWindow()
        {
            int iHwnd = FindWindow("HHTaskBar", null);
            return iHwnd;
        }
        //load all
        [DllImport("coredll.dll", EntryPoint = "FindWindow")]
        public static extern int FindWindow(string lpWindowName, string lpClassName);
        [DllImport("coredll.dll", EntryPoint = "ShowWindow")]
        public static extern int ShowWindow(int hwnd, int nCmdShow);

        [DllImport("coredll.dll")]
        public extern static void SipShowIM(uint dwFlag);
    }
}
