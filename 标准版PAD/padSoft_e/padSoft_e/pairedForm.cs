using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlServerCe;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace padSoft_e
{
    public partial class pairedForm : Form
    {
        string sqlPath = sysFunction.exePath() + @"数据\database.sdf";
        //内机所有页数 
        protected int inAllpage = 0;
        //外机所有页数
        protected int outAllpage = 0;
        //内机当前页数,在窗体load时使其等于最大页数 
        protected int inCurrentPage = 0;
        //外机当前页数
        protected int outCurrentPage = 0;
        public pairedForm()
        {
            InitializeComponent();
        }

        private void pairedForm_Load(object sender, EventArgs e)
        {
            initInOutCode();
            initListView();
        }

        private void initListView()
        {
            SqlCeConnection connet = new SqlCeConnection("Data Source =" + sqlPath);
            SqlCeCommand command = new SqlCeCommand();
            command.Connection = connet;
            SqlCeDataAdapter adapter = new SqlCeDataAdapter();
            DataTable dt = new DataTable();
            DataTable allCount = new DataTable();
            string selectInCount = "select count(*) from InTempTable";
            command.CommandText = selectInCount;
            adapter.SelectCommand = command;
            adapter.Fill(allCount);
            if (allCount.Rows.Count >= 0)
            {
                string count = allCount.Rows[0][0].ToString();
                try
                {
                    inAllpage = Convert.ToInt32(count) / 10;
                    lab_inNumber.Text = count.ToString();
                }
                catch
                {
                    inAllpage = 0;
                }
            }
            inCurrentPage = inAllpage;
            inCurrLable.Text = inAllpage.ToString();
            inAllpageLable.Text = inAllpage.ToString();
            inPageTurning(inCurrentPage.ToString());

            string selectOutCount = "select count(*) from OutTempTable";
            command.CommandText = selectOutCount;
            adapter.SelectCommand = command;
            allCount.Clear();
            adapter.Fill(allCount);
            if (allCount.Rows.Count >= 0)
            {
                string count = allCount.Rows[0][0].ToString();
                try
                {
                    outAllpage = Convert.ToInt32(count) / 10;
                    lab_outNumber.Text = count.ToString();
                }
                catch
                {
                    outAllpage = 0;
                }
            }
            outCurrentPage = outAllpage;
            outCurrLable.Text = outAllpage.ToString();
            outAllPageLable.Text = outAllpage.ToString();
            outPageTurning(outCurrentPage.ToString());
            connet.Close();
        }

        private bool paired = false;//是否完成匹配的标识lukasuper
        private List<string> pairBar = new List<string>();//匹配成功的数据列表
        List<string> lack_InBarCode = new List<string>();//多扫或遗漏的入库数据
        List<string> lack_OutBarCode = new List<string>();//~~~
        List<string[]> pairItems = new List<string[]>();//所有的数据,拆分成数组
        List<string> inBarCodeList = new List<string>();//排除inbarList中为空的元素后的list
        List<string> outBarCodeList = new List<string>();//~~~
        public List<string> strInCode = new List<string>();//配置表的入/出/型号
        public List<string> strOutCode = new List<string>();//~~~
        public List<string> strAirTpye = new List<string>();//~~~

        public void initInOutCode()
        {
            DBHelper dbHelper = new DBHelper();
            DataTable dt = dbHelper.selectAllToPairedTable();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    strInCode.Add(dr[1].ToString());
                    strOutCode.Add(dr[2].ToString());
                    strAirTpye.Add(dr[3].ToString());
                }
            }
        }
        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        

        //做匹配,并存储到匹配列表pairbar中,以提供保存使用 
        private void buttonPair_Click(object sender, EventArgs e)
        {
            DBHelper dbHelper = new DBHelper();
            DataTable indt = dbHelper.selectAllToTempInTable();
            DataTable outdt = dbHelper.selectAllToTempOutTable();
            for (int i = 0; i < indt.Rows.Count; i++)
            {
                for(int j = 0; j < outdt.Rows.Count; j++)
                {
                    //这里写比较 删除 和写入 
                    if (indt.Rows[i][3].Equals(outdt.Rows[j][3]))
                    {
                        int influenceRow = dbHelper.insertOutTable(indt.Rows[i][1].ToString(),
                            outdt.Rows[j][2].ToString(),indt.Rows[i][3].ToString(),
                            indt.Rows[i][4].ToString(),indt.Rows[i][5].ToString(),
                            indt.Rows[i][6].ToString(),indt.Rows[i][7].ToString(),
                            indt.Rows[i][8].ToString(),indt.Rows[i][9].ToString(), 
                            indt.Rows[i][10].ToString(),indt.Rows[i][11].ToString(), 
                            indt.Rows[i][12].ToString(),"测试");
                        if (influenceRow > 0)
                        {
                            dbHelper.deleteTempInTableByID(indt.Rows[i][0].ToString());
                            dbHelper.deleteTempOutTableByID(outdt.Rows[j][0].ToString() );
                            outdt.Rows.RemoveAt(j);
                            break;
                        }
                    }
                }
            }
            listView_in.Items.Clear();
            listView_out.Items.Clear();
            initListView();
            scanFunction.oneBeeper();
            MessageBox.Show("匹配完成!");
        }

        /// <summary>
        /// 保留不匹配的数据,调用方法存储匹配的数据 
        /// </summary>
        private void addNoPairSavePair()
        {
            foreach (string items in pairBar)//拆分
            {
                string[] item = items.Split('\t');
                pairItems.Add(item);
            }
            bool lack = true;//是被遗漏的数据
            //检测入库数据是否存在遗漏
            //若是则存到遗漏list里 
            foreach (string inbar in inBarCodeList)
            {
                lack = true;
                foreach (string[] a in pairItems)
                {
                    if (a[0] == inbar.Substring(0, 13))
                    {
                        lack = false;
                        break;
                    }
                }
                if (lack)
                {
                    lack_InBarCode.Add(inbar);
                }
            }
            //检测出库数据是否存在遗漏
            //若是则存到遗漏list里这个在
            foreach (string outbar in outBarCodeList)
            {
                lack = true;//是被遗漏的数据
                foreach (string[] a in pairItems)
                {
                    if (a[1] == outbar.Substring(1, 13))
                    {
                        lack = false;
                        break;
                    }
                }
                if (lack)
                    lack_OutBarCode.Add(outbar);
            }
            paired = true;
            savePairedCode();
            listView_in.Items.Clear();
            listView_out.Items.Clear();
            XmlFactory xf = new XmlFactory();
            MessageBox.Show("存在不匹配的数据,可继续扫描或清空", "温馨提示");
        }

        /// <summary>
        /// 保存数据,如果检查到剩余内/外表中还有 
        /// 数据,则把原本的临时表用剩余数据覆盖,
        /// 把匹配成功的数据存入出库表,剩余数据存入
        /// 临时表. 
        /// </summary>
        private void savePairedCode()
        {
            try
            {
                int a = lack_InBarCode.Count;
                int b = lack_OutBarCode.Count;
                if (paired)
                {
                    string strFilePath = sysFunction.exePath() + "\\数据\\出库登记表.txt";
                    UTF8Encoding utf8 = new UTF8Encoding(false);
                    StreamWriter sw = new StreamWriter(strFilePath, true, utf8);
                    foreach (string data in pairBar)
                    {
                        if(!String.IsNullOrEmpty(data))
                            sw.WriteLine(data);
                    }
                    sw.Flush();
                    sw.Close();
                    MessageBox.Show("匹配的数据已保存成功");
                    if (lack_InBarCode.Count > 0)
                    {
                        strFilePath = sysFunction.exePath() + "\\数据\\内机临时表.txt";
                        sw = new StreamWriter(strFilePath,false, utf8);
                        foreach (string data in lack_InBarCode)
                            sw.WriteLine(data);
                        sw.Flush();
                        sw.Close();
                    }
                    else
                    {
                        if (File.Exists(sysFunction.exePath() + "\\数据\\内机临时表.txt"))
                            File.Create(sysFunction.exePath() + "\\数据\\内机临时表.txt").Close();
                    }
                    if (lack_OutBarCode.Count > 0)
                    {
                        strFilePath = sysFunction.exePath() + "\\数据\\外机临时表.txt";
                        sw = new StreamWriter(strFilePath, false, utf8);
                        foreach (string data in lack_OutBarCode)
                            sw.WriteLine(data);
                        sw.Flush();
                        sw.Close();
                    }
                    else
                    {
                        if (File.Exists(sysFunction.exePath() + "\\数据\\外机临时表.txt"))
                            File.Create(sysFunction.exePath() + "\\数据\\外机临时表.txt").Close();
                    }
                    paired = false;
                }
            }
            catch
            {
                MessageBox.Show("文件流写入失败,在批量出库时");
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("是否确定清除数据?清除不可回复,请确认!"
                , "重要提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation
                ,MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.OK)
            {
                DBHelper dbHelper = new DBHelper();
                dbHelper.clearTempInTable();
                dbHelper.clearTempOutTable();
                scanFunction.oneBeeper();
                MessageBox.Show("清空完成");
            }
        }

        protected virtual void inPageTurning(string index)
        {
            SqlCeConnection connet = new SqlCeConnection("Data Source =" + sqlPath);
            SqlCeCommand command = new SqlCeCommand();
            command.Connection = connet;
            SqlCeDataAdapter adapter = new SqlCeDataAdapter();
            DataTable dt = new DataTable();
            string selectText = "select top (10) * from InTempTable where id not in" +
                "(select top (@page*10) id from InTempTable order by id) order by id";
            command.Parameters.Add("page", SqlDbType.Int);
            command.Parameters["page"].Value = index;
            command.CommandText = selectText;
            adapter.SelectCommand = command;
            adapter.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                int num = 0;
                if (inCurrentPage >= 0)
                    num += inCurrentPage * 10;
                listView_in.Items.Clear();
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

        protected virtual void outPageTurning(string index)
        {
            SqlCeConnection connet = new SqlCeConnection("Data Source =" + sqlPath);
            SqlCeCommand command = new SqlCeCommand();
            command.Connection = connet;
            SqlCeDataAdapter adapter = new SqlCeDataAdapter();
            DataTable dt = new DataTable();
            string selectText = "select top (10) * from OutTempTable where id not in" +
                "(select top (@page*10) id from OutTempTable order by id) order by id";
            command.Parameters.Add("page", SqlDbType.Int);
            command.Parameters["page"].Value = index;
            command.CommandText = selectText;
            adapter.SelectCommand = command;
            adapter.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                int num = 0;
                if (outCurrentPage >= 0)
                    num += outCurrentPage * 10;
                listView_out.Items.Clear();
                foreach (DataRow dr in dt.Rows)
                {
                    num++;
                    outlistviewBeforeData(num.ToString(), dr[1].ToString(),
                        dr[2].ToString(), dr[3].ToString());
                }
            }
            connet.Close();
        }

        protected void outlistviewBeforeData(string id, string strInBar,
            string strOutBar, string strType)
        {
            ListViewItem lv = new ListViewItem();
            lv.Text = id;
            lv.SubItems.Add(strInBar);
            lv.SubItems.Add(strOutBar);
            lv.SubItems.Add(strType);
            listView_out.Items.Insert(0, lv);
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
            listView_in.Items.Insert(0, lv);
        }
        //
        private void pairedForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                buttonPair_Click(null, null);
            if (e.KeyCode == Keys.F2)
                savePairedCode();
            if (e.KeyCode == Keys.F4)
                buttonClear_Click(null, null);
            if (e.KeyCode == Keys.Escape)
                buttonBack_Click(null, null);
            if (e.KeyCode == Keys.Down)
            {
                if (buttonPair.Focused)
                {
                    buttonClear.Focus();
                    e.Handled = true;
                }
                if (buttonClear.Focused)
                {
                    buttonBack.Focus();
                    e.Handled = true;
                }
                if (buttonBack.Focused)
                {
                    buttonPair.Focus();
                    e.Handled = true;
                }
            }
            else if (e.KeyCode == Keys.Up)
            {
                if (buttonBack.Focused)
                {
                    buttonClear.Focus();
                    e.Handled = true;
                }
                if (buttonClear.Focused)
                {
                    buttonPair.Focus();
                    e.Handled = true;
                }
                if (buttonPair.Focused)
                {
                    buttonBack.Focus();
                    e.Handled = true;
                }
            }
        }

        private void btnInLeft_Click(object sender, EventArgs e)
        {
            if (inCurrentPage > 0)
            {
                try
                {
                    inCurrentPage--;
                    inPageTurning(inCurrentPage.ToString());
                    inCurrLable.Text = inCurrentPage.ToString();
                }
                catch
                {
                    MessageBox.Show("数据异常,请尝试重新进入页面");
                }
            }
            else
            {
                MessageBox.Show("当前已经是第一页");
            }
        }

        private void btnInRight_Click(object sender, EventArgs e)
        {
            if (inCurrentPage < inAllpage)
            {
                try
                {
                    inCurrentPage++;
                    inPageTurning(inCurrentPage.ToString());
                    inCurrLable.Text = inCurrentPage.ToString();
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

        private void btnOutLeft_Click(object sender, EventArgs e)
        {
            if (outCurrentPage > 0)
            {
                try
                {
                    outCurrentPage--;
                    outPageTurning(outCurrentPage.ToString());
                    outCurrLable.Text = outCurrentPage.ToString();
                }
                catch
                {
                    MessageBox.Show("数据异常,请尝试重新进入页面");
                }
            }
            else
            {
                MessageBox.Show("当前已经是第一页");//
            }
        }

        private void btnOutRight_Click(object sender, EventArgs e)
        {
            if (outCurrentPage < outAllpage)
            {
                try
                {
                    outCurrentPage++;
                    outPageTurning(outCurrentPage.ToString());
                    outCurrLable.Text = outCurrentPage.ToString();
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

    }
}