using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _54_55_PizzaOrderingSystem
{
    public partial class Admin_form : Form
    {
        public Admin_form()
        {
            InitializeComponent();
        }
        SqlConnection con;
        SqlCommand cmd;
       
        void DoConnection()
        {
            con = new SqlConnection();
            
            con.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\user\Documents\pizza_db.mdf;Integrated Security=True;Connect Timeout=30";
            con.Open();
        }

        private void add_btn_Click(object sender, EventArgs e)
        {
            Add oAdd = new Add();
            oAdd.Show();
            this.Hide();
        }

        private void edit_btn_Click(object sender, EventArgs e)
        {
            Edit ed = new Edit();
            ed.Show();
            this.Hide();
        }

        private void logout_btn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Admin Succefully logged out!");
            this.Hide();
            Choice oChoice = new Choice();
            oChoice.Show();
        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            Delete del = new Delete();
            del.Show();
            this.Hide();
        }

        private void menu_btn_Click(object sender, EventArgs e)
        {
            Menu oMenu = new Menu();
            oMenu.Show();
        }

        private void Admin_form_Load(object sender, EventArgs e)
        {

        }
    }
}