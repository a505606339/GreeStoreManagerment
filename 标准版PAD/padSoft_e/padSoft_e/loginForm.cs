using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Data.SqlServerCe;
using System.Threading;

namespace padSoft_e
{
    public partial class loginForm : Form
    {
        public loginForm()
        {
            InitializeComponent();
            sysFunction.ShowWindow(sysFunction.iShowHideWindow(), 1);
            string strLoginName =sysFunction.readLastLoginName();
            this.loginName_textBox.Text = strLoginName;
            sysFunction.ShowWindow(sysFunction.iShowHideWindow(), 0);
            sysFunction.SipShowIM(0x01);
            this.loginPw_textBox.Focus();
        }
        private void loginEnter()
        {
            this.F1Login_button.Enabled = false;
            sysFunction.SipShowIM(0x00);
            string strLoginName = this.loginName_textBox.Text;
            string strPw = this.loginPw_textBox.Text.Trim();
            string strCodePw = strAsciiToHEx(strPw);
            //MessageBox.Show(strCodePw);
            string strSavePw = sysFunction.readPw();
            if (strSavePw == strCodePw)
            {
                sysFunction.saveLoginName(strLoginName);
                mainForm myMain = new mainForm();
                SingletonUser.CurrentUser.AccountName = strLoginName;
                SingletonUser.CurrentUser.LoginTime = DateTime.Now;
                myMain.ShowDialog();
            }
            else
            {
                sysFunction.SipShowIM(0x01);
                MessageBox.Show("√‹¬Î¥ÌŒÛ£¨«Î‘Ÿ¥Œ ‰»Î", "Œ¬‹∞Ã· æ");
            }
            this.F1Login_button.Enabled = true;
        }
        private void F1Login_button_Click(object sender, EventArgs e)
        {
            loginEnter();
        }
        private string strAsciiToHEx(string strAscii)
        {
            string strHex = "";
             byte[] strBytes = System.Text.UTF8Encoding.Default.GetBytes(strAscii);
            byte[] codeBytes = new byte[strBytes.Length];
            int key1 = 21;
            int key2 = 218;
            for (int i = 0; i < strBytes.Length; i++)
            {
                try
                {
                    byte code = strBytes[i];
                    code = (byte)(((code & 0x0f) << 4) + ((code & 0xf0) >> 4));
                    code = (byte)~code;
                    byte code2 = (byte)~(key1 ^ key2);
                    code = (byte)(code ^ code2);
                    code = (byte)(((code & 0x0f) << 4) + ((code & 0xf0) >> 4));
                    codeBytes[i] = code;
                }
                catch
                {
                }
            }
            if (codeBytes.Length >= 1)
                strHex = BitConverter.ToString(codeBytes).Replace("-", "");
            return strHex;
        }

        //key down     
        bool blCapital = false;
        bool blNum = false;
        bool blLow = false;
        private void loginForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
            {
                if (blCapital == true)
                {
                    blCapital = false;
                    blNum = true;
                    blLow = false;
                    this.textBox_input.Text = "1";
                }
                else if (blNum == true)
                {
                    blCapital = false;
                    blNum = false;
                    blLow = true;
                    this.textBox_input.Text = "a";
                }
            }
            if ((e.KeyCode == Keys.Capital) && (blNum == false))
            {
                blCapital = true;
                blNum = false;
                blLow = false;
                this.textBox_input.Text = "A";
            }
            if (e.KeyCode == Keys.F1)
                loginEnter();
            if (e.KeyCode == Keys.Escape)
                closeForm();
            if (e.KeyCode == Keys.Down)
            {
                if (this.loginName_textBox .Focused)
                {
                    this.loginPw_textBox .Focus();
                    e.Handled = true;
                    this.loginPw_textBox.SelectAll();
                }
                else if (this.loginPw_textBox.Focused)
                {
                    this.F1Login_button.Focus();
                    e.Handled = true;
                }
                else if (this.F1Login_button .Focused)
                {
                    this.redEsc_button .Focus();
                    e.Handled = true;
                }
            }
            if (e.KeyCode == Keys.Up)
            {
                if (this.redEsc_button.Focused)
                {
                    this.F1Login_button.Focus();
                    e.Handled = true;
                }
                else if (this.F1Login_button.Focused)
                {
                    this.loginPw_textBox.Focus();
                    e.Handled = true;
                    this.loginPw_textBox.SelectAll();
                }
                else if (this.loginPw_textBox.Focused)
                {
                    this.loginName_textBox.Focus();
                    e.Handled = true;
                    this.loginName_textBox.SelectAll();
                }
            }
        }
        private void closeForm()
        {
            sysFunction.SipShowIM(0x00);
            sysFunction.ShowWindow(sysFunction.iShowHideWindow(), 1);
            Application.Exit();
            this.Close();
        }
        private void redEsc_button_Click(object sender, EventArgs e)
        {
            closeForm();
            //scanFunction.ScanPowerOff();
            
        }
    }
}