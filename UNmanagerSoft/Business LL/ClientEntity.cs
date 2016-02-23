using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UNmanagerSoft.Business_LL
{
    class ClientEntity
    {
        private string _ID;
        private string _ClientName;
        private string _ClientAddress;
        private string _ClientPhone;
        private string _DateTime;

        public string ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        public string ClientName
        {
            get { return _ClientName; }
            set { _ClientName = value; }
        }

        public string ClientAddress
        {
            get { return _ClientAddress; }
            set { _ClientAddress = value; }
        }

        public string ClientPhone
        {
            get { return _ClientPhone; }
            set { _ClientPhone = value; }
        }

        public string DateTime
        {
            get { return _DateTime; }
            set { _DateTime = value; }
        }
    }
}
