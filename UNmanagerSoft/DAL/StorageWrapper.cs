using System;
using System.Data;
using System.Data.OleDb;
using UNmanagerSoft.Utility;
using UNmanagerSoft.Business_LL;

namespace UNmanagerSoft.DAL
{
    class StorageWrapper
    {
        officeTool off = new officeTool();
        public DataTable selectDBCommand(string sqlstr)
        {
            string strConOffice = off.readConnOffice();
            OleDbConnection myConn = new OleDbConnection(strConOffice);
            myConn.Open();
            OleDbDataAdapter da = new OleDbDataAdapter(sqlstr, myConn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            myConn.Close();
            myConn.Dispose();
            return dt;
        }

        public int getDateAllCount()
        {
            string strConOffice = off.readConnOffice();
            OleDbConnection myConn = new OleDbConnection(strConOffice);
            myConn.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            OleDbCommand command = new OleDbCommand();
            DataTable allCount = new DataTable();
            int allpage = 0;
            string sqlstr = "select count(*) from 库存表";
            command.CommandText = sqlstr;
            command.Connection = myConn;
            adapter.SelectCommand = command;
            adapter.Fill(allCount);
            if (allCount.Rows.Count >= 0)
            {
                string count = allCount.Rows[0][0].ToString();
                try
                {
                    allpage = Convert.ToInt32(count);
                }
                catch
                {
                    allpage = 0;
                }
            }
            myConn.Close();
            return allpage;
        }

        public DataTable BindDataWithPage(int index)
        {
            string strConOffice = off.readConnOffice();
            OleDbConnection myConn = new OleDbConnection(strConOffice);
            myConn.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            OleDbCommand command = new OleDbCommand();
            DataTable dt = new DataTable();
            index --;
            int num = index*20;
            //string selectText = "select top 10 * from 库存表 where 条码 not in" +
            //    "(select top @page*10 条码 from 库存表)";
            string selectText = "";
            if (num == 0)
            {
                selectText = "select top 20 * from 库存表 ";
            }
            else
            {
                selectText = "select top 20 * from 库存表 where 条码 not in" +
                    "(select top " + num.ToString() + " 条码 from 库存表)";
            }
            command.CommandText = selectText;
            command.Connection = myConn;
            adapter.SelectCommand = command;
            adapter.Fill(dt);
            myConn.Close();
            return dt;
        }
    }
}
