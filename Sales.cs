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
        SqlDataAdapter adap;
        public Sales()
        {
            InitializeComponent();
        }

        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Sales_Load(object sender, EventArgs e)
        {

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
    }
}
