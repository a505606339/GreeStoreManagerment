using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UNmanagerSoft.DAL;

namespace UNmanagerSoft.View
{
    public partial class WarehouseForm : Form
    {
        private int allpage = 0;
        public WarehouseForm()
        {
            InitializeComponent();
        }
        private void WarehouseForm_Load(object sender, EventArgs e)
        {
            StorageWrapper storageWrapper = new StorageWrapper();
            allpage = storageWrapper.getDateAllCount();
            winFormPager1.PageIndex = 1;
            winFormPager1.RecordCount = allpage;
            StorageSelectForm ssf = new StorageSelectForm();
            ssf.datasouce += new ReturnDataSouce(ssf_datasouce);
            ssf.ShowDialog();
        }
        //
        private void ssf_datasouce(DataTable dt)
        {
            dgv_inStorage.DataSource = dt;
        }

        private void winFormPager1_PageIndexChanged(object sender, EventArgs e)
        {
            StorageWrapper storageWrapper = new StorageWrapper();
            DataTable dt = storageWrapper.BindDataWithPage(winFormPager1.PageIndex);
            dgv_inStorage.DataSource = dt;
        }

        
    }
}
