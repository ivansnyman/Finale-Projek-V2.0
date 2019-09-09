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
    public partial class Add_Employee : Form
    {
        SqlConnection con;
        public String constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Gerhard\Source\Repos\ivansnyman\Finale-Projek-V2.0\Supplement_Database.mdf;Integrated Security=True";
        SqlCommand cmd;


        private void Add_Employee_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(constr);
        }

        public int employeeID;
        public Add_Employee()
        {
            InitializeComponent();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            con.Open();
            string fName = tbxFirst.Text;
            string lName = tbxLast.Text;
            string phoneNumber = tbxPhone.Text;
            string email = tbxEmail.Text;
            string password = tbxPassword.Text;
            cmd = new SqlCommand(@"INSERT INTO Employees Values('" + fName + "','" + lName + "','" + phoneNumber + "','" + email + "','" + password + "')", con);
            cmd.ExecuteNonQuery();

            con.Close();

            MessageBox.Show("Successfully added employee");
        }
    }
}
