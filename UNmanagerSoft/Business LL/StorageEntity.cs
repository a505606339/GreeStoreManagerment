using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UNmanagerSoft.Business_LL
{
    public class StorageEntity
    {
        private string _uid;
        private string _type;
        private string _number;
        private string _inMoney;
        private string _receiptsNumber;
        private string _receiptsName;
        private string _inOpter;
        private string _inDateTime;
        private string _inRemark;
        private string _stockName;

        public string UID
        {
            get { return _uid; }
            set { _uid = value; }
        }

        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public string Number
        {
            get { return _number; }
            set { _number = value; }
        }

        public string InMoney
        {
            get { return _inMoney; }
            set { _inMoney = value; }
        }

        public string ReceiptsNumber
        {
            get { return _receiptsNumber; }
            set { _receiptsNumber = value; }
        }

        public string ReceiptsName
        {
            get { return _receiptsName; }
            set { _receiptsName = value; }
        }

        public string InOpter
        {
            get { return _inOpter; }
            set { _inOpter = value; }
        }

        public string InDateTime
        {
            get { return _inDateTime; }
            set { _inDateTime = value; }
        }

        public string InRemark
        {
            get { return _inRemark; }
            set { _inRemark = value; }
        }

        public string StockName
        {
            get { return _stockName; }
            set { _stockName = value; }
        }
    }
}
