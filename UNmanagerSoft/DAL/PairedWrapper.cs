using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.OleDb;
using System.Text;
using System.Text.RegularExpressions;
using UNmanagerSoft.Utility;

namespace UNmanagerSoft.DAL
{
    class PairedWrapper
    {
        officeTool off = new officeTool();

        /// <summary>
        /// 查询所有型号条码的内容
        /// </summary>
        /// <returns>返回的表单数据</returns>
        public DataTable SelectAllPaired()
        {
            string strConOffice = off.readConnOffice();
            OleDbConnection conn = new OleDbConnection(strConOffice);
            conn.Open();
            string sqlStr = "select * from 型号条码配置表";
            OleDbDataAdapter adapter = new OleDbDataAdapter(sqlStr, conn);
            DataTable dataset = new DataTable();
            adapter.Fill(dataset);
            conn.Close();
            return dataset;
        }
        /// <summary>
        /// 根据条码查询符合的配置表数据
        /// </summary>
        /// <param name="inbarcode">内机条码</param>
        /// <param name="outbarcode">外机条码</param>
        /// <returns>符合条件的数据</returns>
        public DataTable SelectPairedWithBarcode(string inbarcode, string outbarcode)
        {
            string strConOffice = off.readConnOffice();
            OleDbConnection myConn = new OleDbConnection(strConOffice);
            myConn.Open();
            string mySqlQuery = "SELECT * from 型号条码配置表 where 内机条码 = '"
                + inbarcode + "' or 外机条码 = '"
                + outbarcode + "'";
            OleDbDataAdapter da = new OleDbDataAdapter(mySqlQuery, myConn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            myConn.Close();
            return dt;
        }
        /// <summary>
        /// 根据型号做模糊查询符合的配置表数据 
        /// </summary>
        /// <param name="type">型号</param>
        /// <returns>返回的数据</returns>
        public DataTable SelectPaierdWithType(string type)
        {
            string strConOffice = off.readConnOffice();
            OleDbConnection myConn = new OleDbConnection(strConOffice);
            myConn.Open();
            string mySqlQuery = "SELECT * from 型号条码配置表 where 型号名称 like '"
                + type + "%'";
            OleDbDataAdapter da = new OleDbDataAdapter(mySqlQuery, myConn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            myConn.Close();
            return dt;
        }
        /// <summary>
        /// 插入新配置表 
        /// </summary>
        /// <param name="inbarcode">内机条码</param>
        /// <param name="outbarcode">外机条码</param>
        /// <param name="type">型号</param>
        /// <returns>返回插入结果,-1代表不成功,0代表已存在,1以上为插入的行数</returns>
        public int InsertPaired(string inbarcode,string outbarcode,string type)
        {
            int sign = -1;
            string strConOffice = off.readConnOffice();
            OleDbConnection myConn = new OleDbConnection(strConOffice);
            myConn.Open();
            OleDbDataAdapter sda = new OleDbDataAdapter();
            DataSet ds = new DataSet();
            string mySqlQuery = "SELECT * from 型号条码配置表 where 内机条码='"
                + inbarcode + "' and 外机条码='" + outbarcode + "'";
            sda.SelectCommand = new OleDbCommand(mySqlQuery, myConn);
            sda.Fill(ds);
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count == 0)
                {
                    OleDbCommand mySqlAddData = myConn.CreateCommand();
                    mySqlAddData.CommandText = "INSERT INTO 型号条码配置表 VALUES ('"
                        + inbarcode + "','" + outbarcode + "','" + type + "')";
                    sign = mySqlAddData.ExecuteNonQuery();
                }
                else
                {
                    sign = 0;
                }
            }
            myConn.Close();
            return sign;
        }
        /// <summary>
        /// 修改配置表的某条数据
        /// </summary>
        /// <param name="inbarcode">要修改的原内机条码</param>
        /// <param name="outbarcode">原外机条码</param>
        /// <param name="newInbarcode">修改后的内机条码</param>
        /// <param name="newOutbarcode">修改后的外机条码</param>
        /// <param name="type">修改后的型号</param>
        /// <returns>修改情况,-1代表修改异常,0代表该原数据不存在,大于零修改成功,数字等于修改的行数</returns>
        public int UpdatePaired(string inbarcode, string outbarcode,
            string newInbarcode, string newOutbarcode ,string type)
        {
            int sign = -1;
            string strConOffice = off.readConnOffice();
            OleDbConnection myConn = new OleDbConnection(strConOffice);
            myConn.Open();
            OleDbDataAdapter sda = new OleDbDataAdapter();
            DataSet ds = new DataSet();
            string mySqlQuery = "SELECT * from 型号条码配置表 where 内机条码='"
                                + inbarcode + "' and 外机条码 = '" + outbarcode + "'";
            sda.SelectCommand = new OleDbCommand(mySqlQuery, myConn);
            sda.Fill(ds);
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count >= 1)
                {
                    OleDbCommand mySqlQueryD = new OleDbCommand();
                    mySqlQueryD.CommandText = "UPDATE   型号条码配置表 set 内机条码 = '"
                                              + newInbarcode + " ' , 外机条码 = '" + newOutbarcode
                                              + "' , 型号名称 = '" + type + "' where 内机条码 = '"
                                              + inbarcode + "' and 外机条码 = '" + outbarcode + "'";
                    mySqlQueryD.Connection = myConn;
                    sign = mySqlQueryD.ExecuteNonQuery();
                }
                else
                {
                    sign = 0;
                }
            }
            myConn.Close();
            return sign;
        }

        public int DeletePaired(string inbarcode, string outbarcode)
        {
            int sign = -1;
            string strConOffice = off.readConnOffice();
            OleDbConnection myConn = new OleDbConnection(strConOffice);
            myConn.Open();
            OleDbCommand mySqlQueryD = new OleDbCommand();
            mySqlQueryD.CommandText = "DELETE  from 型号条码配置表 where 内机条码 ='"
                + inbarcode + "' and 外机条码 = '" + outbarcode + "'";
            mySqlQueryD.Connection = myConn;
            sign = mySqlQueryD.ExecuteNonQuery();
            myConn.Close();
            return sign;
        }

        public string uploadPaired(string[] strData)
        {
            systemFunction.systemFunction mySys = new systemFunction.systemFunction();
            string accessConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source = "
                + mySys.exePath()
                + @"\数据库\greeDatabase.accdb;Jet OLEDB:Database Password=123456";
            OleDbConnection con = new OleDbConnection(accessConn);
            OleDbConnection con2 = new OleDbConnection(accessConn);
            con.Open();
            con2.Open();
            DataTable dt = new DataTable();
            OleDbDataAdapter apt = new OleDbDataAdapter();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = con;
            cmd.Transaction = con.BeginTransaction();
            try
            {
                foreach (string str in strData)
                {
                    if (!string.IsNullOrEmpty(str))
                    {
                        string[] strItems = Regex.Split(str, "#");
                        if (strItems.Length > 2)
                        {
                            string selectSqlStr = "select * from 型号条码配置表 where 内机条码 = '" +
                                strItems[0] + "' and 外机条码 = '" + strItems[1] + "'";
                            apt.SelectCommand = new OleDbCommand(selectSqlStr, con2);
                            apt.Fill(dt);
                            if (dt.Rows.Count < 1)
                            {
                                string sqlstr = "insert into 型号条码配置表 (内机条码,外机条码,型号名称) "
                                    + "values('" + strItems[0] + "','"
                                    + strItems[1] + "','"
                                    + strItems[2] + "')";
                                if (sqlstr.Trim().Length > 1)
                                {
                                    cmd.CommandText = sqlstr;
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
                cmd.Transaction.Commit();
                return "1,ok";
            }
            catch (Exception ex)
            {
                cmd.Transaction.Rollback();
                return "0,"+ex.Message;
            }
            finally
            {
                con.Close();
            }
        }
    }
}
