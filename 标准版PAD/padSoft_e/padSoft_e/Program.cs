using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Text;

namespace padSoft_e
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [MTAThread]
        static void Main()
        {
            try
            {
                Application.Run(new loginForm());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                WriteErrLog(ex.ToString(),ex);
            }
        }

        /// <summary>
        /// д��������־
        /// </summary>
        /// <param name="ex">exception</param>
        /// <param name="backStr">�������</param>
        static void WriteErrLog(string errTitle, Exception ex)
        {
            string path = sysFunction.exePath() + "\\errlog.txt";

            if (!File.Exists(path))
            {
                File.Create(path).Close();
            }

            StringBuilder strBuilderErrorMessage = new StringBuilder();

            strBuilderErrorMessage.Append("________________________________________________________________________________________________________________\r\n");
            strBuilderErrorMessage.Append("����:" + System.DateTime.Now.ToString() + "\r\n");
            strBuilderErrorMessage.Append("�к�:" + ex.StackTrace);
            strBuilderErrorMessage.Append("�������:" + errTitle + "\r\n");
            strBuilderErrorMessage.Append("������Ϣ:" + ex.Message + "\r\n");
            strBuilderErrorMessage.Append("��������:" + ex.StackTrace + "\r\n");
            strBuilderErrorMessage.Append("________________________________________________________________________________________________________________\r\n");
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.Write(strBuilderErrorMessage);
                sw.Flush();
                sw.Close();
            }
        }
    }
}