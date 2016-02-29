using System;
using System.Windows.Forms;
using UNmanagerSoft.Business_LL;
using UNmanagerSoft.DAL;

namespace UNmanagerSoft.View
{
    public partial class StockUpdateForm : Form
    {
        StorageEntity storage ;
        public delegate void updateEventHandler(int rows);
        public event updateEventHandler row;
        public StockUpdateForm()
        {
            InitializeComponent();
        }

        private void StockUpdateForm_Load(object sender, EventArgs e)
        {
            if (storage != null)
            {
                //初始化数据
                textBoxType.Text = storage.Type;
                textBoxPrice.Text = storage.InMoney;
                textBoxReceiptsNumber.Text = storage.ReceiptsNumber;
                textBoxReceiptsName.Text = storage.ReceiptsName;
                try
                {
                    dateTimePickerInDateTime.Value = Convert.ToDateTime(storage.InDateTime);
                }
                catch
                {
                    dateTimePickerInDateTime.Value = Convert.
                        ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                }
                textBoxNumber.Text = storage.Number;
                textBoxOpt.Text = storage.InOpter;
                textBoxStockName.Text = storage.StockName;
                textBoxRemark.Text = storage.InRemark;
                //鼠标移动到控件上时显示原先的数据
                toolTip1.SetToolTip(label1, storage.Type);
                toolTip1.SetToolTip(label4, storage.InMoney);
                toolTip1.SetToolTip(label5, storage.ReceiptsNumber);
                toolTip1.SetToolTip(label6, storage.ReceiptsName);
                toolTip1.SetToolTip(label8, storage.InDateTime);
                toolTip1.SetToolTip(label3, storage.Number);
                toolTip1.SetToolTip(label7, storage.InOpter);
                toolTip1.SetToolTip(label9, storage.StockName);
                toolTip1.SetToolTip(label10, storage.InRemark);
            }
            else
            {
                MessageBox.Show("未获取到要修改的数据 请尝试重新点击修改");
                this.Close();
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            StorageEntity saveEntity = new StorageEntity();
            StorageWrapper storageWrapper = new StorageWrapper();
            saveEntity.UID = storage.UID;
            saveEntity.Type = textBoxType.Text;
            saveEntity.StockName = textBoxStockName.Text;
            saveEntity.ReceiptsNumber = textBoxReceiptsNumber.Text;
            saveEntity.ReceiptsName = textBoxReceiptsName.Text;
            saveEntity.Number = textBoxNumber.Text;
            saveEntity.InRemark = textBoxRemark.Text;
            saveEntity.InOpter = textBoxOpt.Text;
            saveEntity.InMoney = textBoxPrice.Text;
            saveEntity.InDateTime = dateTimePickerInDateTime.Value.ToString();
            int influenceRow = storageWrapper.
                updateStockByID(saveEntity,storage.UID,storage.StockName);
            if (row != null)
            {
                row(influenceRow);
            }
            this.Close();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public StorageEntity Storage
        {
            get { return storage; }
            set { storage = value; }
        }
    }
}
