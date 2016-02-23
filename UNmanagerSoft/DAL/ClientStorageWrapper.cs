using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.OleDb;
using System.Text;
using UNmanagerSoft.Utility;
using UNmanagerSoft.Business_LL;

namespace UNmanagerSoft.DAL
{
    class ClientStorageWrapper
    {
        officeTool off = new officeTool();

        /// <summary>
        /// 查询用户表所有数据
        /// </summary>
        /// <returns>用户表所有数据</returns>
        public DataTable clientSelect()
        {
            string strConOffice = off.readConnOffice();
            OleDbConnection conn = new OleDbConnection(strConOffice);
            conn.Open();
            string sqlStr = "select * from 客户表";
            OleDbDataAdapter adapter = new OleDbDataAdapter(sqlStr, conn);
            DataTable dataset = new DataTable();
            adapter.Fill(dataset);
            conn.Close();
            return dataset;
        }

        /// <summary>
        /// 根据条件查询用户表中符合的数据 
        /// </summary>
        /// <param name="name">条件字段名</param>
        /// <returns>查询的数据集</returns>
        public DataTable clientSelect(string field, string condition)
        {
            string strConOffice = off.readConnOffice();
            OleDbConnection conn = new OleDbConnection(strConOffice);
            conn.Open();
            string sqlStr = "select * from 客户表 where " + field + " = " + "'" + condition + "'";
            OleDbDataAdapter adapter = new OleDbDataAdapter(sqlStr, conn);
            DataTable dataset = new DataTable();
            adapter.Fill(dataset);
            conn.Close();
            return dataset;
        }

        /// <summary>
        /// 插入数据到客户表
        /// </summary>
        /// <param name="clientName">客户名称</param>
        /// <param name="clientAddress">客户地址</param>
        /// <param name="clientPhone">客户电话</param>
        /// <param name="insertDate">插入时间</param>
        /// <returns>受影响的行数</returns>
        public int clientInsert(ClientEntity clientEntity)
        {
            string strConOffice = off.readConnOffice();
            OleDbConnection conn = new OleDbConnection(strConOffice);
            conn.Open();
            string sqlStr = "insert into 客户表(客户姓名,客户地址,客户电话,添加时间) values ('"
                + clientEntity.ClientName + "', '" + clientEntity.ClientAddress + "', '"
                + clientEntity.ClientPhone + "', '" + clientEntity.DateTime + "')";
            OleDbCommand command = new OleDbCommand(sqlStr, conn);
            int returnflag = 0;
            try
            {
                returnflag = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
            return returnflag;
        }

        /// <summary>
        /// 更新客户表中的某行数据
        /// </summary>
        /// <param name="clientName">客户名称</param>
        /// <param name="clientAddress">客户地址</param>
        /// <param name="clientPhone">客户电话</param>
        /// <param name="insertDate">客户时间</param>
        /// <param name="field">条件字段</param>
        /// <param name="condition">条件内容</param>
        /// <returns>受影响的行数</returns>
        public int clientUpdate(ClientEntity clientEntity)
        {
            string strConOffice = off.readConnOffice();
            OleDbConnection conn = new OleDbConnection(strConOffice);
            conn.Open();

            string sqlStr = "update 客户表 set 客户姓名 = '" + clientEntity.ClientName
                + "', 客户地址 = '" + clientEntity.ClientAddress + "', 客户电话 = '"
                + clientEntity.ClientPhone + "', 添加时间 = '" + clientEntity.DateTime
                + "' where ID = " + clientEntity.ID;
            OleDbCommand command = new OleDbCommand(sqlStr, conn);
            int returnflag = command.ExecuteNonQuery();
            return returnflag;
        }

        /// <summary>
        /// 根据条件删除客户表中的数据 
        /// </summary>
        /// <param name="condition">删除的行ID</param>
        /// <returns>受影响的行数</returns>
        public int clientDelete(int id)
        {
            string strConOffice = off.readConnOffice();
            OleDbConnection conn = new OleDbConnection(strConOffice);
            conn.Open();
            string sqlStr = "delete from 客户表 where ID = " + id;
            OleDbCommand command = new OleDbCommand(sqlStr, conn);
            int returnflag = command.ExecuteNonQuery();
            return returnflag;
        }

    }
}
