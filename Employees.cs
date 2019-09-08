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
            SqlCommand getID = new SqlCommand("Select Employee_ID FROM Employees");
            reader = getID.ExecuteReader();
            while (reader.Read())
            {
                empID += 1;
            }

                try
            {
                con.Open();
                cmd = new SqlCommand(@"INSERT INTO Employees Values('" + empID + "'," + first + "'," + last + "'," + phone + "'," + email + "'," + password +"')",con);
                adap = new SqlDataAdapter();
                adap.InsertCommand = cmd;
                adap.InsertCommand.ExecuteNonQuery();
                MessageBox.Show("Record inserted successfully");
                con.Close();
                
            }
            catch(SqlException error)
            {
                MessageBox.Show(error.Message);
            }
           
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            con.Open();
            display();
            con.Close();
        }
        private void display()
        {
            string selectquery = "SELECT * FROM Employees";
            cmd = new SqlCommand(selectquery, con);
            DataSet ds = new DataSet();
            adap = new SqlDataAdapter();
            adap.SelectCommand = cmd;
            adap.Fill(ds, "Employees");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Employees";
            cmd.ExecuteNonQuery();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            con.Open();
            string sql = @"DELETE FROM Employees WHERE Employee_ID = '" + textBox2.Text + "'";
            SqlDataAdapter adap = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand(sql, con);
            DataSet ds = new DataSet();
            adap.DeleteCommand = cmd;
            adap.DeleteCommand.ExecuteNonQuery();

            display();

            con.Close();
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            con.Open();
            string query = @"SELECT * from Employees WHERE First_Name LIKE '%" + textBox1.Text + "%' OR Last_Name LIKE '%" + textBox1.Text + "%'";
            SqlDataAdapter adap = new SqlDataAdapter(query, con);
            DataSet ds = new DataSet();
            adap.Fill(ds, "Employees");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Employees";
            con.Close();
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {
            con.Open();
            string query = @"SELECT * from Employees WHERE First_Name LIKE '%" + textBox2.Text + "%'";
            SqlDataAdapter adap = new SqlDataAdapter(query, con);
            DataSet ds = new DataSet();
            adap.Fill(ds, "Employees");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Employees";
            con.Close();
        }

        private void BtnChange_Click(object sender, EventArgs e)
        {

        }

        private void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Employees_Load(object sender, EventArgs e)
        {
            display();
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            int index = comboBox1.SelectedIndex;
            string id = dataGridView1.SelectedCells[0].Value.ToString();
            string insertQuery;

            if (index == 0)
            {
                insertQuery = @"UPDATE Employees SET First_Name = '" + tbxValue.Text + "' WHERE Employee_ID = '" + id + "'";
            }
            else if (index == 1)
            {
                insertQuery = @"UPDATE Employees SET Last_Name = '" + tbxValue.Text + "' WHERE Employee_ID = '" + id + "'";
            }
            else if (index == 2)
            {
                insertQuery = @"UPDATE Employees SET Phone_Number = '" + int.Parse(tbxValue.Text) + "' WHERE Employee_ID = '" + id + "'";
            }
            else if (index == 3)
            {
                insertQuery = @"UPDATE Employees SET Email = '" + int.Parse(tbxValue.Text) + "' WHERE Employee_ID = '" + id + "'";
            }
            else
            {
                insertQuery = @"UPDATE Employees SET Password = '" + int.Parse(tbxValue.Text) + "' WHERE Employee_ID = '" + id + "'";
            }
            

            con.Open();


            adap = new SqlDataAdapter();
            cmd = new SqlCommand(insertQuery, con);
            cmd.CommandText = insertQuery;

            cmd.ExecuteNonQuery();
            display();

            con.Close();
        }
    }
}
