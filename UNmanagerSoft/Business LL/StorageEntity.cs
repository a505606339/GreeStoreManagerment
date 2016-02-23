using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UNmanagerSoft.Business_LL
{
    class StorageEntity
    {
        private string _barcode;
        private string _model;
        private string _type;
        private string _number;
        private string _inMoney;
        private string _receiptsNumber;
        private string _receiptsName;
        private string _inOpter;
        private string _inDateTime;
        private string _outReceiptsNumber;
        private string _clientName;
        private string _outMoney;
        private string _outOpter;
        private string _deliver;
        private string _install;
        private string _outDateTime;
        private string _inRemark;
        private string _outRemark;

        public string Barcode
        {
            get { return _barcode; }
            set { _barcode = value; }
        }

        public string OutReceiptsNumber
        {
            get { return _outReceiptsNumber; }
            set { _outReceiptsNumber = value; }
        }

        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public string Model
        {
            get { return _model; }
            set { _model = value; }
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

        public string ClientName
        {
            get { return _clientName; }
            set { _clientName = value; }
        }

        public string OutMoney
        {
            get { return _outMoney; }
            set { _outMoney = value; }
        }

        public string OutOpter
        {
            get { return _outOpter; }
            set { _outOpter = value; }
        }

        public string Deliver
        {
            get { return _deliver; }
            set { _deliver = value; }
        }

        public string Install
        {
            get { return _install; }
            set { _install = value; }
        }

        public string OutDateTime
        {
            get { return _outDateTime; }
            set { _outDateTime = value; }
        }

        public string InRemark
        {
            get { return _inRemark; }
            set { _inRemark = value; }
        }

        public string OutRemark
        {
            get { return _outRemark; }
            set { _outRemark = value; }
        }
    }
}
