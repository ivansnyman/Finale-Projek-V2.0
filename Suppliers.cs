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
    public partial class Suppliers : Form
    {

        SqlConnection con;
        public String constr = @"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Gerhard\\Source\\Repos\\ivansnyman\\Finale-Projek-V2.0\\Supplement_Database.mdf;Integrated Security=True";
        SqlCommand cmd;
        SqlDataAdapter adap;
        public Suppliers()
        {
            InitializeComponent();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            Add_Supplier frmAddSupplier = new Add_Supplier();
            frmAddSupplier.ShowDialog();
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

        private void display()
        {
            string selectquery = "SELECT * FROM Suppliers";
            SqlCommand cmd = new SqlCommand(selectquery, con);
            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            adapter.Fill(ds, "Suppliers");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Suppliers";
            cmd.ExecuteNonQuery();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            con.Open();
            string sql = @"DELETE FROM Suppliers WHERE Supplier_ID = '" + textBox2.Text + "'";
            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand(sql, con);
            DataSet ds = new DataSet();
            adapter.DeleteCommand = cmd;
            adapter.DeleteCommand.ExecuteNonQuery();

            display();

            con.Close();
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            con.Open();
            string query = @"SELECT * from Suppliers WHERE Supplier_Name LIKE '%" + textBox1.Text + "%'";
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Suppliers");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Suppliers";
            con.Close();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            int index = comboBox1.SelectedIndex;
            string id = dataGridView1.SelectedCells[0].Value.ToString();
            string insertQuery;

            if (index == 0)
            {
                insertQuery = @"UPDATE Suppliers SET Phone_Number = '" + textBox7.Text + "' WHERE Supplier_ID = '" + id + "'";
            }
            else if (index == 1)
            {
                insertQuery = @"UPDATE Suppliers SET Email = '" + textBox7.Text + "' WHERE Supplier_ID = '" + id + "'";
            }
            else if (index == 2)
            {
                insertQuery = @"UPDATE Suppliers SET Website = '" + textBox7.Text + "' WHERE Supplier_ID = '" + id + "'";
            }
            else
            {
                insertQuery = @"UPDATE Suppliers SET Supplier_Name = '" + textBox7.Text + "' WHERE Supplier_ID = '" + id + "'";
            }

            con.Open();


            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand(insertQuery, con);
            cmd.CommandText = insertQuery;

            cmd.ExecuteNonQuery();
            display();

            con.Close();
        }

        private void TextBox5_TextChanged(object sender, EventArgs e)
        {
            con.Open();
            string query = @"SELECT * from Suppliers WHERE Supplier_Name LIKE '%" + textBox5.Text + "%'OR Supplier_ID LIKE '%" + textBox5.Text + "%'";
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Suppliers");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Suppliers";
            con.Close();
        }
    }
}
