using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using UNmanagerSoft.DAL;

namespace UNmanagerSoft.Utility
{
    class ReceiveDataDispose
    {
        systemFunction.systemFunction mySys = new systemFunction.systemFunction();
        public void saveInOutFile(string strInfor)
        {
            saveInInfor(strInfor);
        }

        public void saveOutFile(string strInfor)
        {
            saveOutInfor(strInfor);
        }

        public void saveReturnedFile(string strInfor)
        {
            saveReturnedfor(strInfor);
        }

        #region 保存文件和生成xls
        public string saveInInfor(string strTpye)
        {
            InStorageWrapper instorageWrapper = new InStorageWrapper();
            string strExePath = mySys.exePath();
            string strNowDate = System.DateTime
                .Now.ToString("yyyy-MM-dd HH:mm:ss").Replace("-", "");
            strNowDate = strNowDate.Replace(":", "");
            strNowDate = strNowDate.Replace(" ", "");
            string strWhPdaYieldNumFile = strExePath
                + @"\数据\入库\" + strNowDate + "_入库.txt";
            UTF8Encoding utf8 = new UTF8Encoding(false);
            StreamWriter Writer = new StreamWriter(
                strWhPdaYieldNumFile, false, utf8);
            Writer.WriteLine(strTpye);
            Writer.Flush();
            Writer.Dispose();
            Writer.Close();
            string saveXlsFile = strExePath
                + @"\数据\入库备份\" + strNowDate + "_入库.xls";
            txtExchangeExcel(strWhPdaYieldNumFile, saveXlsFile);
            return instorageWrapper.insertDBCommand();
        }

        public string saveOutInfor(string strTpye)
        {
            OutStorageWrapper outstorageWrapper = new OutStorageWrapper();
            string strExePath = mySys.exePath();
            string strNowDate = System.DateTime
                .Now.ToString("yyyy-MM-dd HH:mm:ss").Replace("-", "");
            strNowDate = strNowDate.Replace(":", "");
            strNowDate = strNowDate.Replace(" ", "");
            string strWhPdaYieldNumFile = strExePath
                + @"\数据\出库\" + strNowDate + "_出库.txt";
            UTF8Encoding utf8 = new UTF8Encoding(false);
            StreamWriter Writer = new StreamWriter(
                strWhPdaYieldNumFile, false, utf8);
            Writer.WriteLine(strTpye);
            Writer.Dispose();
            Writer.Close();
            string saveXlsFile = strExePath
                + @"\数据\出库备份\" + strNowDate + "_出库.xls";
            txtExchangeExcel(strWhPdaYieldNumFile, saveXlsFile);
            return outstorageWrapper.insertDBCommand();
        }

        public string saveReturnedfor(string strData)
        {
            ReturnedWrapper returnedWrapper = new ReturnedWrapper();
            string strExePath = mySys.exePath();
            string strNowDate = System.DateTime
                .Now.ToString("yyyy-MM-dd HH:mm:ss").Replace("-", "");
            strNowDate = strNowDate.Replace(":", "");
            strNowDate = strNowDate.Replace(" ", "");
            string strWhPdaYieldNumFile = strExePath
                + @"\数据\退货\" + strNowDate + "_退货.txt";
            UTF8Encoding utf8 = new UTF8Encoding(false);
            StreamWriter Writer = new StreamWriter(
                strWhPdaYieldNumFile, false, utf8);
            Writer.WriteLine(strData);
            Writer.Dispose();
            Writer.Close();
            string saveXlsFile = strExePath
                + @"\数据\退货备份\" + strNowDate + "_退货.xls";
            txtExchangeExcel(strWhPdaYieldNumFile, saveXlsFile);
            return returnedWrapper.returnedInsertDBCommand();
        }
        private void txtExchangeExcel(string strFile, string saveFile)
        {
            string fileName = strFile.Substring(0, strFile.Length - 3) + "xls";
            using (StreamReader sr = new StreamReader(
                strFile, System.Text.Encoding.GetEncoding("utf-8")))
            {
                if (strFile.IndexOf('入') > 0)
                {
                    ExcelUtiltity eu = new ExcelUtiltity();
                    eu.CreateExcel(strFile, saveFile, "1");
                }
                else if (strFile.IndexOf('出') > 0)
                {
                    ExcelUtiltity eu = new ExcelUtiltity();
                    eu.CreateExcel(strFile, saveFile, "2");
                }
                else if (strFile.IndexOf('退') > 0)
                {
                    ExcelUtiltity eu = new ExcelUtiltity();
                    eu.CreateExcel(strFile, saveFile, "3");
                }
            }
        }
        #endregion
    }
}
