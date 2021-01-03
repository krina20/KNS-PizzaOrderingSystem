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
    public partial class User_menu : Form
    {
        SqlConnection con;
        SqlCommand cmd;

        public User_menu()
        {
            InitializeComponent();
        }

        void DoConnection()
        {
            con = new SqlConnection();

            con.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\user\Documents\pizza_db.mdf;Integrated Security=True;Connect Timeout=30";
            con.Open();
        }

        void DisplayAllPizza()
        {
            DoConnection();
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from tbl_pizza";
            cmd.CommandType = CommandType.Text;
            SqlDataReader odr = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(odr);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].HeaderText = "Pizza ID ";
            dataGridView1.Columns[1].HeaderText = "Pizza Name";
            dataGridView1.Columns[2].HeaderText = "Image";
            dataGridView1.Columns[3].HeaderText = "Description";
            dataGridView1.Columns[4].HeaderText = "Price";

            con.Close();
        }

        private void User_menu_Load(object sender, EventArgs e)
        {
            label14.Text = User_login.cname;
            DisplayAllPizza();
            DoConnection();
            con.Close();
        }

        

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                //textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                label2.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                label3.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                label4.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                label5.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                label13.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            }
            else
            {
                MessageBox.Show("There is no pizza!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (label14.Text != "" & label2.Text != "" & label3.Text != "" & label4.Text != "" & label5.Text != "" & label13.Text != "")
            {
                DoConnection();
                //con.Open(); 
                cmd = con.CreateCommand();
                cmd.CommandText = "Insert into bill_tbl(Customer_Name,Order_ID,Name,Image,Description,Price) values('" + label14.Text + "','" + label2.Text + "','" + label3.Text + "','" + label4.Text + "','" + label5.Text +"','" + label13.Text  + "')";

                cmd.ExecuteNonQuery();
                
                MessageBox.Show("Data Saved Successfully..!!");
                con.Close();

                label14.Text = string.Empty;
                label2.Text = string.Empty;
                label3.Text = string.Empty;
                label4.Text = string.Empty;
                label5.Text = string.Empty;
                label13.Text = string.Empty;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            new Bill().Visible = true;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        

    }
}
