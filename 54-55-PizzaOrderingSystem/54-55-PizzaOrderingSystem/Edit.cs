using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _54_55_PizzaOrderingSystem
{
    public partial class Edit : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        String Filename;

        public Edit()
        {
            InitializeComponent();
            DoConnection();
            cmd = new SqlCommand();
            cmd.CommandText = "select Name from tbl_pizza";
            cmd.Connection = con;
            SqlDataReader sdr =  cmd.ExecuteReader();
            while (sdr.Read())
            {
                name_combobox.Items.Add(sdr.GetString(0));
            }
            sdr.Close();
        }

        void DoConnection()
        {
            con = new SqlConnection();

            con.ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\user\Documents\pizza_db.mdf;Integrated Security=True;Connect Timeout=30";
            con.Open();
        }

        private void edit_btn_Click(object sender, EventArgs e)
        {
            try
            {
                DoConnection();
                cmd.Connection = con;
                string query = "update tbl_pizza set Pizza_ID='" + id_txtbox.Text + "' ,Name='"+ name_combobox.Text + "' ,Image ='" + image_txtbox.Text +"' ,Description ='" + desc_richtxtbox.Text + "' ,Price ='" + price_txtbox.Text + "'where Pizza_ID = " + id_txtbox.Text + "";
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data edited successfully!");
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR!" + ex);
            }
        }

        private void Edit_Delete_Load(object sender, EventArgs e)
        {

        }

        private void back_button_Click(object sender, EventArgs e)
        {
            Admin_form af = new Admin_form();
            af.Show();
            this.Hide();
        }

        private void name_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            String Query = "select * from tbl_pizza where Name='"+ name_combobox.Text +"'; ";
            try
            {
                SqlDataReader dataReader;
                DoConnection();
                cmd = con.CreateCommand();
                cmd.CommandText = Query;
                dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    int sID = dataReader.GetInt32(0);
                   //Console.WriteLine(sID);
                   string sImage = dataReader.GetString(2);
                    string sDesc = dataReader.GetString(3);
                   //Console.WriteLine(sDesc);
                    double sPrice = dataReader.GetDouble(4);
                   //Console.WriteLine(sPrice);

                    id_txtbox.Text = sID.ToString();
                    desc_richtxtbox.Text = sDesc;
                    price_txtbox.Text = sPrice.ToString();
                    image_txtbox.Text = sImage.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void price_txtbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void edit_picture_Click(object sender, EventArgs e)
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
             //  pictureBox1.Image = new Bitmap(Filename);
                image_txtbox.Text = Filename;
                this.Controls.Add(image_txtbox);
            }
        }
    }
}