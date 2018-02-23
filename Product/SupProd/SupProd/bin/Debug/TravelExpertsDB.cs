using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace supSupplier
{/**Purpose:connect to database
 * Name:sabrina gomes
 * Date:JAn 18.2018
 * 
 * */
    public static   class TravelExpertsDB
    {
        public static SqlConnection GetConnection()
        {
            
            string connString = @"server=(local)\SQLExpress;database=TravelExperts;integrated Security=SSPI;";
            SqlConnection conn = new SqlConnection(connString);

            return conn;
        }

    }
}
