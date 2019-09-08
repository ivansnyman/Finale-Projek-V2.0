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
    public partial class Add_Supplier : Form
    {
        public string phone, email, website, name;
        public int suppID;
        SqlConnection con;
        public Add_Supplier()
        {
            InitializeComponent();
        }

        private void Add_Supplier_Load(object sender, EventArgs e)
        {
            String cnn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Gerhard\Source\Repos\ivansnyman\Finale-Projek-V2.0\Supplement_Database.mdf;Integrated Security=True";
            con = new SqlConnection(cnn);
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            phone = tbxPhone.Text;
            email = tbxEmail.Text;
            website = tbxWebsite.Text;
            name = tbxName.Text;
            con.Open();

            String insertQuery = "INSERT INTO  Suppliers VALUES('" + phone + "','" + email + "','" + website + "','" + name + "')";

            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand(insertQuery, con);
            cmd.ExecuteNonQuery();

            con.Close();

            MessageBox.Show("Successfully added Supplier");
            this.Close();
            
        }
    }
}
