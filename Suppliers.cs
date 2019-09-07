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
        public Suppliers()
        {
            InitializeComponent();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            Add_Supplier supp1 = new Add_Supplier();
            supp1.MdiParent = this;
            supp1.Show();
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
