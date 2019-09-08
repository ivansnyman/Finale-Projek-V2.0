using System;
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
    public partial class Suppliers : Form
    {

        SqlConnection con;
        public String constr = @"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\baren\\Source\\Repos\\ivansnyman\\Finale-Projek-V2.0\\Supplement_Database.mdf;Integrated Security=True";
        SqlCommand cmd;
        SqlDataAdapter adap;
        SqlDataReader reader;
        public Suppliers()
        {
            InitializeComponent();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            Add_Supplier frmAddSupplier = new Add_Supplier();
            frmAddSupplier.ShowDialog();
            string phone = frmAddSupplier.phone;
            string email = frmAddSupplier.email;
            string webiste = frmAddSupplier.website;
            string name = frmAddSupplier.name;
            int suppID = 0;
            SqlCommand getID = new SqlCommand("Select Supplier_ID FROM Suppliers");
            reader = getID.ExecuteReader();
            while (reader.Read())
            {
                suppID += 1;
            }

            try
            {
                con.Open();
                cmd = new SqlCommand(@"INSERT INTO Suppliers Values('" + suppID + "'," + phone + "'," + email + "'," + webiste + "'," + name + "')", con);
                adap = new SqlDataAdapter();
                adap.InsertCommand = cmd;
                adap.InsertCommand.ExecuteNonQuery();
                MessageBox.Show("Record inserted successfully");
                con.Close();

            }
            catch (SqlException error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Gerhard\\Source\\Repos\\ivansnyman\\Finale-Projek-V2.0\\Supplement_Database.mdf;Integrated Security=True");

            con.Open();
            String sql;
            sql = "Select * From Suppliers";
            SqlCommand command;
            SqlDataReader reader;
            SqlDataAdapter adapter = new SqlDataAdapter();
            command = new SqlCommand(sql, con);
            adapter.SelectCommand = command;

            DataSet ds = new DataSet();
            adapter.Fill(ds, "Suppliers");

            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Suppliers";

            reader = command.ExecuteReader();

            con.Close();
        }
    }
}
