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
    public partial class Delete : Form
    { 
        SqlConnection con;
        SqlCommand cmd;

        public Delete()
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

        private void delete_btn_Click(object sender, EventArgs e)
        {
            try
            {
                DoConnection();
                cmd.Connection = con;
                string query = "delete from tbl_pizza where Pizza_ID="+ id_txtbox.Text + "";
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Pizza deleted successfully!");
                id_txtbox.Clear();
                name_combobox.Items.RemoveAt(name_combobox.SelectedIndex);
                image_txtbox.Clear();
                desc_richtxtbox.Clear();
                price_txtbox.Clear();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR!" + ex);
            }
        }

        private void name_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            String Query = "select * from tbl_pizza where Name='" + name_combobox.Text + "'; ";
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
                    // Console.WriteLine(sID);
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
           // this.Hide();
        }

        private void back_button_Click(object sender, EventArgs e)
        {
            Admin_form af = new Admin_form();
            af.Show();
            this.Hide();
        }

        private void Delete_Load(object sender, EventArgs e)
        {

        }
     }
}
