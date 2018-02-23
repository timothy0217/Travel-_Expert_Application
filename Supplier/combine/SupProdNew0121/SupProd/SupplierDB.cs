using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SupProd
{
   public static  class SupplierDB
    {
        public static List<Supplier> GetAllsuppliers()
        {
            //create an empty list
            List<Supplier> suppliers = new List<Supplier>();
            Supplier supplier1;

            //defining connection
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

                //process the result
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

        // returns an int for a new supplier id
        public static int GetSupplierId()
        {
            SqlConnection connection = TravelExpertsDB.GetConnection();
            SqlTransaction getidTransaction = null;
            string selectQuery = "select max(SupplierId) as MaxID from Suppliers ";

            SqlCommand selectCommand = new SqlCommand(selectQuery, connection);
            try
            {
                // open connection
                connection.Open();
                getidTransaction = connection.BeginTransaction();
                selectCommand.Transaction = getidTransaction;
                SqlDataReader reader = selectCommand.ExecuteReader(CommandBehavior.SingleRow);

                if (reader.Read())
                {
                    return ((int)reader["MaxID"] + 1);
                }

            }
            catch (Exception ex)
            {
                throw ex; // pass the buck
            }

            finally
            {
                connection.Close();
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

                string insertString = "INSERT into Suppliers (SupplierId, SupName) values (@SupplierId, @SupName)";

                SqlCommand insertCommand = new SqlCommand(insertString, connection);

                insertCommand.Parameters.AddWithValue("@SupplierId", supplierid);
                insertCommand.Parameters.AddWithValue("@SupName", supname);

                int i = insertCommand.ExecuteNonQuery();
                if (i == 1)
                {
                    successful = true;
                }

            }
            catch (Exception ex)
            {
                throw ex; // pass the buck
            }

            finally
            {
                connection.Close();//close connect 
            }
            return successful;
        }

        //updates existingsupplier record
        public static bool UpdateSupplier(Supplier oldSupplier, Supplier newSupplier)
        {
            bool successful = false;

            SqlConnection connection = TravelExpertsDB.GetConnection();

            string updateString = "update Suppliers set SupName = @SupName where SupplierId = @SupplierId";
            SqlCommand updateCommand = new SqlCommand(updateString, connection);
            updateCommand.Parameters.AddWithValue("@SupName", newSupplier.SupName);
            updateCommand.Parameters.AddWithValue("@SupplierId", oldSupplier.SupplierId);

            try
            {
                // open connection
                connection.Open();



                int count = updateCommand.ExecuteNonQuery();
                if (count > 0)
                {
                    successful = true;
                }


            }
            catch (Exception ex)
            {

                throw ex; // pass the buck
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
            SqlConnection connection = TravelExpertsDB.GetConnection();
            SqlTransaction deleteTransaction = null;

            try
            {
                // open connection
                connection.Open();
                deleteTransaction = connection.BeginTransaction();
                SqlDataAdapter sda = new SqlDataAdapter("delete from Suppliers where SupplierId = '" + oldsupplier.SupplierId.ToString() + "'", connection);
                sda.SelectCommand.Transaction = deleteTransaction;
                int count = sda.SelectCommand.ExecuteNonQuery();
                if (count == 1)
                {
                    successful = true;
                }

                deleteTransaction.Commit();
                MessageBox.Show("Successfully deletes the selected supplier!!");

            }
            catch (Exception ex)
            {
                deleteTransaction.Rollback();
                throw ex; // pass the buck
            }
            finally
            {
                connection.Close();
            }
            return successful;
        }

    }
}
