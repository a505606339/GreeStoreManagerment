using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlServerCe;
using System.IO;
using System.Drawing;
using System.Threading;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace padSoft_e
{
    public partial class PairForm : Form
    {
        DBHelper dbHelper = new DBHelper();
        string dbPath = sysFunction.exePath() + @"数据\database.sdf";
        DataTable allpairedTable = new DataTable();
        //所有页数
        protected int allpage = 0;
        //当前页数,在窗体load时使其等于最大页数 
        protected int currentPage = 0;
        //用户搜索了数据进行上下页时,当前处于的行数
        private int userSelectRow = 0;
        //用户搜索数据的当前处于页数
        private int userSelectCurrentPage = 0;
        //用户搜索数据产生的总页数 
        private int userSelectAllPage = 0;
        //用户是否点了搜索
        private bool userSelectFlag = false;
        //用户搜索产生的datatable 
        DataTable userSelectDataTable = new DataTable();
        //加载数据完成
        public static bool loadingDataOK = false;

        public PairForm()
        {
            InitializeComponent();
            sysFunction.ShowWindow(sysFunction.iShowHideWindow(), 1);
        }

        private void PairForm_Load(object sender, EventArgs e)
        {
            

            listViewItemInit();
            openCommScan();
        }

        private void listViewItemInit()
        {
            string sqlPath = "Data Source = " + dbPath;
            SqlCeConnection connet = new SqlCeConnection(sqlPath);
            connet.Open();
            listView_pair.FullRowSelect = true;
            listView_pair.View = View.Details;
            listView_pair.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            this.listView_pair.Columns.Add("序号", 50, HorizontalAlignment.Center);
            this.listView_pair.Columns.Add("内机条码", 100, HorizontalAlignment.Left);
            this.listView_pair.Columns.Add("外机条码", 100, HorizontalAlignment.Left);
            this.listView_pair.Columns.Add("产品型号", 120, HorizontalAlignment.Left);
            this.listView_pair.View = View.Details;
            allpairedTable = dbHelper.selectAllToPairedTable();

            SqlCeCommand command = new SqlCeCommand();
            command.Connection = connet;
            SqlCeDataAdapter adapter = new SqlCeDataAdapter();
            DataTable dt = new DataTable();
            DataTable allCount = new DataTable();
            string selectCount = "select count(*) from PairedTable";
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
            connet.Close();
            labAllPage.Text = allpage.ToString();
            textboxPage.Text = allpage.ToString();
            currentPage = allpage;
            pageTurning(allpage.ToString());
        }

        protected virtual void pageTurning(string index)
        {
            string sqlPath = "Data Source = " + dbPath;
            SqlCeConnection connet = new SqlCeConnection(sqlPath);
            connet.Open();
            SqlCeCommand command = new SqlCeCommand();
            command.Connection = connet;
            SqlCeDataAdapter adapter = new SqlCeDataAdapter();
            DataTable dt = new DataTable();
            string selectText = "select top (10) * from PairedTable where id not in" +
                "(select top (@page*10) id from PairedTable order by id) order by id";
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
                listView_pair.Items.Clear();
                foreach (DataRow dr in dt.Rows)
                {
                    num++;
                    listviewBeforeData(num.ToString(), dr[1].ToString(),
                        dr[2].ToString(), dr[3].ToString());
                }
            }
            connet.Close();
        }
        //当剩余(ramain)数量少于十的时候取剩余的数量的数据 
        //不少于十取十条数据,添加到列表中 
        private void addListViewItems()
        {
            if (userSelectDataTable.Rows.Count > 0)
            {
                int loopCount = 10;
                int remain = userSelectDataTable.Rows.Count - userSelectRow;
                if (remain <= 10)
                {
                    loopCount = remain;
                }
                listView_pair.Items.Clear();
                int rows = userSelectRow;
                for (int i = 0; i < loopCount; i++)
                {
                    listviewBeforeData(rows.ToString(),
                        userSelectDataTable.Rows[rows][1].ToString(),
                        userSelectDataTable.Rows[rows][2].ToString(),
                        userSelectDataTable.Rows[rows][3].ToString());
                    rows++;
                }
            }
            else
            {
                listView_pair.Items.Clear();
            }
        }

        protected void listviewBeforeData(string id, string strInBar,
            string strOutBar, string strTpye)
        {
            ListViewItem lv = new ListViewItem();
            lv.Text = id;
            lv.SubItems.Add(strInBar);
            lv.SubItems.Add(strOutBar);
            lv.SubItems.Add(strTpye);
            if (userSelectFlag)
            {
                listView_pair.Items.Add(lv);
            }
            else
            {
                listView_pair.Items.Insert(0, lv);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
                serialPort1.Close();
            this.Close();
        }

        private void btn_PairSelect_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(text_type.Text.Trim()))
            {
                //初始化当前的行数
                userSelectRow = 0;
                //初始化当前的页数
                userSelectCurrentPage = 0;
                userSelectDataTable = dbHelper.selectPairedByType(text_type.Text.Trim());
                userSelectAllPage = userSelectDataTable.Rows.Count / 10;
                labAllPage.Text = userSelectAllPage.ToString();
                userSelectFlag = true;
                textboxPage.Text = "0";
                addListViewItems();
            }
            else
            {
                //初始化当前的行数
                userSelectRow = 0;
                //初始化当前的页数
                userSelectCurrentPage = 0;
                string inbarcode = text_inbarcode.Text.Trim();
                string outbarcode = text_outbarcode.Text.Trim();
                //查询符合条件的数据,并赋值给一个全局的DataTable
                userSelectDataTable = dbHelper.
                    selectPairedByCondiction(inbarcode, outbarcode);
                userSelectAllPage = userSelectDataTable.Rows.Count / 10;
                labAllPage.Text = userSelectAllPage.ToString();
                userSelectFlag = true;
                textboxPage.Text = "0";
                addListViewItems();
            }
        }

        private void btn_PairSave_Click(object sender, EventArgs e)
        {
            int insertflag = 0;
            string inbarcode = text_inbarcode.Text.Trim();
            string outbarcode = text_outbarcode.Text.Trim();
            string type = text_type.Text.Trim();
            if (!String.IsNullOrEmpty(text_inbarcode.Text.Trim()) &&
                !String.IsNullOrEmpty(text_outbarcode.Text.Trim()))
            {
                insertflag = dbHelper.insertPaired(inbarcode,
                    outbarcode,
                    type);
            }
            else
            {
                scanFunction.twoBeeper();
                MessageBox.Show("内机或外机为空,请检查输入");
            }
            if (insertflag > 0)
            {
                string newpath = sysFunction.exePath() + "\\config\\newPair.txt";
                using (StreamWriter sw2 = new StreamWriter(newpath, true, UTF8Encoding.UTF8))
                {
                    sw2.WriteLine(inbarcode + "#" + outbarcode + "#" + type);
                }
                scanFunction.oneBeeper();
                MessageBox.Show("插入数据成功,如要查看新增配置请点取消");
            }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            //显示load窗体以加载数据  
            this.KeyPreview = false;
            Thread loadThread = new Thread(loadFormStart);
            loadThread.Start();
            loadingDataOK = false;

            listView_pair.Clear();
            userSelectFlag = false;
            userSelectAllPage = 0;
            userSelectCurrentPage = 0;
            userSelectRow = 0;
            text_inbarcode.Text = "";
            text_outbarcode.Text = "";
            text_type.Text = "";
            listViewItemInit();

            loadingDataOK = true;
            this.KeyPreview = true;
        }

        private void loadFormStart()
        {
            LoadingForm loadingForm = new LoadingForm();
            loadingForm.ShowDialog();
        }

        private bool openCommScan()
        {
            if (serialPort1.IsOpen)
            {
                this.serialPort1.Close();
            }
            try
            {
                serialPort1.Open();
            }
            catch (Exception ex)
            {
                //comm = new SerialPort();  
                MessageBox.Show(ex.Message);
            }
            if (serialPort1.IsOpen)
                return true;
            else
                return false;
        }

        private void yellowScan()
        {
            scanFunction.ScanPowerOn();
            scanFunction.OneKeyScan();
        }

        private void PairForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                btn_PairSelect_Click(null, null);
            else if (e.KeyCode == Keys.F2)
                btn_PairSave_Click(null, null);
            else if (e.KeyCode == Keys.F4)
                button1_Click(null, null);
            else if (e.KeyCode == Keys.Escape)
                button2_Click(null, null);
            else if (e.KeyCode == Keys.F6)
                yellowScan();
            if (e.KeyCode == Keys.Down)
            {
                if (this.text_inbarcode.Focused)
                {
                    this.text_outbarcode.Focus();
                    e.Handled = true;
                    this.text_inbarcode.SelectAll();
                }
                else if (this.text_outbarcode.Focused)
                {
                    this.text_type.Focus();
                    e.Handled = true;
                    this.text_type.SelectAll();
                }
                else if (this.text_type.Focused)
                {
                    this.text_inbarcode.Focus();
                    e.Handled = true;
                    this.text_inbarcode.SelectAll();
                }
            }
            if (e.KeyCode == Keys.Up)
            {
                if (this.text_type.Focused)
                {
                    this.text_outbarcode.Focus();
                    e.Handled = true;
                    this.text_inbarcode.SelectAll();
                }
                else if (this.text_outbarcode.Focused)
                {
                    this.text_inbarcode.Focus();
                    e.Handled = true;
                    this.text_inbarcode.SelectAll();
                }
                else if (this.text_inbarcode.Focused)
                {
                    this.text_type.Focus();
                    e.Handled = true;
                    this.text_inbarcode.SelectAll();
                }
            }
        }

        private void serialPort1_DataReceived(object sender,
            System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            Thread.Sleep(10); //读取速度太慢，加Sleep延长读取时间, 不可缺少//500:2047   1000:2047

            byte[] readBuffer = new byte[this.serialPort1.BytesToRead];

            this.serialPort1.Read(readBuffer, 0, readBuffer.Length);

            string txt = System.Text.Encoding.Default.GetString(readBuffer, 0, readBuffer.Length);

            ChangeTextScan(txt);
        }

        //截取用户扫描到的想要增加的条码 
        private void ChangeTextScan(string str)
        {
            Invoke(new EventHandler(delegate
            {
                if (text_inbarcode.Focused)
                {
                    string barcode = str.Substring(0, 5);
                    text_inbarcode.Text = barcode;
                    scanFunction.oneBeeper();
                }
                if (text_outbarcode.Focused)
                {
                    string barcode = str.Substring(0, 5);
                    text_outbarcode.Text = barcode;
                    scanFunction.oneBeeper();
                }
            }));
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            this.KeyPreview = false;
            Thread loadThread = new Thread(loadFormStart);
            loadThread.Start();
            loadingDataOK = false;
            Thread.Sleep(200);

            if (userSelectFlag)
            {
                if (userSelectCurrentPage <= 0)
                {
                    MessageBox.Show("当前已经是第一页");
                }
                else
                {
                    userSelectRow -= 10;
                    userSelectCurrentPage--;
                    addListViewItems();
                    textboxPage.Text = userSelectCurrentPage.ToString();
                }
            }
            else
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

            loadingDataOK = true;
            this.KeyPreview = true;
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            this.KeyPreview = false;
            Thread loadThread = new Thread(loadFormStart);
            loadThread.Start();
            loadingDataOK = false;
            Thread.Sleep(200);

            if (userSelectFlag)
            {
                if (userSelectCurrentPage >= userSelectAllPage)
                {
                    MessageBox.Show("当前已经是最后一页");
                }
                else
                {
                    userSelectRow += 10;
                    userSelectCurrentPage++;
                    addListViewItems();
                    textboxPage.Text = userSelectCurrentPage.ToString();

                }
            }
            else
            {
                if (!currentPage.ToString().Equals(labAllPage.Text))
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

            loadingDataOK = true;
            this.KeyPreview = true;
        }

        private void btnGotoPage_Click(object sender, EventArgs e)
        {
            try
            {
                Regex reg = new Regex("^[0-9]+$");
                Match ma = reg.Match(textboxPage.Text.Trim());
                if (ma.Success)
                {
                    int userInputPage = Convert.ToInt32(textboxPage.Text.Trim());
                    if (userSelectFlag && userInputPage <= userSelectAllPage)
                    {
                        userSelectCurrentPage = userInputPage;
                        userSelectRow = userInputPage * 10;
                        addListViewItems();
                    }
                    else if (userInputPage <= allpage)
                    {
                        currentPage = userInputPage;
                        pageTurning(userInputPage.ToString());
                    }
                    else
                    {
                        MessageBox.Show("请输入不大于总页数的数字");
                    }
                }
                else
                {
                    MessageBox.Show("请输入数字");
                }
            }
            catch
            {

            }
        }
    }
}