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
        public String constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\baren\Source\Repos\ivansnyman\Finale-Projek-V2.0\Supplement_Database.mdf;Integrated Security=True";
        SqlCommand cmd;
        SqlDataReader reader;
        SqlDataAdapter adap;
        public string custID, cartName;
        public double cartPrice, totalPrice;
        public int currentID, prodID, transactionID, quantity, currentStock;
        public Sales()
        {
            
            InitializeComponent();
        }

        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Sales_Load(object sender, EventArgs e)
        {
           
            con = new SqlConnection(constr);
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            string selected_Item = listBox2.SelectedIndex.ToString();
            int index = selected_Item.IndexOf(",");
            int selected_ProductID = Convert.ToInt32(selected_Item.Substring(1, index - 1));
            selected_Item = selected_Item.Remove(1, index);
            index = selected_Item.IndexOf(",");
            selected_Item = selected_Item.Remove(1, index);
            index = selected_Item.IndexOf(",");
            int quantity = Convert.ToInt32(selected_Item.Substring(1, index - 1));
            int currentStock = 0;
            con.Open();
            SqlCommand command1 = new SqlCommand("Select Stock FROM Products WHERE Product_ID = " + selected_ProductID + "", con);
            SqlDataReader reader = command1.ExecuteReader();
            while (reader.Read())
            {
                currentStock = Convert.ToInt32(reader.GetValue(0));
            }
            //sql query om stock reg te maak 
            int newStock = currentStock + quantity;
            string update_Query = "UPDATE Products SET Stock = '" + newStock + "' WHERE Product_ID = '" + currentID + "'";
            con.Open();
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            command = new SqlCommand(update_Query,con);
            adapter.UpdateCommand = new SqlCommand(update_Query, con);
            adapter.UpdateCommand.ExecuteNonQuery();
            command.Dispose();
            con.Close();
            //------------------------------------------------------
            String delete_Query = "DELETE From Product_Transaction WHERE Product_ID = '" + currentID + "' AND Transaction_ID = '" + transactionID + "' AND Quantity = '" + quantity + "'";
            try
            {
                con.Open();
                SqlCommand delete_Command = new SqlCommand(delete_Query, con);
                SqlDataAdapter adapter3 = new SqlDataAdapter();
                adapter3.DeleteCommand = delete_Command;
                adapter3.DeleteCommand.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Item removed succesfully.");
            }
            catch (SqlException error)
            {
                MessageBox.Show(error.Message);
            }
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
            string selectedProductID = dataGridView1.SelectedCells[0].Value.ToString();
            if ((numericUpDown1.Value == 0) || (numericUpDown1.Value < 0) || (selectedProductID == ""))
            {
                MessageBox.Show("Please make sure you selected a product and entered a quantity");
            }
            else
            {
                quantity = Convert.ToInt32(numericUpDown1.Value);
                con.Open();
                cmd = new SqlCommand("SELECT Product_ID, Product_Name, Price_Sold, Stock FROM Products",con);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (Convert.ToString(reader.GetValue(0)) == selectedProductID)
                    {
                        prodID = Convert.ToInt32(reader.GetValue(0));
                        cartName = Convert.ToString(reader.GetValue(1));
                        cartPrice = Convert.ToDouble(reader.GetValue(2));
                        currentStock = Convert.ToInt32(reader.GetValue(3));
                    }
                }
                con.Close();
                
                    listBox2.Items.Add(prodID + "," + "\t" + cartName + "," + "\t" + Convert.ToString(quantity) + "," + "\t" + "R" + Convert.ToString(cartPrice * quantity));
                    totalPrice += cartPrice * quantity;
                    listBox2.Items.Add("Total Due:\t\t" + "R" + Convert.ToString(totalPrice));

                try
                {
                    ConfirmLogin frmConfirm = new ConfirmLogin();
                    frmConfirm.ShowDialog();
                    currentID = Convert.ToInt32(frmConfirm.employeeID);
                    transactionID = Convert.ToInt32(frmConfirm.transactionID);
                    transactionID += 1;
                    con.Open();
                    int updatedStock = currentStock - quantity;
                    SqlCommand command;
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    String sql = "Update Product set Stock='" + Convert.ToString(updatedStock) + "' where Product_ID ='" + prodID + "'";
                    command = new SqlCommand(sql, con);
                    adapter.UpdateCommand = new SqlCommand(sql, con);
                    adapter.UpdateCommand.ExecuteNonQuery();
                    command.Dispose();
                    con.Close();
                    con.Open();
                    command = new SqlCommand(@"INSERT Into Product_Transaction Values(" + prodID + ", " + transactionID + "," + quantity + ")",con);
                    adap = new SqlDataAdapter();
                    adap.InsertCommand = command;
                    adap.InsertCommand.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                    
                }
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
                listBox3.Items.Clear();
                string search = textBox3.Text;
                cmd = new SqlCommand("SELECT * FROM Customers WHERE First_Name LIKE '%" + textBox3.Text + "%' OR Last_Name LIKE '%" + textBox3.Text + "%' OR Phone_Number LIKE '%" + textBox3.Text + "%'",con);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    listBox3.Items.Add(reader.GetValue(1) + "\t\t " + reader.GetValue(2) + "\t\t " + reader.GetValue(3));
                    custID =  Convert.ToString(reader.GetValue(0));
                }
                con.Close();
            }
            catch (SqlException error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            int index = listBox3.SelectedIndex;
            if (index >= 0 && listBox2.Items.Count > 0)
            {
                System.IO.File.WriteAllText(@"C:\Users\ivans\source\repos\Finale Projek V2.0\Transaction_ID.txt", Convert.ToString(transactionID));
                MessageBox.Show("Sale completed succesfully");
            }
            else
            {
                MessageBox.Show("Please enter valid customer information and check if cart is empty");
            }
        }
    }
}
