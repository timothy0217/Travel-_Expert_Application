using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace supSupplier
{ /**Purpose:provide interface to let user to add,edit and delete product record
 * Name:sabrina gomes
 * Date:JAn 18.2018
 * 
 * */
    public partial class Form3 : Form
    {
        public string OperationSign = null;//make sure oeration action "save,update,delete"
       // public ProductSupplier selectedprosupplier;//an object of prodcutsupplier class ,this variable is for storage specific row got from top grid by focuse event
       // public List<Product> Products = new List<Product>();
        public List<Supplier> Suppliers = new List<Supplier>();//Suppliers is used to store all of suppliers queried from SUPPLIERS TABLE
        public Supplier oldsupplier;

        public Form3()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //initiallize 
            Suppliers =SupplierDB.GetAllsuppliers();//get all of products from PRODUCTS TABLE
            //allPS = ProSu;//copy ProSu to allPS
            dgvProductSupplier.SelectionMode = DataGridViewSelectionMode.FullRowSelect;//dgc select full roll
            dgvProductSupplier.DataSource = Suppliers;//display all of products and corresponding suppliers  get from PRODUCTS_SUPPLIERS TABLE
            txtPName.Visible = false;
            lblSave.Visible = false;
            lblPName.Visible = false;
            btnSave.Visible = false;
            btnCancel.Visible = false;


        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            lblSave.Text = "Add";
            OperationSign = "Add";
            txtPName.Visible = true;
            lblSave.Visible = true;
            lblPName.Visible = true;
            btnSave.Visible = true;
            btnCancel.Visible = true;
            

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (OperationSign == "Add")
            {   if (txtPName.Text != "")
                {
                    Supplier supplierIstance = new Supplier();
                    supplierIstance.SupName = txtPName.Text;
                    //ProductDB.AddProduct(productIstance);
                    int supplierid = SupplierDB.GetSupplierId();
                    SupplierDB.AddSupplier(supplierid, txtPName.Text);
                    Suppliers = SupplierDB.GetAllsuppliers();
                    dgvProductSupplier.DataSource = Suppliers;

                    MessageBox.Show("Success!");
                    txtPName.Text = "";
                    txtPName.Visible = false;
                    lblSave.Visible = false;
                    lblPName.Visible = false;
                    btnSave.Visible = false;
                    btnCancel.Visible = false;
                }
                else
                {
                    MessageBox.Show("Supplier Name can not be empty!");
                }
            }
            else if (OperationSign == "Update")// when confim button click, and OperationSign = update, update the data
            {
                // Product updateProduct = (Product)dgvProductSupplier.Rows[dgvProductSupplier.CurrentRow.Index].DataBoundItem;
                Supplier oldSupplier = (Supplier)dgvProductSupplier.Rows[dgvProductSupplier.CurrentRow.Index].DataBoundItem;

                //   updateProduct.ProdName = txtPName.Text;
                Supplier updateSupplier = new Supplier();
                updateSupplier.SupName = txtPName.Text;
                //MessageBox.Show(oldProduct.ProdName.ToString());
                //SupplierDB.UpdateProduct(oldSupplier, updateSupplier);
                SupplierDB.UpdateSupplier(oldSupplier, updateSupplier);
                Suppliers = SupplierDB.GetAllsuppliers();
                dgvProductSupplier.DataSource = Suppliers;

                MessageBox.Show("Success!");
                txtPName.Text = "";
                txtPName.Visible = false;
                lblSave.Visible = false;
                lblPName.Visible = false;
                btnSave.Visible = false;
                btnCancel.Visible = false;


            }
            else if (OperationSign == "Delete") // when confim button click, and OperationSign = delete, delete the data
            {
                string errorReference = "";
                Supplier deleteSupplier = (Supplier)dgvProductSupplier.Rows[dgvProductSupplier.CurrentRow.Index].DataBoundItem;
                if (SupplierDB.referenceCheck(deleteSupplier.SupplierId,"SupplierContacts"))//there is a refrenect
                {
                    errorReference = "SupplierContacts Table";
                }
                if (SupplierDB.referenceCheck(deleteSupplier.SupplierId, "Products_suppliers"))
                {
                    errorReference += " and Products_suppliers Table";
                }
                if (errorReference == "")
                {
                    try
                    {

                        SupplierDB.DeleteSupplier(deleteSupplier);
                        Suppliers = SupplierDB.GetAllsuppliers();

                        dgvProductSupplier.DataSource = Suppliers;

                    }
                    catch
                    {
                        MessageBox.Show("The product you select has been correlated with one or more record. Please contact the database associate to countinue");
                    }
                    finally
                    {
                        txtPName.Text = "";
                        txtPName.Visible = false;
                        lblSave.Visible = false;
                        lblPName.Visible = false;
                        btnSave.Visible = false;
                        btnCancel.Visible = false;
                    }
                }
                else
                {
                    MessageBox.Show("Selecected supplier is referenced in " + errorReference + " , delete failed please contact with DBA!");

                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            Supplier oldSupplier = (Supplier)dgvProductSupplier.Rows[dgvProductSupplier.CurrentRow.Index].DataBoundItem;
            OperationSign = "Update";
            lblSave.Text = "Update selected Product";
            lblPName.Text = "New Product Name";
            txtPName.Visible = true;
            lblSave.Visible = true;
            lblPName.Visible = true;
            btnSave.Visible = true;
            btnCancel.Visible = true;
            txtPName.Text = oldSupplier.SupName; // the txtPName = selected item((Product)dgvProductSupplier.Rows[dgvProductSupplier.CurrentRow.Index].DataBoundItem;)
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            OperationSign = "Delete";
            lblSave.Text = "Delete selected Supplier";
            oldsupplier = (Supplier)dgvProductSupplier.Rows[dgvProductSupplier.CurrentRow.Index].DataBoundItem;
            //MessageBox.Show();
            lblSave.Visible = true;
            lblPName.Visible = false;
            btnSave.Visible = true;
            btnCancel.Visible = true;
            txtPName.Visible = true;
            txtPName.Text = oldsupplier.SupName;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtPName.Visible = false;
            lblSave.Visible = false;
            lblPName.Visible = false;
            btnSave.Visible = false;
            btnCancel.Visible = false;
        }
    }
}
