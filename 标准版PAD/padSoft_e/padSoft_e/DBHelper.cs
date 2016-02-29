using System;
using System.Data;
using System.Data.SqlServerCe;
using System.Collections.Generic;
using System.Text;

namespace padSoft_e
{
    class DBHelper
    {
        string sqlPath = sysFunction.exePath() + @"数据\database.sdf";
        
        /// <summary>
        /// 查询入库表中所有数据
        /// </summary>
        /// <param name="connection">打开的数据库连接</param>
        /// <returns>返回的数据</returns>
        public DataTable selectAllDataToIntable()
        {
            SqlCeConnection connet = new SqlCeConnection("Data Source =" + sqlPath); ;
            connet.Open();
            DataTable dt = new DataTable();
            string sqlSelectText = "select * from InTable";
            SqlCeCommand command = new SqlCeCommand(sqlSelectText, connet);
            SqlCeDataAdapter adapter = new SqlCeDataAdapter();
            adapter.SelectCommand = command;
            adapter.Fill(dt);
            connet.Close();
            return dt;
        }

        /// <summary>
        /// 根据传递连接连接服务器,搜索是否存在传递过来的内外机条码
        /// </summary>
        /// <param name="barcode">条码</param>
        /// <param name="connet">打开的数据库连接</param>
        /// <returns>若不存在于数据库中返回false</returns>
        public bool existsBarcodeInTable(string barcode)
        {
            SqlCeConnection connet = new SqlCeConnection("Data Source =" + sqlPath); ;
            connet.Open();
            string sqlSelectText = "select * from InTable where inBarcode = @inbarcodeValue or " +
                "outBarcode = @outbarcodeValue";
            SqlCeDataAdapter adapter = new SqlCeDataAdapter();
            DataTable dt = new DataTable();
            SqlCeCommand command = new SqlCeCommand(sqlSelectText, connet);
            command.Parameters.Add("@inbarcodeValue", SqlDbType.NVarChar);
            command.Parameters.Add("@outbarcodeValue", SqlDbType.NVarChar);
            command.Parameters["@inbarcodeValue"].Value = barcode;
            command.Parameters["@outbarcodeValue"].Value = barcode;
            adapter.SelectCommand = command;
            try
            {
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connet.Close();
            }
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 插入新数据到入库表
        /// </summary>
        /// <param name="inBarcode">内机条码</param>
        /// <param name="outBarcode">外机条码</param>
        /// <param name="inType">型号</param>
        /// <param name="inOrderNumber">单号</param>
        /// <param name="inOrderNumberName">单号名称</param>
        /// <param name="inDate">入库时间</param>
        /// <param name="inQuantity">入库数量</param>
        /// <param name="inMoney">入库金额</param>
        /// <param name="inOperater">操作员</param>
        /// <param name="inRemark">入库备注</param>
        /// <param name="connet">打开的数据库连接</param>
        /// <param name="inStockName">仓库名称</param>
        /// <returns>被影响的行数</returns>
        public int insertInTable(string inBarcode, string outBarcode, string inType,
            string inOrderNumber, string inOrderNumberName, string inDate,
            string inQuantity, string inMoney, string inOperater, string inRemark,string inStockName)
        {
            //
            SqlCeConnection connet = new SqlCeConnection("Data Source =" + sqlPath); ;
            connet.Open();
            string insertText = "insert into InTable(inBarcode,outBarcode,inType,inOrderNumber," +
                "inOrderName,inDate,inQuantity,inMoney,inOperater,inRemark,inStockName) values('" +
                inBarcode + "','" +
                outBarcode + "','" +
                inType + "','" +
                inOrderNumber + "','" +
                inOrderNumberName + "','" +
                inDate + "','" +
                inQuantity + "','" +
                inMoney + "','" +
                inOperater + "','" +
                inRemark + "','" +
                inStockName + "')";
            SqlCeCommand command = new SqlCeCommand(insertText, connet);
            int report = command.ExecuteNonQuery();
            connet.Close();
            return report;
        }
        /// <summary>
        /// 查询所有出库数据
        /// </summary>
        /// <param name="connection"></param>
        /// <returns>数据表</returns>
        public DataTable selectAllDataToOuttable()
        {
            SqlCeConnection connet = new SqlCeConnection("Data Source =" + sqlPath); ;
            connet.Open();
            DataTable dt = new DataTable();
            string sqlSelectText = "select * from OutTable";
            SqlCeCommand command = new SqlCeCommand(sqlSelectText, connet);
            SqlCeDataAdapter adapter = new SqlCeDataAdapter();
            adapter.SelectCommand = command;
            adapter.Fill(dt);
            connet.Close();
            return dt;
        }
        /// <summary>
        /// 根据条码查询出库数据中是否存在该条码
        /// </summary>
        /// <param name="barcode">条码</param>
        /// <param name="connet">打开的连接</param>
        /// <returns>true为存在</returns>
        public bool existsBarcodeOutTable(string barcode)
        {
            SqlCeConnection connet = new SqlCeConnection("Data Source =" + sqlPath); ;
            connet.Open();
            string sqlSelectText = "select * from OutTable where inBarcode = @inbarcodeValue or " +
                "outBarcode = @outbarcodeValue";
            SqlCeDataAdapter adapter = new SqlCeDataAdapter();
            DataTable dt = new DataTable();
            SqlCeCommand command = new SqlCeCommand(sqlSelectText,connet);
            command.Parameters.Add("@inbarcodeValue", SqlDbType.NVarChar);
            command.Parameters.Add("@outbarcodeValue", SqlDbType.NVarChar);
            command.Parameters["@inbarcodeValue"].Value = barcode;
            command.Parameters["@outbarcodeValue"].Value = barcode;
            adapter.SelectCommand = command;
            try
            {
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connet.Close();
            }
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 插入数据到出库表
        /// </summary>
        /// <param name="inBarcode"></param>
        /// <param name="outBarcode"></param>
        /// <param name="outType"></param>
        /// <param name="outOrderNumber"></param>
        /// <param name="outOrderNumberName"></param>
        /// <param name="outDate"></param>
        /// <param name="outQuantity"></param>
        /// <param name="outMoney"></param>
        /// <param name="outOperater"></param>
        /// <param name="outDeliver"></param>
        /// <param name="outSetter"></param>
        /// <param name="outRemark"></param>
        /// <param name="connet"></param>
        /// <returns></returns>
        public int insertOutTable(string inBarcode, string outBarcode, string outType,
            string outOrderNumber, string outOrderNumberName, string outDate,
            string outQuantity, string outMoney, string outOperater, string outDeliver,
            string outSetter, string outRemark, string outStockName)
        {
            SqlCeConnection connet = new SqlCeConnection("Data Source =" + sqlPath); ;
            connet.Open();
            string insertText = "insert into OutTable(inBarcode,outBarcode,outType,outOrderNumber," +
                "outClientName,outDate,outQuantity,outMoney,outOperater,outDeliver,outSetter,outRemark," + 
                "outStockName) values('" +
                inBarcode + "','" +
                outBarcode + "','" +
                outType + "','" +
                outOrderNumber + "','" +
                outOrderNumberName + "','" +
                outDate + "','" +
                outQuantity + "','" +
                outMoney + "','" +
                outOperater + "','" +
                outDeliver + "','" +
                outSetter + "','" +
                outRemark + "','" +
                outStockName + "')";
            SqlCeCommand command = new SqlCeCommand(insertText, connet);
            int affectRow = 0;
            try
            {
                affectRow = command.ExecuteNonQuery();
            }
            catch
            {

            }
            finally
            {
                connet.Close();
            }
            return affectRow;
        }

        public DataTable selectAllReturnedTable()
        {
            SqlCeConnection connet = new SqlCeConnection("Data Source =" + sqlPath); ;
            connet.Open();
            DataTable dt = new DataTable();
            string sqlSelectText = "select * from ReturnedTable";
            SqlCeCommand command = new SqlCeCommand(sqlSelectText, connet);
            SqlCeDataAdapter adapter = new SqlCeDataAdapter();
            adapter.SelectCommand = command;
            adapter.Fill(dt);
            connet.Close();
            return dt;
        }

        public bool existsBarcodeReturned(string inBarcode, string outBarcode)
        {
            SqlCeConnection connet = new SqlCeConnection("Data Source =" + sqlPath); ;
            connet.Open();
            string sqlSelectText = "select * from ReturnedTable where inBarcode = @inbarcodeValue or " +
                "outBarcode = @outbarcodeValue";
            SqlCeDataAdapter adapter = new SqlCeDataAdapter();
            DataTable dt = new DataTable();
            SqlCeCommand command = new SqlCeCommand(sqlSelectText, connet);
            command.Parameters.Add("@inbarcodeValue", SqlDbType.NVarChar);
            command.Parameters.Add("@outbarcodeValue", SqlDbType.NVarChar);
            command.Parameters["@inbarcodeValue"].Value = inBarcode;
            command.Parameters["@outbarcodeValue"].Value = outBarcode;
            adapter.SelectCommand = command;
            try
            {
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connet.Close();
            }
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int insertReturnedTable(string inBarcode, string outBarcode, string returnedType,
            string returnedRemark, string returnedClientName, string returnedOperater,
            string returnedDate)
        {
            SqlCeConnection connet = new SqlCeConnection("Data Source =" + sqlPath); ;
            connet.Open();
            string insertText = "insert into ReturnedTable(inBarcode,outBarcode,reType," +
                "reRemark,reClientName,reOperater,reReturnedDate) values('" +
                inBarcode + "','" +
                outBarcode + "','" +
                returnedType + "','" +
                returnedRemark + "','" +
                returnedClientName + "','" +
                returnedOperater + "','" +
                returnedDate + "')";
            SqlCeCommand command = new SqlCeCommand(insertText, connet);
            int report = command.ExecuteNonQuery();
            connet.Close();
            return report;
        }

        public DataTable selectAllToPairedTable()
        {
            SqlCeConnection connet = new SqlCeConnection("Data Source =" + sqlPath); ;
            connet.Open();
            DataTable dt = new DataTable();
            string selectText = "select * from PairedTable";
            SqlCeCommand command = new SqlCeCommand(selectText,connet);
            SqlCeDataAdapter adapter = new SqlCeDataAdapter();
            adapter.SelectCommand = command;
            try
            {
                adapter.Fill(dt);
            }
            catch
            {

            }
            finally
            {
                connet.Close();
            }
            return dt;
        }

        public DataTable selectAllToNewPairedTable()
        {
            SqlCeConnection connet = new SqlCeConnection("Data Source =" + sqlPath); ;
            connet.Open();
            DataTable dt = new DataTable();
            string selectText = "select * from NewPairedTable";
            SqlCeCommand command = new SqlCeCommand(selectText, connet);
            SqlCeDataAdapter adapter = new SqlCeDataAdapter();
            adapter.SelectCommand = command;
            adapter.Fill(dt);
            connet.Close();
            return dt;
        }

        public int insertPaired(string inBarcode, string outBarcode, string type)
        {
            SqlCeConnection connet = new SqlCeConnection("Data Source =" + sqlPath); ;
            connet.Open();
            string sqlInsertText = "insert into PairedTable(inBarcode,outBarcode,pairType)" +
                " values(@inValue,@outValue,@typeValue)";
            SqlCeCommand command = new SqlCeCommand();
            SqlCeDataAdapter adapter = new SqlCeDataAdapter();
            DataTable dt = new DataTable();
            command.CommandText = sqlInsertText;
            command.Connection = connet;
            command.Parameters.Add("@inValue", SqlDbType.NVarChar);
            command.Parameters.Add("@outValue", SqlDbType.NVarChar);
            command.Parameters.Add("@typeValue", SqlDbType.NVarChar);
            command.Parameters["@inValue"].Value = inBarcode;
            command.Parameters["@outValue"].Value = outBarcode;
            command.Parameters["@typeValue"].Value = type;
            int affectedRows = command.ExecuteNonQuery();
            string sqlInsertNewPairedText = "insert into NewPairedTable(inBarcode,outBarcode,type)" +
                " values(@inValue,@outValue,@typeValue)";
            command.CommandText = sqlInsertNewPairedText;
            command.ExecuteNonQuery();
            connet.Close();
            return affectedRows;//
        }

        public bool existsBarcodePaired(string inBarcode, string outBarcode)
        {
            SqlCeConnection connet = new SqlCeConnection("Data Source =" + sqlPath); ;
            connet.Open();
            string sqlSelectText = "select * from PairedTable where inBarcode" +
                " = @inbarcodeValue or " +
                "outBarcode = @outbarcodeValue";
            SqlCeDataAdapter adapter = new SqlCeDataAdapter();
            DataTable dt = new DataTable();
            SqlCeCommand command = new SqlCeCommand(sqlSelectText, connet);
            command.Parameters.Add("@inbarcodeValue", SqlDbType.NVarChar);
            command.Parameters.Add("@outbarcodeValue", SqlDbType.NVarChar);
            command.Parameters["@inbarcodeValue"].Value = inBarcode;//
            command.Parameters["@outbarcodeValue"].Value = outBarcode;
            adapter.SelectCommand = command;
            try
            {
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connet.Close();
            }
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public DataTable selectPairedByCondiction(string inBarcode, string outBarcode)
        {
            SqlCeConnection connet = new SqlCeConnection("Data Source =" + sqlPath); ;
            connet.Open();
            string selectText = "select * from PairedTable where inBarcode = '" +
                inBarcode + "' or outBarcode = '" + outBarcode + "'";
            SqlCeDataAdapter adapter = new SqlCeDataAdapter();
            DataTable dt = new DataTable();
            SqlCeCommand command = new SqlCeCommand(selectText, connet);
            adapter.SelectCommand = command;
            adapter.Fill(dt);
            connet.Close();
            return dt;
        }

        public DataTable selectPairedByType(string type)
        {
            SqlCeConnection connet = new SqlCeConnection("Data Source =" + sqlPath); ;
            connet.Open();
            string selectText = "select * from PairedTable where pairType like '" +
                type + "%'";
            SqlCeDataAdapter adapter = new SqlCeDataAdapter();
            DataTable dt = new DataTable();
            SqlCeCommand command = new SqlCeCommand(selectText, connet);
            adapter.SelectCommand = command;
            adapter.Fill(dt);
            connet.Close();
            return dt;
        }

        public DataTable selectPairedByBarcode(string barcode)
        {
            SqlCeConnection connet = new SqlCeConnection("Data Source =" + sqlPath); ;
            connet.Open();
            string selectText = "select * from PairedTable where inBarcode = '" +
                barcode + "' or outBarcode = '" + barcode + "'";
            DataTable dt = new DataTable();
            SqlCeDataAdapter adapter = new SqlCeDataAdapter(selectText, connet);
            adapter.Fill(dt);
            connet.Close();
            return dt;
        }

        public void clearIn()
        {
            SqlCeConnection connet = new SqlCeConnection("Data Source =" + sqlPath); ;
            connet.Open();
            string deleteText = "delete from InTable";
            SqlCeCommand command = new SqlCeCommand();
            command.CommandText = deleteText;
            command.Connection = connet;
            command.ExecuteNonQuery();
            connet.Close();
        }

        public void clearOut()
        {
            SqlCeConnection connet = new SqlCeConnection("Data Source =" + sqlPath); ;
            connet.Open();
            string deleteText = "delete from OutTable";
            SqlCeCommand command = new SqlCeCommand();
            command.CommandText = deleteText;
            command.Connection = connet;
            command.ExecuteNonQuery();
            connet.Close();
        }

        public void clearReturned()
        {
            SqlCeConnection connet = new SqlCeConnection("Data Source =" + sqlPath); ;
            connet.Open();
            string deleteText = "delete from ReturnedTable";
            SqlCeCommand command = new SqlCeCommand();
            command.CommandText = deleteText;
            command.Connection = connet;
            command.ExecuteNonQuery();
            connet.Close();
        }

        public void clearNewPaired()
        {
            SqlCeConnection connet = new SqlCeConnection("Data Source =" + sqlPath); ;
            connet.Open();
            string deleteText = "delete from NewPairedTable";
            SqlCeCommand command = new SqlCeCommand();
            command.CommandText = deleteText;
            command.Connection = connet;
            command.ExecuteNonQuery();
            connet.Close();
        }

        public bool existsBarcodeTempInbarcode(string inBarcode,string outBarcode)
        {
            SqlCeConnection connet = new SqlCeConnection("Data Source =" + sqlPath); ;
            connet.Open();
            string sqlSelectText = "select * from InTempTable where inBarcode" +
                " = @inbarcodeValue or " +
                "outBarcode = @outbarcodeValue";
            SqlCeDataAdapter adapter = new SqlCeDataAdapter();
            DataTable dt = new DataTable();
            SqlCeCommand command = new SqlCeCommand(sqlSelectText, connet);
            command.Parameters.Add("@inbarcodeValue", SqlDbType.NVarChar);
            command.Parameters.Add("@outbarcodeValue", SqlDbType.NVarChar);
            command.Parameters["@inbarcodeValue"].Value = inBarcode;
            command.Parameters["@outbarcodeValue"].Value = outBarcode;
            adapter.SelectCommand = command;
            try
            {
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connet.Close();
            }
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool existsBarcodeTempOutbarcode(string inBarcode, string outBarcode)
        {
            SqlCeConnection connet = new SqlCeConnection("Data Source =" + sqlPath); ;
            connet.Open();
            string sqlSelectText = "select * from OutTempTable where inBarcode" +
                " = @inbarcodeValue or " +
                "outBarcode = @outbarcodeValue";
            SqlCeDataAdapter adapter = new SqlCeDataAdapter();
            DataTable dt = new DataTable();
            SqlCeCommand command = new SqlCeCommand(sqlSelectText, connet);
            command.Parameters.Add("@inbarcodeValue", SqlDbType.NVarChar);
            command.Parameters.Add("@outbarcodeValue", SqlDbType.NVarChar);
            command.Parameters["@inbarcodeValue"].Value = inBarcode;
            command.Parameters["@outbarcodeValue"].Value = outBarcode;
            adapter.SelectCommand = command;
            try
            {
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connet.Close();
            }
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //
        public int InsertTempInTable(string inBarcode, string outBarcode, string type,
            string outNumber, string clientName, string dateTime,
            string outQty, string outMoney, string outOpt, string outSdr,
            string outStr, string remark)
        {
            SqlCeConnection connet = new SqlCeConnection("Data Source =" + sqlPath); ;
            connet.Open();
            string sqlInsertText = "insert into InTempTable(inBarcode,outBarcode,outType,"+
                "outOrderNumber,outClientName,outDate,outQuantity,outMoney,outOperater,outDeliver," +
                "outSetter,outRemark) values(@inValue,@outValue,@typeValue,@numberValue,"+
                "@clientNameValue,@dateTimeValue,@qtyValue,@moneyValue,@optValue,@sdrValue,"+
                "@strValue,@remarkValue)";
            SqlCeCommand command = new SqlCeCommand();
            SqlCeDataAdapter adapter = new SqlCeDataAdapter();
            DataTable dt = new DataTable();
            command.CommandText = sqlInsertText;
            command.Connection = connet;
            command.Parameters.Add("@inValue", SqlDbType.NVarChar);
            command.Parameters.Add("@outValue", SqlDbType.NVarChar);
            command.Parameters.Add("@typeValue", SqlDbType.NVarChar);
            command.Parameters.Add("@numberValue", SqlDbType.NVarChar);
            command.Parameters.Add("@clientNameValue", SqlDbType.NVarChar);
            command.Parameters.Add("@dateTimeValue", SqlDbType.NVarChar);
            command.Parameters.Add("@qtyValue", SqlDbType.NVarChar);
            command.Parameters.Add("@moneyValue", SqlDbType.NVarChar);
            command.Parameters.Add("@optValue", SqlDbType.NVarChar);
            command.Parameters.Add("@sdrValue", SqlDbType.NVarChar);
            command.Parameters.Add("@strValue", SqlDbType.NVarChar);
            command.Parameters.Add("@remarkValue", SqlDbType.NVarChar);
            command.Parameters["@inValue"].Value = inBarcode;
            command.Parameters["@outValue"].Value = outBarcode;
            command.Parameters["@typeValue"].Value = type;
            command.Parameters["@numberValue"].Value = outNumber;
            command.Parameters["@clientNameValue"].Value = clientName;
            command.Parameters["@dateTimeValue"].Value = dateTime;
            command.Parameters["@qtyValue"].Value = outQty;
            command.Parameters["@moneyValue"].Value = outMoney;
            command.Parameters["@optValue"].Value = outOpt;
            command.Parameters["@sdrValue"].Value = outSdr;
            command.Parameters["@strValue"].Value = outStr;
            command.Parameters["@remarkValue"].Value = remark;
            int affectedRows = 0;
            try
            {
                affectedRows = command.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                connet.Close();
            }
            return affectedRows;
        }

        public DataTable selectAllToTempInTable()
        {
            SqlCeConnection connet = new SqlCeConnection("Data Source =" + sqlPath); ;
            connet.Open();
            DataTable dt = new DataTable();
            string sqlSelectText = "select * from InTempTable";
            SqlCeCommand command = new SqlCeCommand(sqlSelectText, connet);
            SqlCeDataAdapter adapter = new SqlCeDataAdapter();
            adapter.SelectCommand = command;
            adapter.Fill(dt);
            connet.Close();
            return dt;
        }

        public void clearTempInTable()
        {
            SqlCeConnection connet = new SqlCeConnection("Data Source =" + sqlPath); ;
            connet.Open();
            string deleteText = "delete from InTempTable";
            SqlCeCommand command = new SqlCeCommand();
            command.CommandText = deleteText;
            command.Connection = connet;
            command.ExecuteNonQuery();
            connet.Close();
        }

        public void deleteTempInTableByID(string ID)
        {
            SqlCeConnection connet = new SqlCeConnection("Data Source =" + sqlPath); ;
            connet.Open();
            string deleteText = "delete from InTempTable where id = " + ID;
            SqlCeCommand command = new SqlCeCommand();
            command.CommandText = deleteText;
            command.Connection = connet;
            command.ExecuteNonQuery();
            connet.Close();
        }

        public int InsertTempOutTable(string inBarcode, string outBarcode,string type)
        {
            SqlCeConnection connet = new SqlCeConnection("Data Source =" + sqlPath);;
            connet.Open();
            string sqlInsertText = "insert into OutTempTable(inBarcode,outBarcode,outType)" +
                " values(@inValue,@outValue,@typeValue)";
            SqlCeCommand command = new SqlCeCommand();
            SqlCeDataAdapter adapter = new SqlCeDataAdapter();
            DataTable dt = new DataTable();
            command.CommandText = sqlInsertText;
            command.Connection = connet;
            command.Parameters.Add("@inValue", SqlDbType.NVarChar);
            command.Parameters.Add("@outValue", SqlDbType.NVarChar);
            command.Parameters.Add("@typeValue", SqlDbType.NVarChar);
            command.Parameters["@inValue"].Value = inBarcode;
            command.Parameters["@outValue"].Value = outBarcode;
            command.Parameters["@typeValue"].Value = type;
            int affectedRows = 0;
            try
            {
                affectedRows = command.ExecuteNonQuery();
            }
            catch
            {
 
            }
            finally
            {
                connet.Close();
            }
            return affectedRows;
        }

        public DataTable selectAllToTempOutTable()
        {
            SqlCeConnection connet = new SqlCeConnection("Data Source =" + sqlPath);
            connet.Open();
            DataTable dt = new DataTable();
            string sqlSelectText = "select * from OutTempTable";
            SqlCeCommand command = new SqlCeCommand(sqlSelectText, connet);
            SqlCeDataAdapter adapter = new SqlCeDataAdapter();
            adapter.SelectCommand = command;
            adapter.Fill(dt);
            connet.Close();
            return dt;
        }

        public void clearTempOutTable()
        {
            SqlCeConnection connet = new SqlCeConnection("Data Source =" + sqlPath); ;
            connet.Open();
            string deleteText = "delete from OutTempTable";
            SqlCeCommand command = new SqlCeCommand();
            command.CommandText = deleteText;
            command.Connection = connet;
            command.ExecuteNonQuery();
            connet.Close();
        }

        public void deleteTempOutTableByID(string ID)
        {
            SqlCeConnection connet = new SqlCeConnection("Data Source =" + sqlPath); ;
            connet.Open();
            string deleteText = "delete from OutTempTable where id = " + ID;
            SqlCeCommand command = new SqlCeCommand();
            command.CommandText = deleteText;
            command.Connection = connet;
            command.ExecuteNonQuery();
            connet.Close();
        }


    }
}
