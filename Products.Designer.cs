namespace Finale_Projek_V2._0
{
    partial class Products
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnChangeProd = new System.Windows.Forms.Button();
            this.btnRemoveProd = new System.Windows.Forms.Button();
            this.btnAddProd = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(571, 426);
            this.dataGridView1.TabIndex = 0;
            // 
            // btnChangeProd
            // 
            this.btnChangeProd.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangeProd.Location = new System.Drawing.Point(597, 186);
            this.btnChangeProd.Name = "btnChangeProd";
            this.btnChangeProd.Size = new System.Drawing.Size(181, 33);
            this.btnChangeProd.TabIndex = 8;
            this.btnChangeProd.Text = "Change Product";
            this.btnChangeProd.UseVisualStyleBackColor = true;
            // 
            // btnRemoveProd
            // 
            this.btnRemoveProd.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveProd.Location = new System.Drawing.Point(597, 132);
            this.btnRemoveProd.Name = "btnRemoveProd";
            this.btnRemoveProd.Size = new System.Drawing.Size(182, 34);
            this.btnRemoveProd.TabIndex = 7;
            this.btnRemoveProd.Text = "Remove Product";
            this.btnRemoveProd.UseVisualStyleBackColor = true;
            // 
            // btnAddProd
            // 
            this.btnAddProd.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddProd.Location = new System.Drawing.Point(597, 76);
            this.btnAddProd.Name = "btnAddProd";
            this.btnAddProd.Size = new System.Drawing.Size(181, 32);
            this.btnAddProd.TabIndex = 6;
            this.btnAddProd.Text = "Add Product";
            this.btnAddProd.UseVisualStyleBackColor = true;
            // 
            // btnView
            // 
            this.btnView.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnView.Location = new System.Drawing.Point(598, 23);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(181, 32);
            this.btnView.TabIndex = 5;
            this.btnView.Text = "View all";
            this.btnView.UseVisualStyleBackColor = true;
            // 
            // Products
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnChangeProd);
            this.Controls.Add(this.btnRemoveProd);
            this.Controls.Add(this.btnAddProd);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Products";
            this.Text = "Products";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnChangeProd;
        private System.Windows.Forms.Button btnRemoveProd;
        private System.Windows.Forms.Button btnAddProd;
        private System.Windows.Forms.Button btnView;
    }
}