using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupProd
{
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
