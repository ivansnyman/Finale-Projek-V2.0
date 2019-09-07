using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace Finale_Projek_V2._0
{
    public partial class Products : Form
    {
        SqlConnection con;
        public Products()
        {
            InitializeComponent();
        }

        private void Products_Load(object sender, EventArgs e)
        {
            String cnn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\baren\Source\Repos\ivansnyman\Finale-Projek-V2.0\Supplement_Database.mdf;Integrated Security=True";
            con = new SqlConnection(cnn);
            con.Open();
            display();
            con.Close();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            Add_Product myproduct = new Add_Product();
            myproduct.ShowDialog();
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            con.Open();
            display();
            con.Close();
        }

        private void display()
        {
            string selectquery = "SELECT * FROM Products";
            SqlCommand cmd = new SqlCommand(selectquery, con);
            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            adapter.Fill(ds, "Products");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Products";
            cmd.ExecuteNonQuery();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            con.Open();
            string sql = @"DELETE FROM Products WHERE Product_ID = '"+textBox2.Text+"'";
            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand(sql, con);
            DataSet ds = new DataSet();
            adapter.DeleteCommand = cmd;
            adapter.DeleteCommand.ExecuteNonQuery();

            display();

            con.Close();

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            con.Open();
            string query = @"SELECT * from Products WHERE Manufacturer_Name LIKE '%" + textBox1.Text + "%' OR Product_Name LIKE '%" + textBox1.Text + "%'";
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Products");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Products";            con.Close();        }
    }
}
