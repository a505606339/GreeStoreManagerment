using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;
using systemFunction;

namespace UNmanagerSoft.Utility
{
    class ComboxDateInit
    {
        systemFunction.systemFunction s = new systemFunction.systemFunction();

        public DataTable optlist()
        {
            string strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source = "
                + s.exePath()
                + @"\数据库\greeDatabase.accdb;Jet OLEDB:Database Password=123456";
            OleDbConnection conn = new OleDbConnection(strConn);
            conn.Open();
            string sqlStr = "select 名字 from 操作员表";
            OleDbDataAdapter adapter = new OleDbDataAdapter(sqlStr, conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            conn.Close();
            return dt;
        }

        public DataTable sdrlist()
        {
            string strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source = "
                           + s.exePath()
                           + @"\数据库\greeDatabase.accdb;Jet OLEDB:Database Password=123456";
            OleDbConnection conn = new OleDbConnection(strConn);
            conn.Open();
            string sqlStr = "select 名字 from 安装员表";
            OleDbDataAdapter adapter = new OleDbDataAdapter(sqlStr, conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            conn.Close();
            return dt;
        }

        public DataTable strlist()
        {
            string strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source = "
                           + s.exePath()
                           + @"\数据库\greeDatabase.accdb;Jet OLEDB:Database Password=123456";
            OleDbConnection conn = new OleDbConnection(strConn);
            conn.Open();
            string sqlStr = "select 名字 from 送货员表";
            OleDbDataAdapter adapter = new OleDbDataAdapter(sqlStr, conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            conn.Close();
            return dt;
        }
    }
}
