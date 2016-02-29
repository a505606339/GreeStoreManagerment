using System;
using System.Threading;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Data.SqlServerCe;
using System.Windows.Forms;

namespace padSoft_e
{
    public partial class InDateListForm : Form
    {
        protected string sqlPath = "Data Source =" + sysFunction.exePath() + @"数据\database.sdf";
        protected SqlCeConnection connet;
        //所有页数 
        protected int allpage = 0;
        //当前页数,在窗体load时使其等于最大页数  
        protected int currentPage = 0;
        public InDateListForm()
        {
            InitializeComponent();
            initListView();
        }

        protected virtual void initListView()
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
            this.listView1.Columns.Add("备注", 60, HorizontalAlignment.Center);
        }
        
        protected virtual void InDateListForm_Load(object sender, EventArgs e)
        {
            connet = new SqlCeConnection(sqlPath);
            connet.Open();
            SqlCeCommand command = new SqlCeCommand();
            command.Connection = connet;
            SqlCeDataAdapter adapter = new SqlCeDataAdapter();
            DataTable dt = new DataTable();
            DataTable allCount = new DataTable();
            string selectCount = "select count(*) from InTable";
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
            currentPage = allpage;
            textboxPage.Text = allpage.ToString();
            pageTurning(allpage.ToString());
        }

        protected void listviewBeforeData(string id, string strInBar,
            string strOutBar, string strTpye, string strOutNum,
            string strOutNumName, string strDate, string strQty,
            string strMoney, string strOptName, string strMark)
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
            lv.SubItems.Add(strMark);
            this.listView1.Items.Insert(0, lv);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //上一页按钮.将数据库中前十条搜索出来 
        private void button1_Click(object sender, EventArgs e)
        {
            if (currentPage > 0)
            {
                currentPage--;
                pageTurning(currentPage.ToString());
                textboxPage.Text = currentPage.ToString();
            }
            else
            {
                MessageBox.Show("当前已经是第一页");
            }
        }
        //下一页按钮,当当前页数等于最大页数时不可再下一页
        private void button2_Click(object sender, EventArgs e)
        {
            if (!currentPage.ToString().Equals(lab_allpage.Text))
            {
                try
                {
                    currentPage++;
                    pageTurning(currentPage.ToString());
                    textboxPage.Text = currentPage.ToString();
                }
                catch
                {
                    MessageBox.Show("保持页数输入框内为数字");
                }
            }
            else
            {
                MessageBox.Show("当前为最后一页");
            }
        }
        //跳转到指定页数 
        private void btnGoToPage_Click(object sender, EventArgs e)
        {
            try
            {
                int userIputPage = Convert.ToInt32(textboxPage.Text.Trim());

                if (userIputPage <= allpage)
                {
                    pageTurning(userIputPage.ToString());
                    currentPage = userIputPage;
                }
                else
                {
                    MessageBox.Show("请输入不大于总页数的数字");
                }
            }
            catch (FormatException fe)
            {
                MessageBox.Show("请输入不大于总页数的数字");
            }
        }

        protected virtual void pageTurning(string index)
        {
            connet = new SqlCeConnection(sqlPath);
            connet.Open();
            SqlCeCommand command = new SqlCeCommand();
            command.Connection = connet;
            SqlCeDataAdapter adapter = new SqlCeDataAdapter();
            DataTable dt = new DataTable();
            string selectText = "select top (10) * from InTable where id not in" +
                "(select top (@page*10) id from InTable order by id) order by id";
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
                        dr[10].ToString());
                }
            }
            connet.Close();
        }

        private void InDateListForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                button3_Click(null, null);
        }
    }
}