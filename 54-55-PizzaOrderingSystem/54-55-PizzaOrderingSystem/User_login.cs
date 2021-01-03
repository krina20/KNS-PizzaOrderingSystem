using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _54_55_PizzaOrderingSystem
{
    public partial class User_login : Form
    {
        public static string cname;
        public User_login()
        {
            InitializeComponent();
        }

        private void login_btn_Click(object sender, EventArgs e)
        {
            cname = uname_txtbox.Text;
            User oUser = new User();
            oUser.Login(uname_txtbox.Text, pwd_txtbox.Text);
            //MessageBox.Show("User Succefully logged in!");

            User_menu um = new User_menu();
            um.Show();
            this.Hide();
        }

        private void User_login_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }
    }
}
