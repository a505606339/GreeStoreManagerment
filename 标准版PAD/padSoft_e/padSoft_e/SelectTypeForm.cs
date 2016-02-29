using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace padSoft_e
{
    public partial class SelectTypeForm : Form
    {
        private List<string> _comboxlist = new List<string>();
        private string _barcode = "";
        private string _sing = "";
        public delegate void typeSetdelegate(string str,string barcode,string sing);
        public event typeSetdelegate typeSetEvent;


        public void clearComboxList()
        {
            _comboxlist.Clear();
        }
        public string comboxlist
        {
            set
            {
                _comboxlist.Add(value);
            }
        }
        public string sing
        {
            get { return _sing; }
            set { _sing = value; }
        }
        public string barcode
        {
            get { return _barcode; }
            set
            {
                _barcode = value;
            }
        }

        public SelectTypeForm()
        {
            InitializeComponent();
            combox_airTypeList.Items.Add("");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (combox_airTypeList.SelectedIndex > -1)
            {
                typeSetEvent(combox_airTypeList.Text, _barcode, _sing);
                this.Close();
            }
            else
            {
                MessageBox.Show("请选择型号");
            }
        }

        private void SelectTypeForm_Load(object sender, EventArgs e)
        {
            if (_comboxlist.Count > 0)
            {
                combox_airTypeList.DataSource = _comboxlist;
            }
            if (!String.IsNullOrEmpty(_barcode))
            {
                textBox1.Text = _barcode;
            }
        }

        private void SelectTypeForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4)
            {
                button1_Click(null, null);
            }
        }
    }
}