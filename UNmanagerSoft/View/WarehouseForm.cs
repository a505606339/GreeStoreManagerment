using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UNmanagerSoft.DAL;
using UNmanagerSoft.Business_LL;

namespace UNmanagerSoft.View
{
    public partial class WarehouseForm : Form
    {
        private int allRecordCount = 0;
        private int allPage = 0;
        public WarehouseForm()
        {
            InitializeComponent();
        }
        private void WarehouseForm_Load(object sender, EventArgs e)
        {
            StorageWrapper storageWrapper = new StorageWrapper();
            allRecordCount = storageWrapper.getDateAllCount();
            winFormPager1.PageIndex = 1;
            winFormPager1.RecordCount = allRecordCount;
            allPage = allRecordCount / 20;
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
            if (allPage != 0)
            {
                StorageWrapper storageWrapper = new StorageWrapper();
                DataTable dt = storageWrapper.BindDataWithPage(winFormPager1.PageIndex);
                dgv_inStorage.DataSource = dt;
            }
            else
            {
                winFormPager1.PageIndex--;
                MessageBox.Show("当前已是最后一页");
            }
        }

        private void 修改数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgv_inStorage.SelectedCells.Count > 0)
            {
                StorageEntity storage = fillStorageEntityBySelectRow();
                StockUpdateForm stockDataList = new StockUpdateForm();
                stockDataList.row += new StockUpdateForm.updateEventHandler(updateEvent);
                stockDataList.Storage = storage;
                stockDataList.ShowDialog();
            }
            else
            {
                MessageBox.Show("请先选择要修改的数据行");
            }
            
        }

        private void 删除数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgv_inStorage.SelectedCells.Count > 0)
            {
                DialogResult dr = MessageBox.Show("确定要删除该条数据吗?","请注意",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button2);
                if (dr == System.Windows.Forms.DialogResult.Yes)
                {
                    StorageEntity storage = fillStorageEntityBySelectRow();
                    StorageWrapper storageWrapper = new StorageWrapper();
                    int influenceRow = storageWrapper.deleteStorageByID(storage);
                    if (influenceRow > 0)
                    {
                        MessageBox.Show("删除了" + influenceRow.ToString() + "条数据");
                        string selecttext = "select * from 库存表";
                        dgv_inStorage.DataSource = storageWrapper.selectDBCommand(selecttext);
                    }
                    else
                    {
                        MessageBox.Show("未更新任何数据,请检查该数据情况");
                    }
                }
            }
            else
            {
                MessageBox.Show("请先选择要修改的数据行");
            }
            
        }

        //获取要操作的库存数据
        private StorageEntity fillStorageEntityBySelectRow()
        {
            StorageEntity storage = new StorageEntity();
            int rowIndex = dgv_inStorage.SelectedCells[0].RowIndex;
            storage.UID = dgv_inStorage.Rows[rowIndex].Cells[0].Value.ToString();
            storage.Type = dgv_inStorage.Rows[rowIndex].Cells[1].Value.ToString();
            storage.Number = dgv_inStorage.Rows[rowIndex].Cells[2].Value.ToString();
            storage.InMoney = dgv_inStorage.Rows[rowIndex].Cells[3].Value.ToString();
            storage.ReceiptsNumber = dgv_inStorage.Rows[rowIndex].Cells[4].Value.ToString();
            storage.ReceiptsName = dgv_inStorage.Rows[rowIndex].Cells[5].Value.ToString();
            storage.InOpter = dgv_inStorage.Rows[rowIndex].Cells[6].Value.ToString();
            storage.InDateTime = dgv_inStorage.Rows[rowIndex].Cells[7].Value.ToString();
            storage.InRemark = dgv_inStorage.Rows[rowIndex].Cells[8].Value.ToString();
            storage.StockName = dgv_inStorage.Rows[rowIndex].Cells[9].Value.ToString();

            return storage;
        }

        //事件传递的方法,根据返回值判断更新的状态
        private void updateEvent(int influenceRow)
        {
            if (influenceRow > 0)
            {
                StorageWrapper storageWrapper = new StorageWrapper();
                MessageBox.Show("更新了" + influenceRow.ToString() + "条数据");
                string selecttext = "select * from 库存表";
                dgv_inStorage.DataSource = storageWrapper.selectDBCommand(selecttext);
            }
            else
            {
                MessageBox.Show("未更新任何数据,请检查该数据情况");
            }
        }
    }
}
