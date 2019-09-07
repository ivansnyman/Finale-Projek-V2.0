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
    public partial class Login : Form
    {
        public String constr = @"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\ivans\\Source\\Repos\\ivansnyman\\Finale-Projek-V2.0\\Supplement_Database.mdf;Integrated Security=True";
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dataReader;
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            int empID = Convert.ToInt32(tbxID.Text);
            string password = tbxPass.Text;
            MainScreen mainScreen = new MainScreen();
            con = new SqlConnection(constr);
            con.Open();
            cmd = new SqlCommand("Select Employee_ID, Password",con);
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
