using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupProd
{
   public  class Product
    {
        public Product() { }

        public int ProductID { get; set; }
        public string ProdName { get; set; }

        public override string ToString()
        {
            return "ID: " + ProductID.ToString() +
                   "\nName: " + ProdName;
        }
        

    }
}
