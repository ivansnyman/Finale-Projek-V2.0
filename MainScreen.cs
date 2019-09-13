using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Finale_Projek_V2._0
{
    public partial class MainScreen : Form
    {
        public MainScreen(string employeeID)
        {
            InitializeComponent();
            tbxEmployee.Text = employeeID;
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            tbxGlobal.Text = tbxEmployee.Text;
            Sales frmSales = new Sales(tbxGlobal.Text);
            
            frmSales.ShowDialog();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Customers frmCustomers = new Customers();
            frmCustomers.ShowDialog();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Products frmProducts = new Products();
            frmProducts.ShowDialog();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Order frmOrders = new Order();
            frmOrders.ShowDialog();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            Suppliers frmSuppliers = new Suppliers();
            frmSuppliers.ShowDialog();
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            Employees frmEmployees = new Employees();
            frmEmployees.ShowDialog();
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            
           
        }

        private void MainScreen_Load(object sender, EventArgs e)
        {

        }
    }
}
