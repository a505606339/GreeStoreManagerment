using System;
using System.Data.SqlServerCe;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace padSoft_e
{
    public partial class OutDataListForm : InDateListForm
    {
        public OutDataListForm()
        {
            InitializeComponent();
        }

        protected override void InDateListForm_Load(object sender, EventArgs e)
        {
            connet = new SqlCeConnection(sqlPath);
            connet.Open();
            SqlCeCommand command = new SqlCeCommand();
            command.Connection = connet;
            SqlCeDataAdapter adapter = new SqlCeDataAdapter();
            DataTable dt = new DataTable();
            DataTable allCount = new DataTable();
            //
            string selectText = "select top (10) * from OutTable where id not in" +
                "(select top (@page*10) id from OutTable ) order by id";
            string selectCount = "select count(*) from OutTable";
            command.CommandText = selectCount;
            adapter.SelectCommand = command;
            adapter.Fill(allCount);
            if (allCount.Rows.Count >= 0)
            {
                string count = allCount.Rows[0][0].ToString();
                try
                {
                    allpage = Convert.ToInt32(count) / 10;
                }
                catch
                {
                    allpage = 0;
                }
            }
            lab_allpage.Text = allpage.ToString();

            command.Parameters.Add("page", SqlDbType.Int);
            command.Parameters["page"].Value = allpage.ToString();
            command.CommandText = selectText;
            adapter.SelectCommand = command;
            adapter.Fill(dt);
            pageTurning(allpage.ToString());
            currentPage = allpage;
            textboxPage.Text = allpage.ToString();
        }

        //因为是继承窗体,这里直接重写
        protected override void initListView()
        {
            listView1.FullRowSelect = true;
            listView1.View = View.Details;
            listView1.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            this.listView1.Columns.Add("序号", 100, HorizontalAlignment.Left);
            this.listView1.Columns.Add("内机条码", 100, HorizontalAlignment.Left);
            this.listView1.Columns.Add("外机条码", 100, HorizontalAlignment.Left);
            this.listView1.Columns.Add("空调类型", 100, HorizontalAlignment.Center);
            this.listView1.Columns.Add("单据单号", 100, HorizontalAlignment.Left);
            this.listView1.Columns.Add("单据名称", 100, HorizontalAlignment.Center);
            this.listView1.Columns.Add("入库时间", 100, HorizontalAlignment.Center);
            this.listView1.Columns.Add("数量", 60, HorizontalAlignment.Center);
            this.listView1.Columns.Add("金额", 60, HorizontalAlignment.Center);
            this.listView1.Columns.Add("操作员", 60, HorizontalAlignment.Center);
            this.listView1.Columns.Add("安装员", 60, HorizontalAlignment.Center);
            this.listView1.Columns.Add("送货员", 60, HorizontalAlignment.Center);
            this.listView1.Columns.Add("备注", 60, HorizontalAlignment.Center);
        }

        protected override void pageTurning(string index)
        {
            connet = new SqlCeConnection(sqlPath);
            connet.Open();
            SqlCeCommand command = new SqlCeCommand();
            command.Connection = connet;
            SqlCeDataAdapter adapter = new SqlCeDataAdapter();
            DataTable dt = new DataTable();
            string selectText = "select top (10) * from OutTable where id not in" +
                "(select top (@page*10) id from OutTable order by id) order by id";
            command.Parameters.Add("page", SqlDbType.Int);
            command.Parameters["page"].Value = index;
            command.CommandText = selectText;
            adapter.SelectCommand = command;
            adapter.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                int num = 0;
                if (currentPage >= 0)
                    num += currentPage * 10;
                listView1.Items.Clear();
                foreach (DataRow dr in dt.Rows)
                {
                    num++;
                    listviewBeforeData(num.ToString(), dr[1].ToString(),
                        dr[2].ToString(), dr[3].ToString(),
                        dr[4].ToString(), dr[5].ToString(),
                        dr[6].ToString(), dr[7].ToString(),
                        dr[8].ToString(), dr[9].ToString(),
                        dr[10].ToString(), dr[11].ToString(),
                        dr[12].ToString());
                }
            }
            connet.Close();
        }
        //
        protected void listviewBeforeData(string id,
            string strInBar, string strOutBar, string strTpye,
            string strOutNum, string strOutNumName, string strDate,
            string strQty, string strMoney, string strOptName,
            string strDeliver, string strSetter, string strMark)
        {
            ListViewItem lv = new ListViewItem();
            lv.Text = id;
            lv.SubItems.Add(strInBar);
            lv.SubItems.Add(strOutBar);
            lv.SubItems.Add(strTpye);
            lv.SubItems.Add(strOutNum);
            lv.SubItems.Add(strOutNumName);
            lv.SubItems.Add(strDate);
            lv.SubItems.Add(strQty);
            lv.SubItems.Add(strMoney);
            lv.SubItems.Add(strOptName);
            lv.SubItems.Add(strDeliver);
            lv.SubItems.Add(strSetter);
            lv.SubItems.Add(strMark);
            this.listView1.Items.Insert(0, lv);
        }

    }
}