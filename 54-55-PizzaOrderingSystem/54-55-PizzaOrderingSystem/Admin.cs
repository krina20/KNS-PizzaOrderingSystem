using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _54_55_PizzaOrderingSystem
{
    class Admin
    {
        private string _userName;
        private string _password;

        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public void Login(string userName, string password)
        {
            UserName = userName;
            Password = password;

            if (userName == "krina" & password == "krina")
            {  
            }
            else if (userName == "nidhi" & password == "nidhi")
            {
            }
            else
            {
                throw new Exception("Login incorrect.");
            }
        }
    }
}