using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Finale_Projek_V2._0
{
    public partial class Sales : Form
    {
        SqlConnection con;
        public String constr = @"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Gerhard\\Source\\Repos\\ivansnyman\\Finale-Projek-V2.0\\Supplement_Database.mdf;Integrated Security=True";
        SqlCommand cmd;
        SqlDataReader reader;
        SqlDataAdapter adap;
        public string name;
        public bool flag = false;
        public Sales()
        {
            InitializeComponent();
        }

        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Sales_Load(object sender, EventArgs e)
        {
            listBox3.Items.Add("First Name:\t\t Last Name:\t\t Address:");
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            con.Open();
            string query = @"SELECT * from Products WHERE Manufacturer_Name LIKE '%" + textBox1.Text + "%' OR Product_Name LIKE '%" + textBox1.Text + "%'";
            adap = new SqlDataAdapter(query, con);
            DataSet ds = new DataSet();
            adap.Fill(ds, "Products");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Products";
            con.Close();
        }

        private void TextBox5_TextChanged(object sender, EventArgs e)
        {
            con.Open();
            string query = @"SELECT * from Products WHERE Product_ID LIKE '%" + textBox5.Text + "%'";
            adap = new SqlDataAdapter(query, con);
            DataSet ds = new DataSet();
            adap.Fill(ds, "Products");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Products";
            con.Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
           
            string product = "";
            int quantity = 0;
            if (flag == false)
            {
                MessageBox.Show("Please enter customer information");
            }
            else
            {
                flag = true;

            }
        }

        private void BtnCustomer_Click(object sender, EventArgs e)
        {
            

        }

        private void TextBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string search = textBox3.Text;
                cmd = new SqlCommand("SELECT * FROM Customers WHERE First_Name LIKE '%" + textBox3.Text + "%' OR Last_Name LIKE '%" + textBox3.Text + "%' OR Phone_Number LIKE '%" + textBox3.Text + "%'",con);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    listBox3.Items.Add(reader.GetValue(1) + "\t\t " + reader.GetValue(2) + "\t\t " + reader.GetValue(3));
                    
                }
            }
            catch (Exception)
            {

                
            }
        }
    }
}
