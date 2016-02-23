using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net.Sockets;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UNmanagerSoft.DAL;
using UNmanagerSoft.Business_LL;

namespace UNmanagerSoft.View
{
    public partial class ClientNameForm : Form
    {
        private Socket linkSocket = null;
        private bool linkOK = false;
        public delegate void myDelegate(Socket socket,bool linkOK);
        public static myDelegate testEvent;
        ClientEntity clientEntity = null;
        
        public ClientNameForm()
        {
            InitializeComponent();
            testEvent = setSocketLinkValue;
            
        }
        private void button_ClientSelect_Click(object sender, EventArgs e)
        {
            ClientStorageWrapper clientDAO = new ClientStorageWrapper();
            if (String.IsNullOrEmpty(textBox_ClientManagerName.Text.Trim()) &&
                String.IsNullOrEmpty(textBox_ClientManAddreager.Text.Trim()) &&
                String.IsNullOrEmpty(textBox_ClientManagerPho.Text.Trim())
                )
            {
                
                dgv_Client.DataSource = clientDAO.clientSelect();
            }
            else
            {
                if (!String.IsNullOrEmpty(textBox_ClientManagerName.Text.Trim()))
                {
                    string text = textBox_ClientManagerName.Text.Trim();
                    dgv_Client.DataSource = clientDAO.clientSelect("客户姓名", text);
                }
                else if(!String.IsNullOrEmpty(textBox_ClientManAddreager.Text.Trim()))
                {
                    string text = textBox_ClientManAddreager.Text.Trim();
                    dgv_Client.DataSource = clientDAO.clientSelect("客户地址", text);
                }
                else if(!String.IsNullOrEmpty(textBox_ClientManagerPho.Text.Trim()))
                {
                    string text = textBox_ClientManagerPho.Text.Trim();
                    dgv_Client.DataSource = clientDAO.clientSelect("客户电话", text);
                }
            }
        }

        private void button_ClientUpdate_Click(object sender, EventArgs e)
        {
            if (clientEntity != null)
            {
                if (!String.IsNullOrEmpty(textBox_ClientManagerName.Text))
                {
                    
                    clientEntity.ClientName = textBox_ClientManagerName.Text.Trim();
                    clientEntity.ClientAddress = textBox_ClientManAddreager.Text.Trim();
                    clientEntity.ClientPhone = textBox_ClientManagerPho.Text.Trim();
                    ClientStorageWrapper clientDAO = new ClientStorageWrapper();
                    int flag = clientDAO.clientUpdate(clientEntity);
                    if (flag > 0)
                    {
                        MessageBox.Show("客户信息更新成功");
                        dgv_Client.DataSource = clientDAO.clientSelect();
                    }
                }
                else
                {
                    MessageBox.Show("客户名称不能为空,请检查");
                }
            }
            else
            {
                MessageBox.Show("请先选择要更改的客户信息");
            }
            
        }

        private void button_ClientInsert_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBox_ClientManagerName.Text.Trim()))
            {
                ClientStorageWrapper clientDAO = new ClientStorageWrapper();
                ClientEntity newClientEntity = new ClientEntity();
                DataTable dt = clientDAO.clientSelect("客户姓名",
                    textBox_ClientManagerName.Text.Trim());
                if (dt.Rows.Count == 0)
                {
                    newClientEntity.ClientName = textBox_ClientManagerName.Text.Trim();
                    newClientEntity.ClientAddress = textBox_ClientManAddreager.Text.Trim();
                    newClientEntity.ClientPhone = textBox_ClientManagerPho.Text.Trim();
                    newClientEntity.DateTime = DateTime.Now.ToString("yyyy-MM-dd");
                    int flag = clientDAO.clientInsert(newClientEntity);
                    if (flag > 0)
                    {
                        MessageBox.Show("客户信息增加成功!");
                        button_clear.PerformClick();
                        dgv_Client.DataSource = clientDAO.clientSelect();
                    }
                    else
                    {
                        MessageBox.Show("客户信息增加遇到问题,未能成功增加");
                    }
                }
                else
                {
                    MessageBox.Show("该客户名称已存在,请检查");
                }
                
            }
            else
            {

            }
        }

        private void button_ClientDelete_Click(object sender, EventArgs e)
        {
            if (clientEntity != null)
            {
                DialogResult dr = MessageBox.Show("确定要删除该条客户信息吗?",
                    "删除信息", MessageBoxButtons.OKCancel);
                if (dr == System.Windows.Forms.DialogResult.OK)
                {
                    ClientStorageWrapper clientDAO = new ClientStorageWrapper();
                    int flag = clientDAO.clientDelete(Convert.ToInt32(clientEntity.ID));
                    if (flag > 0)
                    {
                        MessageBox.Show("用户信息删除已成功");//
                        dgv_Client.DataSource = clientDAO.clientSelect();
                    }
                    else
                    {
                        MessageBox.Show("客户信息删除失败,请检查该信息是否还存在");
                        dgv_Client.DataSource = clientDAO.clientSelect();
                    }
                }
            }
            else
            {
                MessageBox.Show("请先选择要删除的客户信息");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox_ClientManAddreager.Text = "";
            textBox_ClientManagerName.Text = "";
            textBox_ClientManagerPho.Text = "";
        }

        private void dgv_Client_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                clientEntity = new ClientEntity();
                clientEntity.ClientName = dgv_Client.Rows[e.RowIndex].
                    Cells["name"].Value.ToString();
                clientEntity.ClientAddress = dgv_Client.Rows[e.RowIndex].
                    Cells["address"].Value.ToString();
                clientEntity.ClientPhone = dgv_Client.Rows[e.RowIndex].
                    Cells["phone"].Value.ToString();
                clientEntity.DateTime = dgv_Client.Rows[e.RowIndex].
                    Cells["date"].Value.ToString();
                clientEntity.ID = dgv_Client.Rows[e.RowIndex].
                    Cells["ID"].Value.ToString();
                
                textBox_ClientManagerName.Text = clientEntity.ClientName;
                textBox_ClientManAddreager.Text = clientEntity.ClientAddress;
                textBox_ClientManagerPho.Text = clientEntity.ClientPhone;
            }
        }

        private void button_DownClient_Click(object sender, EventArgs e)
        {
            if (linkOK)
            {
                if (linkSocket != null)
                {
                    ClientStorageWrapper clientWrapper = new ClientStorageWrapper();
                    DataTable dt = clientWrapper.clientSelect();
                    string strTmp = "";
                    string strTable = "";
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        strTmp = dt.Rows[i][1].ToString();
                        strTable += strTmp + "\r\n";
                    }
                    string optNameList = "clientName:" + strTable + "#endClient";
                    try
                    {
                        byte[] sendbytes = System.Text.Encoding.UTF8.GetBytes(optNameList);
                        linkSocket.Send(sendbytes);
                    }
                    catch(Exception ex)
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

        private void setSocketLinkValue(Socket s,bool link)
        {
            linkSocket = s;
            linkOK = link;
        }

        private void ClientNameForm_Load(object sender, EventArgs e)
        {
            //a = (MainForm)this.Owner;
        }
    }
}
