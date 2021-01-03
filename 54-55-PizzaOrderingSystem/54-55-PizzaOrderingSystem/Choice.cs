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
    public partial class Choice : Form
    {
        public Choice()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            admin_login login = new admin_login();
            login.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            User_login oLogin = new User_login();
            oLogin.Show();
            this.Hide();
        }

        private void Choice_Load(object sender, EventArgs e)
        {

        }
    }
}
