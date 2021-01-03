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
    public partial class Bill : Form
    {
        SqlConnection con;
        SqlCommand cmd;

        public Bill()
        {
            InitializeComponent();
            userLBL.Text = User.username;
        }

        void DoConnection()
        {
            con = new SqlConnection();

            con.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\user\Documents\pizza_db.mdf;Integrated Security=True;Connect Timeout=30";
            con.Open();
        }

        void DisplayOrder()
        {
            DoConnection();
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from bill_tbl where Customer_Name = '" + userLBL.Text + "';";
            cmd.CommandType = CommandType.Text;
            SqlDataReader odr = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(odr);
            dataGridView1.DataSource = dt;
            //dataGridView1.Columns[0].HeaderText = "Pizza ID ";
            dataGridView1.Columns[1].HeaderText = "Pizza Name";
            //dataGridView1.Columns[2].HeaderText = "Image";
            dataGridView1.Columns[3].HeaderText = "Description";
            //dataGridView1.Columns[4].HeaderText = "Price";

            con.Close();
        }

        private void Bill_Load(object sender, EventArgs e)
        {
            DisplayOrder();
            DoConnection();
            con.Close();
        }

        

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("User Succefully logged out!");
            this.Hide();
            Choice oChoice = new Choice();
            oChoice.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}
