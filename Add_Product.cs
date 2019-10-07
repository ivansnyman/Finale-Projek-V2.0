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
            String cnn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Gerhard\Source\Repos\ivansnyman\Finale-Projek-V2.0\Supplement_Database.mdf;Integrated Security=True";
            con = new SqlConnection(cnn);
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "")
                MessageBox.Show("Please enter product name");
            else if (txtManufacturer.Text == "")
                MessageBox.Show("Please enter Product manufacturer");
            else if (txtSellPrice.Text == "")
                MessageBox.Show("Please enter product selling price");
            else if (txtPricePaid.Text == "")
                MessageBox.Show("Please enter product paid price");
            else if (txtDate.Text == "")
                MessageBox.Show("Please enter date received");
            else if (txtSupplierId.Text == "")
                MessageBox.Show("Please enter supplier ID");
            else if (txtQuantity.Text == "")
                MessageBox.Show("Please enter quintity");
            else if (!(int.TryParse(txtSellPrice.Text, out int myInt)))
            {
                MessageBox.Show("Please enter a valid price sold");
            }
            else if (!(int.TryParse(txtPricePaid.Text, out int myIn)))
            {
                MessageBox.Show("Please enter a valid price paid");
            }
            else if (!(int.TryParse(txtQuantity.Text, out int myI)))
            {
                MessageBox.Show("Please enter a valid Quintity");
            }




            else
            {
                con.Open();
                int supplierID, quintity;
                string productName, manufacturer, dateReceived;
                double sellPrice, paidPrice;

                productName = txtName.Text;
                manufacturer = txtManufacturer.Text;
                dateReceived = txtDate.Text;

                sellPrice = Convert.ToDouble(txtSellPrice.Text);
                paidPrice = Convert.ToDouble(txtPricePaid.Text);
                supplierID = int.Parse(txtSupplierId.Text);
                quintity = int.Parse(txtQuantity.Text);

                String insertQuery = "INSERT INTO  Products VALUES('" + manufacturer + "','" + productName + "','" + sellPrice + "','" + paidPrice + "','" + supplierID + "','" + quintity + "')";

                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand(insertQuery, con);
                cmd.ExecuteNonQuery();

                con.Close();

                MessageBox.Show("Successfully added product");
            }
        }
    }
}
