using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Data.SqlServerCe;
using System.IO;

namespace padSoft_e
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
            initScanModule();
        }
        private bool initScanModule()
        {
            if (scanFunction.initScan())
                return true;
            else
            {
                scanFunction.twoBeeper();
                return false;
            }
        }
        private void inputManage()
        {
            bool openflag = true;
            if (openflag)
            {
                this.KeyPreview = false;
                this.inputMana_button.Enabled = false;
                inputForm myInput = new inputForm();
                myInput.ShowDialog();
                this.inputMana_button.Enabled = true;
                this.KeyPreview = true;
            }
        }
        private void inputMana_button_Click(object sender, EventArgs e)
        {
            inputManage();
        }
        private void outManage()
        {
            bool openflag = true;
            if (openflag)
            {
                this.KeyPreview = false;
                this.outMana_button.Enabled = false;
                outputForm myOutput = new outputForm();
                myOutput.ShowDialog();
                myOutput.Dispose();
                this.outMana_button.Enabled = true;
                openflag = false;
                this.KeyPreview = true;
            }
        }
        private void outMana_button_Click(object sender, EventArgs e)
        {
            outManage();
        }
        private void uploadData()
        {
            bool openflag = true;
            if (openflag)
            {
                this.KeyPreview = false;
                this.upload_button.Enabled = false;
                uploadForm myUpload = new uploadForm();
                try
                {
                    myUpload.ShowDialog();
                    myUpload.Dispose();
                }
                catch
                {
                    myUpload = null;
                }
                this.upload_button.Enabled = true;
                this.KeyPreview = true;
            }
        }
        private void upload_button_Click(object sender, EventArgs e)
        {
            uploadData();
        }

        private void mainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.NumPad1)
                inputManage();
            else if (e.KeyCode == Keys.NumPad2)
                outManage();
            else if (e.KeyCode == Keys.NumPad3)
                uploadData();
            else if (e.KeyCode == Keys.Escape)
                closeForm();
            else if (e.KeyCode == Keys.NumPad4)
                Returned();
            else if (e.KeyCode == Keys.NumPad5)
                pairedClick();
            else if (e.KeyCode == Keys.NumPad6)
                btn_pair_Click(null,null);
            if (e.KeyCode == Keys.Down)
            {
                if (this.picboxInput.Focused)
                {
                    this.picboxInput.Focus();
                    e.Handled = true;
                }
                else if (this.picboxInput.Focused)
                {
                    this.picboxOutput.Focus();
                    e.Handled = true;
                }
                else if (this.picboxOutput.Focused)
                {
                    this.picboxReturned.Focus();
                    e.Handled = true;
                }
                else if (this.picboxReturned.Focused)
                {
                    this.picboxPaired.Focus();
                    e.Handled = true;
                }
                else if (picboxPaired.Focused)
                {
                    this.picboxPairManage.Focus();
                    e.Handled = true;
                }
                else if (this.picboxPairManage.Focused)
                {
                    this.picboxUpload.Focus();
                    e.Handled = true;
                }

                else if (this.picboxUpload.Focused)
                {
                    this.picboxClose.Focus();
                    e.Handled = true;
                }
            }
            if (e.KeyCode == Keys.Up)
            {
                if (this.picboxClose.Focused)
                {
                    this.picboxUpload.Focus();
                    e.Handled = true;
                }
                else if (picboxUpload.Focused)
                {
                    this.picboxPairManage.Focus();
                    e.Handled = true;
                }
                else if (picboxPairManage.Focused)
                {
                    this.picboxPaired.Focus();
                    e.Handled = true;
                }
                else if (this.picboxPaired.Focused)
                {
                    this.picboxReturned.Focus();
                    e.Handled = true;
                }
                else if (this.picboxReturned.Focused)
                {
                    this.picboxOutput.Focus();
                    e.Handled = true;
                }
                else if (this.picboxOutput.Focused)
                {
                    this.picboxInput.Focus();
                    e.Handled = true;
                }
            }
        }
        private void closeForm()
        {
            this.redEsc_button.Enabled = false;
            this.Close();
        }
        private void redEsc_button_Click(object sender, EventArgs e)
        {
            closeForm();
        }

        private void returnedbutton_Click(object sender, EventArgs e)
        {
            Returned();
        }

        private void Returned()
        {
            bool openflag = true;
            if (openflag)
            {
                this.KeyPreview = false;
                returned_button.Enabled = false;
                returnedForm rtForm = new returnedForm();
                rtForm.ShowDialog();
                returned_button.Enabled = true;
                this.KeyPreview = true;
            }
        }

        private void button_Paired_Click(object sender, EventArgs e)
        {
            pairedClick();
        }
        private void pairedClick()
        {
            bool openflag = true;
            if (openflag)
            {
                this.KeyPreview = false;
                button_Paired.Enabled = false;
                pairedForm pform = new pairedForm();
                pform.ShowDialog();
                button_Paired.Enabled = true;
                this.KeyPreview = true;
            }
        }

        //private void xmlCreate()
        //{
        //    if (!File.Exists(sysFunction.exePath() + "\\config\\barcode.xml"))
        //    {
        //        XmlDocument xmlDocument;
        //        XmlElement xmlElement;

        //        xmlDocument = new XmlDocument();
        //        XmlDeclaration xmldec;
        //        xmldec = xmlDocument
        //            .CreateXmlDeclaration("1.0", "utf-8", null);
        //        xmlDocument.AppendChild(xmldec);
        //        xmlElement = xmlDocument.CreateElement("Barcode", "Barcode", "");
        //        xmlDocument.AppendChild(xmlElement);
        //        xmlDocument.Save(sysFunction.exePath() + "\\config\\barcode.xml");
        //    }
        //}

        private void btn_pair_Click(object sender, EventArgs e)
        {
            btn_pair.Enabled = false;
            PairForm pairf = new PairForm();
            pairf.ShowDialog();
            btn_pair.Enabled = true;
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            string dbPath = sysFunction.exePath() + @"\数据\database.sdf";
            SqlCeConnection connection = new SqlCeConnection();
            if (!File.Exists(dbPath))
            {
                if (!createData())
                {
                    MessageBox.Show("建立数据库失败,请联系管理员.");
                }
            }
            else
            {
                string strConn = "Data Source =" + dbPath;
                SqlCeConnection sqlConnet = new SqlCeConnection(strConn);
                sqlConnet.Open();
                sqlConnet.Close();
            }
        }

        private bool createData()
        {
            string dbPath = sysFunction.exePath() + @"\数据\database.sdf";
            string strConn = "Data Source =" + dbPath;

            SqlCeEngine sqlEngine = new SqlCeEngine(strConn);
            sqlEngine.CreateDatabase();
            SqlCeConnection sqlConnet = new SqlCeConnection(strConn);
            sqlConnet.Open();
            SqlCeTransaction transaction = sqlConnet.BeginTransaction();
            SqlCeCommand sqlCommand = sqlConnet.CreateCommand();
            sqlCommand.Transaction = transaction;
            bool creationSuccessful = false;
            try
            {
                sqlCommand.CommandText = "CREATE TABLE InTable(id int identity(1,1) primary key" +
                    ",inBarcode nvarchar(30)," +
                    "outBarcode nvarchar(30),inType nvarchar(200),inOrderNumber nvarchar(30)," +
                    "inOrderName nvarchar(30),inDate nvarchar(30),inQuantity nvarchar(6)," +
                    "inMoney nvarchar(15),inOperater nvarchar(10),inRemark nvarchar(300),inStockName nvarchar(30))";
                sqlCommand.ExecuteNonQuery();

                sqlCommand.CommandText = "CREATE TABLE OutTable(id int identity(1,1) primary key," +
                    "inBarcode nvarchar(30)," +
                    "outBarcode nvarchar(30),outType nvarchar(200),outOrderNumber nvarchar(30),outClientName nvarchar(10)," +
                    "outDate nvarchar(30),outQuantity nvarchar(6),outMoney nvarchar(10)," +
                    "outOperater nvarchar(10),outDeliver nvarchar(10)," +
                    "outSetter nvarchar(10),outRemark nvarchar(300),outStockName nvarchar(30))";
                sqlCommand.ExecuteNonQuery();

                sqlCommand.CommandText = "CREATE TABLE ReturnedTable(id int identity(1,1) primary key," +
                    "inBarcode nvarchar(30)," +
                    "outBarcode nvarchar(30),reType nvarchar(200),reRemark nvarchar(300),reClientName nvarchar(10)," +
                    "reOperater nvarchar(10),reReturnedDate nvarchar(30))";
                sqlCommand.ExecuteNonQuery();

                sqlCommand.CommandText = "CREATE TABLE PairedTable(id int identity(1,1) primary key," +
                    "inBarcode nvarchar(30)," +
                    "outBarcode nvarchar(30),pairType nvarchar(200))";
                sqlCommand.ExecuteNonQuery();

                sqlCommand.CommandText = "CREATE TABLE NewPairedTable(id int identity(1,1) primary key," +
                    "inBarcode nvarchar(30),outBarcode nvarchar(30),type nvarchar(200))";
                sqlCommand.ExecuteNonQuery();

                sqlCommand.CommandText = "CREATE TABLE InTempTable(id int identity(1,1) primary key," +
                    "inBarcode nvarchar(30),outBarcode nvarchar(30),outType nvarchar(200),outOrderNumber "+
                    "nvarchar(30),outClientName nvarchar(10)," +
                    "outDate nvarchar(30),outQuantity nvarchar(6),outMoney nvarchar(10)," +
                    "outOperater nvarchar(10),outDeliver nvarchar(10)," +
                    "outSetter nvarchar(10),outRemark nvarchar(300))";
                sqlCommand.ExecuteNonQuery();

                sqlCommand.CommandText = "CREATE TABLE OutTempTable(id int identity(1,1) primary key," +
                    "inBarcode nvarchar(30),outBarcode nvarchar(30),outType nvarchar(200))";
                sqlCommand.ExecuteNonQuery();
                transaction.Commit();
                creationSuccessful = true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                creationSuccessful = false;
                throw ex;
            }
            finally
            {
                sqlConnet.Close();
            }
            return creationSuccessful;
        }

        #region 单击替换图片

        public struct imagebutton
        {
            public PictureBox currentyButton;
            public PictureBox beforeButton;
        }
        imagebutton imgbtn = new imagebutton();
        private void picboxInput_Click(object sender, EventArgs e)
        {
            imgbtn.currentyButton = this.picboxInput;
            replaceImage(imgbtn);
            picboxInput.Image = Properties.Resources.ruku2;
            imgbtn.beforeButton = picboxInput;
        }

        private void picboxOutput_Click(object sender, EventArgs e)
        {
            imgbtn.currentyButton = this.picboxOutput;
            replaceImage(imgbtn);
            picboxOutput.Image = Properties.Resources.chuku2;
            imgbtn.beforeButton = picboxOutput;
        }

        private void picboxReturned_Click(object sender, EventArgs e)
        {
            imgbtn.currentyButton = this.picboxReturned;
            replaceImage(imgbtn);
            picboxReturned.Image = Properties.Resources.tuihuo2;
            imgbtn.beforeButton = picboxReturned;
        }

        private void picboxPaired_Click(object sender, EventArgs e)
        {
            imgbtn.currentyButton = this.picboxPaired;
            replaceImage(imgbtn);
            picboxPaired.Image = Properties.Resources.piliang2;
            imgbtn.beforeButton = picboxPaired;
        }

        private void picboxPairManage_Click(object sender, EventArgs e)
        {
            imgbtn.currentyButton = this.picboxPairManage;
            replaceImage(imgbtn);
            picboxPairManage.Image = Properties.Resources.peizhibiao2;
            imgbtn.beforeButton = picboxPairManage;
        }

        private void picboxUpload_Click(object sender, EventArgs e)
        {
            imgbtn.currentyButton = this.picboxUpload;
            replaceImage(imgbtn);
            picboxUpload.Image = Properties.Resources.shangchuan2;
            imgbtn.beforeButton = picboxUpload;
        }

        private void picboxClose_Click(object sender, EventArgs e)
        {
            imgbtn.currentyButton = this.picboxClose;
            replaceImage(imgbtn);
            picboxClose.Image = Properties.Resources.tuichu2;
            imgbtn.beforeButton = picboxClose;
        }

        private void replaceImage(imagebutton btn)
        {
            if (btn.currentyButton != null && btn.beforeButton != null)
            {
                switch (btn.beforeButton.Name)
                {
                    case "picboxInput":
                        if (imgbtn.currentyButton.Name != imgbtn.beforeButton.Name)
                        {
                            imgbtn.beforeButton.Image = Properties.Resources.rukuguanli;
                        }
                        break;
                    case "picboxOutput":
                        if (imgbtn.currentyButton.Name != imgbtn.beforeButton.Name)
                        {
                            imgbtn.beforeButton.Image = Properties.Resources.chukuguanli;
                        }
                        break;
                    case "picboxReturned":
                        if (imgbtn.currentyButton.Name != imgbtn.beforeButton.Name)
                        {
                            imgbtn.beforeButton.Image = Properties.Resources.tuihuoguanli;
                        }
                        break;
                    case "picboxPaired":
                        if (imgbtn.currentyButton.Name != imgbtn.beforeButton.Name)
                        {
                            imgbtn.beforeButton.Image = Properties.Resources.piliangjiancha;
                        }
                        break;
                    case "picboxPairManage":
                        if (imgbtn.currentyButton.Name != imgbtn.beforeButton.Name)
                        {
                            imgbtn.beforeButton.Image = Properties.Resources.peizhibiao;
                        }
                        break;
                    case "picboxUpload":
                        if (imgbtn.currentyButton.Name != imgbtn.beforeButton.Name)
                        {
                            imgbtn.beforeButton.Image = Properties.Resources.shangchuanshuju;
                        }
                        break;
                    case "picboxClose":
                        if (imgbtn.currentyButton.Name != imgbtn.beforeButton.Name)
                        {
                            imgbtn.beforeButton.Image = Properties.Resources.tuichuchengxu;
                        }
                        break;
                }
            }
        }
        #endregion

        
    }
}