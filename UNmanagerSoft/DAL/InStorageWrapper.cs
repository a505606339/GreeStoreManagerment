using System;
using System.Data;
using System.Data.OleDb;
using System.IO;
using UNmanagerSoft.Utility;
using UNmanagerSoft.Business_LL;

namespace UNmanagerSoft.DAL
{
    class InStorageWrapper
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

        public int updateDBCommand(InEntity indate)
        {
            //1表示保存成功
            //-1表示入库数据更新失败
            //-2表示条码不在入库表中
            int returnflag = 0;
            if (!String.IsNullOrEmpty(indate.inbarcode) || !String.IsNullOrEmpty(indate.outbarcode))
            {
                string inBarcode = indate.inbarcode;
                string outBarcode = indate.outbarcode;
                string receiptsNumber = indate.receiptsNumber;
                string receiptsName = indate.receiptsName;
                string inNumber = indate.inNumber;
                string inMoney = indate.inMoney;
                string type = indate.type;
                string operators = indate.operators;
                string inDate = indate.inDate;
                string remark = indate.remark;
                string mySqlQuery = "";
                string mySqlQuery2 = "";
                string strInBar = "";
                string strOutBar = "";
                mySqlQuery = "SELECT * from 入库表 where 内机条码 = '" + inBarcode + "' and 外机条码 = '"
                    + outBarcode + "'";
                strInBar = inBarcode;
                strOutBar = outBarcode;
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
                        mySqlQueryD.CommandText = "UPDATE 入库表 set 单据单号='" + receiptsNumber
                            + "' , 单据名称 = '" + receiptsName
                            + "' , 数量 = '" + inNumber
                            + "' , 金额 = '" + inMoney
                            + "' , 操作员 = '" + operators
                            + "' , 入库时间 = '" + inDate
                            + "' , 备注 = '" + remark
                            + "' , 空调型号= '" + type
                            + "' where 内机条码 = '" + inBarcode + "' and 外机条码 = '"
                            + outBarcode + "'";
                        mySqlQueryD.Connection = myConn;
                        try
                        {
                            int myReslut = mySqlQueryD.ExecuteNonQuery();
                            if (myReslut > 0)
                            {
                                returnflag = 1;
                            }
                        }
                        catch (Exception ex)
                        {
                            returnflag = -1;
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
                return "false,启动数据库失败";
            }
            try
            {
                OleDbDataAdapter sda = new OleDbDataAdapter();
                
                string strInputPath = mySys.exePath() + @"\数据\入库\";
                DirectoryInfo dir = new DirectoryInfo(strInputPath);
                FileInfo[] finfo = dir.GetFiles();
                string fnames = string.Empty;
                int i = 0;
                bool blOk = false;
                for (i = 0; i < finfo.Length; i++)
                {
                    fnames = finfo[i].Name; // +"#";
                    int intFnames = fnames.IndexOf(".txt");
                    if (intFnames >= 0 &&
                        fnames.Length >= 10 &&
                        fnames.IndexOf("入库") >= 0 &&
                        File.Exists(strInputPath + fnames))
                    {
                        using (StreamReader reader = new StreamReader(
                            strInputPath + fnames, System.Text.Encoding.
                                GetEncoding("utf-8"), false))
                        {
                            while (reader.Peek() > -1)
                            {
                                string strInputData = reader.ReadLine();
                                int intTab = strInputData.IndexOf("\t");
                                if (intTab >= 0)
                                {
                                    string[] strArrays = strInputData.Split('\t');
                                    if (strArrays.Length >= 10)
                                    {
                                        string mySqlQuery = "";
                                        if (strArrays[0].Length > 0)
                                        {
                                            mySqlQuery = "SELECT * from 入库表 where 内机条码='" +
                                                         strArrays[0].ToString() + "'";
                                        }
                                        else if (strArrays[1].Length > 0)
                                        {
                                            mySqlQuery = "SELECT * from 入库表 where 外机条码='" +
                                                         strArrays[1].ToString() + "'";
                                        }
                                        DataTable indt = new DataTable();
                                        sda.SelectCommand = new OleDbCommand(mySqlQuery, myConn);
                                        sda.Fill(indt);
                                        if (indt != null)
                                        {
                                            if (indt.Rows.Count >= 1)
                                            {
                                            }
                                            else
                                            {
                                                OleDbCommand mySqlAddData = myConn.CreateCommand();
                                                mySqlAddData.CommandText = "INSERT INTO 入库表 VALUES ('" +
                                                    strArrays[0].ToString() + "','" +
                                                    strArrays[1].ToString() + "','" +
                                                    strArrays[2].ToString() + "','" +
                                                    strArrays[3].ToString() + "','" +
                                                    strArrays[4].ToString() + "','" +
                                                    strArrays[5].ToString() + "','" +
                                                    strArrays[6].ToString() + "','" +
                                                    strArrays[7].ToString() + "','" +
                                                    strArrays[8].ToString() + "','" +
                                                    strArrays[9].ToString() + "','" + 
                                                    strArrays[10].ToString() + "')";
                                                object myReslut = mySqlAddData.ExecuteNonQuery();
                                                if (myReslut != System.DBNull.Value)
                                                {
                                                    //wh 
                                                    DataTable stockDT = new DataTable();
                                                    string strInOut = "";
                                                    mySqlQuery = "SELECT * FROM 库存表 WHERE 空调型号 = '"
                                                        + strArrays[2] + "' AND 仓库名称 = '" + strArrays[10] + "'";
                                                    sda.SelectCommand = new OleDbCommand(mySqlQuery, myConn);
                                                    sda.Fill(stockDT);
                                                    if (stockDT != null)
                                                    {
                                                        if (stockDT.Rows.Count >= 1) //update
                                                        {
                                                            string strQty = "";
                                                            string strMoney = "";
                                                            try
                                                            {
                                                                int tempStrQty = Convert.ToInt32(stockDT.Rows[0].ItemArray[2]);
                                                                tempStrQty += Convert.ToInt32(strArrays[6]);
                                                                strQty = tempStrQty.ToString();
                                                            }
                                                            catch
                                                            {
                                                                strQty = stockDT.Rows[0].ItemArray[2].ToString();
                                                            }
                                                            try
                                                            {
                                                                int tempStrMoney = Convert.ToInt32(stockDT.Rows[0].ItemArray[3]);
                                                                tempStrMoney += Convert.ToInt32(strArrays[7]);
                                                                strMoney = tempStrMoney.ToString();
                                                            }
                                                            catch
                                                            {
                                                                strMoney = stockDT.Rows[0].ItemArray[3].ToString();
                                                            }
                                                            mySqlAddData = myConn.CreateCommand();
                                                            mySqlAddData.CommandText = "UPDATE 库存表 set 数量 = '" +
                                                                strQty +
                                                                "',入库金额='" +
                                                                strMoney +
                                                                "',单据单号='" +
                                                                strArrays[3] +
                                                                "',单据名称='" +
                                                                strArrays[4] +
                                                                "',入库员='" +
                                                                strArrays[8] +
                                                                "',入库时间='" +
                                                                strArrays[5] +
                                                                "',入库备注='" +
                                                                strArrays[9] +
                                                                "' where 空调型号 = '" +
                                                                strArrays[1] + 
                                                                "' and 仓库名称 = '" + 
                                                                strArrays[10] + "'";
                                                            myReslut = mySqlAddData.ExecuteNonQuery();
                                                            if (myReslut != System.DBNull.Value)
                                                            {
                                                                blOk = true;
                                                            }
                                                            else
                                                            {
                                                                blOk = false;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            mySqlAddData = myConn.CreateCommand();
                                                            mySqlAddData.CommandText = "INSERT INTO 库存表(空调型号,单据单号,单据名称," +
                                                                "入库时间,数量,入库金额,入库员,入库备注,仓库名称) VALUES ('" +
                                                                strArrays[2].ToString() +
                                                                "','" +
                                                                strArrays[3].ToString() +
                                                                "','" +
                                                                strArrays[4].ToString() +
                                                                "','" +
                                                                strArrays[5].ToString() +
                                                                "','" +
                                                                strArrays[6].ToString() +
                                                                "','" +
                                                                strArrays[7].ToString() +
                                                                "','" +
                                                                strArrays[8].ToString() +
                                                                "','" +
                                                                strArrays[9].ToString() +
                                                                "','" +
                                                                strArrays[10].ToString() +
                                                                "')";
                                                            myReslut =
                                                                mySqlAddData.ExecuteNonQuery();
                                                            if (myReslut != System.DBNull.Value)
                                                            {
                                                                blOk = true;
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
                                    }
                                }
                            }
                        }
                    }
                    if (blOk == true)
                    {
                        //保存数据到数据库 备份并删除原先的文件 
                        try
                        {
                            var sourceFilePath = strInputPath + fnames;
                            string strObjPath = mySys.exePath() + @"\数据\入库备份\";
                            var destFileName = strObjPath + fnames;
                            File.Copy(sourceFilePath, destFileName);
                        }
                        catch
                        {
                            //MessageBox.Show("入库文件拷贝出错");
                        }
                        try
                        {
                            File.Delete(strInputPath + fnames);
                        }
                        catch
                        {
                            //MessageBox.Show("入库文件删除失败" + ex.Message);
                        }
                    }
                }
                myConn.Close();
                string returnflag = "";
                if (i >= 1)
                {
                    returnflag = "inputShow," + i.ToString();
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
                return "error," + ex.Message;
            }
        }

        public DataTable SelectCountAndPriceWithInTable()
        {
            string strConOffice = off.readConnOffice();
            systemFunction.systemFunction mySys = new systemFunction.systemFunction();
            OleDbConnection myConn = new OleDbConnection(strConOffice);
            try
            {
                myConn.Open();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            string selectSQLString = "select 数量,金额 from 入库表";
            OleDbDataAdapter adapter = new OleDbDataAdapter(selectSQLString, myConn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }
    }
}
