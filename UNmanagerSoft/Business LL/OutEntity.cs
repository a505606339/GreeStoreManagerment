using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UNmanagerSoft.Business_LL
{
    class OutEntity
    {
        private string _inbarcode;
        private string _outbarcode;
        private string _type;
        private string _clientName;
        private string _outdate;
        private string _number;
        private string _money;
        private string _operators;
        private string _deliver;
        private string _install;
        private string _remark;
        private string _outOrderNum;

        public string InBarcode
        {
            get { return _inbarcode; }
            set { _inbarcode = value; }
        }

        public string OutBarcode
        {
            get { return _outbarcode; }
            set { _outbarcode = value; }
        }

        public string ClientName
        {
            get { return _clientName; }
            set { _clientName = value; }
        }

        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public string Outdate
        {
            get { return _outdate; }
            set { _outdate = value; }
        }

        public string Money
        {
            get { return _money; }
            set { _money = value; }
        }

        public string Number
        {
            get { return _number; }
            set { _number = value; }
        }

        public string Operators
        {
            get { return _operators; }
            set { _operators = value; }
        }

        public string Deliver
        {
            get { return _deliver; }
            set { _deliver = value; }
        }

        public string Remark
        {
            get { return _remark; }
            set { _remark = value; }
        }

        public string Install
        {
            get { return _install; }
            set { _install = value; }
        }

        public string OutOrderNum
        {
            get { return _outOrderNum; }
            set { _outOrderNum = value; }
        }
    }
}
