using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.IO;
using systemFunction;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using UNmanagerSoft.View;
using UNmanagerSoft.Utility;
using UNmanagerSoft.DAL;

namespace UNmanagerSoft
{
    public partial class MainForm : Form
    {
        //当前选中的按钮,用于标记前一个按钮,以替换背景 
        private imageButton clickbtn; 
        private InDataForm inDataForm;
        private OutDataForm outDataForm;
        private ReturnedDataForm returnedDataForm;
        private OutDataForm reOutDataForm;
        private WarehouseForm inwarehouseForm;
        private WarehouseForm outwarehouseForm;
        private WarehouseForm reWarehouseForm;
        private bool ClientNameFormOpen = false;
        private bool OptNameFormOpen = false;

        public MainForm()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            getIPAddress();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoginForm lf = new LoginForm();
            DialogResult dr = lf.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.None)
            {
                
            }
            var off = new officeTool();
            off.initConnString();
            clickbtn = imgbtn_In;
            imgbtn_In.BackgroundImage = Properties.Resources.btn_enter;
            
        }

        #region button触发切换tabpages的方法

        private void imgbtn_In_Click(object sender, EventArgs e)
        {
            if (clickbtn != imgbtn_In)
            {
                lab_location.Text = "入库管理";
                clickbtn.BackgroundImage = Properties.Resources.btn_None;
                tabcontrol_main.SelectedTab = tabPage2;
                clickbtn._buttonStyle = imageButton.buttonStyle.none;
                clickbtn = imgbtn_In;
            }
            pictureBox1_Click(picbox_back, new EventArgs());
        }

        private void imgbtn_Out_Click(object sender, EventArgs e)
        {
            if (clickbtn != imgbtn_Out)
            {
                lab_location.Text = "出库管理";
                clickbtn.BackgroundImage = Properties.Resources.btn_None;
                tabcontrol_main.SelectedTab = tabPage3;
                clickbtn._buttonStyle = imageButton.buttonStyle.none;
                clickbtn = imgbtn_Out;
            }
            pictureBox1_Click(picbox_back, new EventArgs());
        }

        private void imgbtn_Returned_Click(object sender, EventArgs e)
        {
            if (clickbtn != imgbtn_Returned)
            {
                lab_location.Text = "退货管理";
                clickbtn.BackgroundImage = Properties.Resources.btn_None;
                tabcontrol_main.SelectedTab = tabPage4;
                clickbtn._buttonStyle = imageButton.buttonStyle.none;
                clickbtn = imgbtn_Returned;
            }
            pictureBox1_Click(picbox_back, new EventArgs());
        }

        private void imgbtn_Count_Click(object sender, EventArgs e)
        {
            if (clickbtn != imgbtn_Count)
            {
                lab_location.Text = "统计报表";
                clickbtn.BackgroundImage = Properties.Resources.btn_None;
                tabcontrol_main.SelectedTab = tabPage5;
                clickbtn._buttonStyle = imageButton.buttonStyle.none;
                clickbtn = imgbtn_Count;
            }
            pictureBox1_Click(picbox_back, new EventArgs());
        }

        private void imgbtn_Link_Click(object sender, EventArgs e)
        {
            if (clickbtn != imgbtn_Link)
            {
                lab_location.Text = "配置与传输";
                clickbtn.BackgroundImage = Properties.Resources.btn_None;
                tabcontrol_main.SelectedTab = tabPage6;
                clickbtn._buttonStyle = imageButton.buttonStyle.none;
                clickbtn = imgbtn_Link;
            }
            pictureBox1_Click(picbox_back, new EventArgs());
        }
        #endregion

        #region picbox在鼠标移入移出的变化
        private void picbox_MouseLeave(object sender, EventArgs e)
        {
            var pb = sender as PictureBox;
            pb.Location = new Point(pb.Location.X - 2, pb.Location.Y - 2);
            pb.Invalidate();
        }
        //当鼠标进入picbox区域时,绘制线条和移动位置,实现突出效果 
        private void picbox_MouseEnter(object sender, EventArgs e)
        {
            var pb = sender as PictureBox;
            var g = pb.CreateGraphics();
            g.SmoothingMode = SmoothingMode.AntiAlias;
            var p = new Pen(Color.FromArgb(192, 192, 192));
            g.DrawLine(p, 0, pb.Size.Height - 1, pb.Size.Width - 1, pb.Size.Height - 1);
            g.DrawLine(p, pb.Size.Width - 1, pb.Size.Height - 1, pb.Size.Width - 1, 0);
            pb.Location = new Point(pb.Location.X + 2, pb.Location.Y + 2);
            pb.Cursor = Cursors.Hand;
        }
        #endregion

        #region 返回按钮的控制
        //返回按钮的tab控制 
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            switch (tabcontrol_main.SelectedTab.Name)
            {
                case "tabPage2":
                    inContorlPannel.Visible = true;
                    if (inDataForm != null)
                    {
                        inDataForm.Close();
                    }
                    if (inwarehouseForm != null)
                    {
                        inwarehouseForm.Close();
                    }
                    break;
                case "tabPage3":
                    outContorlPannel.Visible = true;
                    if (outDataForm != null)
                    {
                        outDataForm.Close();
                    }
                    if (outwarehouseForm != null)
                    {
                        outwarehouseForm.Close();
                    }
                    break;
                case "tabPage4":
                    reControlsPanel.Visible = true;
                    if (returnedDataForm != null)
                    {
                        returnedDataForm.Close();
                    }
                    if (reWarehouseForm != null)
                    {
                        reWarehouseForm.Close();
                    }
                    if (reOutDataForm != null)
                    {
                        reOutDataForm.Close();
                    }
                    break;
            }
        }


        #endregion

        #region 入库
        private void picbox_inSelect_Click(object sender, EventArgs e)
        {
            inContorlPannel.Visible = false;
            inDataForm = new InDataForm();
            inDataForm.TopLevel = false;
            inDataForm.Parent = tabPage2;
            inDataForm.Dock = DockStyle.Fill;
            inDataForm.Show();
        }

        private void picbox_stock_Click(object sender, EventArgs e)
        {
            inContorlPannel.Visible = false;
            inwarehouseForm = new WarehouseForm();
            inwarehouseForm.TopLevel = false;
            inwarehouseForm.Parent = tabPage2;
            inwarehouseForm.Dock = DockStyle.Fill;
            inwarehouseForm.Show();
        }

        private void PicboxInInputDate(object sender, EventArgs e)
        {
            var inStorageWrapper = new InStorageWrapper();
            inContorlPannel.Enabled = false;
            var flag = inStorageWrapper.insertDBCommand();
            var flags = flag.Split(',');
            if (flags[0] == "inputShow")
            {
                MessageBox.Show("刷新成功,已刷入" + flags[1] + "个文件");
            }
            if (flags[0] == "err")
            {
                MessageBox.Show("没有找到最新的入库文件,请检查");
            }
            inContorlPannel.Enabled = true;
        }
        #endregion

        #region 退货
        private void picbox_reSelect_Click(object sender, EventArgs e)
        {
            reControlsPanel.Visible = false;
            returnedDataForm = new ReturnedDataForm();
            returnedDataForm.TopLevel = false;
            returnedDataForm.Parent = tabPage4;
            returnedDataForm.Dock = DockStyle.Fill;
            returnedDataForm.Show();
        }

        private void picbox_reReturned_Click(object sender, EventArgs e)
        {
            reControlsPanel.Visible = false;
            reOutDataForm = new OutDataForm();
            reOutDataForm.TopLevel = false;
            reOutDataForm.Parent = tabPage4;
            reOutDataForm.Dock = DockStyle.Fill;
            reOutDataForm.updateButton = false;
            reOutDataForm.Show();
        }

        private void picbox_reStock_Click(object sender, EventArgs e)
        {
            reControlsPanel.Visible = false;
            reWarehouseForm = new WarehouseForm();
            reWarehouseForm.TopLevel = false;
            reWarehouseForm.Parent = tabPage4;
            reWarehouseForm.Dock = DockStyle.Fill;
            reWarehouseForm.Show();
        }
        #endregion

        #region 出库
        private void picbox_outSelect_Click(object sender, EventArgs e)
        {
            outContorlPannel.Visible = false;
            outDataForm = new OutDataForm();
            outDataForm.TopLevel = false;
            outDataForm.Parent = tabPage3;
            outDataForm.Dock = DockStyle.Fill;
            outDataForm.Show();
        }

        private void picbox_outStock_Click(object sender, EventArgs e)
        {
            outContorlPannel.Visible = false;
            outwarehouseForm = new WarehouseForm();
            outwarehouseForm.TopLevel = false;
            outwarehouseForm.Parent = tabPage3;
            outwarehouseForm.Dock = DockStyle.Fill;
            outwarehouseForm.Show();
            
        }

        private void PicboxOutInputDate(object sender, EventArgs e)
        {
            var outStorageWrapper = new OutStorageWrapper();
            outContorlPannel.Enabled = false;
            var flag = outStorageWrapper.insertDBCommand();
            var flags = flag.Split(',');
            if (flags[0] == "outputShow")
            {
                MessageBox.Show("刷新成功,已刷入" + flags[1] + "个文件");
            }
            if (flags[0] == "err")
            {
                MessageBox.Show("没有找到最新的出库文件,请检查");
            }
            outContorlPannel.Enabled = true;
        }
        #endregion

        #region 统计报表

        private void toolbtn_ReportCount_Click(object sender, EventArgs e)
        {
            var ssForm = new StorageSelectForm();
            ssForm.datasouce += new ReturnDataSouce(ssForm_datasouce);
            ssForm.ShowDialog();
        }

        void ssForm_datasouce(DataTable dt)
        {
            dataGridView_storage.DataSource = dt;
        }

        //打印预览
        private int mark = 0;//序号
        private int pages = 0;//页数
        private int dataRow = 1;//dgw的数据行号
        private int page = 1;//当前页数
        private int pageAll = 0;
        private void toolbtn_ReportPreview_Click(object sender, EventArgs e)
        {
            if (dataGridView_storage.Rows.Count > 0)
            {
                //指定打印的数目为一页20行 
                if (dataGridView_storage.RowCount % 20 == 0)
                {
                    pages = dataGridView_storage.RowCount / 20;
                    pageAll = pages;
                }
                else
                {
                    pages = dataGridView_storage.RowCount / 20 + 1;
                    pageAll = pages;
                }
                this.printDocument1.DefaultPageSettings.PaperSize =
                    new System.Drawing.Printing.PaperSize("A4", 826, 1170);
                this.printDocument1.DefaultPageSettings.Landscape = true;
                this.printPreviewDialog1.Document = this.printDocument1;
                this.printPreviewDialog1.ShowDialog();
            }
            else
            {
                MessageBox.Show("未发现数据,请检查是否有数据存在");
            }
        }

        //打印按钮,调用printDocument的printed方法
        private void toolbtn_ReportPrint_Click(object sender, EventArgs e)
        {
            if (dataGridView_storage.Rows.Count > 0)
            {
                if (dataGridView_storage.RowCount % 20 == 0)
                {
                    pages = dataGridView_storage.RowCount / 20;
                    pageAll = pages;
                }
                else
                {
                    pages = dataGridView_storage.RowCount / 20 + 1;
                    pageAll = pages;
                }
                this.printDocument1.DefaultPageSettings.PaperSize =
                    new System.Drawing.Printing.PaperSize("A4", 826, 1170);
                this.printDocument1.DefaultPageSettings.Landscape = true;
                if (printDialog1.ShowDialog() == DialogResult.OK)
                {
                    printDocument1.Print();
                }
            }
            else
                MessageBox.Show("未发现数据,请检查是否有数据存在");
        }

        private void toolbtn_ReportExcel_Click(object sender, EventArgs e)
        {
            if (dataGridView_storage != null && dataGridView_storage.DataSource != null)
            {
                var excel = new GenerateExcel();
                excel.createExcel((DataTable) dataGridView_storage.DataSource);
            }
            else
            {
                MessageBox.Show("未发现数据,请检查是否有数据存在");
            }
        }

        //绘制打印表格 
        private void printDocument1_PrintPage(object sender,
            System.Drawing.Printing.PrintPageEventArgs e)
        {
            pages--;

            var font = new System.Drawing.Font("宋体", 26);
            float hangju = font.Height;
            e.Graphics.DrawString("空调库存统计报表", font, Brushes.Black, 300, 25);
            var strUser = "";
            string strYear = DateTime.Now.Year.ToString()
                , strMon = DateTime.Now.Month.ToString()
                , strDay = DateTime.Now.Day.ToString();
            e.Graphics.DrawString(strYear + "年" + strMon + "月"
                + strDay + "日", new Font("宋体", 12), Brushes.Black, 45, 75);
            e.Graphics.DrawString("确认人：" + strUser, new Font("宋体", 12)
                , Brushes.Black, 650, 75);
            var f = new Font("宋体", 8);
            e.Graphics.DrawLine(new Pen(Color.Black), 15, 95, 1155, 95);
            e.Graphics.DrawLine(new Pen(Color.Black), 15, 95, 15, 125);
            e.Graphics.DrawString("序", f, Brushes.Black, 20, 100);
            e.Graphics.DrawString("号", f, Brushes.Black, 20, 110);
            e.Graphics.DrawLine(new Pen(Color.Black), 45, 95, 45, 125);
            e.Graphics.DrawString("条码", f, Brushes.Black, 80, 110);
            e.Graphics.DrawLine(new Pen(Color.Black), 140, 95, 140, 125);
            e.Graphics.DrawString("内/外", f, Brushes.Black, 146, 110);
            e.Graphics.DrawLine(new Pen(Color.Black), 185, 95, 185, 125);
            e.Graphics.DrawString("空调型号", f, Brushes.Black, 240, 110);
            e.Graphics.DrawLine(new Pen(Color.Black), 326, 95, 326, 125);
            e.Graphics.DrawString("数量", f, Brushes.Black, 330, 110);
            e.Graphics.DrawLine(new Pen(Color.Black), 360, 95, 360, 125);
            e.Graphics.DrawString("入库金额", f, Brushes.Black, 365, 110);
            e.Graphics.DrawLine(new Pen(Color.Black), 420, 95, 420, 125);
            e.Graphics.DrawString("单据单号", f, Brushes.Black, 438, 110);
            e.Graphics.DrawLine(new Pen(Color.Black), 500, 95, 500, 125);
            e.Graphics.DrawString("单据名称", f, Brushes.Black, 516, 110);
            e.Graphics.DrawLine(new Pen(Color.Black), 580, 95, 580, 125);
            e.Graphics.DrawString("入库员", f, Brushes.Black, 585, 110);
            e.Graphics.DrawLine(new Pen(Color.Black), 625, 95, 625, 125);
            e.Graphics.DrawString("入库时间", f, Brushes.Black, 660, 110);
            e.Graphics.DrawLine(new Pen(Color.Black), 725, 95, 725, 125);
            e.Graphics.DrawString("出库单号", f, Brushes.Black, 745, 110);
            e.Graphics.DrawLine(new Pen(Color.Black), 805, 95, 805, 125);
            e.Graphics.DrawString("客户名称", f, Brushes.Black, 805, 110);
            e.Graphics.DrawLine(new Pen(Color.Black), 855, 95, 855, 125);
            e.Graphics.DrawString("出库金额", f, Brushes.Black, 860, 110);
            e.Graphics.DrawLine(new Pen(Color.Black), 915, 95, 915, 125);
            e.Graphics.DrawString("出库员", f, Brushes.Black, 920, 110);
            e.Graphics.DrawLine(new Pen(Color.Black), 960, 95, 960, 125);
            e.Graphics.DrawString("送货员", f, Brushes.Black, 965, 110);
            e.Graphics.DrawLine(new Pen(Color.Black), 1005, 95, 1005, 125);
            e.Graphics.DrawString("安装员", f, Brushes.Black, 1010, 110);
            e.Graphics.DrawLine(new Pen(Color.Black), 1050, 95, 1050, 125);
            e.Graphics.DrawString("出库时间", f, Brushes.Black, 1080, 110);
            e.Graphics.DrawLine(new Pen(Color.Black), 1155, 95, 1155, 125);
            e.Graphics.DrawLine(new Pen(Color.Black), 15, 125, 1155, 125);
            //count_dataGridView1多了行空行需减一
            var num = 160;
            if (dataGridView_storage.Rows.Count != 0)
            {
                var dgvData = new string[(dataGridView_storage.Rows.Count)
                    , (dataGridView_storage.Columns.Count)];
                for (var row = 0; row < dataGridView_storage.Rows.Count; row++)
                {
                    for (var column = 0; column < (dataGridView_storage.Columns.Count); column++)
                    {
                        dgvData[row, column] = dataGridView_storage.Rows[row]
                            .Cells[column].Value.ToString();
                    }
                }
                for (var Drawend = 0; Drawend < 20; Drawend++)
                {
                    if (dataRow - 1 == dataGridView_storage.RowCount)
                    {
                        break;
                    }
                    e.Graphics.DrawString(mark.ToString(), f, Brushes.Black, 20, num);//序号
                    e.Graphics.DrawString(dgvData[dataRow - 1, 0]
                        .ToString(), f, Brushes.Black, 50, num);//条码
                    e.Graphics.DrawString(dgvData[dataRow - 1, 1]
                        .ToString(), f, Brushes.Black, 151, num);//内外
                    if (dgvData[dataRow - 1, 2].Trim().Length > 15)
                    {
                        var typeStrSub = dgvData[dataRow - 1, 2].Trim().Substring(0, 15) + "...";
                        e.Graphics.DrawString(typeStrSub, f, Brushes.Black, 193, num);//空调型号
                    }
                    else
                    {
                        e.Graphics.DrawString(dgvData[dataRow - 1, 2]
                        .ToString(), f, Brushes.Black, 193, num);//空调型号
                    }
                    e.Graphics.DrawString(dgvData[dataRow - 1, 3]
                        .ToString(), f, Brushes.Black, 333, num);//数量
                    e.Graphics.DrawString(dgvData[dataRow - 1, 4]
                        .ToString(), f, Brushes.Black, 370, num);//入库金额
                    e.Graphics.DrawString(dgvData[dataRow - 1, 5]
                        .ToString(), f, Brushes.Black, 428, num);//单据单号
                    e.Graphics.DrawString(dgvData[dataRow - 1, 6]
                        .ToString(), f, Brushes.Black, 508, num);//单据名称
                    e.Graphics.DrawString(dgvData[dataRow - 1, 7]
                        .ToString(), f, Brushes.Black, 583, num);//入库员
                    try
                    {
                        e.Graphics.DrawString(dgvData[dataRow - 1, 8]
                            .ToString().Remove(16), f, Brushes.Black, 628, num); //入库时间
                    }
                    catch
                    {
                        e.Graphics.DrawString(dgvData[dataRow - 1, 8]
                            .ToString(), f, Brushes.Black, 628, num); //入库时间
                    }
                    e.Graphics.DrawString(dgvData[dataRow - 1, 9]
                        .ToString(), f, Brushes.Black, 732, num);//出库单号
                    e.Graphics.DrawString(dgvData[dataRow - 1, 10]
                        .ToString(), f, Brushes.Black, 810, num);//客户名称
                    e.Graphics.DrawString(dgvData[dataRow - 1, 11]
                        .ToString(), f, Brushes.Black, 864, num);//出库金额
                    e.Graphics.DrawString(dgvData[dataRow - 1, 12]
                        .ToString(), f, Brushes.Black, 921, num);//出库员
                    e.Graphics.DrawString(dgvData[dataRow - 1, 13]
                        .ToString(), f, Brushes.Black, 966, num);//送货员
                    e.Graphics.DrawString(dgvData[dataRow - 1, 14]
                        .ToString(), f, Brushes.Black, 1009, num);//安装员
                    try
                    {
                        e.Graphics.DrawString(dgvData[dataRow - 1, 15]
                            .ToString().Remove(16), f, Brushes.Black, 1053, num); //出库时间
                    }
                    catch
                    {
                        e.Graphics.DrawString(dgvData[dataRow - 1, 15]
                            .ToString(), f, Brushes.Black, 1053, num); //出库时间
                    }
                    num += 30;
                    mark++;
                    dataRow++;
                }
            }
            if (pages == 0)
            {
                e.HasMorePages = false;
                mark = 0;
                pages = pageAll;
                dataRow = 1;
                page = 1;
                pageAll = 0;
                e.Graphics.DrawString("第" + pageAll + "页" + "/共" + pageAll + "页"
                    , f, Brushes.Black, 1090, 800);
            }
            else
            {
                e.Graphics.DrawString("第" + page + "页" + "/共" + pageAll + "页"
                    , f, Brushes.Black, 1090, 800);
                page++;
                e.HasMorePages = true;
            }
        }
        #endregion

        #region 连接手持机与收发

        private bool blPressLink = true;
        private bool blLinkOK = false;
        Thread threadWatch = null;
        private Dictionary<string, Socket> dict = new Dictionary<string, Socket>();
        private void button_linkPDA_Click(object sender, EventArgs e)
        {
            this.button_linkPDA.Enabled = false;
            if (this.button_linkPDA.Text == "连接手持机")
            {
                if (blPressLink == true)
                {
                    blPressLink = false;
                    linkClient();
                    button_linkPDA.Text = "断开连接";
                    button_linkPDA.ForeColor = Color.Red;
                }
            }
            else if (this.button_linkPDA.Text == "断开连接")
            {
                this.button_linkPDA.Enabled = true;
                this.button_linkPDA.ForeColor = Color.Black;
                this.button_linkPDA.Text = "连接手持机";
                textBox_status.Text = "连接已断开";
                if (blLinkOK == true)
                    threadWatch.Abort();
                blPressLink = true;
                //button_linkPDA.Enabled = false; 
                socketWatch.Close();
            }
            this.button_linkPDA.Enabled = true;

        }

        Socket socketWatch = null;
        private void linkClient()
        {
            if (this.textBox_ipAddr.Text != "")
            {
                socketWatch = new Socket(AddressFamily.InterNetwork,
                    SocketType.Stream, ProtocolType.Tcp);
                var ip = IPAddress.Parse(this.textBox_ipAddr.Text);
                var ipe = new IPEndPoint(ip, 2080);
                try
                {
                    socketWatch.Bind(ipe);
                }
                catch (Exception ex)
                { MessageBox.Show(ex.ToString()); }
                socketWatch.Listen(30);
                threadWatch = new Thread(WatchConnecting);
                threadWatch.IsBackground = true;
                threadWatch.Start();
                blLinkOK = true;
                this.textBox_status.Text = "服务器启动成功";
                this.button_linkPDA.Enabled = false;
            }
        }

        private void WatchConnecting()
        {

            while (true)
            {
                var sokConnection = socketWatch.Accept();
                client_comboBox.Items.Add(sokConnection.RemoteEndPoint.ToString());
                dict.Add(sokConnection.RemoteEndPoint.ToString(), sokConnection);
                this.textBox_status.Text = "连接成功";
                this.button_linkPDA.ForeColor = Color.Red;
                this.button_linkPDA.Text = "取消同步手持机";
                //Thread thr = new Thread(receMsg);
                //thr.IsBackground = true;
                //thr.Start(sokConnection);
                lock (this)
                {
                    receMsg(sokConnection);
                }
            }
        }

        private Socket currentSokClient;
        private void receMsg(object sokConnectionparn)
        {
            currentSokClient = sokConnectionparn as Socket;
            bool Ispair = false;
            bool down = false;
            StringBuilder dataBuilder = new StringBuilder();
            while (true)
            {
                byte[] arrMsgRec = new byte[1024 * 1024 * 10];
                int length = -1;
                try
                {
                    if (currentSokClient != null)
                    {
                        length = currentSokClient.Receive(arrMsgRec);

                        string strTmp = System.Text.Encoding
                            .UTF8.GetString(arrMsgRec, 0, length);

                        if (strTmp == "receOptOk" ||
                            strTmp == "receSdrOk" ||
                            strTmp == "receStrOk" ||
                            strTmp == "rececliOk" ||
                            strTmp == "recePairOk")
                        {
                            downloadText(strTmp);
                        }
                        else
                        {
                            if (strTmp == "newpair#")
                            {
                                Ispair = true;
                            }
                            if (strTmp.Length >= 5)
                            {
                                if (Ispair)
                                {
                                    if (strTmp.IndexOf("#pairEnd") > -1)
                                    {
                                        Ispair = false;
                                        pairTableData(strTmp, currentSokClient);
                                        string sendStrRe = "pairReOK";
                                        byte[] bsr = Encoding.ASCII.GetBytes(sendStrRe);
                                        currentSokClient.Send(bsr, bsr.Length, 0);
                                    }
                                    else
                                        pairTableData(strTmp, currentSokClient);
                                }
                                else
                                {
                                    string[] flaglist = strTmp.Split(new char[] {'#'},
                                        StringSplitOptions.RemoveEmptyEntries);
                                    if (flaglist.Length > 2)
                                    {
                                        int len = Convert.ToInt32(flaglist[0]);
                                        dataBuilder.Append(flaglist[2]);
                                        if (dataBuilder.Length >= len)
                                        {
                                            switch (flaglist[1])
                                            {
                                                case "in":
                                                    InChangeText(dataBuilder.ToString(), currentSokClient);
                                                    break;
                                                case "out":
                                                    OutChangeText(dataBuilder.ToString(), currentSokClient);
                                                    break;
                                                case "re":
                                                    ReChangeText(dataBuilder.ToString(), currentSokClient);
                                                    break;
                                            }
                                            dataBuilder = new StringBuilder();
                                        }
                                    }
                                    else
                                    {
                                        dataBuilder.Append(strTmp);
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    if (length != -1)
                    {
                        MessageBox.Show("错误,在receMsg中" + ex.Message);
                        break;
                    }
                    break;
                }
                if (length == 0)
                {
                    if (currentSokClient.Poll(1000, SelectMode.SelectWrite))
                    {
                        currentSokClient.Shutdown(SocketShutdown.Both);
                        currentSokClient.Close();
                        //break;
                    }
                }
            }
        }

        private void InChangeText(string strText, Socket sokClient)
        {
            ReceiveDataDispose receiveDataDispose = new ReceiveDataDispose();
            string[] result = receiveDataDispose.saveInInfor(strText)
                .Split(',');
            if (result.Length > 1)
            {
                if (result[0].Equals("inputShow"))
                {
                    ShowMsg showMsg = new ShowMsg(result[1]);
                    MethodInvoker invorkerShow = new MethodInvoker(showMsg.inputShow);
                    BeginInvoke(invorkerShow);
                    //MessageBox.Show("文件" + result[1] + "份");
                }
                if (result[0].Equals("err"))
                {
                    ShowMsg showMsg = new ShowMsg(result[1]);
                    MethodInvoker invorkerShow = new MethodInvoker(showMsg.inputErr);
                    BeginInvoke(invorkerShow);
                    //MessageBox.Show("未发现入库文件,请检查数据文件夹下数据是否有文件");
                }
                if (result[0].Equals("error"))
                {
                    ShowMsg showMsg = new ShowMsg(result[1]);
                    MethodInvoker invorkerShow = new MethodInvoker(showMsg.inputError);
                    BeginInvoke(invorkerShow);
                    //MessageBox.Show("数据导入出错,错误代码:" + result[1]);
                }
            }
            else
            {
                MessageBox.Show("数据导入出错,请检查数据文件夹下的入库数据是否存在问题");
            }
            
        }

        private void OutChangeText(string strText, Socket sokClient)
        {
            ReceiveDataDispose receiveDataDispose = new ReceiveDataDispose();
            string[] result = receiveDataDispose.saveOutInfor(strText)
                .Split(',');
            if (result.Length > 1)
            {
                if (result[0].Equals("outputShow"))
                {
                    ShowMsg showMsg = new ShowMsg(result[1]);
                    MethodInvoker invorkerShow = new MethodInvoker(showMsg.outputShow);
                    BeginInvoke(invorkerShow);
                    //MessageBox.Show("已刷新出库文件" + result[1] + "份");
                }
                if (result[0].Equals("err"))
                {
                    ShowMsg showMsg = new ShowMsg(result[1]);
                    MethodInvoker invorkerShow = new MethodInvoker(showMsg.outputErr);
                    BeginInvoke(invorkerShow);
                    //MessageBox.Show("未发现出库文件,请检查数据文件夹下数据是否有文件");
                }
                if (result[0].Equals("error"))
                {
                    ShowMsg showMsg = new ShowMsg(result[1]);
                    MethodInvoker invorkerShow = new MethodInvoker(showMsg.outputError);
                    BeginInvoke(invorkerShow);
                    //MessageBox.Show("数据导入出错,错误代码:" + result[1]);
                }
            }
            else
            {
                MessageBox.Show("数据导入出错,请检查数据文件夹下的出库数据是否存在问题");
            }
        }

        private void ReChangeText(string strText, Socket sokClient)
        {
            ReceiveDataDispose receiveDataDispose = new ReceiveDataDispose();
            string[] result = receiveDataDispose.saveReturnedfor(strText)
                .Split(',');
            if (result.Length > 1)
            {
                
                
                if (result[0].Equals("returnedShow"))
                {
                    ShowMsg showMsg = new ShowMsg(result[1]);
                    MethodInvoker invorkerShow = new MethodInvoker(showMsg.returnerShow);
                    BeginInvoke(invorkerShow);
                    //MessageBox.Show("已刷新退货文件" + result[1] + "份");
                }
                if (result[0].Equals("err"))
                {
                    ShowMsg showMsg = new ShowMsg(result[1]);
                    MethodInvoker invorkerShow = new MethodInvoker(showMsg.returnerErr);
                    BeginInvoke(invorkerShow);
                    //MessageBox.Show("未发现退货文件,请检查数据文件夹下数据是否有文件"); 
                }
                if (result[0].Equals("error"))
                {
                    ShowMsg showMsg = new ShowMsg(result[1]);
                    MethodInvoker invorkerShow = new MethodInvoker(showMsg.returnerError);
                    BeginInvoke(invorkerShow);
                    //MessageBox.Show("数据导入出错,错误代码:" + result[1]);
                }
            }
            else
            {
                MessageBox.Show("数据导入出错,请检查数据文件夹下的入退货数据是否存在问题");
            }
        }

        private StringBuilder strPairData = new StringBuilder();
        private void pairTableData(string data, Socket socketClient)
        {
            strPairData.Append(data);
            if (strPairData.ToString().IndexOf("#pairEnd") > -1)
            {
                if (strPairData.Length > 20)
                {
                    if (strPairData.ToString().IndexOf("\r\n") < 10)
                    {
                        string subData = strPairData.ToString().Substring(10, strPairData.Length - 20);
                        string[] dataItems = Regex.Split(subData, "\r\n");
                        PairedWrapper pair = new PairedWrapper();
                        string[] result = pair.uploadPaired(dataItems).Split(',');
                        if (result[0] == "1")
                        {
                            ShowMsg sm = new ShowMsg(result[1]);
                            MethodInvoker invokerShow = new MethodInvoker(sm.pairShow);
                            BeginInvoke(invokerShow);
                        }
                        else
                        {
                            ShowMsg sm = new ShowMsg(result[1]);
                            MethodInvoker invokerShow = new MethodInvoker(sm.pairError);
                            BeginInvoke(invokerShow);
                        }
                        strPairData = new StringBuilder();
                    }
                    else
                    {
                        string subData = strPairData.ToString().Substring(8, strPairData.Length - 18);
                        string[] dataItems = Regex.Split(subData, "\r\n");
                        PairedWrapper pair = new PairedWrapper();
                        string[] result = pair.uploadPaired(dataItems).Split(',');
                        if (result[0] == "1")
                        {
                            ShowMsg sm = new ShowMsg(result[1]);
                            MethodInvoker invokerShow = new MethodInvoker(sm.pairShow);
                            BeginInvoke(invokerShow);
                        }
                        else
                        {
                            ShowMsg sm = new ShowMsg(result[1]);//
                            MethodInvoker invokerShow = new MethodInvoker(sm.pairError);
                            BeginInvoke(invokerShow);
                        }
                        strPairData = new StringBuilder();
                    }
                    //string[] dataList = Regex.Split(data, "\r\n");
                }
            }
        }

        private void downloadText(string flag)
        {
            switch (flag)
            {
                case "recePairOk":
                    MessageBox.Show("下载配对表成功", "温馨提示");
                    break;
                case "receOptOk":
                    MessageBox.Show("下载操作员表成功", "温馨提示");
                    break;
                case "receSdrOk":
                    MessageBox.Show("下载送货员表成功", "温馨提示");
                    break;
                case "receStrOk":
                    MessageBox.Show("下载安装员表成功", "温馨提示");
                    break;
                case "rececliOk":
                    MessageBox.Show("下载客户信息成功", "温馨提示");
                    break;
            }
        }

        //private StringBuilder strPairData = new StringBuilder();
        //private void pairTableData(string data, Socket socketClient)
        //{
        //    strPairData.Append(data);
        //    if (strPairData.ToString().IndexOf("#pairEnd") > -1)
        //    {
        //        if (strPairData.Length > 20)
        //        {
        //            if (strPairData.ToString().IndexOf("\r\n") < 10)
        //            {
        //                string subData = strPairData.ToString().Substring(10, strPairData.Length - 20);
        //                string[] dataItems = Regex.Split(subData, "\r\n");
        //                pairTableUpdate pair = new pairTableUpdate();
        //                int result = pair.updatePairMethod(dataItems);
        //                if (result == 1)
        //                {
        //                    ShowMsg sm = new ShowMsg("1");
        //                    MethodInvoker invokerShow = new MethodInvoker(sm.pairShow);
        //                    BeginInvoke(invokerShow);
        //                }
        //                else
        //                {
        //                    ShowMsg sm = new ShowMsg("0");
        //                    MethodInvoker invokerShow = new MethodInvoker(sm.returnerErr);
        //                    BeginInvoke(invokerShow);
        //                }
        //                strPairData = new StringBuilder();
        //            }
        //            else
        //            {
        //                string subData = strPairData.ToString().Substring(8, strPairData.Length - 18);
        //                string[] dataItems = Regex.Split(subData, "\r\n");
        //                pairTableUpdate pair = new pairTableUpdate();
        //                int result = pair.updatePairMethod(dataItems);
        //                if (result == 1)
        //                {
        //                    ShowMsg sm = new ShowMsg("1");
        //                    MethodInvoker invokerShow = new MethodInvoker(sm.pairShow);
        //                    BeginInvoke(invokerShow);
        //                }
        //                else
        //                {
        //                    ShowMsg sm = new ShowMsg("0");
        //                    MethodInvoker invokerShow = new MethodInvoker(sm.returnerErr);
        //                    BeginInvoke(invokerShow);
        //                }
        //                strPairData = new StringBuilder();// 
        //            }
        //            string[] dataList = Regex.Split(data, "\r\n");
        //        }
        //    }
        //}

        private void MsgShow(string msg)
        {
            Invoke(new Action(() =>
                {
                    MessageBox.Show(msg);
                }));
        }

        private void picbox_inInsert_Click(object sender, EventArgs e)
        {
            var inStorageWrapper = new InStorageWrapper();
            inContorlPannel.Enabled = false;
            var flag = inStorageWrapper.insertDBCommand();
            var flags = flag.Split(',');
            if (flags[0] == "inputShow")
            {
                MessageBox.Show("刷新成功,已刷入" + flags[1] + "个文件");
            }
            if (flags[0] == "err")
            {
                MessageBox.Show("没有找到最新的入库文件,请检查");
            }
            inContorlPannel.Enabled = true;
        }

        private void getIPAddress()
        {
            var hostName = Dns.GetHostName();
            var myIp =
                Dns.GetHostEntry(hostName);
            var ipList = myIp.AddressList;

            foreach (var ip in ipList)
            {
                if (ip.AddressFamily.Equals(AddressFamily.InterNetwork))
                {
                    if (!ip.Equals("127.0.0.1") &&
                        !ip.Equals("0.0.0.0"))
                    {
                        textBox_ipAddr.Text = ip.ToString();
                    }
                    else
                    {
                        MessageBox.Show("获取网络地址失败,请检查网络配置");
                    }
                }
            }
        }

        #endregion

        #region 员工与客户的配置信息按钮
        private void toolStripButton5_Click(object sender, EventArgs e)
        {

            if (groupBox_client.Controls.Count > 2)
            {
                var f = groupBox_client.Controls[2] as Form;
                f.Close();
                f.Dispose();
                OptNameFormOpen = false;
            }
            if (groupBox_client.Controls.Count == 2)
            {
                groupBox_client.Controls[0].Visible = false;
                groupBox_client.Controls[1].Visible = false;
            }
            ClientNameFormOpen = true;//
            client_comboBox.Text = "";
            groupBox_client.Visible = true;
            groupBox_client.Text = "客户管理";
            var clientNameForm = new ClientNameForm();
            clientNameForm.TopLevel = false;
            clientNameForm.Parent = groupBox_client;
            clientNameForm.Dock = DockStyle.Fill;
            clientNameForm.Show();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            if (groupBox_client.Controls.Count > 2)
            {
                var f = groupBox_client.Controls[2] as Form;
                f.Close();
                f.Dispose();
                ClientNameFormOpen = false;
            }
            if (groupBox_client.Controls.Count == 2)
            {
                groupBox_client.Controls[0].Visible = false;
                groupBox_client.Controls[1].Visible = false;
            }
            OptNameFormOpen = true;
            client_comboBox.Text = "";
            groupBox_client.Visible = true;
            groupBox_client.Text = "安装员";
            var optNameForm = new OptNameForm();
            optNameForm.flag = 0;
            optNameForm.TopLevel = false;
            optNameForm.Parent = groupBox_client;
            optNameForm.Dock = DockStyle.Fill;
            optNameForm.Show();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            if (groupBox_client.Controls.Count > 2)
            {
                var f = groupBox_client.Controls[2] as Form;
                f.Close();
                f.Dispose();
                ClientNameFormOpen = false;
            }
            if (groupBox_client.Controls.Count == 2)
            {
                groupBox_client.Controls[0].Visible = false;
                groupBox_client.Controls[1].Visible = false;
            }
            OptNameFormOpen = true;
            client_comboBox.Text = "";
            groupBox_client.Visible = true;
            groupBox_client.Text = "送货员";
            var optNameForm = new OptNameForm();
            optNameForm.flag = 1;
            optNameForm.TopLevel = false;
            optNameForm.Parent = groupBox_client;
            optNameForm.Dock = DockStyle.Fill;
            optNameForm.Show();
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            if (groupBox_client.Controls.Count > 2)
            {
                var f = groupBox_client.Controls[2] as Form;
                f.Close();
                f.Dispose();
                ClientNameFormOpen = false;
            }
            if (groupBox_client.Controls.Count == 2)
            {
                groupBox_client.Controls[0].Visible = false;
                groupBox_client.Controls[1].Visible = false;
            }
            OptNameFormOpen = true;
            client_comboBox.Text = "";
            groupBox_client.Visible = true;
            groupBox_client.Text = "操作员";
            var optNameForm = new OptNameForm();
            optNameForm.flag = 2;
            optNameForm.TopLevel = false;
            optNameForm.Parent = groupBox_client;
            optNameForm.Dock = DockStyle.Fill;
            optNameForm.Show();
        }

        private void btnPairedManage_Click(object sender, EventArgs e)
        {
            if (groupBox_client.Controls.Count > 2)
            {
                var f = groupBox_client.Controls[2] as Form;
                f.Close();
                f.Dispose();
                ClientNameFormOpen = false;
            }
            panelPairTable.Visible = true;
            panelPairTableButton.Visible = true;
            groupBox_client.Text = "配置表";
        }

        //给客户窗口和员工窗口的委托赋值,在选择了手持机地址的时候
        //把对应的socket和是否已连接的标识赋值给那边的委托对象 
        private void client_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ClientNameForm.testEvent != null || OptNameForm.testEvent != null)
            {
                if (!String.IsNullOrEmpty(client_comboBox.Text))
                {
                    if(ClientNameFormOpen)
                        ClientNameForm.testEvent(
                            dict[client_comboBox.Text.Trim()], blLinkOK);
                    if(OptNameFormOpen)
                        OptNameForm.testEvent(
                            dict[client_comboBox.Text.Trim()], blLinkOK);
                }
                else
                {
                    ClientNameForm.testEvent(
                        null, false);
                }
            }
        }
        #endregion

        #region 重绘控件
        //重绘pannel,添增蓝色边框 
        private void bottomPanelBorder_Paint(object sender, PaintEventArgs e)
        {
            Panel p = sender as Panel;
            ControlPaint.DrawBorder(e.Graphics,
                p.ClientRectangle,
                Color.FromArgb(51, 153, 255),
                1,
                ButtonBorderStyle.None,
                Color.FromArgb(51, 153, 255),
                1,
                ButtonBorderStyle.Solid,
                Color.FromArgb(51, 153, 255),
                1,
                ButtonBorderStyle.None,
                Color.FromArgb(51, 153, 255),
                1,
                ButtonBorderStyle.Solid);
        }

        private void rightPanelBorder_Paint(object sender, PaintEventArgs e)
        {
            Panel p = sender as Panel;
            ControlPaint.DrawBorder(e.Graphics,
                p.ClientRectangle,
                Color.FromArgb(51, 153, 255),
                1,
                ButtonBorderStyle.Solid,
                Color.FromArgb(51, 153, 255),
                1,
                ButtonBorderStyle.None,
                Color.FromArgb(51, 153, 255),
                1,
                ButtonBorderStyle.Solid,
                Color.FromArgb(51, 153, 255),
                1,
                ButtonBorderStyle.None);
        }
        #endregion
        
        #region 配置表
        //检索三种方式,优先根据条码检索,条码为空根据型号检索,都为空查询全部数据 
        private void button_pairCodeQuery_Click(object sender, EventArgs e)
        {
            PairedWrapper pairedWrapper = new PairedWrapper();
            if (combox_paircodeSelect.Text.Length >= 5)
            {
                try
                {
                    dataGridView_pairTable.DataSource =
                        pairedWrapper.SelectPairedWithBarcode(combox_paircodeSelect.Text.Trim(),
                        combox_paircodeSelect.Text.Trim());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("查询数据库失效,在 button_pairCodeQuery_Click"
                                    + ex.Message);
                }
            }
            else if (text_pairAirTypeSelect.Text.Trim().Length > 0)
            {
                try
                {
                    dataGridView_pairTable.DataSource = pairedWrapper.
                        SelectPaierdWithType(text_pairAirTypeSelect.Text.Trim());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("查询数据库失效,在 button_pairCodeQuery_Click"
                                    + ex.Message);
                }
            }
            else
            {
                try
                {
                    dataGridView_pairTable.AutoGenerateColumns = false;
                    dataGridView_pairTable.DataSource = pairedWrapper.SelectAllPaired();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("查询数据库失效,在 button_pairCodeQuery_Click"
                                    + ex.Message);
                }
            }
        }

        //点击dgv的某列时填充到右侧输入框
        private void dataGridView_pairTable_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView_pairTable.CurrentRow != null)
                {
                    if (this.dataGridView_pairTable.SelectedRows.Count >= 0)
                    {
                        this.textBox_inPairCode.Text = this.dataGridView_pairTable
                            .Rows[this.dataGridView_pairTable.CurrentRow.Index]
                            .Cells[0].Value.ToString();
                        this.textBox_outPairCode.Text = this.dataGridView_pairTable
                            .Rows[this.dataGridView_pairTable.CurrentRow.Index]
                            .Cells[1].Value.ToString();
                        this.textBox_pairTpye.Text = this.dataGridView_pairTable
                            .Rows[this.dataGridView_pairTable.CurrentRow.Index]
                            .Cells[2].Value.ToString();
                        oldPairedInbarcode = textBox_inPairCode.Text;
                        oldPairedOutbarcode = textBox_outPairCode.Text;
                    }
                }
            }
            catch (Exception ex)
            { MessageBox.Show("错误,在pairCodeQuery" + ex.Message); }
        }

        //新建配置数据
        private void button_pairCodeSave_Click(object sender, EventArgs e)
        {
            string pairedInbarcode = textBox_inPairCode.Text.Trim();
            string pairedOutbarcode = textBox_outPairCode.Text.Trim();
            string pairedType = textBox_pairTpye.Text.Trim();
            int result = -1;
            PairedWrapper pairedWrapper = new PairedWrapper();
            if (pairedInbarcode.Length == 5 &&
                pairedOutbarcode.Length == 5 &&
                pairedType.Length > 0)
            {
                result = pairedWrapper.InsertPaired(
                    pairedInbarcode,pairedOutbarcode,pairedType);
                dataGridView_pairTable.DataSource = pairedWrapper.SelectAllPaired();
                if (result == -1)
                {
                    MessageBox.Show("数据插入失败,请检查输入");
                }
                if(result == 0)
                {
                    MessageBox.Show("该条码已经存在,请勿重复录入");
                }
                if (result > 0)
                {
                    MessageBox.Show("配置新建成功,新增了" + result.ToString() + "条配置");
                }
            }
            else
            {
                MessageBox.Show("内机条码、外机条码与型号为必填项，请保证输入完整");
            }
        }

        //更新配置表 
        private string oldPairedInbarcode = "";
        private string oldPairedOutbarcode = "";
        private void button_pairCodeModify_Click(object sender, EventArgs e)
        {
            string newInbarcode = textBox_inPairCode.Text.Trim();
            string newOutbarcode = textBox_outPairCode.Text.Trim();
            string newType = textBox_pairTpye.Text.Trim();
            if (!String.IsNullOrEmpty(oldPairedInbarcode) &&
                !String.IsNullOrEmpty(oldPairedOutbarcode))
            {
                if (newInbarcode.Length == 5 &&
                    newInbarcode.Length == 5 &&
                    newType.Length > 0)
                {
                    int result = -1;
                    PairedWrapper pairedWrapper = new PairedWrapper();
                    result = pairedWrapper.UpdatePaired(oldPairedInbarcode,
                        oldPairedOutbarcode, newInbarcode, newOutbarcode, newType);
                    dataGridView_pairTable.DataSource = pairedWrapper.SelectAllPaired();
                    oldPairedInbarcode = "";
                    oldPairedOutbarcode = "";
                    if (result == -1)
                    {
                        MessageBox.Show("数据修改失败,请检查输入");
                    }
                    if (result == 0)
                    {
                        MessageBox.Show("未查找到要修改条码,请确认已点击左侧要修改条码");
                    }
                    if (result > 0)
                    {
                        MessageBox.Show("配置修改成功,修改了" + result.ToString() + "条配置");
                    }
                }
                else
                {
                    MessageBox.Show("内外机条码与型号不可为空");
                }
            }
            else
            {
                MessageBox.Show("请先选择要修改的条码");
            }
        }

        //根据内外机删除某条配置数据
        private void button_pairCodeDelete_Click(object sender, EventArgs e)
        {
            string inbarcode = textBox_inPairCode.Text.Trim();
            string outbarcode = textBox_outPairCode.Text.Trim();
            if (inbarcode.Length > 0 &&
                outbarcode.Length > 0)
            {
                if (DialogResult.Yes == MessageBox.Show("确定删除内机为:" + inbarcode +
                    "外机为:"+outbarcode + "的配置数据吗?",
                    "请检查", MessageBoxButtons.YesNo))
                {
                    PairedWrapper pairedWrapper = new PairedWrapper();
                    int result = pairedWrapper.DeletePaired(inbarcode, outbarcode);
                    if (result > 0)
                    {
                        MessageBox.Show("成功删除" + result.ToString() + "条数据");
                        DataTable newData = pairedWrapper.SelectAllPaired();
                        dataGridView_pairTable.DataSource = newData;
                    }
                    else
                    {
                        MessageBox.Show("删除失败,请检查该条码是否存在.");
                    }
                }
                else
                {
                    textBox_inPairCode.Text = "";
                    textBox_outPairCode.Text = "";
                }
            }
        }

        //清空输入,这里把全局变量oldbarcode也清空
        private void button_pairCodeInsert_Click(object sender, EventArgs e)
        {
            oldPairedInbarcode = "";
            oldPairedOutbarcode = "";
            textBox_inPairCode.Text = "";
            textBox_outPairCode.Text = "";
            textBox_pairTpye.Text = "";
        }

        //下载数据到手持机
        private void button_paircodeDownload_Click(object sender, EventArgs e)
        {
            this.button_paircodeDownload.Enabled = false;
            if (blLinkOK == true)
            {
                try
                {
                    PairedWrapper pairedWrapper = new PairedWrapper();
                    DataTable dt = new DataTable();
                    dt = pairedWrapper.SelectAllPaired();
                    if (dt != null)
                    {
                        if (dt.Rows.Count >= 1)
                        {
                            string strTmp = "";
                            string strKey = this.client_comboBox.Text;
                            if (strKey.Length > 0)
                            {
                                byte[] testop = System.Text.Encoding.UTF8.GetBytes("paircode:");
                                dict[strKey].Send(testop);
                                for (int i = 0; i < dt.Rows.Count; i++)
                                {
                                    strTmp = dt.Rows[i].ItemArray[0].ToString() + "#"
                                             + dt.Rows[i].ItemArray[1].ToString()
                                             + "#" + dt.Rows[i].ItemArray[2].ToString();
                                    strTmp += "\r\n";
                                    byte[] sendbytes = System.Text.Encoding.UTF8.GetBytes(strTmp);
                                    dict[strKey].Send(sendbytes, sendbytes.Length, 0);
                                }
                                byte[] tested = System.Text.Encoding.UTF8.GetBytes("#pairEnd");
                                dict[strKey].Send(tested);
                            }
                            else
                            {
                                MessageBox.Show("请选择手持机的地址", "温馨提示");
                            }
                        }
                        else
                            MessageBox.Show("下载配对码表为空，无法下载", "温馨提示");
                    }
                }
                catch
                { MessageBox.Show("传输错误,请检查手持机地址,并保持手持机与客户端的连接",
                    "温馨提示"); }
            }
            else
                MessageBox.Show(" 请先同步手持扫描枪，请检查", "温馨提示");
            this.button_paircodeDownload.Enabled = true;
        }

        #endregion

        #region 跨线程消息窗体
        public class ShowMsg
        {
            private string str;

            public ShowMsg(string i)
            {
                str = i;
            }

            public void inputShow()
            {
                MessageBox.Show(" 已刷新最新的入库" + str + "文件，请检查", "温馨提示");
            }

            public void inputErr()
            {
                MessageBox.Show(" 没找到最新的入库文件，请检查", "温馨提示");
            }

            public void inputError()
            {
                MessageBox.Show("数据导入出错,错误代码:"+str, "温馨提示");
            }

            public void outputShow()
            {
                MessageBox.Show(" 已刷新最新的出库" + str + "文件，请检查", "温馨提示");
            }

            public void outputErr()
            {
                MessageBox.Show("没找到最新的出库文件，请检查", "温馨提示");
            }

            public void outputError()
            {
                MessageBox.Show("数据导入出错,错误代码:" + str, "温馨提示");
            }

            public void returnerShow()
            {
                MessageBox.Show(" 已刷新退货" + str + "文件,请检查", "温馨提示");
            }

            public void returnerErr()
            {
                MessageBox.Show(" 没找到最新的退货文件，请检查", "温馨提示");
            }

            public void returnerError()
            {
                MessageBox.Show("数据导入出错,错误代码:" + str, "温馨提示");
            }

            public void pairShow()
            {
                MessageBox.Show("配置表更新成功", "温馨提示");
            }

            public void pairErr()
            {
                MessageBox.Show("配置表更新出错,操作已回滚", "温馨提示");
            }

            public void pairError()
            {
                MessageBox.Show("配置表更新出错,错误代码:" + str, "温馨提示");
            }
        }
        #endregion

        //当关闭窗体时把上传线程给关闭掉 
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (threadWatch != null)
                    threadWatch.Abort();
                if (currentSokClient != null)
                    currentSokClient.Close();
                if (socketWatch != null)
                    socketWatch.Close();
            }
            catch
            {
                
            }
        }
    }
}