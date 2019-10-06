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
    public partial class ConfirmLogin : Form
    {
        public bool isTrue = false;
        SqlConnection con;
        public ConfirmLogin()
        {
            InitializeComponent();
        }
        public String employeeID { get; set; }
        public String transactionID { get; set; }

        public String orderID { get; set; }

        private void ConfirmLogin_Load(object sender, EventArgs e)
        {
            String cnn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Gerhard\Source\Repos\ivansnyman\Finale-Projek-V2.0\Supplement_Database.mdf;Integrated Security=True";
            con = new SqlConnection(cnn);
        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            
            if (tbxID.Text == "")
            {
                MessageBox.Show("Please enter employee ID");
            }
            else if (tbxPass.Text == "")
            {
                MessageBox.Show("Please enter employee Password");
            }
            else
            {
                SqlCommand cmd;
                int empID = Convert.ToInt32(tbxID.Text);
                string password = tbxPass.Text;
                SqlDataReader dataReader;
                con.Open();
                cmd = new SqlCommand("Select Employee_ID, Password FROM Employees", con);
                dataReader = cmd.ExecuteReader();
                while ((dataReader.Read())&&(isTrue==false))
                {
                    int currID = Convert.ToInt32(dataReader.GetValue(0));
                    string currPass = Convert.ToString(dataReader.GetValue(1));
                    if ((empID == currID) && (password == currPass))
                    {
                        MessageBox.Show("Login details confirmed.");
                        isTrue = true;
                        employeeID = tbxID.Text;
                        transactionID = System.IO.File.ReadAllText(@"C:\Users\Gerhard\source\repos\ivansnyman\Finale-Projek-V2.0\Transaction_ID.txt");
                        orderID = System.IO.File.ReadAllText(@"C:\Users\Gerhard\source\repos\ivansnyman\Finale-Projek-V2.0\Order_ID.txt");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Incorrect ID/Password, please try again.");
                    }
                }
                con.Close();
            }
        }
    }
}
