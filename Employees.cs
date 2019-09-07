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
    public partial class Employees : Form
    {
        SqlConnection con;
        public String constr = @"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\baren\\Source\\Repos\\ivansnyman\\Finale-Projek-V2.0\\Supplement_Database.mdf;Integrated Security=True";
        SqlCommand cmd;
        SqlDataAdapter adap;
        SqlDataReader reader;
        
        public Employees()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Add_Employee frmAddEmployee = new Add_Employee();
            frmAddEmployee.ShowDialog();
            string first = frmAddEmployee.fName;
            string last = frmAddEmployee.lName;
            string phone = frmAddEmployee.phoneNumber;
            string email = frmAddEmployee.email;
            string password = frmAddEmployee.password;
            int empID = 0;
            SqlCommand getID = new SqlCommand("Select Employee_ID from Supplment_Database");
            reader = getID.ExecuteReader();
            while (reader.Read())
            {
                empID += 1;
            }

                try
            {
                con.Open();
                cmd = new SqlCommand(@"INSERT INTO Supplement_Database Values('" + empID + "'," + first + "'," + last + "'," + phone + "'," + email + "'," + password +"')",con);
                adap = new SqlDataAdapter();
                adap.InsertCommand = cmd;
                adap.InsertCommand.ExecuteNonQuery();
                MessageBox.Show("Message inserted successfully");
                con.Close();
                
            }
            catch(SqlException error)
            {
                MessageBox.Show(error.Message);
            }

        }
    }
}
