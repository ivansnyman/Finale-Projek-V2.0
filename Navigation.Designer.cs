namespace Finale_Projek_V2._0
{
    partial class Navigation
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnProducts = new System.Windows.Forms.Button();
            this.btnCustomers = new System.Windows.Forms.Button();
            this.btnEmployees = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.btnSuppliers = new System.Windows.Forms.Button();
            this.btnSales = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnProducts
            // 
            this.btnProducts.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProducts.Location = new System.Drawing.Point(34, 67);
            this.btnProducts.Name = "btnProducts";
            this.btnProducts.Size = new System.Drawing.Size(158, 39);
            this.btnProducts.TabIndex = 0;
            this.btnProducts.Text = "Manage Products";
            this.btnProducts.UseVisualStyleBackColor = true;
            // 
            // btnCustomers
            // 
            this.btnCustomers.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCustomers.Location = new System.Drawing.Point(234, 67);
            this.btnCustomers.Name = "btnCustomers";
            this.btnCustomers.Size = new System.Drawing.Size(158, 39);
            this.btnCustomers.TabIndex = 1;
            this.btnCustomers.Text = "Manage Customers";
            this.btnCustomers.UseVisualStyleBackColor = true;
            // 
            // btnEmployees
            // 
            this.btnEmployees.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmployees.Location = new System.Drawing.Point(416, 67);
            this.btnEmployees.Name = "btnEmployees";
            this.btnEmployees.Size = new System.Drawing.Size(158, 39);
            this.btnEmployees.TabIndex = 2;
            this.btnEmployees.Text = "Manage Employees";
            this.btnEmployees.UseVisualStyleBackColor = true;
            // 
            // btnReport
            // 
            this.btnReport.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReport.Location = new System.Drawing.Point(34, 136);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(158, 39);
            this.btnReport.TabIndex = 3;
            this.btnReport.Text = "Reporting";
            this.btnReport.UseVisualStyleBackColor = true;
            // 
            // btnSuppliers
            // 
            this.btnSuppliers.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSuppliers.Location = new System.Drawing.Point(234, 136);
            this.btnSuppliers.Name = "btnSuppliers";
            this.btnSuppliers.Size = new System.Drawing.Size(158, 39);
            this.btnSuppliers.TabIndex = 4;
            this.btnSuppliers.Text = "Manage Suppliers";
            this.btnSuppliers.UseVisualStyleBackColor = true;
            // 
            // btnSales
            // 
            this.btnSales.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSales.Location = new System.Drawing.Point(416, 136);
            this.btnSales.Name = "btnSales";
            this.btnSales.Size = new System.Drawing.Size(158, 39);
            this.btnSales.TabIndex = 5;
            this.btnSales.Text = "Sales";
            this.btnSales.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(251, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 27);
            this.label1.TabIndex = 6;
            this.label1.Text = "Navigation";
            // 
            // Navigation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 238);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSales);
            this.Controls.Add(this.btnSuppliers);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.btnEmployees);
            this.Controls.Add(this.btnCustomers);
            this.Controls.Add(this.btnProducts);
            this.Name = "Navigation";
            this.Text = "Navigation";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnProducts;
        private System.Windows.Forms.Button btnCustomers;
        private System.Windows.Forms.Button btnEmployees;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Button btnSuppliers;
        private System.Windows.Forms.Button btnSales;
        private System.Windows.Forms.Label label1;
    }
}