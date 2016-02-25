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
                selectText = "select top 20 * from 库存表 where UID not in" +
                    "(select top " + num.ToString() + " UID from 库存表)";
            }
            command.CommandText = selectText;
            command.Connection = myConn;
            adapter.SelectCommand = command;
            adapter.Fill(dt);
            myConn.Close();
            return dt;
        }

        public int updateStockByID(StorageEntity stock,string uid,string stockName)
        {
            string strConOffice = off.readConnOffice();
            OleDbConnection myConn = new OleDbConnection(strConOffice);
            myConn.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            OleDbCommand command = new OleDbCommand();
            string insertHistoryStock = "insert into 库存备份表(空调型号" +
                ",数量,入库金额,单据单号,单据名称,入库员,入库时间,入库备注,仓库名称,操作) values ('" + 
                stock.Type + "','" +
                stock.Number + "','" +
                stock.InMoney + "','" +
                stock.ReceiptsNumber + "','" + 
                stock.ReceiptsName + "','" + 
                stock.InOpter + "','" + 
                stock.InDateTime + "','" +
                stock.InRemark + "','" +
                stock.StockName + "','" + 
                "更改" + "')";
            command.CommandText = insertHistoryStock;
            command.Connection = myConn;
            command.ExecuteNonQuery();

            string updateText = "update 库存表 set 空调型号 = '" +
                stock.Type + "',数量 = '" +
                stock.Number + "',单据单号 = '" + 
                stock.ReceiptsNumber + "',单据名称 = '" +
                stock.ReceiptsName + "',入库员 = '" +
                stock.InOpter + "',入库时间 = '" +
                stock.InDateTime + "',入库备注 = '" +
                stock.InRemark + "',仓库名称 = '" +
                stock.StockName + "',入库金额 = '" +
                stock.InMoney + "' where UID = " + uid +
                " and 仓库名称 = '" + stockName + "'";
            command = new OleDbCommand();
            command.CommandText = updateText;
            command.Connection = myConn;
            int influenceRow = command.ExecuteNonQuery();
            myConn.Close();
            command.Dispose();
            return influenceRow;
        }

        public int deleteStorageByID(StorageEntity stock)
        {
            string strConOffice = off.readConnOffice();
            OleDbConnection myConn = new OleDbConnection(strConOffice);
            myConn.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            OleDbCommand command = new OleDbCommand();
            string insertHistoryStock = "insert into 库存备份表(空调型号" +
                ",数量,入库金额,单据单号,单据名称,入库员,入库时间,入库备注,仓库名称,操作) values ('" +
                stock.Type + "','" +
                stock.Number + "','" +
                stock.InMoney + "','" +
                stock.ReceiptsNumber + "','" +
                stock.ReceiptsName + "','" +
                stock.InOpter + "','" +
                stock.InDateTime + "','" +
                stock.InRemark + "','" +
                stock.StockName + "','" +
                "删除" + "')";
            command.CommandText = insertHistoryStock;
            command.Connection = myConn;
            command.ExecuteNonQuery();

            string deleteStock = "delete from 库存表 where UID = " + stock.UID;
            command = new OleDbCommand();
            command.CommandText = deleteStock;
            command.Connection = myConn;
            int influenceRow = command.ExecuteNonQuery();
            myConn.Close();
            command.Dispose();
            return influenceRow;
        }
    }
}
