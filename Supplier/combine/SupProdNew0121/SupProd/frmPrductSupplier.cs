using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SupProd
{
    public partial class frmPrductSupplier : Form
    {
        public string OperationSign = null;//make sure oeration action "save,update,delete"
        public int currentProdId;//current productID to which we will add some new suppliers or update this product or delete this product,get value in method of loadProSupplier
        public int currentSupId;//current productID to which we will add some new suppliers or update this product or delete this product,get value in method of loadProSupplier
        public string currentProdName;
        public string currentSupName;
        //for add button
        public int currentAddProductId;
        public string currentAddProductName;
        //for update button
        public int currentUpdateProductId=-1;//active after click button update
        public string currentUpdateProductName;
        public int currentUpdatesupplierId;//active after click button update
        public string currentUpdatesupplierName;
        //for deletebutton

        public int currentDeleteProductId=-1;//active after click button delete
        public string currentDeleteProductName;
        public int currentDeleteSupplierId;
        public string currentDeleteSupplierName;
        public int currentDeleteProductSupplierId;

        public ProductSupplier selectedprosupplier;//an object of prodcutsupplier class ,this variable is for storage specific row got from top grid by focuse event
        public List<Product> Products = new List<Product>();
        public List<Supplier> Suppliers = new List<Supplier>();//Suppliers is used to store all of suppliers queried from SUPPLIERS TABLE

        // public List<ProductSupplier> ProSu = new List<ProductSupplier>();//all rows in productsupplier table
        public List<ProductSupplier> currentPS = new List<ProductSupplier>();//current product and correspinding suppliers based on current selected productID
        public List<ProductSupplier> allPS = new List<ProductSupplier>();// copy allps to ProSu
        public List<Product>ProductsInPS=  new List<Product>();//for lstProdcuts control
        public List<Supplier> SuppliersInPS = new List<Supplier>();//for lstProdcuts control

       

        public frmPrductSupplier()
        {
            InitializeComponent();
        }
        //initialize form area
        private void Form1_Load(object sender, EventArgs e)//
        {
           
            //initiallize recorders from Prodcuts,Suppliers and Product_supplier three TABLES
            Products = ProductDB.GetAllProducts();// LIST of Prodcut :  get all prodcuts from product TABLE to Prodcut List
            Suppliers = SupplierDB.GetAllsuppliers();//List of Supplier:get all suppliers from supplier TABLE 
            allPS = ProductSupplierDB.GetAllProductsSuppliers();//List of PS: get all of products and corresponding suppliers from PRODUCTS_SUPPLIERS TABLE
           
          
            var allProductName= from pro in Products //get each row in List of Prodcuts
                                    orderby pro.ProdName
                                    select new { ProductId = pro.ProductID, ProductName =pro.ProdName };//
            //initialzie datasour for lstProducts to display each product come from products TABLE
            lstProducts.SelectedIndexChanged -= lstProducts_SelectedIndexChanged;//
            
            lstProducts.DataSource = allProductName.ToList();
            lstProducts.ValueMember = "ProductId";
            lstProducts.DisplayMember = "ProductName";
            lstProducts.SelectedIndex = -1;
            lstProducts.SelectedIndexChanged += lstProducts_SelectedIndexChanged;
            //initialize button status,before select product row or (PS row ),none of buttons are available!
            btnAdd.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = false;
            panel2.Visible = false;
            lblSave.Visible = false;
           

        }
        //display CurrentProductsSuppliers in bottom Grid
        public void Display()
        {
            dgvCurrentProSupplier.DataSource = currentPS;//display  row/rows of which the productid is equal to varibale  currentProdId
            dgvCurrentProSupplier.Columns[1].Visible = false;
            dgvCurrentProSupplier.Columns[2].Visible = false;

        }
        
        private void  refreshLstProducts()//refresh lstSupplier which lists all related suppliers for one specific product
        {
          //  Suppliers = SupplierDB.GetAllsuppliers();
            currentProdId = Convert.ToInt32(lstProducts.SelectedValue);//currentProdid is used for ADD button

            List<ProductSupplier> listps = ProductSupplierDB.GetSuppliersForSelectedProduct(currentProdId);//get all have product-supplier related rows from productsuppliers Table where productId

            var relatedSupplierName = from allsupplier in Suppliers//get each row in sUppliers TABle
                                      where (from c in listps select c.SupplierID).Contains(allsupplier.SupplierId)// current row from currentPS doesnt included same supplierid to allsupplier
                                      orderby allsupplier.SupName
                                      select new { Supplierid = allsupplier.SupplierId, SupplierName = allsupplier.SupName };
            //initialize lstSuppliers control
            lstSuppliers.SelectedIndexChanged -= lstSuppliers_SelectedIndexChanged;
            lstSuppliers.DataSource = relatedSupplierName.ToList();
            lstSuppliers.ValueMember = "Supplierid";
            lstSuppliers.DisplayMember = "SupplierName";
            lstSuppliers.SelectedIndex = -1;
            lstSuppliers.SelectedIndexChanged += lstSuppliers_SelectedIndexChanged;

            //initialize ADD Update Delete Buttons
            btnAdd.Enabled = true;
            if (lstSuppliers.Text == "")//When not selecting specific supplier ,only do ADD
            {
                btnDelete.Enabled = false;
                btnUpdate .Enabled= false;
            }

        }
       
        private void cklstProductSupplier_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (OperationSign == "Update")//update control
            {
               
                if (e.NewValue == CheckState.Checked && cklstProductSupplier.CheckedItems.Count > 0)
                {
                    cklstProductSupplier.ItemCheck -= cklstProductSupplier_ItemCheck;
                    cklstProductSupplier.SetItemChecked(cklstProductSupplier.CheckedIndices[0], false);
                    cklstProductSupplier.ItemCheck += cklstProductSupplier_ItemCheck;
                }
            }
        }

        private void lstProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            refreshLstProducts();//when list of product reselected new item, the corresponding suppliers must be changed!
            lblSupplier.Text = "Suppliers for " + lstProducts.Text;
        }
       
        //button function area
        private void btnSave_Click(object sender, EventArgs e)
        {
           
            int count = this.cklstProductSupplier.Items.Count;//how many items is loaded in checkedlistbox
            List<int> availSupplierID = new List<int>();//declare current productid which is available

            int j = 0;

            for (int i = 0; i < count; i++)
            {
                if (this.cklstProductSupplier.GetItemChecked(i))//tell whether item is selected of not
                {
                    this.cklstProductSupplier.SetSelected(i, true);//if selected then set its selected value is ture
                                                                   //MessageBox.Show(this.cklstProductSupplier.Text.ToString()); //获取文本  
                                                                   // MessageBox.Show(this.cklstProductSupplier.SelectedValue.ToString()); //获取Value值  

                    availSupplierID.Add(Convert.ToInt32(cklstProductSupplier.SelectedValue));//store all of selected item's value to availsupplierID list
                    j++;

                }
            }
            if (OperationSign == "Add")
            {
                if (j > 0)// you have selected at leat one item from checkedlistbox
                {
                    int addsuccess = 1;
                    foreach (int p in availSupplierID)//get all of supplierd whic will be added to product
                    {
                        try
                        {
                            if (!ProductSupplierDB.AddProductsSuppliers(currentAddProductId, p))//currentAddProdID to locate a specific product and p is the supplier's id number
                            {
                                addsuccess = 0;
                            }
                            else
                            {
                              
                            }
                        }

                        catch (Exception ex)
                        {
                            throw ex;
                        }
                       
                    }
                    if (addsuccess == 1)
                    {
                        MessageBox.Show("You have added new suppliers succesfullly!");
                        lblSave.Text = "You have added " + j.ToString() + " new suppliers to product:" +currentAddProductName;
                        refreshLstProducts();
                    }
                    currentPS = ProductSupplierDB.GetAllSuppliersForSelectedProduct(currentAddProductId);//after Add operation,current selected product have more suppliers so reload currenPS list
                    dgvCurrentProSupplier.DataSource = currentPS;//refresh bottom grid
                    dgvCurrentProSupplier.Columns[1].Visible = false;
                    dgvCurrentProSupplier.Columns[2].Visible = false;

                    AddAvailableSupplier();//refrehs checkedlistbox  and before do it ,must reassign values in currentPS list
                     
                }
                else
                {
                    MessageBox.Show("please Select at least one Prodcut as new item!");
                }
                btnSave.Enabled = false;

            }

            if (OperationSign == "Update")
            {
                if (j > 0)
                {
                    DialogResult result = MessageBox.Show("Update product:" + currentUpdateProductName + ",replace " +currentUpdatesupplierName + " with "+cklstProductSupplier.Text+" ? ",
                 "Confirm Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            if (!ProductSupplierDB.UpdateProductSupplier(availSupplierID[0],currentUpdatesupplierId,currentUpdateProductId))
                            {
                                MessageBox.Show("Another user has updated or deleted " +
                                        "that customer.", "Database Error");
                            }
                            else
                            {
                                MessageBox.Show("You have updated old supplier:" + currentUpdatesupplierName + " with new supplier " + cklstProductSupplier.Text + "successfully!");
                               
                                lblSave.Text = "You have updated supplier:" + currentUpdatesupplierName + " with new suppliers :" + cklstProductSupplier.Text;
                                currentPS = ProductSupplierDB.GetAllSuppliersForSelectedProduct(currentUpdateProductId);//in david idea,delete excuted successfully
                                dgvCurrentProSupplier.DataSource = currentPS;
                                refreshLstProducts();
                               
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, ex.GetType().ToString());
                        }

                        currentPS = ProductSupplierDB.GetAllSuppliersForSelectedProduct(currentUpdateProductId);
                     //   MessageBox.Show(currentPS.Count().ToString());
                        dgvCurrentProSupplier.DataSource = currentPS;//
                        dgvCurrentProSupplier.Columns[1].Visible = false;
                        dgvCurrentProSupplier.Columns[2].Visible = false;

                        AddAvailableSupplier();
                        currentUpdateProductId = -1;//update saving has finished
                        btnSave.Enabled = false;//after update operation save is locked
                    }
                }
                else
                {
                    MessageBox.Show("please Select one Prodcut !");
                }

                

            }

            if (OperationSign == "Delete")
            {
                DialogResult result = MessageBox.Show("Delete product: " + currentDeleteProductName + " with supplier :" + currentDeleteSupplierName + " ? ",
                           "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    
                        try
                        {



                            if (!ProductSupplierDB.DeleteProductSupplier(currentDeleteProductSupplierId))//delete failure 
                            {
                                MessageBox.Show("Another user has updated or deleted " +
                              "that customer.", "Database Error");

                            }
                            else //delete succussful
                                 //currentProdId = currentPS[0].ProductID;
                            {
                                MessageBox.Show("You have deleted the product: " + currentDeleteProductName + " with supplier :" + currentDeleteSupplierName + " successfully!");
                            }
                            currentPS = ProductSupplierDB.GetAllSuppliersForSelectedProduct(currentDeleteProductId);//in david idea,delete excuted successfully
                            dgvCurrentProSupplier.DataSource = currentPS;
                            refreshLstProducts();
                            lblSave.Text = "You have deleted product:" + currentDeleteProductName + " with suplier:" + currentDeleteSupplierName;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, ex.GetType().ToString());
                        }

                    currentDeleteProductId = -1;
                    btnSave.Enabled = false;//after update operation save is locked


                }
               
            }
            //after any of above operation,we have to refresh top grid
            allPS = ProductSupplierDB.GetAllProductsSuppliers();
            btnAdd.Enabled = false;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
            panel1.Visible = true;
            panel2.Visible = false;

        }
        

        private void btnAdd_Click(object sender, EventArgs e)
        {
            
            OperationSign = "Add";
            //initialize Edit panel
            panel2.Visible = true;
            panel1.Visible = false;
            lblSave.Visible = true;
            btnSave.Enabled = true;
            cklstProductSupplier.Visible = true;
            //get selected productID and productName
            currentProdId = Convert.ToInt32(lstProducts.SelectedValue);//get selected productID
            currentProdName = lstProducts.Text;//get selected productName
            currentAddProductId = currentProdId;
            currentAddProductName = currentProdName;
            //load corresponding suppliers row
            currentPS =OperationPS.getCurrentPS(currentAddProductId, OperationSign);//load all of suppliers corresponding from PRODUCTS_SUPPLIERS TABLE and displayed in bottom grid 
            Display();
            //add all of suppliers which are not related to currtent productID
            AddAvailableSupplier();//add all of suppliers which are not related to currtent productID
            btnAdd.Enabled = false;
            lblSave.Text = "You are adding new suppliers to product:" + currentAddProductName;
            


        }
        private void AddAvailableSupplier()//method to load available suppliers'name to checkedlistbox
        {

            // currentPS  is generated in Method of loadProSupplier
            Suppliers = SupplierDB.GetAllsuppliers();//get all of suppliers in SUPPLIERS TABLE
            var availableSupplierName = from allsupplier in Suppliers//get each row in sUppliers TABle
                                        where !(from c in currentPS select c.SupplierID).Contains(allsupplier.SupplierId)// current row from currentPS doesnt included same supplierid to allsupplier
                                        orderby allsupplier.SupName
                                        select new { Supplierid = allsupplier.SupplierId, SupplierName = allsupplier.SupName };


            cklstProductSupplier.DataSource = availableSupplierName.ToList();
            cklstProductSupplier.DisplayMember = "SupplierName";
            cklstProductSupplier.ValueMember = "Supplierid";
            // this section modify the bug of checkedlistbox 
            for (int i = 0; i < cklstProductSupplier.Items.Count; i++)
            {
                if (cklstProductSupplier.GetItemChecked(i))
                {
                    cklstProductSupplier.SetItemChecked(i, false);
                }
            }
        }
       
        

        private void btnUpdate_Click(object sender, EventArgs e)
        {
          
             OperationSign = "Update";
             //initialize form
            lblSave.Visible = true;
            btnSave.Enabled = true;
            cklstProductSupplier.Visible = true;
            panel2.Visible = true;
            panel1.Visible = false;
            //get update target productId
            // currentProdId = Convert.ToInt32(lstProducts.SelectedValue);
            // currentProdName = lstProducts.Text;
            currentUpdateProductId = Convert.ToInt32(lstProducts.SelectedValue);
            currentUpdateProductName= lstProducts.Text;
            currentUpdatesupplierId = Convert.ToInt32(lstSuppliers.SelectedValue);
            currentUpdatesupplierName = lstSuppliers.Text;
            currentPS = OperationPS.getCurrentPS(currentUpdateProductId, currentUpdatesupplierId, OperationSign);
           // currentUpdateProductId = currentProdId;
            Display();
            UpdateAvailableSupplier();
            btnUpdate.Enabled = false;
            lblSave.Text = "You are updating Prodcut:" + currentUpdateProductName + " with supplier:" + currentUpdatesupplierName;
        }
        private void UpdateAvailableSupplier()//method to update new available supplier to current supplier for a specific row
        {
            //when update,only select one available supplier to update old one,available suppliers is same to add function
            currentPS = ProductSupplierDB.GetAllSuppliersForSelectedProduct(currentUpdateProductId);//select all of suppliers for this current ProductID
            List<Supplier> Suppliers = SupplierDB.GetAllsuppliers();//access DB by select statement and return rows
            var availableSupplierName = from allsupplier in Suppliers
                                        where !(from c in currentPS select c.SupplierID).Contains(allsupplier.SupplierId)
                                        orderby allsupplier.SupName
                                        select new { Supplierid = allsupplier.SupplierId, SupplierName = allsupplier.SupName };


            cklstProductSupplier.DataSource = availableSupplierName.ToList();
            cklstProductSupplier.DisplayMember = "SupplierName";
            cklstProductSupplier.ValueMember = "Supplierid";
            for (int i = 0; i < cklstProductSupplier.Items.Count; i++)
            {
                if (cklstProductSupplier.GetItemChecked(i))
                {
                    cklstProductSupplier.SetItemChecked(i, false);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
           
            //int currentDeletePSid;
            OperationSign = "Delete";
            //
           
            cklstProductSupplier.Visible = false;
            //            
          
            btnDelete.Enabled = false;
            //
            currentDeleteProductId = Convert.ToInt32(lstProducts.SelectedValue);
            currentDeleteSupplierId = Convert.ToInt32(lstSuppliers.SelectedValue);
            currentDeleteProductName = lstProducts.Text;
            currentDeleteSupplierName = lstSuppliers.Text;
            
            currentDeleteProductSupplierId = ProductSupplierDB.getProductSupplierId(currentDeleteProductId, currentDeleteSupplierId);//get productsupplierId in PS TABLE 
            if (ProductSupplierDB.referencedInPackages(currentDeleteProductSupplierId))
            {
                MessageBox.Show("Your selection product:" + currentDeleteProductName + " with supplier of " + currentDeleteSupplierName + " has been referenced in Package Table,Please go to Package!");
                panel2.Visible =false;
                panel1.Visible = true;
                btnSave.Enabled =false;
                lblSave.Enabled = false;
                lblSave.Visible =false;
            }
            else
            {
                panel2.Visible = true;
                panel1.Visible = false;
                btnSave.Enabled = true;
                lblSave.Enabled = true;
                lblSave.Visible = true;
                currentPS = OperationPS.getCurrentPS(currentDeleteProductId, currentDeleteSupplierId, OperationSign);

                lblSave.Text = "You are preparing to delete product:" + currentDeleteProductName + " with supplier:" + currentDeleteSupplierName;
                Display();
            }
           

        }

        private void lstSuppliers_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnAdd.Enabled = false;
            btnUpdate.Enabled = true;//when selecte a suppllier can go to update
            btnDelete.Enabled = true;//when selecte a suppllier can go to delete
            currentSupId = Convert.ToInt32(lstSuppliers.SelectedValue);
            currentSupName = lstSuppliers.Text;
            if( (currentDeleteProductId!=-1)||(currentUpdateProductId!=-1))
            {
                MessageBox.Show("You have not finish data update or deleting,please finish now!");

            }

            else
            {
                btnSave.Enabled = false;//lock
            }
        }

        private void txtProductSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtProductSearch.Text == "")
            {
                Products = ProductDB.GetAllProducts();
               var allProductName = from pro in Products //get each row in sUppliers TABle
                                     orderby pro.ProdName
                                     select new { ProductId = pro.ProductID, ProductName = pro.ProdName };
                lstProducts.SelectedIndexChanged -= lstProducts_SelectedIndexChanged;
                //lstProducts.DataSource = availableProductName.ToList();
                lstProducts.DataSource = allProductName.ToList();
                lstProducts.ValueMember = "ProductId";
                lstProducts.DisplayMember = "ProductName";
                lstProducts.SelectedIndex = -1;
                lstProducts.SelectedIndexChanged += lstProducts_SelectedIndexChanged;
            }

            else
            {

                Products = ProductDB.SearchAllProducts(txtProductSearch.Text);
                var allProductName = from pro in Products //get each row in sUppliers TABle
                                     orderby pro.ProdName
                                     select new { ProductId = pro.ProductID, ProductName = pro.ProdName };
                lstProducts.SelectedIndexChanged -= lstProducts_SelectedIndexChanged;
                //lstProducts.DataSource = availableProductName.ToList();
                lstProducts.DataSource = allProductName.ToList();
                lstProducts.ValueMember = "ProductId";
                lstProducts.DisplayMember = "ProductName";
                lstProducts.SelectedIndex = -1;
                lstProducts.SelectedIndexChanged += lstProducts_SelectedIndexChanged;
               

            }    
        }

       
        private void txtSupplierSearch_TextChanged(object sender, EventArgs e)
        {

        }

       

        private void txtSupplierSearch_KeyUp(object sender, KeyEventArgs e)
        {
            
           
                currentProdId = Convert.ToInt32(lstProducts.SelectedValue);
                //Suppliers = SupplierDB.GetAllsuppliers();
                List<ProductSupplier> listps = ProductSupplierDB.SearchAllSuppliersForSelectedProduct(currentProdId, txtSupplierSearch.Text);
               
                // var relatedSupplierName = from allsupplier in Suppliers//get each row in sUppliers TABle
                //                           where (from c in listps select c.SupplierID).Contains(allsupplier.SupplierId)// current row from currentPS doesnt included same 

                //                          select new { Supplierid = allsupplier.SupplierId, SupplierName = allsupplier.SupName };
                var relatedSupplierName = from relatedSupplier in listps
                                          select new { Supplierid = relatedSupplier.SupplierID, SupplierName = relatedSupplier.SupplierName };
                lstSuppliers.SelectedIndexChanged -= lstSuppliers_SelectedIndexChanged;
                lstSuppliers.DataSource = relatedSupplierName.ToList();
                lstSuppliers.ValueMember = "Supplierid";
                lstSuppliers.DisplayMember = "SupplierName";
                lstSuppliers.SelectedIndex = -1;
                lstSuppliers.SelectedIndexChanged += lstSuppliers_SelectedIndexChanged;


           
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            
            lblSave.Visible = false;
            dgvCurrentProSupplier.DataSource = null;
            cklstProductSupplier.DataSource = null;
            panel2.Visible = false;
            panel1.Visible = true;
            btnAdd.Enabled = false;//return to initial status
            btnDelete.Enabled = false;//return to initial status
            btnUpdate.Enabled = false;//return to initial status
            currentUpdateProductId = -1;
            currentDeleteProductId = -1;
        }

        private void txtProductSearch_Click(object sender, EventArgs e)
        {
            txtProductSearch.Clear();
            txtProductSearch.ForeColor = Color.Black;
        }
        private void txtSupplierSearch_Click(object sender, EventArgs e)
        {
            txtSupplierSearch.Clear();
            txtSupplierSearch.ForeColor = Color.Black;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            DialogResult result = form2.ShowDialog();
            if (result == DialogResult.OK)
            {
                Products = ProductDB.GetAllProducts();// LIST of Prodcut :  get all prodcuts from product TABLE to Prodcut List
                                                      // Suppliers = SupplierDB.GetAllsuppliers();//List of Supplier:get all suppliers from supplier TABLE 
                allPS = ProductSupplierDB.GetAllProductsSuppliers();//List of PS: get all of products and corresponding suppliers from PRODUCTS_SUPPLIERS TABLE


                var allProductName = from pro in Products //get each row in List of Prodcuts
                                     orderby pro.ProdName
                                     select new { ProductId = pro.ProductID, ProductName = pro.ProdName };//
                                                                                                          //initialzie datasour for lstProducts to display each product come from products TABLE
                lstProducts.SelectedIndexChanged -= lstProducts_SelectedIndexChanged;//

                lstProducts.DataSource = allProductName.ToList();
                lstProducts.ValueMember = "ProductId";
                lstProducts.DisplayMember = "ProductName";
                lstProducts.SelectedIndex = -1;
                lstProducts.SelectedIndexChanged += lstProducts_SelectedIndexChanged;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            DialogResult result = form3.ShowDialog();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }

        
    }