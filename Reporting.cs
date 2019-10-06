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
        private void Reporting_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Gerhard\Source\Repos\ivansnyman\Finale-Projek-V2.0\Supplement_Database.mdf;Integrated Security=True");
            //Uitfigure watse maand dit is en dan deur dit gaan met 'n loop vir die maand se sales
            string date = DateTime.Today.ToShortDateString(); // DD/MM/YYYY
            string date_Search = date.Substring(4, 10); // MM/YYYY
            int count = 0;
            double income = 0;
            try
            {
                con.Open();
                command = new SqlCommand("SELECT * FROM Transactions WHERE Date_of_Transaction LIKE '%%" + date_Search + "'", con); // '%%/MM/YYYY'
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
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            string order_ID = listBox1.SelectedIndex.ToString();
            var fromAddress = new MailAddress("randburgstrengthandfitness@gmail.com", "Randburg Strength & Fitness");
            var toAddress = new MailAddress("Barendjohannesvanderwalt1998@gmail.com", "Hanno");
            const string fromPassword = "kameelperdkalmeerpil";
            const string subject = "Late Order Enquiry";
            string body = "Hi, \nOur company Randburg Strength & Fitness placed and order that has not yet been received\nOrder Number: "+ order_ID + "." + "\nCould you please give us some feedback and call us on 0728644173\nKind Regards";

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
    }
}
