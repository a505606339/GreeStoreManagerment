using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UNmanagerSoft.Business_LL
{
    class ReturnedEntity
    {
        private string _inbarcode;
        private string _outbarcode;
        private string _type;
        private string _remark; 
        private string _clientName;
        private string _optName;
        private string _dateTime;

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
        public string type
        {
            get { return _type; }
            set { _type = value; }
        }
        public string remark
        {
            get { return _remark; }
            set { _remark = value; }
        }
        public string clientName
        {
            get { return _clientName; }
            set { _clientName = value; }
        }
        public string optName
        {
            get { return _optName; }
            set { _optName = value; }
        }
        public string dateTime
        {
            get { return _dateTime; }
            set { _dateTime = value; }
        }
    }
}
