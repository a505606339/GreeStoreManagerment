using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using systemFunction;
using System.IO;
using System.Data.OleDb;

namespace UNmanagerSoft.Utility
{
    class officeTool
    {
        private string _strConOffice;
        systemFunction.systemFunction mySys = new systemFunction.systemFunction();

        public string strConOffice
        {
            get { return _strConOffice = readConnOffice(); }
        }

        public void initConnString()
        {
            string strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source = " 
                + mySys.exePath() 
                + @"\数据库\greeDatabase.accdb;Jet OLEDB:Database Password=123456";
            try
            {
                saveConnOffice(strConn);
            }
            catch
            { }
        }
        private void saveConnOffice(string strConnOffice)
        {
            string strDataPath = mySys.exePath() + @"\config\connOffice.txt";
            UTF8Encoding utf8 = new UTF8Encoding(false);
            StreamWriter Writer = new StreamWriter(strDataPath, false, utf8);
            Writer.WriteLine(strConnOffice);
            Writer.Close();
        }
        public string readConnOffice()
        {
            string strDataPath = mySys.exePath() + @"\config\connOffice.txt";
            UTF8Encoding utf8 = new UTF8Encoding(false);
            StreamReader reader = new StreamReader(strDataPath,utf8);
            string officeConn = reader.ReadLine();
            reader.Close();
            return officeConn;
        }
    }
}
