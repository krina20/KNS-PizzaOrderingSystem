using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _54_55_PizzaOrderingSystem
{
    class User
    {
        private string _userName;
        private string _password;

        public static string username;
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

            if (userName == "shivam" & password == "shivam")
            {
                username = userName;
            }
            else if (userName == "pruthvi" & password == "pruthvi")
            {
                username = userName;
            }
            else
            {
                throw new Exception("Login incorrect.");
            }
        }
    }
    }
