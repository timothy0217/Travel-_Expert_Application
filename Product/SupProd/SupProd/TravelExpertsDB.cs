using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace supProduct
{
  public static   class TravelExpertsDB
    {
        public static SqlConnection GetConnection()
        {
            
            string connString = @"server=(local)\SQLExpress;database=TravelExperts;integrated Security=SSPI;";//connect to local Sqlserver  Database
            SqlConnection conn = new SqlConnection(connString);

            return conn;
        }

    }
}
