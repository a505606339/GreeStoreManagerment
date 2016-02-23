using System;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using UNmanagerSoft.Utility;
using UNmanagerSoft.Business_LL;

namespace UNmanagerSoft.DAL
{
    class ReturnedWrapper
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
        
        public string returnedInsertDBCommand()
        {
            string returnflag = "";
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
            try
            {
                OleDbDataAdapter sda = new OleDbDataAdapter();
                DataSet outFromDS = new DataSet();
                DataSet inFromDS = new DataSet();
                DataSet stockFromDS = new DataSet();
                OleDbCommand command;
                string strRePath = mySys.exePath() + @"\数据\退货\";
                DirectoryInfo dir = new DirectoryInfo(strRePath);
                FileInfo[] finfo = dir.GetFiles();
                string fnames = string.Empty;
                string reDate = "";
                string sqlSelectOut = "";
                string sqlSelectStock = "";
                string sqlDeleteOut = "";
                string sqlInsertReturned = "";
                string sqlUpdateStock = "";
                int i = 0;
                for (i = 0; i < finfo.Length; i++)
                {
                    if (finfo[i].Name.IndexOf(".txt") > 0)
                    {
                        fnames = finfo[i].Name;
                        if (fnames.Length > 10 && fnames.IndexOf("退货") > 0)
                        {
                            bool readOk = false;
                            using (StreamReader sr = new StreamReader(strRePath + fnames
                                , Encoding.UTF8, false))
                            {
                                while (sr.Peek() > -1)
                                {
                                    reDate = sr.ReadLine();
                                    if (reDate.Length > 13 && reDate.IndexOf("\t") > 0)
                                    {
                                        string[] reDateItem = reDate.Split('\t');
                                        if (reDateItem.Length > 1)
                                        {
                                            //if (reDateItem[0].Length > 0)
                                            //{
                                            //    sqlSelectOut = "select * from 出库表 where 内机条码 = '"
                                            //    + reDateItem[0] + "'";
                                            //    sqlSelectStock = "select 数量 from 库存表 where 条码 = '"
                                            //        + reDateItem[0] + "'";
                                            //}
                                            //else
                                            //{
                                            //    sqlSelectOut = "select * from 出库表 where 内机条码 = '"
                                            //    + reDateItem[0]
                                            //    + "' or 外机条码 = '"
                                            //    + reDateItem[1] + "'";
                                            //    sqlSelectStock = "select 数量 from 库存表 where 条码 = '"
                                            //        + reDateItem[0] + "' or 条码 = '" + reDateItem[1] + "'";
                                            //}
                                            if (reDateItem[0].Length > 0 && reDateItem[1].Length > 0)
                                            {
                                                sqlSelectOut = "select * from 出库表 where 内机条码 = '"
                                                               + reDateItem[0] + "' and 外机条码 = '" + reDateItem[1]
                                                               + "'";
                                                sqlSelectStock = "select 数量 from 库存表 where 条码 = '"
                                                                 + reDateItem[0] + "' or 条码 = '"
                                                                 + reDateItem[1] + "'";
                                            }
                                            //填充出库数据
                                            sda.SelectCommand = new
                                                OleDbCommand(sqlSelectOut, myConn);
                                            outFromDS.Tables.Clear();
                                            sda.Fill(outFromDS);
                                            //填充库存表dataset,填充数量以更新
                                            sda.SelectCommand = new
                                                OleDbCommand(sqlSelectStock, myConn);
                                            stockFromDS.Tables.Clear();
                                            sda.Fill(stockFromDS);
                                            if (outFromDS != null && stockFromDS != null
                                                && outFromDS.Tables.Count > 0
                                                && stockFromDS.Tables.Count > 0)
                                            {
                                                if (outFromDS.Tables[0].Rows.Count > 0
                                                    && stockFromDS.Tables[0].Rows.Count > 0)
                                                {
                                                    if (reDateItem[0].Length > 0)
                                                    {
                                                        sqlDeleteOut = "delete from 出库表 where 内机条码 = '"
                                                                       + reDateItem[0] + "' and 外机条码 = '"
                                                                       + reDateItem[1] + "'";
                                                    }
                                                    command = new OleDbCommand(sqlDeleteOut, myConn);
                                                    command.ExecuteNonQuery();
                                                    string sqlSelectReturned = "select * from 退货表 where 内机条码 = '"
                                                        + reDateItem[0] + "'";
                                                    DataTable selectRetuenedDT = new DataTable();
                                                    OleDbDataAdapter adapter = new OleDbDataAdapter(sqlSelectReturned,
                                                        myConn);
                                                    adapter.Fill(selectRetuenedDT);
                                                    if (selectRetuenedDT.Rows.Count <= 0)
                                                    {
                                                        sqlInsertReturned = "insert into 退货表 values ("
                                                                            + "'" + reDateItem[0] + "',"
                                                                            + "'" + reDateItem[1] + "',"
                                                                            + "'" + reDateItem[2] + "',"
                                                                            + "'" + reDateItem[3] + "',"
                                                                            + "'" + reDateItem[4] + "',"
                                                                            + "'" + reDateItem[5] + "',"
                                                                            + "'" + reDateItem[6] + "')";
                                                        command = new OleDbCommand(sqlInsertReturned, myConn);
                                                        command.ExecuteNonQuery();
                                                    }
                                                    int numS1 = 0;
                                                    int numS2 = 0;
                                                    try
                                                    {
                                                        if (stockFromDS.Tables[0].Rows.Count == 2)
                                                        {
                                                            string num1 = stockFromDS.Tables[0].Rows[0]["数量"].ToString();
                                                            string num2 = stockFromDS.Tables[0].Rows[1]["数量"].ToString();
                                                            numS1 = Convert.ToInt32(num1);
                                                            numS2 = Convert.ToInt32(num1);
                                                            numS1 += 1;
                                                            numS2 += 1;
                                                        }
                                                    }
                                                    catch
                                                    {
                                                        numS1 = 1;
                                                        numS2 = 1;
                                                    }
                                                    if (reDateItem[0].Length > 0)
                                                    {
                                                        sqlUpdateStock = "update 库存表 set 数量 = '"
                                                                         + numS1.ToString() + "' where 条码 = '" +
                                                                         reDateItem[0] + "'";
                                                        command = new OleDbCommand(sqlUpdateStock, myConn);
                                                        command.ExecuteNonQuery();
                                                    }
                                                    if (reDateItem[1].Length > 0)
                                                    {
                                                        sqlUpdateStock = "update 库存表 set 数量 = '"
                                                                         + numS2.ToString() + "' where 条码 = '" +
                                                                         reDateItem[1] + "'";
                                                        command = new OleDbCommand(sqlUpdateStock, myConn);
                                                        command.ExecuteNonQuery();
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                //MessageBox.Show("不存在任何数据,请检查");
                                            }
                                        }
                                    }
                                    readOk = true;
                                }
                            }
                            if (readOk)
                            {
                                try
                                {
                                    var sourceFilePath = strRePath + fnames;
                                    string strObjPath = mySys.exePath() + @"\数据\退货备份\";
                                    var destFileName = strObjPath + fnames;
                                    File.Copy(sourceFilePath, destFileName);
                                    File.Delete(strRePath + fnames);
                                }
                                catch
                                {
                                    returnflag = "err," + i.ToString();
                                }
                            }
                        }
                    }
                }
                myConn.Close();
                if (i > 0 && returnflag.IndexOf("err") < 0)
                {
                    returnflag = "returnedShow," + i.ToString();
                }
                else if (i == 0)
                {
                    returnflag = "err," + i.ToString();
                }
            }
            catch (Exception ex)
            {
                myConn.Close();
                return "error," + ex.Message; 
            }
            finally
            {
                myConn.Close();
            }
            return returnflag;            
        }

        /// <summary>
        /// 根据传来的退货数据对商品进行退货处理 
        /// </summary>
        /// <param name="entity">退货数据实体</param>
        /// <returns>成功标识,-1出现错误,0未更新,大于0更新该返回数的数据</returns>
        public int MannulreturnedDBCommand(ReturnedEntity entity)
        {
            string strConOffice = off.readConnOffice();
            systemFunction.systemFunction mySys = new systemFunction.systemFunction();
            OleDbConnection connet = new OleDbConnection(strConOffice);
            connet.Open();
            OleDbDataAdapter dataAda = new OleDbDataAdapter();
            int returnflag = -1;
            try
            {
                string a = "";
                string b = "";
                int[] flags = new int[4];
                DataTable dt = new DataTable();
                string sqlInsertStr = "";
                string sqlDeleteStr = "";
                string sqlSelectStr = "";
                sqlInsertStr = "insert into 退货表 values ("
                    + "'" + entity.InBarcode + "',"
                    + "'" + entity.OutBarcode + "',"
                    + "'" + entity.type + "',"
                    + "'" + entity.remark + "',"
                    + "'" + entity.clientName + "',"
                    + "'" + entity.optName + "',"
                    + "'" + entity.dateTime + "'"
                    + ")";
                sqlDeleteStr = "delete from 出库表 where 内机条码 = '" + entity.InBarcode
                    + "' and 外机条码 = '" + entity.OutBarcode + "'";
                OleDbCommand command = new OleDbCommand(sqlInsertStr, connet);
                command.ExecuteNonQuery();

                command = new OleDbCommand(sqlDeleteStr, connet);
                command.ExecuteNonQuery();
                sqlSelectStr = "select 数量 from 库存表 where 条码 = '"
                    + entity.InBarcode + "' or 条码 = '" + entity.OutBarcode + "'";
                dataAda.SelectCommand = new OleDbCommand(sqlSelectStr, connet);
                dataAda.Fill(dt);
                try
                {
                    if (!String.IsNullOrEmpty(dt.Rows[0][0].ToString()))
                    {
                        a = (Convert.ToInt32(dt.Rows[0][0]) + 1).ToString();
                    }
                    if (String.IsNullOrEmpty(dt.Rows[1][0].ToString()))
                    {
                        b = (Convert.ToInt32(dt.Rows[1][0]) + 1).ToString();
                    }
                }
                catch
                {
                    a = "0";
                    b = "0";
                }
                sqlInsertStr = "update 库存表 set 数量 = '" + a + "' where 条码 = '"
                    + entity.InBarcode + "'";
                command = new OleDbCommand(sqlInsertStr, connet);
                command.ExecuteNonQuery();

                sqlInsertStr = "update 库存表 set 数量 = '" + b + "' where 条码 = '"
                   + entity.OutBarcode + "'";
                command = new OleDbCommand(sqlInsertStr, connet);
                command.ExecuteNonQuery();
                returnflag = 1;
            }
            catch (Exception ex)
            {
                returnflag = -1;
                throw ex;
            }
            finally
            {
                connet.Close();
            }
            return returnflag;
        }
    }
}
