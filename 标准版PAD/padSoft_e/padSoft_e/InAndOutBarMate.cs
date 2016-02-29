using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace padSoft_e
{
    class InAndOutBarMate
    {
        public List<string> inBarList = new List<string>();//内机对应列表
        public List<string> outBarList = new List<string>();//外机对应列表
        public List<string> typeList = new List<string>();//类型对应列表

        public List<string> scanInBarList = new List<string>();//扫描的内机数据列表
        public List<string> scanOutBarList = new List<string>();//扫描的外机数据列表
        //public List<string> pairBar = new List<string>();//匹配的条码对应所有数据

        public void scanInBarListSet(string item)
        {
            scanInBarList.Add(item);
        }

        public void scanOutBarListSet(string item)
        {
            scanOutBarList.Add(item);
        }

        //public List<string> pairInOutBar()
        //{
        //    foreach (string inData in scanInBarList)
        //    {
        //        string[] inlist = inData.Split('\t');
        //        foreach (string outData in scanOutBarList)
        //        {
        //            string[] outlist = outData.Split('\t');
        //            if (inlist[2] == outlist[2])
        //            {
        //                inlist[1] = outlist[1];
        //                pairBar.Add(inlist[0] + "\t" + inlist[1] + "\t" + inlist[2] + "\t"
        //                    + inlist[3] + "\t" + inlist[4] + "\t" + inlist[5] + "\t" +
        //                    inlist[6] + "\t" + inlist[7] + "\t" + inlist[8] + "\t" + inlist[9] + "\t" +
        //                    inlist[10] + "\t" + inlist[11] + "\t");
        //                break;
        //            }
        //        }
        //    }
        //    return pairBar;
        //}
    }
}
