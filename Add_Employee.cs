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
    public partial class Add_Employee : Form
    {
        public string fName, lName, email, phoneNumber, password;
        public int employeeID;
        public Add_Employee()
        {
            InitializeComponent();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            fName = tbxFirst.Text;
            lName = tbxLast.Text;
            phoneNumber = tbxPhone.Text;
            email = tbxEmail.Text;
            password = tbxPassword.Text;
            if (password.Length > 20)
            {
                MessageBox.Show("Password cannot exceed 20 characters, please enter a new password.");
            }
            password = tbxPassword.Text;
            this.Close();
        }
    }
}
