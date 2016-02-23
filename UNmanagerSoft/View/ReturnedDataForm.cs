using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UNmanagerSoft.View
{
    public partial class ReturnedDataForm : Form
    {
        /// <summary>
        /// 判断是查询还是修改
        /// 查询传入为0
        /// 修改传入为1
        /// </summary>
        private int _flag;
        public int flag
        {
            set { _flag = value; }
        }

        public ReturnedDataForm()
        {
            InitializeComponent();
        }

        private void ReturnedDataForm_Load(object sender, EventArgs e)
        {
            ReturnedSelectForm rsForm = new ReturnedSelectForm();
            rsForm.datasouse += new ReturnDataSouce(rsForm_datasouse);
            rsForm.ShowDialog();
        }

        void rsForm_datasouse(DataTable dt)
        {
            dataGridView_returnOrder.DataSource = dt;
        }

        private void btn_returnSave_Click(object sender, EventArgs e)
        {

        }

        private void btn_returnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}
