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
    public partial class AddCustomer : Form
    {
        SqlConnection con;

        public AddCustomer()
        {
            InitializeComponent();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            con.Open();
            int phone;
            string fName, Lname, email,gender, dob;
            
            phone = int.Parse(tbxPhone.Text);
            fName = tbxFname.Text;
            Lname = tbxLname.Text;
            email = tbxEmail.Text;
            dob = txbdob.Text;

            if (radioButton1.Checked)
                gender = "Male";
            else if (radioButton2.Checked)
                gender = "Female";
            else
                gender = "";
             

            String insertQuery = "INSERT INTO  Customers VALUES('" + fName + "','" + Lname + "','" + phone + "','" + email + "','" + gender + "','" + dob + "')";

            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand(insertQuery, con);
            cmd.ExecuteNonQuery();

            con.Close();

            MessageBox.Show("Successfully added product");

        }

        private void AddCustomer_Load(object sender, EventArgs e)
        {
            String cnn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Gerhard\Source\Repos\ivansnyman\Finale-Projek-V2.0\Supplement_Database.mdf;Integrated Security=True";
            con = new SqlConnection(cnn);

        }
    }
}
