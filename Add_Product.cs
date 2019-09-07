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
    public partial class Add_Product : Form
    {
        SqlConnection con;
        public Add_Product()
        {
            InitializeComponent();
        }

        private void Add_Product_Load(object sender, EventArgs e)
        {
            String cnn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\baren\Source\Repos\ivansnyman\Finale-Projek-V2.0\Supplement_Database.mdf;Integrated Security=True";
            con = new SqlConnection(cnn);
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            con.Open();
            int sellPrice, paidPrice, supplierID, quintity;
            string productName, manufacturer, dateReceived;

            productName = txtName.Text;
            manufacturer = txtManufacturer.Text;
            dateReceived = txtDate.Text;

            sellPrice = int.Parse(txtSellPrice.Text);
            paidPrice = int.Parse(txtPricePaid.Text);
            supplierID = int.Parse(txtSupplierId.Text);
            quintity = int.Parse(txtQuantity.Text);

            String insertQuery = "INSERT INTO  Products VALUES('" + sellPrice + "','" + manufacturer+ "','" + productName + "','" + sellPrice + "','" + paidPrice + "','" + supplierID + "','" + quintity + "')";

            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand(insertQuery,con);
            cmd.ExecuteNonQuery();

            con.Close();

            MessageBox.Show("Successfully added product");
        }
    }
}
