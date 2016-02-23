using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;

namespace UNmanagerSoft.View
{
    public partial class LoginForm : Form
    {
        systemFunction.systemFunction s = new systemFunction.systemFunction();
        public LoginForm()
        {
            InitializeComponent();
        }

        //把窗体的关闭按钮禁用掉
        private const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams mycp = base.CreateParams;
                mycp.ClassStyle = mycp.ClassStyle | CP_NOCLOSE_BUTTON;
                return mycp;
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            using (StreamReader sr = new StreamReader(s.exePath() + @"\config\loginName.ini"))
            {
                textBoxName.Text = sr.ReadLine();
            }
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxName.Text.Trim()))
            {
                MessageBox.Show("用户名不可为空");
            }
            else if (String.IsNullOrEmpty(textBoxPassword.Text))
            {
                MessageBox.Show("密码不可为空");
            }
            else
            {
                if (verify(textBoxName.Text.Trim(), sha1Cryptography(textBoxPassword.Text)))
                {
                    this.Close();
                }
                else
                {
                    MessageBox.Show("用户名或密码不正确 ");
                }
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private string sha1Cryptography(string text)
        {
            byte[] computeBytes = Encoding.Default.GetBytes(text);
            byte[] hashBytes = SHA1.Create().ComputeHash(computeBytes);
            Console.WriteLine(BitConverter.ToString(hashBytes).Replace("-", ""));
            return BitConverter.ToString(hashBytes).Replace("-", "");
        }

        private bool verify(string name, string pw)
        {
            using (StreamReader nameSR = new StreamReader(s.exePath() + @"\config\loginName.ini"))
            {
                using (StreamReader pwSR = new StreamReader(s.exePath() + @"\config\loginPw.ini"))
                {
                    if (name == nameSR.ReadLine() && pw == pwSR.ReadLine())
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

        private void LoginForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonLogin.PerformClick();
            }
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        
    }
}
