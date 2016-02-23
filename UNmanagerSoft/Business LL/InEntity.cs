using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UNmanagerSoft.Business_LL
{
    class InEntity
    {
        private string _inBarcode;
        private string _outBarcode;
        private string _type;
        private string _receiptsNumber;
        private string _receiptsName;
        private string _inDate;
        private string _inNumber;
        private string _inMoney;
        private string _operators;
        private string _remark;

        public string inbarcode
        {
            get { return _inBarcode; }
            set { _inBarcode = value; }
        }

        public string outbarcode
        {
            get { return _outBarcode; }
            set { _outBarcode = value; }
        }

        public string type
        {
            get { return _type; }
            set { _type = value; }
        }

        public string receiptsNumber
        {
            get { return _receiptsNumber; }
            set { _receiptsNumber = value; }
        }
        public string receiptsName
        {
            get { return _receiptsName; }
            set { _receiptsName = value; }
        }
        public string inDate
        {
            get { return _inDate; }
            set { _inDate = value; }
        }
        public string inNumber
        {
            get { return _inNumber; }
            set { _inNumber = value; }
        }
        public string inMoney
        {
            get { return _inMoney; }
            set { _inMoney = value; }
        }
        public string operators
        {
            get { return _operators; }
            set { _operators = value; }
        }
        public string remark
        {
            get { return _remark; }
            set { _remark = value; }
        }
    }
}
