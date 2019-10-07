﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;


namespace Finale_Projek_V2._0
{
    public partial class Reporting : Form
    {

        public Reporting()
        {
            InitializeComponent();
        }
        SqlConnection con;
        SqlDataAdapter adapter;
        SqlCommand command;
        DataSet ds;
        int count_Employees;
        private void Reporting_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\baren\Source\Repos\ivansnyman\Finale-Projek-V2.0\Supplement_Database.mdf;Integrated Security=True");
            //Uitfigure watse maand dit is en dan deur dit gaan met 'n loop vir die maand se sales
            string date = DateTime.Today.ToShortDateString(); // DD/MM/YYYY
            string date_Search = date.Substring(4, 10); // MM/YYYY
            int count = 0;
            double income = 0;
            try
            {
                con.Open();
                command = new SqlCommand("SELECT * FROM Transactions WHERE Date_of_Transaction LIKE '%%/" + date_Search + "'", con); // '%%/MM/YYYY'
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    count += 1; //Kry total sales vir gegewe maand
                    double sale_Amount = Convert.ToDouble(reader.GetValue(1)); 
                    income += sale_Amount; //Tell die total income vir die maand
                }
                con.Close();
            }
            catch (SqlException error)
            {
                MessageBox.Show(error.Message);
                
            }
            // Code om total orders en total expenditure te kry
            int count_Orders = 0;
            double monthly_Cost = 0;
            try
            {
                con.Open();
                command = new SqlCommand("SELECT * FROM Orders WHERE Date_Order_Placed LIKE '%%" + date_Search + "'", con); // '%%/MM/YYYY'
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    count_Orders += 1; //Kry total orders vir gegewe maand
                    double order_Amount = Convert.ToDouble(reader.GetValue(1));
                    monthly_Cost += order_Amount; //Tell die total income vir die maand
                }
                con.Close();
            }
            catch (SqlException error)
            {
                MessageBox.Show(error.Message);
                
            }
            double total_Profit = income - monthly_Cost;
            //Set die textboxes
            tbxSales.Text = Convert.ToString(count);
            tbxIncome.Text = Convert.ToString(income);
            tbxOrders.Text = Convert.ToString(count_Orders);
            tbxCosts.Text = Convert.ToString(monthly_Cost);
            tbxProfit.Text = Convert.ToString(total_Profit);

            //Populate die combobox met orders wat nog nie gekom het nie
            try
            {
                string null_Search = "";
                con.Open();
                adapter = new SqlDataAdapter();
                command = new SqlCommand(@"SELECT Order_ID FROM Orders WHERE Date_Order_Received = '" + null_Search + "'", con);
                ds = new DataSet();
                adapter.SelectCommand = command;
                adapter.Fill(ds, "Orders");
                listBox1.DisplayMember = "Order_ID";
                listBox1.ValueMember = "Order_ID";
                listBox1.DataSource = ds.Tables["Orders"];
            }
            catch (SqlException error)
            {
                MessageBox.Show(error.Message);
            }

            count_Employees = 0;
            try
            {
                con.Open();
                command = new SqlCommand("SELECT * FROM Employees");
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    count_Employees += 1;
                }
                con.Close();
            }
            catch (SqlException error)
            {

                MessageBox.Show(error.Message);
            }
        }
        

        private void Button2_Click(object sender, EventArgs e)
        {
            //string order_ID = listBox1.SelectedIndex.ToString();
            var fromAddress = new MailAddress("randburgstrengthandfitness@gmail.com", "Randburg Strength & Fitness");
            var toAddress = new MailAddress("Barendjohannesvanderwalt1998@gmail.com", "Hanno");
            const string fromPassword = "kameelperdkalmeerpil";
            const string subject = "Late Order Enquiry";
            string body = "Hello boepens dis katryn wat praat";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
                Timeout = 20000
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }

        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            //Hanno maak 'n textfile in folder genoem Sales_Data.txt
            try
            {
                con.Open();
                command = new SqlCommand("SELECT * FROM Transactions");
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string output = Convert.ToString(reader.GetValue(0)) + "\t" + Convert.ToString(reader.GetValue(1)) + "\t" + Convert.ToString(reader.GetValue(2)) + "\t" + Convert.ToString(reader.GetValue(3)) + "\t" + Convert.ToString(reader.GetValue(4)) + "\t";
                    using (System.IO.StreamWriter file =
                        new System.IO.StreamWriter(@"C:\Users\ivans\source\repos\Finale Projek V2.0\Sales_Data.txt", true))
                    {
                        file.WriteLine(output);
                    }
                }
            }
            catch (SqlException error)
            {

               MessageBox.Show(error.Message);
            }
            MessageBox.Show("Sucessfully exported sales data");
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                try
                {
                    listBox2.Items.Clear();
                    con.Open();
                    adapter = new SqlDataAdapter();
                    command = new SqlCommand("SELECT * FROM Transactions", con);
                    ds = new DataSet();
                    adapter.SelectCommand = command;
                    adapter.Fill(ds, "Info");
                    dataGridView1.DataSource = ds;
                    dataGridView1.DataMember = "Info";
                    con.Close();
                }
                catch (SqlException error)
                {

                    MessageBox.Show(error.Message);
                }
                string sale_ID = dataGridView1.SelectedCells[0].Value.ToString();
                string line = "";
                
                try
                {
                    listBox2.Items.Clear();
                    listBox2.Items.Add("Product Bought\tQuantity");
                    con.Open();
                    command = new SqlCommand("SELECT * FROM Product_Transaction WHERE Transaction_ID = " + Convert.ToInt32(sale_ID) +"", con);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        line = reader.GetValue(0) + "\t" + reader.GetValue(2);
                        listBox2.Items.Add(line);
                    }
                }
                catch (SqlException error)
                {

                    MessageBox.Show(error.Message);
                }
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                try
                {
                    con.Open();
                    adapter = new SqlDataAdapter();
                    command = new SqlCommand("SELECT * FROM Orders", con);
                    ds = new DataSet();
                    adapter.SelectCommand = command;
                    adapter.Fill(ds, "Info");
                    dataGridView1.DataSource = ds;
                    dataGridView1.DataMember = "Info";
                    con.Close();
                }
                catch (SqlException error)
                {

                    MessageBox.Show(error.Message);
                }
                string order_ID = dataGridView1.SelectedCells[0].Value.ToString();
                string line = "";

                try
                {
                    listBox2.Items.Clear();
                    listBox2.Items.Add("Product Bought\tQuantity");
                    con.Open();
                    command = new SqlCommand("SELECT * FROM Products_Order WHERE Order_ID = " + Convert.ToInt32(order_ID) + "", con);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        line = reader.GetValue(0) + "\t" + reader.GetValue(2);
                        listBox2.Items.Add(line);
                    }
                }
                catch (SqlException error)
                {

                    MessageBox.Show(error.Message);
                }
            }
           
            //customers between 18 and 30
            else if (comboBox1.SelectedIndex == 2)
            {
                con.Open();
                adapter = new SqlDataAdapter();
                command = new SqlCommand("SELECT * FROM Customers WHERE Date_of_Birth BETWEEN '%%/%%/1989' AND '%%/%%/2001'",con);
                ds = new DataSet();
                adapter.SelectCommand = command;
                adapter.Fill(ds, "Info");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "Info";
                con.Close();
            }
            //customers between 30 and 40 
            else if (comboBox1.SelectedIndex == 3)
            {
                con.Open();
                adapter = new SqlDataAdapter();
                command = new SqlCommand("SELECT * FROM Customers WHERE Date_of_Birth BETWEEN '%%/%%/1979' AND '%%/%%/1989'", con);
                ds = new DataSet();
                adapter.SelectCommand = command;
                adapter.Fill(ds, "Info");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "Info";
                con.Close();
            }
            //customers between 40 and 60
            else if (comboBox1.SelectedIndex == 4)
            {
                con.Open();
                adapter = new SqlDataAdapter();
                command = new SqlCommand("SELECT * FROM Customers WHERE Date_of_Birth BETWEEN '%%/%%/1959' AND '%%/%%/1979'", con);
                ds = new DataSet();
                adapter.SelectCommand = command;
                adapter.Fill(ds, "Info");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "Info";
                con.Close();
            }
            //amount of males 
            else
            {
                int total_Male = 0;
                int total_Female = 0;
                try
                {
                    con.Open();
                    command = new SqlCommand("SELECT Gender FROM Customers");
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        string gender = Convert.ToString(reader.GetValue(0));
                        if (gender == "Male")
                        {
                            total_Male += 1;
                        }
                        else
                        {
                            total_Female += 1;
                        }
                    }
                    con.Close();
                }
                catch (SqlException error)
                {

                    MessageBox.Show(error.Message);
                }
                listBox2.Items.Clear();
                listBox2.Items.Add("Total Male Customers: " + total_Male + "\tTotal Female Customers: " + total_Female);
            }
           
        }

        private void BtnExport_Orders_Click(object sender, EventArgs e)
        {
            
            //Hanno maak 'n textfile in folder genoem Order_Data.txt
            //Order_ID  \t  Employee_ID \t Date Placed \t Amount \t Supplier_ID \t Date Received
            try
            {
                con.Open();
                command = new SqlCommand("SELECT * FROM Orders");
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string output = Convert.ToString(reader.GetValue(0)) + "\t" + Convert.ToString(reader.GetValue(1)) + "\t" + Convert.ToString(reader.GetValue(2)) + "\t" + Convert.ToString(reader.GetValue(3)) + "\t" + Convert.ToString(reader.GetValue(4)) + "\t";
                    using (System.IO.StreamWriter file =
                        new System.IO.StreamWriter(@"C:\Users\ivans\source\repos\Finale Projek V2.0\Order_Data.txt", true))
                    {
                        file.WriteLine(output);
                    }
                }
            }
            catch (SqlException error)
            {

                MessageBox.Show(error.Message);
            }
            MessageBox.Show("Sucessfully exported order data");
        }

        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
