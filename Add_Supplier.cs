﻿using System;
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
        public Add_Supplier()
        {
            InitializeComponent();
        }

        private void Add_Supplier_Load(object sender, EventArgs e)
        {

        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            phone = tbxPhone.Text;
            email = tbxEmail.Text;
            website = tbxWebsite.Text;
            name = tbxName.Text;
            this.Close();
        }
    }
}