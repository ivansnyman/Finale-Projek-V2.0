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
    public partial class Customers : Form
    {
        SqlConnection con;


        public Customers()
        {
            InitializeComponent();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            AddCustomer frmAddCustomer = new AddCustomer();
            frmAddCustomer.ShowDialog();
        }
        private void display()
        {
            con.Open();
            string selectquery = "SELECT * FROM Customers";
            SqlCommand cmd = new SqlCommand(selectquery, con);
            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            adapter.Fill(ds, "Customers");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Customers";
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void Customers_Load(object sender, EventArgs e)
        {
            String cnn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\baren\Source\Repos\ivansnyman\Finale-Projek-V2.0\Supplement_Database.mdf;Integrated Security=True";
            con = new SqlConnection(cnn);
            display();

        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            display();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            con.Open();
            string sql = @"DELETE FROM Customers WHERE Customer_ID = '" + textBox2.Text + "'";
            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand(sql, con);
            DataSet ds = new DataSet();
            adapter.DeleteCommand = cmd;
            adapter.DeleteCommand.ExecuteNonQuery();


            con.Close();
            display();

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            con.Open();
            string query = @"SELECT * from Customers WHERE First_Name LIKE '%" + textBox1.Text + "%' OR Last_Name LIKE '%" + textBox1.Text + "%'";
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Products");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Products";
            con.Close();

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            int index = comboBox1.SelectedIndex;
            string id = dataGridView1.SelectedCells[0].Value.ToString();
            string insertQuery;

            if (index == 0)
            {
                insertQuery = @"UPDATE Customers SET First_Name = '" + Valuetxt.Text + "' WHERE Customer_ID = '" + id + "'";
            }
            else if (index == 1)
            {
                insertQuery = @"UPDATE Customers SET Last_Name = '" + Valuetxt.Text + "' WHERE Customer_ID = '" + id + "'";
            }
            else if (index == 2)
            {
                insertQuery = @"UPDATE Customers SET Phone_Number = '" + int.Parse(Valuetxt.Text) + "' WHERE Customer_ID = '" + id + "'";
            }
            else if (index == 3)
            {
                insertQuery = @"UPDATE Customers SET Email = '" + int.Parse(Valuetxt.Text) + "' WHERE Customer_ID = '" + id + "'";
            }
            else if (index == 4)
            {
                insertQuery = @"UPDATE Customers SET Gender = '" + int.Parse(Valuetxt.Text) + "' WHERE Customer_ID = '" + id + "'";
            }
            else if (index == 5)
            {
                insertQuery = @"UPDATE Customers SET Date_of_Birth = '" + int.Parse(Valuetxt.Text) + "' WHERE Customer_ID= '" + id + "'";
            }
            else
            {
                insertQuery = @"UPDATE Customers SET Stock = '" + int.Parse(Valuetxt.Text) + "' WHERE Customer_ID = '" + id + "'";
            }

            con.Open();


            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand(insertQuery, con);
            cmd.CommandText = insertQuery;

            cmd.ExecuteNonQuery();
            con.Close();
            display();

        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            con.Open();
            string query = @"SELECT * from Customers WHERE First_Name LIKE '%" + textBox1.Text + "%' OR Last_Name LIKE '%" + textBox1.Text + "%'";
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Products");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Products";
            con.Close();

        }
    }
}
