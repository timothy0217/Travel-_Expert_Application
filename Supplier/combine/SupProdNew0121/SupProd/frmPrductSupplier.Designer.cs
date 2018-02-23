namespace SupProd
{
    partial class frmPrductSupplier
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblSupplier = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSupplierSearch = new System.Windows.Forms.TextBox();
            this.lstSuppliers = new System.Windows.Forms.ListBox();
            this.lstProducts = new System.Windows.Forms.ListBox();
            this.txtProductSearch = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.cklstProductSupplier = new System.Windows.Forms.CheckedListBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblSave = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.dgvCurrentProSupplier = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCurrentProSupplier)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(207)))), ((int)(((byte)(212)))));
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lblSupplier);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtSupplierSearch);
            this.panel1.Controls.Add(this.lstSuppliers);
            this.panel1.Controls.Add(this.lstProducts);
            this.panel1.Controls.Add(this.txtProductSearch);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnUpdate);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(754, 576);
            this.panel1.TabIndex = 2;
            // 
            // lblSupplier
            // 
            this.lblSupplier.AutoSize = true;
            this.lblSupplier.Location = new System.Drawing.Point(304, 213);
            this.lblSupplier.Name = "lblSupplier";
            this.lblSupplier.Size = new System.Drawing.Size(0, 13);
            this.lblSupplier.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 212);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 9;
            // 
            // txtSupplierSearch
            // 
            this.txtSupplierSearch.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSupplierSearch.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.txtSupplierSearch.Location = new System.Drawing.Point(298, 184);
            this.txtSupplierSearch.Name = "txtSupplierSearch";
            this.txtSupplierSearch.Size = new System.Drawing.Size(220, 22);
            this.txtSupplierSearch.TabIndex = 8;
            this.txtSupplierSearch.Text = "Search Suppliers";
            this.txtSupplierSearch.Click += new System.EventHandler(this.txtSupplierSearch_Click);
            this.txtSupplierSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSupplierSearch_KeyUp);
            // 
            // lstSuppliers
            // 
            this.lstSuppliers.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstSuppliers.FormattingEnabled = true;
            this.lstSuppliers.ItemHeight = 14;
            this.lstSuppliers.Location = new System.Drawing.Point(298, 231);
            this.lstSuppliers.Name = "lstSuppliers";
            this.lstSuppliers.Size = new System.Drawing.Size(225, 116);
            this.lstSuppliers.TabIndex = 7;
            this.lstSuppliers.SelectedIndexChanged += new System.EventHandler(this.lstSuppliers_SelectedIndexChanged);
            // 
            // lstProducts
            // 
            this.lstProducts.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstProducts.FormattingEnabled = true;
            this.lstProducts.ItemHeight = 14;
            this.lstProducts.Location = new System.Drawing.Point(42, 231);
            this.lstProducts.Name = "lstProducts";
            this.lstProducts.Size = new System.Drawing.Size(211, 116);
            this.lstProducts.TabIndex = 6;
            // 
            // txtProductSearch
            // 
            this.txtProductSearch.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductSearch.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.txtProductSearch.Location = new System.Drawing.Point(42, 184);
            this.txtProductSearch.Name = "txtProductSearch";
            this.txtProductSearch.Size = new System.Drawing.Size(211, 22);
            this.txtProductSearch.TabIndex = 5;
            this.txtProductSearch.Text = "Search Products";
            this.txtProductSearch.Click += new System.EventHandler(this.txtProductSearch_Click);
            this.txtProductSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtProductSearch_KeyUp);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(160)))), ((int)(((byte)(133)))));
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(228)))), ((int)(((byte)(212)))));
            this.btnDelete.Location = new System.Drawing.Point(549, 212);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(158, 42);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(160)))), ((int)(((byte)(133)))));
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(228)))), ((int)(((byte)(212)))));
            this.btnUpdate.Location = new System.Drawing.Point(549, 259);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(158, 42);
            this.btnUpdate.TabIndex = 3;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(160)))), ((int)(((byte)(133)))));
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(228)))), ((int)(((byte)(212)))));
            this.btnAdd.Location = new System.Drawing.Point(549, 306);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(158, 42);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // cklstProductSupplier
            // 
            this.cklstProductSupplier.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cklstProductSupplier.FormattingEnabled = true;
            this.cklstProductSupplier.Location = new System.Drawing.Point(463, 144);
            this.cklstProductSupplier.Name = "cklstProductSupplier";
            this.cklstProductSupplier.Size = new System.Drawing.Size(255, 184);
            this.cklstProductSupplier.TabIndex = 3;
            this.cklstProductSupplier.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.cklstProductSupplier_ItemCheck);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(160)))), ((int)(((byte)(133)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(228)))), ((int)(((byte)(212)))));
            this.btnSave.Location = new System.Drawing.Point(399, 354);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(158, 42);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(207)))), ((int)(((byte)(212)))));
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.lblSave);
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Controls.Add(this.dgvCurrentProSupplier);
            this.panel2.Controls.Add(this.cklstProductSupplier);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(754, 576);
            this.panel2.TabIndex = 5;
            // 
            // lblSave
            // 
            this.lblSave.AutoSize = true;
            this.lblSave.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSave.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.lblSave.Location = new System.Drawing.Point(35, 118);
            this.lblSave.Name = "lblSave";
            this.lblSave.Size = new System.Drawing.Size(47, 16);
            this.lblSave.TabIndex = 6;
            this.lblSave.Text = "label1";
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(160)))), ((int)(((byte)(133)))));
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(228)))), ((int)(((byte)(212)))));
            this.btnCancel.Location = new System.Drawing.Point(563, 354);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(155, 42);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // dgvCurrentProSupplier
            // 
            this.dgvCurrentProSupplier.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvCurrentProSupplier.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCurrentProSupplier.Location = new System.Drawing.Point(35, 144);
            this.dgvCurrentProSupplier.Name = "dgvCurrentProSupplier";
            this.dgvCurrentProSupplier.ReadOnly = true;
            this.dgvCurrentProSupplier.Size = new System.Drawing.Size(409, 184);
            this.dgvCurrentProSupplier.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(35, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(397, 44);
            this.label2.TabIndex = 11;
            this.label2.Text = "Supplier and Product";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(35, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(397, 44);
            this.label3.TabIndex = 12;
            this.label3.Text = "Supplier and Product";
            // 
            // frmPrductSupplier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 537);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmPrductSupplier";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCurrentProSupplier)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.CheckedListBox cklstProductSupplier;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvCurrentProSupplier;
        private System.Windows.Forms.TextBox txtProductSearch;
        private System.Windows.Forms.Label lblSave;
        private System.Windows.Forms.TextBox txtSupplierSearch;
        private System.Windows.Forms.ListBox lstSuppliers;
        private System.Windows.Forms.ListBox lstProducts;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblSupplier;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

