﻿using System;
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
        public string custID, cartName, manuName;
        double cartPrice, totalPrice;
        public bool flag = false;
        public int orderID, currentID, currentStock;
        public int supplierID = 1;
        public string date_placed;
        public int quantity;
        public string date_received = "";
        public Order()
        {
            
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
                string query = @"SELECT * from Orders WHERE Date_Order_Received = '" + date_received + "'";
                adap = new SqlDataAdapter(query, con);
                DataSet ds = new DataSet();
                adap.Fill(ds, "Orders");
                dataGridView2.DataSource = ds;
                dataGridView2.DataMember = "Orders";
                con.Close();
            }
            catch(SqlException error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            
            date_placed = DateTime.Today.ToShortDateString();
            int index = listBox1.SelectedIndex;
            if (index >= 0 && listBox2.Items.Count > 0)
            {
                System.IO.File.WriteAllText(@"C:\Users\Gerhard\source\repos\ivansnyman\Finale-Projek-V2.0\Order_ID.txt", Convert.ToString(orderID));
                listBox2.Items.Clear();
                MessageBox.Show("Order completed succesfully");
                con.Open();
                SqlCommand command = new SqlCommand(@"Insert Into Orders Values('" + orderID + "','" + currentID + "','" + date_placed + "','" + totalPrice + "','" + supplierID + "','" + date_received + "')", con);
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.InsertCommand = command;
                adapter.InsertCommand.ExecuteNonQuery();
                con.Close();
            }
            else
            {
                MessageBox.Show("Please enter valid supplier information and check if cart is empty");
            }
        }

        private void TxtDateFilter_TextChanged(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string query = @"SELECT * from Orders WHERE Date_Order_Placed = '" + txtDateFilter.Text + "'";
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

        private void BtnReceived_Click(object sender, EventArgs e)
        {
            string date_received_order = DateTime.Today.ToShortDateString();
            string selectedOrderID = dataGridView2.SelectedCells[0].Value.ToString();

            try
            {
                string recQuery = "UPDATE Orders SET Date_Order_Received = '" + date_received_order + "' WHERE Order_ID = '" + selectedOrderID + "'";
                con.Close();
                con.Open();
                SqlCommand command;
                SqlDataAdapter adapter = new SqlDataAdapter();
                command = new SqlCommand(recQuery, con);
                adapter.UpdateCommand = new SqlCommand(recQuery, con);
                adapter.UpdateCommand.ExecuteNonQuery();
                command.Dispose();
                con.Close();
                MessageBox.Show("Successfully received order");
            }
            catch(SqlException error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            if (!(listBox2.SelectedIndex >= 0))
                MessageBox.Show("Please select an item to remove");


            con.Close();
            string selected_Item = listBox2.SelectedItem.ToString();
            int index = selected_Item.IndexOf(',');
            int selected_ProductID = Convert.ToInt32(selected_Item.Substring(0, index-1));
            selected_Item = selected_Item.Remove(0, index+1);
            index = selected_Item.IndexOf(',');
            selected_Item = selected_Item.Remove(0, index+1);
            index = selected_Item.IndexOf(',');
            int quantity = Convert.ToInt32(selected_Item.Substring(0, index-1));
            int currentStock = 0;
            con.Open();
            SqlCommand command1 = new SqlCommand("Select Stock FROM Products WHERE Product_ID = " + selected_ProductID + "", con);
            SqlDataReader reader = command1.ExecuteReader();
            while (reader.Read())
            {
                currentStock = Convert.ToInt32(reader.GetValue(0));
            }
            //sql query om stock reg te maak 
            int newStock = currentStock - quantity;
            string update_Query = "UPDATE Products SET Stock = '" + newStock + "' WHERE Product_ID = '" + currentID + "'";
            con.Close();
            con.Open();
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            command = new SqlCommand(update_Query, con);
            adapter.UpdateCommand = new SqlCommand(update_Query, con);
            adapter.UpdateCommand.ExecuteNonQuery();
            command.Dispose();
            con.Close();
            //------------------------------------------------------
            String delete_Query = "DELETE From Products_Order WHERE Product_ID = '" + currentID + "' AND Order_ID = '" + orderID + "' AND Quantity = '" + quantity + "'";
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
            if (!(listBox1.SelectedIndex >= 0))
                MessageBox.Show("Please select an supplier to proceed");
            else if (dataGridView1.SelectedRows == null)
                MessageBox.Show("Please select one or more product to proceed");
            else if (!(numericUpDown1.Value > 0))
                MessageBox.Show("Please select the quantity of the product you wish to add to cart");
            else
            { 
                string selectedProductID = dataGridView1.SelectedCells[0].Value.ToString();
                if ((numericUpDown1.Value == 0) || (numericUpDown1.Value < 0) || (selectedProductID == ""))
                {
                    MessageBox.Show("Please make sure you selected a product and entered a quantity");
                }
                else
                {
                    quantity = Convert.ToInt32(numericUpDown1.Value);
                    con.Close();
                    con.Open();
                    cmd = new SqlCommand("SELECT Product_ID, Product_Name, Price_Sold, Manufacturer_Name, Stock FROM Products", con);
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (Convert.ToString(reader.GetValue(0)) == selectedProductID)
                        {
                            cartName = Convert.ToString(reader.GetValue(1));
                            cartPrice = Convert.ToDouble(reader.GetValue(2));
                            manuName = Convert.ToString(reader.GetValue(3));
                            currentStock = Convert.ToInt32(reader.GetValue(4));
                        }
                    }
                    con.Close();
                    listBox2.Items.Add(selectedProductID + "    ," + cartName + "    ," + Convert.ToString(quantity) + "    ," + "R" + Convert.ToString(cartPrice * quantity) + "    ," + manuName);
                    totalPrice += cartPrice * quantity;
                    listBox2.Items.Add("Total Due: " + "R" + Convert.ToString(totalPrice));

                    try
                    {
                        ConfirmLogin frmConfirm = new ConfirmLogin();
                        frmConfirm.ShowDialog();
                        currentID = Convert.ToInt32(frmConfirm.employeeID);
                        orderID = Convert.ToInt32(frmConfirm.orderID);
                        orderID += 1;
                        con.Open();
                        int updatedStock = currentStock + quantity;
                        SqlCommand command;
                        SqlDataAdapter adapter = new SqlDataAdapter();
                        String sql = "Update Products set Stock='" + Convert.ToString(updatedStock) + "' where Product_ID ='" + Convert.ToInt32(selectedProductID) + "'";
                        command = new SqlCommand(sql, con);
                        adapter.UpdateCommand = new SqlCommand(sql, con);
                        adapter.UpdateCommand.ExecuteNonQuery();
                        command.Dispose();
                        con.Close();
                        con.Open();
                        command = new SqlCommand(@"INSERT Into Products_Order Values('" + Convert.ToInt32(selectedProductID) + "','" + orderID + "','" + quantity + "')", con);
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
        }
    }
}
