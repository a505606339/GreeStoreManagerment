using System;
using System.Collections.Generic;
using System.Text;

namespace padSoft_e
{
    public class SingletonUser
    {
        //用户名  
        private string _AccountName = "";
        public string AccountName { get { return _AccountName; } set { _AccountName = value; } }

        //登录时间  
        private DateTime _LoginTime;
        public  DateTime LoginTime { get { return _LoginTime; } set { _LoginTime = value; } }

        private static SingletonUser _CurrentUser = null;

        //应用单件模式，保存用户登录状态 
        public static SingletonUser CurrentUser
        {
            get
            {
                if (_CurrentUser == null)
                    _CurrentUser = new SingletonUser();
                return _CurrentUser;
            }
        }
    }
}
