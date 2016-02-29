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
        /// 写到错误日志
        /// </summary>
        /// <param name="ex">exception</param>
        /// <param name="backStr">错误标题</param>
        static void WriteErrLog(string errTitle, Exception ex)
        {
            string path = sysFunction.exePath() + "\\errlog.txt";

            if (!File.Exists(path))
            {
                File.Create(path).Close();
            }

            StringBuilder strBuilderErrorMessage = new StringBuilder();

            strBuilderErrorMessage.Append("________________________________________________________________________________________________________________\r\n");
            strBuilderErrorMessage.Append("日期:" + System.DateTime.Now.ToString() + "\r\n");
            strBuilderErrorMessage.Append("行号:" + ex.StackTrace);
            strBuilderErrorMessage.Append("错误标题:" + errTitle + "\r\n");
            strBuilderErrorMessage.Append("错误信息:" + ex.Message + "\r\n");
            strBuilderErrorMessage.Append("错误内容:" + ex.StackTrace + "\r\n");
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