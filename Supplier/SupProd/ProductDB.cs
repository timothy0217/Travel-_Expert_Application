using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace supSupplier
{
    public static class ProductDB
    {
        public static List<Product> GetAllProducts()
        {
            //create an empty list
            List<Product> products = new List<Product>();
            Product product;

            //defining connection
            SqlConnection connection = TravelExpertsDB.GetConnection();

            //defining the query
            string selectQuery = "Select * from Products";

            //defining the command
            SqlCommand selectCommand = new SqlCommand(selectQuery, connection);

            //connection to database
            try
            {
                //open the connection
                connection.Open();

                //execute the command
                SqlDataReader reader = selectCommand.ExecuteReader();

                //process the result
                while (reader.Read())
                {

                    product = new Product();

                    product.ProductID = Convert.ToInt32(reader["ProductID"]);
                    product.ProdName = reader["ProdName"].ToString();

                    // Add to list
                    products.Add(product);
                }
            }

            //exception handling from the program
            catch (Exception ex)
            {
                throw ex;
            }
            //always closing the connection
            finally
            {
                connection.Close();
            }
            return products;
        }


        //add new products
        public static int AddProduct(Product product)
        {
            int prodID = 0;

            SqlConnection connection = TravelExpertsDB.GetConnection();

            string insertString = "INSERT into Products (ProdName) values (@ProdName)";

            SqlCommand insertCommand = new SqlCommand(insertString, connection);

            insertCommand.Parameters.AddWithValue("@ProdName", product.ProdName);

            try
            {
                connection.Open();

                int i = insertCommand.ExecuteNonQuery();
                if (i == 1)
                {
                    string selectString = "SELECT ident_current('Products') FROM Products";

                    SqlCommand selectCommand = new SqlCommand(selectString, connection);
                    prodID = Convert.ToInt32(selectCommand.ExecuteScalar());
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
            return prodID;
        }

        internal static void AddProduct(string productName, object ab)
        {
            throw new NotImplementedException();
        }

        //updates existing customer record

        public static bool UpdateProduct(Product oldProduct, Product newProduct)
        {
            bool successful = false;

            SqlConnection conn = TravelExpertsDB.GetConnection();

            string updateString = "Update products set ProdName = @NewProdName where ProductID = @ProductID and ProdName = @OldProdName";

            SqlCommand updateCommand = new SqlCommand(updateString, conn);


            updateCommand.Parameters.AddWithValue("@OldProdName", oldProduct.ProdName);
            updateCommand.Parameters.AddWithValue("@ProductID", oldProduct.ProductID);
            updateCommand.Parameters.AddWithValue("@NewProdName", newProduct.ProdName);
           
            try
            {
                conn.Open();
                int count = updateCommand.ExecuteNonQuery();
                if (count == 1)
                    successful = true;
               
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


        //delete products 
        public static bool DeleteProduct(Product product)
        {
            bool successful = false;

            SqlConnection connection = TravelExpertsDB.GetConnection();
            string deleteString = "DELETE from Products WHERE ProductId = @ProductID AND ProdName = @ProdName";

            SqlCommand deleteCommand = new SqlCommand(deleteString, connection);
            deleteCommand.Parameters.AddWithValue("@ProductID", product.ProductID);
            deleteCommand.Parameters.AddWithValue("@ProdName", product.ProdName);


            try
            {
                connection.Open();
                int count = deleteCommand.ExecuteNonQuery();
                if (count == 1)
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

    }
}
