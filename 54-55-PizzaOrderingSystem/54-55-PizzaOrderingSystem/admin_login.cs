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
    public partial class admin_login : Form
    {
        public admin_login()
        {
            InitializeComponent();
        }

        private void login_btn_Click(object sender, EventArgs e)
        {
            Admin oAdmin = new Admin();
            oAdmin.Login(uname_txtbox.Text, pwd_txtbox.Text);
            //MessageBox.Show("Admin Succefully logged in!");
           
            load oLoad = new load();
            oLoad.Show();
            this.Hide();
        }

        private void admin_login_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //this.Close();
            System.Environment.Exit(0);
        }

        private void uname_txtbox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}