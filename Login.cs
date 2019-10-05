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
using System.IO;

namespace Finale_Projek_V2._0
{
    public partial class Login : Form
    {
        SqlConnection con;
        
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            String cnn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\baren\Source\Repos\ivansnyman\Finale-Projek-V2.0\Supplement_Database.mdf;Integrated Security=True";
            con = new SqlConnection(cnn);
        }

        private void Button1_Click(object sender, EventArgs e)
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
                MainScreen mainScreen = new MainScreen(tbxID.Text);
                SqlDataReader dataReader;
                con.Open();
                cmd = new SqlCommand("Select Employee_ID, Password FROM Employees", con);
                dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    int currID = Convert.ToInt32(dataReader.GetValue(0));
                    string currPass = Convert.ToString(dataReader.GetValue(1));
                    if ((empID == currID) && (password == currPass))
                    {
                        mainScreen.ShowDialog();
                    }
                }
                con.Close();
                MessageBox.Show("Incorrect Employee ID OR Password, please try again");
            }
        }
    }
}
