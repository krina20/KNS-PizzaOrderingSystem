using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _54_55_PizzaOrderingSystem
{
    public partial class Add : Form
    {
        Menu obj = new Menu();
        public Add()
        {
            InitializeComponent();
        }
        SqlConnection con;
        SqlCommand cmd;
        String Filename;

        void DoConnection()
        {
            con = new SqlConnection();

            con.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\user\Documents\pizza_db.mdf;Integrated Security=True;Connect Timeout=30";
            con.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "e:\\";
            openFileDialog1.Filter = "image files (*.jpeg)|*.jpg|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Filename = openFileDialog1.FileName;
                pictureBox1.Image = new Bitmap(Filename);
                this.Controls.Add(pictureBox1);
            }
        }

        private void added_btn_Click(object sender, EventArgs e)
        {
            DoConnection();
            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into tbl_Pizza values(" + id_txtbox.Text + ",'" + name_txtbox.Text + "','" + Filename + "','" + desc_txtbox.Text + "'," + price_txtbox.Text.ToString() + ");";
           
            int x = cmd.ExecuteNonQuery();
            if (x == 1)
            {
                MessageBox.Show("New Pizza added to menu!!");
            }
            else
            {
                MessageBox.Show("no records to insert");
            }
            

            Admin_form af = new Admin_form();
            af.Show();

            String Name = name_txtbox.Text;
            float Price = float.Parse(price_txtbox.Text);

            this.Hide();
            obj.Show();
            this.Hide();
            con.Close(); 
        }

        private void back_btn_Click(object sender, EventArgs e)
        {
            Admin_form af = new Admin_form();
            af.Show();
            this.Hide();
        }

        private void Add_Load(object sender, EventArgs e)
        {

        }
    }
}