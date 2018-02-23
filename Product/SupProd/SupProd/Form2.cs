using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using supSupplier;
using SupProduct;
namespace supProduct
{  /**purpose: Add,update and delete product row
    **
    ** Author:Timothy,Tsai
    ** Date:Jan19.2018
    **/
    public partial class Form2 : Form
    {
        public string OperationSign = null;//make sure oeration action "save,update,delete"
        //public SupProd.SupProductSupplier selectedprosupplier;//an object of prodcutsupplier class ,this variable is for storage specific row got from top grid by focuse event
        public List<Product> Products = new List<Product>();
        public List<Supplier> Suppliers = new List<Supplier>();//Suppliers is used to store all of suppliers queried from SUPPLIERS TABLE
        public Product oldProduct;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e) //initiallize  form2
        {
           
            Products = ProductDB.GetAllProducts();//get all of products from PRODUCTS TABLE
            
            dgvProductSupplier.SelectionMode = DataGridViewSelectionMode.FullRowSelect;//dgc select full roll
            dgvProductSupplier.DataSource = Products;//display all of products and corresponding suppliers  get from PRODUCTS_SUPPLIERS TABLE
            txtPName.Visible = false;
            lblSave.Visible = false;
            lblPName.Visible = false;
            btnSave.Visible = false;
            btnCancel.Visible = false;


        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //when Add button is clicked,then change text and show 
            lblSave.Text = "Add";
            OperationSign = "Add";
            txtPName.Visible = true;
            lblSave.Visible = true;
            lblPName.Visible = true;
            btnSave.Visible = true;
            btnCancel.Visible = true;
            txtPName.Text = "";
            txtPName.ReadOnly = false;


        }

        private void btnSave_Click(object sender, EventArgs e)//save functionality to save what you did
        {
            if (OperationSign == "Add")//to excute insert a new product row
            {   if (txtPName.Text != "")//when new productname is not empty
                {
                    Product productIstance = new Product();
                    productIstance.ProdName = txtPName.Text;
                    ProductDB.AddProduct(productIstance);//call insert method to add new product into Table Products
                    Products = ProductDB.GetAllProducts();
                    dgvProductSupplier.DataSource = Products;

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
                    MessageBox.Show("Product name can not be empty!");//can't insert empty product name

                }
            }
            else if (OperationSign == "Update")// when confim button click, and OperationSign = update, update the data
            {
              
                Product oldProduct = (Product)dgvProductSupplier.Rows[dgvProductSupplier.CurrentRow.Index].DataBoundItem;//get current selected product row

                
                Product updateProduct = new Product();
                updateProduct.ProdName = txtPName.Text;
               
                ProductDB.UpdateProduct(oldProduct, updateProduct);//call update method to update product name
                Products = ProductDB.GetAllProducts();//get updated database 
                dgvProductSupplier.DataSource = Products;

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
                try {
                  
                    ProductDB.DeleteProduct(oldProduct);//call delete method to delete selected product
                    Products = ProductDB.GetAllProducts();
                    dgvProductSupplier.DataSource = Products;
                   
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
        }

        private void btnUpdate_Click(object sender, EventArgs e)//when click update set controls 
        {

            oldProduct = (Product)dgvProductSupplier.Rows[dgvProductSupplier.CurrentRow.Index].DataBoundItem;//get target row
            OperationSign = "Update";
            lblSave.Text = "Update selected Product";
            lblPName.Text = "New Product Name";
            txtPName.Visible = true;
            lblSave.Visible = true;
            lblPName.Visible = true;
            btnSave.Visible = true;
            btnCancel.Visible = true;
            txtPName.ReadOnly = false;
            txtPName.Text = oldProduct.ProdName.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            OperationSign = "Delete";
            lblSave.Text = "Confirm to delete selected Product";
            oldProduct = (Product)dgvProductSupplier.Rows[dgvProductSupplier.CurrentRow.Index].DataBoundItem;//get delete target
            lblSave.Visible = true;
            lblPName.Visible = false;
            btnSave.Visible = true;
            btnCancel.Visible = true;
            txtPName.Visible = true;
            txtPName.ReadOnly = true;
            txtPName.Text = oldProduct.ProdName.ToString();
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
