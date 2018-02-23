using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SupProd
{/**Purpose:methods to visit Product_supplier table
    *Author: David ,Zhu
    *Date:JAn23,2018
    **/
    public static class ProductSupplierDB
    {  
        public static List<ProductSupplier> GetAllProductsSuppliers()//get all of products and suppliers which has relationship
        {
            List<ProductSupplier> productsSuppliers = new List<ProductSupplier>();
            
            // define connection of database
            SqlConnection connection = TravelExpertsDB.GetConnection();

            // define the select query
            string selectQuery = "select ps.ProductSupplierId, ps.ProductID, ps.SupplierID, sup.SupName, prod.ProdName " +
                                 "from Products_Suppliers ps " +
                                 "inner join Suppliers sup on ps.SupplierId = sup.SupplierId " +//join table supplier
                                 "inner join Products prod on ps.ProductId = prod.ProductId";//join table products

            SqlCommand selectCommand = new SqlCommand(selectQuery, connection);

            // Connect to DB
            try
            {
                // open the connection
                connection.Open();

                // execute query
                SqlDataReader reader = selectCommand.ExecuteReader();

                // process the result
                while (reader.Read())
                {
                    ProductSupplier ps = new ProductSupplier();

                    // get PS object property values from database
                    ps.ProductSupplierId = Convert.ToInt32(reader["ProductSupplierId"]);
                    ps.ProductID = Convert.ToInt32(reader["ProductID"]);
                    ps.SupplierID = Convert.ToInt32(reader["SupplierID"]);
                    ps.ProductName = reader["ProdName"].ToString();
                    ps.SupplierName = reader["SupName"].ToString();


                    // Add to list
                    productsSuppliers.Add(ps);
                }
            }
            catch (Exception ex)
            {
                throw ex; // display exception information
            }
            finally
            {
                connection.Close();
            }
           
            return productsSuppliers;//return List
        }

        public static List<ProductSupplier> GetAllSuppliersForSelectedProduct(int productID)//return a list of productsupplier corresponding to a specific productname
        {
            List<ProductSupplier> productsSuppliers = new List<ProductSupplier>();

            // define connection
            SqlConnection connection = TravelExpertsDB.GetConnection();

            // define the select query
            string selectQuery = "select ps.ProductSupplierId, ps.ProductID, ps.SupplierID, sup.SupName, prod.ProdName " +
                                 "from Suppliers sup, Products_Suppliers ps, Products prod " +
                                 "where ps.SupplierId = sup.SupplierId " +//joint PS table  and Supplier Table
                                 "and ps.ProductId = prod.ProductId " +//joint PS table and Prodcut Table
                                 "and ps.ProductId ='" + productID + "' " +//set ProdcutID
                                 "order by sup.SupName";

            SqlCommand selectCommand = new SqlCommand(selectQuery, connection);

            // Connect to DB
            try
            {
                // open the connection
                connection.Open();

                // execute query
                SqlDataReader reader = selectCommand.ExecuteReader();

                // process the result
                while (reader.Read())
                {
                    ProductSupplier ps = new ProductSupplier();

                    // get PS object value from database
                    ps.ProductSupplierId = Convert.ToInt32(reader["ProductSupplierId"]);
                    ps.ProductID = Convert.ToInt32(reader["ProductID"]);
                    ps.SupplierID = Convert.ToInt32(reader["SupplierID"]);
                    ps.ProductName = reader["ProdName"].ToString();
                    ps.SupplierName = reader["SupName"].ToString();
                    //add to list
                    productsSuppliers.Add(ps);
                }
            }
            catch (Exception ex)
            {
                throw ex; // display exception information
            }
            finally
            {
                connection.Close();
            }

            return productsSuppliers;
        }

        public static List<ProductSupplier> SearchAllSuppliersForSelectedProduct(int productID,string supplierName)//return a list of productsupplier objects corresponding to speicfic product and supplier
        {
            List<ProductSupplier> productsSuppliers = new List<ProductSupplier>();

            // define connection
            SqlConnection connection = TravelExpertsDB.GetConnection();

            // define the select query
            string selectQuery = "";
            selectQuery = "select ps.ProductSupplierId, ps.ProductID, ps.SupplierID, sup.SupName, prod.ProdName " +
                                 "from Suppliers sup, Products_Suppliers ps, Products prod " +
                                 "where ps.SupplierId = sup.SupplierId " +//joint PS table and Supplier Table
                                 "and ps.ProductId = prod.ProductId " +//join PS table and Product Table
                                 "and ps.ProductId ='" + productID + "' " +//set ProductID
                                 "and sup.SupName LIKE '%' + @ProdName + '%' ";//fuzzy querey using "%"
            if (supplierName == "")//select all of products when not input specific character in textbox
            {
            selectQuery = "select ps.ProductSupplierId, ps.ProductID, ps.SupplierID, sup.SupName, prod.ProdName " +
                                                 "from Suppliers sup, Products_Suppliers ps, Products prod " +
                                                 "where ps.SupplierId = sup.SupplierId " +//join PS table and Supplier Table
                                                 "and ps.ProductId = prod.ProductId " +//join PS table and Product Table
                                                 "and ps.ProductId ='" + productID + "' ";
                                                
            }
            SqlCommand selectCommand = new SqlCommand(selectQuery, connection);
            selectCommand.Parameters.AddWithValue("@ProdName", supplierName);
            // Connect to DB
            try
            {
                // open the connection
                connection.Open();

                // execute query
                SqlDataReader reader = selectCommand.ExecuteReader();

                // process the result
                while (reader.Read())
                {
                    ProductSupplier ps = new ProductSupplier();

                    // Assign  PS object properties from database
                    ps.ProductSupplierId = Convert.ToInt32(reader["ProductSupplierId"]);
                    ps.ProductID = Convert.ToInt32(reader["ProductID"]);
                    ps.SupplierID = Convert.ToInt32(reader["SupplierID"]);
                    ps.ProductName = reader["ProdName"].ToString();
                    ps.SupplierName = reader["SupName"].ToString();


                    // Add to list
                    productsSuppliers.Add(ps);
                }
            }
            catch (Exception ex)
            {
                throw ex; //  display exception information
            }
            finally
            {
                connection.Close();
            }

            return productsSuppliers;
        }
        public static List<ProductSupplier> GetOneSuppliersForSelectedProduct(int productID,int supplierID)//return a single row according to ProductID and SupplierID
        {
            List<ProductSupplier> productsSuppliers = new List<ProductSupplier>();

            // define connection
            SqlConnection connection = TravelExpertsDB.GetConnection();

            // define the select query
            string selectQuery = "select ps.ProductSupplierId, ps.ProductID, ps.SupplierID, sup.SupName, prod.ProdName " +
                                 "from Suppliers sup, Products_Suppliers ps, Products prod " +
                                 "where ps.SupplierId = sup.SupplierId " +
                                 "and ps.ProductId = prod.ProductId " +
                                 "and ps.ProductId ='" + productID + "' "
                                 + "and ps.SupplierId='"+supplierID+"'";

            SqlCommand selectCommand = new SqlCommand(selectQuery, connection);

            // Connect to DB
            try
            {
                // open the connection
                connection.Open();

                // execute query
                SqlDataReader reader = selectCommand.ExecuteReader();

                // process the result
                while (reader.Read())
                {
                    ProductSupplier ps = new ProductSupplier();

                    // Assign  PS object properties from database
                    ps.ProductSupplierId = Convert.ToInt32(reader["ProductSupplierId"]);
                    ps.ProductID = Convert.ToInt32(reader["ProductID"]);
                    ps.SupplierID = Convert.ToInt32(reader["SupplierID"]);
                    ps.ProductName = reader["ProdName"].ToString();
                    ps.SupplierName = reader["SupName"].ToString();


                    // Add to list
                    productsSuppliers.Add(ps);
                }
            }
            catch (Exception ex)
            {
                throw ex; // display exception information
            }
            finally
            {
                connection.Close();
            }

            return productsSuppliers;
        }
        public static List<ProductSupplier> GetSuppliersForSelectedProduct(int productID)//return all selected suppliers for a specific product
        {
            List<ProductSupplier> productsSuppliers = new List<ProductSupplier>();

            // define connection
            SqlConnection connection = TravelExpertsDB.GetConnection();

            // define the select query
            string selectQuery = "select ps.ProductSupplierId, ps.ProductID, ps.SupplierID, sup.SupName, prod.ProdName " +
                                 "from Suppliers sup, Products_Suppliers ps, Products prod " +
                                 "where ps.SupplierId = sup.SupplierId " +
                                 "and ps.ProductId = prod.ProductId " +
                                 "and ps.ProductId ='" + productID + "' ";
                                 

            SqlCommand selectCommand = new SqlCommand(selectQuery, connection);

            // Connect to DB
            try
            {
                // open the connection
                connection.Open();

                // execute query
                SqlDataReader reader = selectCommand.ExecuteReader();

                // process the result
                while (reader.Read())
                {
                    ProductSupplier ps = new ProductSupplier();

                    // Assign properties to order
                    ps.ProductSupplierId = Convert.ToInt32(reader["ProductSupplierId"]);
                    ps.ProductID = Convert.ToInt32(reader["ProductID"]);
                    ps.SupplierID = Convert.ToInt32(reader["SupplierID"]);
                    ps.ProductName = reader["ProdName"].ToString();
                    ps.SupplierName = reader["SupName"].ToString();


                    // Add to list
                    productsSuppliers.Add(ps);
                }
            }
            catch (Exception ex)
            {
                throw ex; // let the form handle it
            }
            finally
            {
                connection.Close();
            }

            return productsSuppliers;
        }
        

        public static int  getProductSupplierId(int productid,int supplierid)//return the ProductSupplierID in PRoductSupplier table
        {

            int ProductSupplierId=-1;

            // define connection
            SqlConnection connection = TravelExpertsDB.GetConnection();

            // define the select query
            string selectQuery = "select ProductSupplierId from Products_Suppliers where ProductID=@productid and SupplierID=@supplierid";

            SqlCommand selectCommand = new SqlCommand(selectQuery, connection);
            selectCommand.Parameters.AddWithValue("@productid", productid);
            selectCommand.Parameters.AddWithValue("@supplierid", supplierid);
            // Connect to DB
            try
            {
                // open the connection
                connection.Open();

                // execute query
                SqlDataReader reader = selectCommand.ExecuteReader(CommandBehavior.SingleRow);

                // process the result
                if (reader.Read())
                {
                    ProductSupplierId = Convert.ToInt32(reader["ProductSupplierId"]);
                }
            }
            catch (Exception ex)
            {
                throw ex; // let the form handle it
            }
            finally
            {
                connection.Close();
            }

            return ProductSupplierId;

        }

        public static bool AddProductsSuppliers(int productId, int supplierId)//insert a new productSupplier row in table of ProdcutSupplier table
        {


            bool successful = false;
            // prepare connection
            SqlConnection connection = TravelExpertsDB.GetConnection();

           // Build the SQL query

            string insertString = "INSERT INTO Products_Suppliers (ProductId, SupplierId) VALUES (@ProductId, @SupplierId)";

            // Create command from the query
            SqlCommand insertCommand = new SqlCommand(insertString, connection);
            insertCommand.Parameters.AddWithValue("@ProductId", productId);
            insertCommand.Parameters.AddWithValue("@SupplierId", supplierId);

            try
            {
                // open connection
                connection.Open();

                // execute the statement
                int i = insertCommand.ExecuteNonQuery();
                if (i == 1)
                {
                    successful = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return successful;
        }

       
        public static bool UpdateProductSupplier(int NewSupplierId, int OldSupplierId,int ProductId)//updated  selected row
        {
            bool successful = false;

            SqlConnection conn = TravelExpertsDB.GetConnection();

           // string updateString = "Update Products_Suppliers set SupplierId = @NewSupplierId where ProductSupplierId = @ProductSupplierID";
            string updateString = "Update Products_Suppliers set SupplierId = @NewSupplierId where SupplierID = @OldSupplierId and ProductID=@ProductId";
            SqlCommand updateCommand = new SqlCommand(updateString, conn);


            updateCommand.Parameters.AddWithValue("@NewSupplierId", NewSupplierId);
            updateCommand.Parameters.AddWithValue("@OldSupplierId", OldSupplierId);
            updateCommand.Parameters.AddWithValue("@ProductId", ProductId);
            try
            {
                conn.Open();
                int count = updateCommand.ExecuteNonQuery();
                if (count == 1)
                { successful = true; }
                else
                { successful = false; }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return successful;
        }
       
        public static bool DeleteProductSupplier(int ProductSupplierId)//delete selected row 
        {
            bool successfull = false;
            int count;
            // define connection
            SqlConnection connection = TravelExpertsDB.GetConnection();

            // define the select query command
            string deleteStatement = "delete from Products_Suppliers WHERE  ProductSupplierId = @productsupplierid";
            SqlCommand deleteCommand = new SqlCommand(deleteStatement, connection);
            deleteCommand.Parameters.AddWithValue("@productsupplierid", ProductSupplierId);
           
            try
            {
                // open the connection
                connection.Open();


                count = Convert.ToInt32(deleteCommand.ExecuteScalar());
                if (count >= 1)
                {
                    successfull = false;
                }
                else
                {
                    successfull = true;
                }
            }
            catch (Exception)
            {
                //  throw ex; // let the form handle it
                MessageBox.Show("Your selection is referenced in the other table ,so please contact to DataAdiministrator!");
            }
            finally
            {
                connection.Close(); // close connecto no matter what
            }
            return successfull;
        }

       
        public static bool referencedInPackages(int deleteproductsupplierid)//check there is referenced in package table when delete row

        {
            bool refPSinPackages = false;
            string selectQuery = "select * from Packages_Products_Suppliers where ProductSupplierID=@deleteproductsupplierid ";
            SqlConnection connection = TravelExpertsDB.GetConnection();
            SqlCommand selectCommand = new SqlCommand(selectQuery, connection);
            selectCommand.Parameters.AddWithValue("@deleteproductsupplierid", deleteproductsupplierid);
            
            // Connect to DB
            try
            {
                // open the connection
                connection.Open();

                // execute query
                SqlDataReader reader = selectCommand.ExecuteReader(CommandBehavior.SingleRow);

                // process the result
                if (reader.Read())
                {
                    refPSinPackages=true;//referenced in Package_Prodcut_Supplier Table
                }
            }
            catch (Exception ex)
            {
                throw ex; // let the form handle it
            }
            finally
            {
                connection.Close();
            }



            return refPSinPackages;

        }

       
    }
}
