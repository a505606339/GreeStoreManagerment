using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;

namespace UNmanagerSoft.Utility
{
    class ExcelUtiltity
    {
        public void CreateExcel(string txtFile, string saveFile, string flag)
        {
            string fileName = txtFile.Substring(0, txtFile.Length - 3) + "xls";
            StreamReader sr = new StreamReader(txtFile, System.Text.Encoding.GetEncoding("utf-8"));
            HSSFWorkbook workbook = new HSSFWorkbook();
            ISheet sheet = workbook.CreateSheet("sheet1");
            //标题
            IRow row = sheet.CreateRow(0);//添加一行
            if (flag == "1")
            {
                row.CreateCell(0).SetCellValue("内机条码");
                row.CreateCell(1).SetCellValue("外机条码"); ;
                row.CreateCell(2).SetCellValue("空调型号");
                row.CreateCell(3).SetCellValue("单据单号");
                row.CreateCell(4).SetCellValue("单据名称");
                row.CreateCell(5).SetCellValue("入库时间");
                row.CreateCell(6).SetCellValue("数量");
                row.CreateCell(7).SetCellValue("金额");
                row.CreateCell(8).SetCellValue("操作员");
                row.CreateCell(9).SetCellValue("备注");
            }
            else if (flag == "2")
            {
                row.CreateCell(0).SetCellValue("内机条码");
                row.CreateCell(1).SetCellValue("外机条码");
                row.CreateCell(2).SetCellValue("空调型号");
                row.CreateCell(3).SetCellValue("出库单号");
                row.CreateCell(4).SetCellValue("客户名称");
                row.CreateCell(5).SetCellValue("出库时间");
                row.CreateCell(6).SetCellValue("数量");
                row.CreateCell(7).SetCellValue("金额");
                row.CreateCell(8).SetCellValue("操作员");
                row.CreateCell(9).SetCellValue("送货员");
                row.CreateCell(10).SetCellValue("安装员");
                row.CreateCell(11).SetCellValue("备注");
            }
            else
            {
                row.CreateCell(0).SetCellValue("内机条码");
                row.CreateCell(1).SetCellValue("外机条码");
                row.CreateCell(2).SetCellValue("空调型号");
                row.CreateCell(3).SetCellValue("退货备注");
                row.CreateCell(4).SetCellValue("客户名称");
                row.CreateCell(5).SetCellValue("操作员");
                row.CreateCell(6).SetCellValue("退货时间");
            }
            //数据
            int count = 1;
            string[] datalist;
            string readLine = "";
            while (sr.Peek() > -1)
            {
                readLine = sr.ReadLine();
                if (readLine.Length > 13)
                {
                    datalist = Regex.Split(readLine, "\t", RegexOptions.IgnoreCase);
                    row = sheet.CreateRow(count);
                    for (int j = 0; j < datalist.Length; j++)
                    {
                        ICell cell = row.CreateCell(j);
                        cell.SetCellValue(datalist[j]);
                    }
                    count++;
                }
            }
            sr.Dispose();
            sr.Close();
            //保存为excel
            MemoryStream ms = new MemoryStream();
            workbook.Write(ms);
            using (FileStream fs = new FileStream(saveFile, 
                FileMode.Create, FileAccess.Write))
            {
                byte[] b = ms.ToArray();
                fs.Write(b, 0, b.Length);
                fs.Flush();
                fs.Dispose();
                fs.Close();
            }
            ms.Dispose();
            ms.Close();
            GC.Collect();
        }
    }
}
