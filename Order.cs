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
    public partial class Order : Form
    {
        SqlConnection con;
        public String constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Gerhard\Source\Repos\ivansnyman\Finale-Projek-V2.0\Supplement_Database.mdf;Integrated Security=True";
        SqlCommand cmd;
        SqlDataAdapter adap;
        SqlDataReader reader;
        public string name;
        public string custID, prodID, cartName, manuName;
        double cartPrice, totalPrice;
        public bool flag = false;
        public Order(string employeeID)
        {
            txtEmployee.Text = employeeID;
            InitializeComponent();
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

        private void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string query = @"SELECT * from Products WHERE Date_Order_Received IS NULL";
                adap = new SqlDataAdapter(query, con);
                DataSet ds = new DataSet();
                adap.Fill(ds, "Products");
                dataGridView2.DataSource = ds;
                dataGridView2.DataMember = "Products";
                con.Close();
            }
            catch(SqlException error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void TxtDateFilter_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string query = @"SELECT * from Products WHERE Date_Order_Placed = '" + txtDateFilter.Text + "'";
                adap = new SqlDataAdapter(query, con);
                DataSet ds = new DataSet();
                adap.Fill(ds, "Products");
                dataGridView2.DataSource = ds;
                dataGridView2.DataMember = "Products";
                con.Close();
            }
            catch (SqlException error)
            {
                MessageBox.Show(error.Message);
            }
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

        private void Order_Load(object sender, EventArgs e)
        {
            listBox1.Items.Add("Supplier Name:\t\t Phone Number:\t\t Email:");
            listBox2.Items.Add("Product Name:\t\t Quantity:\t\t Price:\t\t Supplier Name");
            con = new SqlConnection(constr);
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string search = textBox2.Text;
                cmd = new SqlCommand("SELECT * FROM Suppliers WHERE Supplier_Name LIKE '%" + textBox2.Text + "%' OR Supplier_ID LIKE '%" + textBox2.Text + "%' OR Phone_Number LIKE '%" + textBox2.Text + "%'", con);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    listBox1.Items.Clear();
                    listBox1.Items.Add(reader.GetValue(1) + "\t\t " + reader.GetValue(2) + "\t\t " + reader.GetValue(3));

                }
                con.Close();
            }
            catch (SqlException error)
            {
                MessageBox.Show(error.Message);

            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            string selectedProductID = dataGridView1.SelectedCells[0].Value.ToString();
            if ((numericUpDown1.Value == 0) || (numericUpDown1.Value < 0) || (selectedProductID == ""))
            {
                MessageBox.Show("Please make sure you selected a product and entered a quantity");
            }
            else
            {
                int quantity = Convert.ToInt32(numericUpDown1.Value);
                con.Open();
                cmd = new SqlCommand("SELECT Product_ID, Product_Name, Price_Sold, Manufacturer_Name FROM Products", con);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (Convert.ToString(reader.GetValue(0)) == selectedProductID)
                    {
                        cartName = Convert.ToString(reader.GetValue(1));
                        cartPrice = Convert.ToDouble(reader.GetValue(2));
                        manuName = Convert.ToString(reader.GetValue(3));
                    }
                }
                con.Close();
                listBox2.Items.Add(cartName + "\t" + Convert.ToString(quantity) + "\t" + "R" + Convert.ToString(cartPrice * quantity));
                totalPrice += cartPrice * quantity;
                listBox2.Items.Add("Total Due:\t\t" + "R" + Convert.ToString(totalPrice));
            }
        }
    }
}
