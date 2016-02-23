using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using UNmanagerSoft.DAL;

namespace UNmanagerSoft.View
{
    public partial class OptNameForm : Form
    {
        public int flag = 0;
        private Socket linkSocket = null;
        private bool linkOK = false;
        public delegate void myDelegate(Socket socket, bool linkOK);
        public static myDelegate testEvent;
        public OptNameForm()
        {
            InitializeComponent();
            testEvent = setSocketLinkValue;
        }

        private void OptNameForm_Load(object sender, EventArgs e)
        {
            switch(flag)
            {
                case 0:
                    lab_name.Text = "安装员名称";
                    break;
                case 1:
                    lab_name.Text = "送货员名称";
                    break;
                case 2:
                    lab_name.Text = "操作员名称";
                    break;
            }
        }

        private void button_optNameQuery_Click(object sender, EventArgs e)
        {

            switch (flag)
            {
                case 0:
                    SetterWapper setterWapper = new SetterWapper();
                    if (String.IsNullOrEmpty(comboBox_operatorName.Text.Trim()))
                    {
                        dgv_staff.DataSource = setterWapper.setterSelect();
                        dgv_staff.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }
                    break;
                case 1:
                    DeliveryWapper deliveryWapper = new DeliveryWapper();
                    if(String.IsNullOrEmpty(comboBox_operatorName.Text.Trim()))
                    {
                        dgv_staff.DataSource = deliveryWapper.deliverySelect();
                        dgv_staff.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }
                    break;
                case 2:
                    OperaterWapper operaterWapper = new OperaterWapper();
                    if(String.IsNullOrEmpty(comboBox_operatorName.Text.Trim()))
                    {
                        dgv_staff.DataSource = operaterWapper.operaterSelect();
                        dgv_staff.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }
                    break;
            }
        }

        private void button_optpNameAdd_Click(object sender, EventArgs e)
        {
            if (button_optpNameAdd.Text == "增加")
            {
                button_optpNameAdd.Text = "保存";
                comboBox_operatorDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }
            else
            {
                if (button_optpNameAdd.Text == "保存")
                {
                    string name, date;
                    name = comboBox_operatorName.Text.Trim();
                    date = DateTime.Now.ToString("yyyy-MM-dd");
                    switch (flag)
                    {
                        case 0:
                            SetterWapper setterWapper = new SetterWapper();
                            if (!String.IsNullOrEmpty(name))
                            {
                                int resualt = setterWapper.setterInsert(name, date);
                                if (resualt > 0)
                                {
                                    MessageBox.Show("增加员工信息成功!");
                                    comboBox_operatorName.Text = "";
                                    comboBox_operatorDate.Text = "";
                                    button_optNameQuery.PerformClick();
                                }
                                else
                                {
                                    MessageBox.Show("增加信息失败,请检查");
                                }

                            }
                            else
                            {
                                MessageBox.Show("用户名不可为空");
                            }
                            break;
                        case 1:
                            DeliveryWapper deliveryWapper = new DeliveryWapper();
                            if (!String.IsNullOrEmpty(name))
                            {
                                int resualt = deliveryWapper.deliveryInsert(name, date);
                                if (resualt > 0)
                                {
                                    MessageBox.Show("增加员工信息成功!");
                                    comboBox_operatorName.Text = "";
                                    comboBox_operatorDate.Text = "";
                                    button_optNameQuery.PerformClick();
                                }
                                else
                                {
                                    MessageBox.Show("增加信息失败,请检查");
                                }

                            }
                            else
                            {
                                MessageBox.Show("用户名不可为空");
                            }
                            break;
                        case 2:
                            OperaterWapper operaterWapper = new OperaterWapper();
                            if (!String.IsNullOrEmpty(name))
                            {
                                int resualt = operaterWapper.operaterInsert(name, date);
                                if (resualt > 0)
                                {
                                    MessageBox.Show("增加员工信息成功!");
                                    comboBox_operatorName.Text = "";
                                    comboBox_operatorDate.Text = "";
                                    button_optNameQuery.PerformClick();
                                }
                                else
                                {
                                    MessageBox.Show("增加信息失败,请检查");
                                }

                            }
                            else
                            {
                                MessageBox.Show("用户名不可为空");
                            }
                            break;
                    }
                    comboBox_operatorName.Text = "";
                    comboBox_operatorDate.Text = "";
                    button_optpNameAdd.Text = "增加";
                }
            }
        }

        private void button_optNameDelete_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("确认要删除该员工的信息吗?",
                "删除信息", MessageBoxButtons.YesNo);
            if (dr == System.Windows.Forms.DialogResult.Yes)
            {
                string name = comboBox_operatorName.Text.Trim();
                if (!String.IsNullOrEmpty(name))
                {
                    comboBox_operatorName.Text = "";
                    comboBox_operatorDate.Text = "";
                    int resualt = 0;
                    switch (flag)
                    {
                        case 0:
                            SetterWapper sw = new SetterWapper();
                            resualt = sw.setterDelete(name);
                            
                            break;
                        case 1:
                            DeliveryWapper dw = new DeliveryWapper();
                            resualt = dw.deliveryDelete(name);
                            
                            break;
                        case 2:
                            OperaterWapper ow = new OperaterWapper();
                            resualt = ow.operaterDelete(name);
                            
                            break;
                    }
                    if (resualt > 0)
                    {
                        MessageBox.Show("删除成功,请检查");
                        switch(flag)
                        {
                            case 0:
                                SetterWapper sw = new SetterWapper();
                                dgv_staff.DataSource = sw.setterSelect();
                                break;
                            case 1:
                                DeliveryWapper dw = new DeliveryWapper();
                                dgv_staff.DataSource = dw.deliverySelect();
                                break;
                            case 2:
                                OperaterWapper ow = new OperaterWapper();
                                dgv_staff.DataSource = ow.operaterSelect();
                                break;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("请先选择或输入要删除的员工名称");
                }
            }
        }

        private void button_optNameDownload_Click(object sender, EventArgs e)
        {
            if (linkOK)
            {
                if (lab_name.Text == "安装员名称")
                {
                    if (linkSocket != null)
                    {
                        //
                        SetterWapper setterWrapper = new SetterWapper();
                        DataTable dt = setterWrapper.setterSelect();
                        string strTmp = "";
                        string strTable = "";
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            strTmp = dt.Rows[i][0].ToString();
                            strTable += strTmp + "\r\n";
                        }
                        string setterNameList = "strTable:" + strTable + "#strEnd";
                        try
                        {
                            byte[] sendbytes = System.Text.Encoding.
                                UTF8.GetBytes(setterNameList);
                            linkSocket.Send(sendbytes);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("下载出现问题:" + ex.Message);
                        }
                    }
                    else
                    {
                        MessageBox.Show("请选择手持机地址");
                    }
                }
                if (lab_name.Text == "送货员名称")
                {
                    if (linkSocket != null)
                    {

                        DeliveryWapper deliveryWrapper = new DeliveryWapper();
                        DataTable dt = deliveryWrapper.deliverySelect();
                        string strTmp = "";
                        string strTable = "";
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            strTmp = dt.Rows[i][0].ToString();
                            strTable += strTmp + "\r\n";
                        }
                        string deliveryNameList = "sdrTable:" + strTable + "#sdrEnd";
                        try
                        {
                            byte[] sendbytes = System.Text.Encoding.
                                UTF8.GetBytes(deliveryNameList);
                            linkSocket.Send(sendbytes);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("下载出现问题:" + ex.Message);
                        }
                    }
                    else
                    {
                        MessageBox.Show("请选择手持机地址");
                    }
                }
                if (lab_name.Text == "操作员名称")
                {
                    if (linkSocket != null)
                    {

                        OperaterWapper operaterWrapper = new OperaterWapper();
                        DataTable dt = operaterWrapper.operaterSelect();
                        string strTmp = "";
                        string strTable = "";
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            strTmp = dt.Rows[i][0].ToString();
                            strTable += strTmp + "\r\n";
                        }
                        string optNameList = "optTable:" + strTable + "#optEnd";
                        try
                        {
                            byte[] sendbytes = System.Text.Encoding.UTF8.GetBytes(optNameList);
                            linkSocket.Send(sendbytes);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("下载出现问题:" + ex.Message);
                        }
                    }
                    else
                    {
                        MessageBox.Show("请选择手持机地址");
                    }
                }
            }
            else
            {
                MessageBox.Show("请检查是否已启动服务器并选择了手持机地址");
            }
        }

        private void dgv_staff_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                comboBox_operatorName.Text = 
                    dgv_staff.Rows[e.RowIndex].Cells[0].Value.ToString();
                comboBox_operatorDate.Text =
                    dgv_staff.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
        }

        private void setSocketLinkValue(Socket s, bool link)
        {
            linkSocket = s;
            linkOK = link;
        }
    }
}
