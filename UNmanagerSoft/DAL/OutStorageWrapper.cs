using System;
using System.Data;
using System.Data.OleDb;
using System.IO;
using UNmanagerSoft.Utility;
using UNmanagerSoft.Business_LL;

namespace UNmanagerSoft.DAL
{
    class OutStorageWrapper
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
        
        public int updateDBCommand(OutEntity outdata)
        {
            int returnflag = 0;
            if (!String.IsNullOrEmpty(outdata.InBarcode))
            {
                string inbarcode = outdata.InBarcode;
                string outbarcode = outdata.OutBarcode;
                string type = outdata.Type;
                string clientName = outdata.ClientName;
                string number = outdata.Number;
                string money = outdata.Money;
                string operators = outdata.Operators;
                string deliver = outdata.Deliver;
                string install = outdata.Install;
                string remark = outdata.Remark;
                string outOrderNum = outdata.OutOrderNum;
                string mySqlQuery = mySqlQuery = "SELECT * from 出库表 where 内机条码 = '"
                    + inbarcode + "' and 外机条码 = '" + outbarcode + "'" ;
                string strConOffice = off.readConnOffice();
                OleDbConnection myConn = new OleDbConnection(strConOffice);
                myConn.Open();
                OleDbDataAdapter sda = new OleDbDataAdapter();
                DataSet ds = new DataSet();
                DataSet ds2 = new DataSet();
                sda.SelectCommand = new OleDbCommand(mySqlQuery, myConn);
                sda.Fill(ds);
                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count >= 1)
                    {
                        OleDbCommand mySqlQueryD = new OleDbCommand();
                        mySqlQueryD.CommandText = "UPDATE 出库表 set 空调型号='"
                            + type
                            + "', 出库单号 = '" + outOrderNum
                            + "',客户名称 = '" + clientName
                            + "',数量 = '" + number
                            + "', 金额 = '" + money
                            + "',操作员 = '" + operators
                            + "', 送货员 = '" + deliver
                            + "',安装员 = '" + install
                            + "', 备注 = '" + remark
                            + "' where 内机条码 = '" + inbarcode 
                            + "' and 外机条码 = '"+ outbarcode + "'";
                        mySqlQueryD.Connection = myConn;
                        try
                        {
                            object myReslut = mySqlQueryD.ExecuteNonQuery();
                            if (myReslut != System.DBNull.Value)
                            {
                                returnflag = 1;
                            }
                            else
                                returnflag = -1;
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }
                    else
                        returnflag = -2;
                }
            }
            return returnflag;
        }

        public string insertDBCommand()
        {
            string strConOffice = off.readConnOffice();
            systemFunction.systemFunction mySys = new systemFunction.systemFunction();
            OleDbConnection myConn = new OleDbConnection(strConOffice);
            try
            {
                myConn.Open();
            }
            catch
            {
                return "数据库启动失败";
            }
            OleDbTransaction transaction = myConn.BeginTransaction();
            OleDbDataAdapter sda = new OleDbDataAdapter();
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();
            string strInputPath = mySys.exePath() + @"\数据\出库\";
            DirectoryInfo dir = new DirectoryInfo(strInputPath);
            FileInfo[] finfo = dir.GetFiles();
            try
            {
                string fnames = string.Empty;
                int i = 0;
                bool blOk = false;
                for (i = 0; i < finfo.Length; i++)
                {
                    fnames = finfo[i].Name; // +"#";
                    int intFnames = fnames.IndexOf(".txt");
                    if (intFnames >= 0 &&
                        fnames.Length >= 10 &&
                        fnames.IndexOf("出库") >= 0 &&
                        File.Exists(strInputPath + fnames))
                    {
                        StreamReader reader = new StreamReader(
                            strInputPath + fnames
                            , System.Text.Encoding.GetEncoding("utf-8"), false);
                        while (reader.Peek() > -1)
                        {
                            string strInputData = reader.ReadLine();
                            if (strInputData.Length >= 10)
                            {
                                int intTab = strInputData.IndexOf("\t");
                                if (intTab >= 0)
                                {
                                    string[] strArrays = strInputData.Split('\t');
                                    if (strArrays.Length >= 12)
                                    {
                                        //查询非空条码是否已经存在出库表里 
                                        string mySqlQuery = "";
                                        if (strArrays[0].ToString() != "")
                                        {
                                            mySqlQuery = "SELECT * from 出库表 where 内机条码='" +
                                                         strArrays[0].ToString() + "'";
                                        }
                                        else if (strArrays[1].ToString() != "")
                                        {
                                            mySqlQuery = "SELECT * from 出库表 where 外机条码='" +
                                                         strArrays[1].ToString() + "'";
                                        }
                                        dt1 = new DataTable();
                                        //换成adapter
                                        sda.SelectCommand = new OleDbCommand(
                                            mySqlQuery, myConn);
                                        sda.Fill(dt1);
                                        if (dt1 != null)
                                        {
                                            if (dt1.Rows.Count > 0)
                                            {

                                            }
                                            else
                                            {
                                                OleDbCommand mySqlAddData = myConn.CreateCommand();
                                                mySqlAddData.Transaction = transaction;
                                                mySqlAddData.CommandText = "INSERT INTO 出库表 VALUES ('"
                                                                           + strArrays[0].ToString() + "','"
                                                                           + strArrays[1].ToString() + "','"
                                                                           + strArrays[2].ToString() + "','"
                                                                           + strArrays[3].ToString() + "','"
                                                                           + strArrays[4].ToString() + "','"
                                                                           + strArrays[5].ToString() + "','"
                                                                           + strArrays[6].ToString() + "','"
                                                                           + strArrays[7].ToString() + "','"
                                                                           + strArrays[8].ToString() + "','"
                                                                           + strArrays[9].ToString() + "','"
                                                                           + strArrays[10].ToString() + "','"
                                                                           + strArrays[11].ToString() + "','"
                                                                           + strArrays[12].ToString() + "')";
                                                object myReslut = mySqlAddData.ExecuteNonQuery();
                                                if (myReslut != System.DBNull.Value)
                                                {
                                                    //wh 
                                                    dt1 = new DataTable();
                                                    mySqlQuery = "SELECT * from 库存表 where 空调型号='"
                                                                    + strArrays[0].ToString() + "'";
                                                    sda.SelectCommand = new OleDbCommand(
                                                        mySqlQuery, myConn);
                                                    sda.Fill(dt1);
                                                    updateStock(myConn, strArrays, dt1, ref blOk,transaction);
                                                }
                                                else
                                                {
                                                    blOk = false;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                blOk = true;
                            }
                        }
                        reader.Close();
                        if (blOk == true)
                        {
                            //save as 
                            try
                            {
                                var sourceFilePath = strInputPath + fnames;
                                string strObjPath = mySys.exePath() + @"\数据\出库备份\";
                                var destFileName = strObjPath + fnames;
                                File.Copy(sourceFilePath, destFileName);
                            }
                            catch
                            {
                                //MessageBox.Show("出库拷贝出错");
                            }
                            //delete file 
                            try
                            {
                                File.Delete(strInputPath + fnames);
                            }
                            catch
                            {
                                //MessageBox.Show("文件删除失败");
                            }
                        }
                    }
                }
                myConn.Close();
                string returnflag = "";
                if (i >= 1)
                {
                    returnflag = "outputShow," + i.ToString();
                }
                else if (i == 0)
                {
                    returnflag = "err," + i.ToString();
                }
                return returnflag;
            }
            catch (Exception ex)
            {
                myConn.Close();
                transaction.Rollback();
                return "error," + ex.Message;
            }
        }
        
        /// <summary>
        /// 当该条码已经有库存时对库存进行更新 
        /// 当没有库存时新建库存数据 
        /// </summary>
        /// <param name="myConn">打开的连接</param>
        /// <param name="outArray">出库数据</param>
        /// <param name="dt">查询出的库存数据</param>
        /// <param name="blOk">是否执行完成的标识</param>
        public void updateStock(OleDbConnection myConn,
            string[] outArray,
            DataTable dt,
            ref bool blOk,
            OleDbTransaction transaction)
        {
            OleDbCommand mySqlAddData = myConn.CreateCommand();
            var myReslut = 0;
            //若存在库存则进行更新,不存在则新建该数据库存 
            if (dt.Rows.Count > 0)
            {
                int strQty = 0;
                try
                {
                    strQty = Convert.ToInt32(dt.Rows[0].ItemArray[3]);
                }
                catch(Exception ex)
                {
                    throw ex;
                }
                mySqlAddData = myConn.CreateCommand();
                mySqlAddData.CommandText = "UPDATE 库存表 set 数量 = '" +
                                            strQty +
                                            "' where 空调型号='" +
                                            outArray[2].ToString() +
                                            "' and 仓库名称 = '" +
                                            outArray[12].ToString();
                mySqlAddData.Transaction = transaction;
                myReslut = mySqlAddData.ExecuteNonQuery();
                if (myReslut > -1)
                {
                    blOk = true;
                }
            }
            else
            {
                //MessageBox.Show("test01");
                mySqlAddData = myConn.CreateCommand();
                mySqlAddData.CommandText = "INSERT INTO 库存表(空调型号,数量,仓库名称) VALUES ('"
                                            + outArray[2] + "','" 
                                            + "-1" + "','" 
                                            + outArray[12] + "')";
                mySqlAddData.Transaction = transaction;
                myReslut = mySqlAddData.ExecuteNonQuery();
                if (myReslut > -1)
                {
                    blOk = true;
                }
            }
        }

        public DataTable SelectCountAndPriceWithOutTable()
        {
            string strConOffice = off.readConnOffice();
            systemFunction.systemFunction mySys = new systemFunction.systemFunction();
            OleDbConnection myConn = new OleDbConnection(strConOffice);
            try
            {
                myConn.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            string selectSQLString = "select 数量,金额 from 出库表";
            OleDbDataAdapter adapter = new OleDbDataAdapter(selectSQLString, myConn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }
    }
}
