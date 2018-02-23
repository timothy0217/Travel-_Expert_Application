using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/**Purpose:provide methods to access databse for excuting product insert ,updatea and delete
 * Name:sabrina gomes
 * Date:JAn 18.2018
 * 
 * */

//it adds, delete, updates and also checks if the file to delete is referenced in another table (so it can't be deleted)
namespace supSupplier
{
   public static  class SupplierDB  //method that connects to supplier database
    {
        public static List<Supplier> GetAllsuppliers()    //method that creates a list from db
        {
            //create an empty list
            List<Supplier> suppliers = new List<Supplier>();
            Supplier supplier1;

           // sql statement to connect with database
            SqlConnection connection = TravelExpertsDB.GetConnection();

            //defining the query
            string selectQuery = "select * from Suppliers order by SupplierID asc";

            //defining the command
            SqlCommand selectCommand = new SqlCommand(selectQuery, connection);

            //connection to database
            try
            {
                //open the connection
                connection.Open();

                //execute the command
                SqlDataReader reader = selectCommand.ExecuteReader();

                //while there is data to read, read it and add to list
                while (reader.Read())
                {

                    supplier1 = new Supplier();

                    supplier1.SupplierId = Convert.ToInt32(reader["SupplierID"]);
                    supplier1.SupName = reader["SupName"].ToString();

                    // Add to list
                    suppliers.Add(supplier1);
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
            return suppliers;
        }

        // method to get a new ID number for new supplier based on Maximum number from Id on database
        public static int GetSupplierId()
        {
            SqlConnection connection = TravelExpertsDB.GetConnection();  //connects to db
            SqlTransaction getidTransaction = null;    //first transaction empty
            string selectQuery = "select max(SupplierId) as MaxID from Suppliers ";  //find the max ID supplier from DB

            SqlCommand selectCommand = new SqlCommand(selectQuery, connection);
            try
            {
                // open connection
                connection.Open();
                getidTransaction = connection.BeginTransaction();    //get max ID transaction connection
                selectCommand.Transaction = getidTransaction;  //selects max ID
                SqlDataReader reader = selectCommand.ExecuteReader(CommandBehavior.SingleRow);

                if (reader.Read())
                {
                    return ((int)reader["MaxID"] + 1);    //returns Max Id from DB + 1
                }

            }
            catch (Exception ex)
            {
                throw ex; // exception handle
            }

            finally
            {
                connection.Close();  //close connection no matter what
            }

            return -1;// supplier table is empty.there is no recorder in it
        }
        //add new supplier
        public static bool AddSupplier(int supplierid, string supname)
        {
            bool successful = false;
            SqlConnection connection = TravelExpertsDB.GetConnection();
            if (supplierid == 0) supplierid += 1;//empty table this will be the first recorder in supplier table

            try
            {
                // open connection
                connection.Open();

                string insertString = "INSERT into Suppliers (SupplierId, SupName) values (@SupplierId, @SupName)";  //add data to DB

                SqlCommand insertCommand = new SqlCommand(insertString, connection);

                insertCommand.Parameters.AddWithValue("@SupplierId", supplierid);  
                insertCommand.Parameters.AddWithValue("@SupName", supname);

                int i = insertCommand.ExecuteNonQuery();  //insert command
                if (i == 1)
                {
                    successful = true;  //if insert true return successful
                }

            }
            catch (Exception ex)
            {
                throw ex; // exception handled
            }

            finally
            {
                connection.Close();//close connection
            }
            return successful;
        }

        //updates existing supplier record
        public static bool UpdateSupplier(Supplier oldSupplier, Supplier newSupplier)
        {
            bool successful = false;

            SqlConnection connection = TravelExpertsDB.GetConnection();

            string updateString = "update Suppliers set SupName = @SupName where SupplierId = @SupplierId";
            SqlCommand updateCommand = new SqlCommand(updateString, connection);
            updateCommand.Parameters.AddWithValue("@SupName", newSupplier.SupName);  //new supplier updated
            updateCommand.Parameters.AddWithValue("@SupplierId", oldSupplier.SupplierId);   //supplierID receives old supplierID. so it doesnt change ID

            try
            {
                // open connection
                connection.Open();



                int count = updateCommand.ExecuteNonQuery();
                if (count > 0)
                {
                    successful = true; //if update > 0, means updated 1 record, means it was successful
                }


            }
            catch (Exception ex)
            {

                throw ex; // exception handled
            }
            finally
            {
                connection.Close();
            }
            return successful;
        }
        //delete data from database
        public static bool DeleteSupplier(Supplier oldsupplier)
        {
            bool successful = false;
            SqlConnection connection = TravelExpertsDB.GetConnection(); //connects to db
            SqlTransaction deleteTransaction = null;  

            try
            {
                // open connection
                connection.Open();
                deleteTransaction = connection.BeginTransaction();  //starts transaction
                SqlDataAdapter sda = new SqlDataAdapter("delete from Suppliers where SupplierId = '" + oldsupplier.SupplierId.ToString() + "'", connection);
                sda.SelectCommand.Transaction = deleteTransaction;
                int count = sda.SelectCommand.ExecuteNonQuery();
                if (count == 1)
                {
                    successful = true;   //count ==1 meand deleted successful
                }

                deleteTransaction.Commit();    //then commit 
                MessageBox.Show("Successfully deletes the selected supplier!!");

            }
            catch (Exception ex)
            {
                deleteTransaction.Rollback();   //if something wrong, it rollback on database and wont delete
                throw ex; // exception handled
            }
            finally
            {
                connection.Close();
            }
            return successful;
        }
        //to check if there is reference with other table. foreign key
        public static bool referenceCheck(int deletesupplierid, string tablename)

        {
            bool refSupplier = false;
            string selectQuery = "select * from " + tablename + " where SupplierId=@deletesupplierid ";  //query to check
            SqlConnection connection = TravelExpertsDB.GetConnection();    //connects to db
            SqlCommand selectCommand = new SqlCommand(selectQuery, connection);   //selects command
            selectCommand.Parameters.AddWithValue("@deletesupplierid", deletesupplierid);  

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
                    refSupplier = true;//referenced in Package_Prodcut_Supplier Table. If is foreign key to other table.
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



            return refSupplier;

        }

    }
}
