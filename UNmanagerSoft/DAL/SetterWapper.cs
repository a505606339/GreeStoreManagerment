using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.OleDb;
using System.Text;
using UNmanagerSoft.Utility;

namespace UNmanagerSoft.DAL
{
    class SetterWapper
    {
        officeTool off = new officeTool();
        /// <summary>
        /// 查询用户表所有数据
        /// </summary>
        /// <returns>用户表所有数据</returns>
        public DataTable setterSelect()
        {
            string strConOffice = off.readConnOffice();
            OleDbConnection conn = new OleDbConnection(strConOffice);
            conn.Open();
            string sqlStr = "select * from 安装员表";
            OleDbDataAdapter adapter = new OleDbDataAdapter(sqlStr, conn);
            DataTable dataset = new DataTable();
            adapter.Fill(dataset);
            conn.Close();
            return dataset;
        }

        /// <summary>
        /// 根据条件查询用户表中符合的数据 
        /// </summary>
        /// <param name="name">查询条件</param>
        /// <returns>查询的数据集</returns>
        public DataTable setterSelect(string name)
        {
            string strConOffice = off.readConnOffice();
            OleDbConnection conn = new OleDbConnection(strConOffice);
            conn.Open();
            string sqlStr = "select * from 安装员表 where 名字 = " + "'" + name + "'";
            OleDbDataAdapter adapter = new OleDbDataAdapter(sqlStr, conn);
            DataTable dataset = new DataTable();
            adapter.Fill(dataset);
            conn.Close();
            return dataset;
        }

        /// <summary>
        /// 插入数据到安装员表
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="dateTime">增加时间</param>
        /// <returns>受影响的行数</returns>
        public int setterInsert(string name, string dateTime)
        {
            string strConOffice = off.readConnOffice();
            OleDbConnection conn = new OleDbConnection(strConOffice);
            conn.Open();
            string sqlStr = "insert into 安装员表 values('" + name + "','" +
                dateTime + "')";
            OleDbCommand command = new OleDbCommand(sqlStr, conn);
            int returnflag = 0;
            try
            {
                returnflag = command.ExecuteNonQuery();
            }
            catch (Exception)
            {
            }
            return returnflag;
        }

        /// <summary>
        /// 根据条件删除客户表中的数据 
        /// </summary>
        /// <param name="condition">删除的名称</param>
        /// <returns>受影响的行数</returns>
        public int setterDelete(string name)
        {
            string strConOffice = off.readConnOffice();
            OleDbConnection conn = new OleDbConnection(strConOffice);
            conn.Open();
            string sqlStr = "delete from 安装员表 where 名字 = '" + name + "'";
            OleDbCommand command = new OleDbCommand(sqlStr, conn);
            int returnflag = command.ExecuteNonQuery();
            return returnflag;
        }
    }
}
