using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace supProduct
{  /**purpose: declare Product Class
    **
    ** Author:Timothy,Tsai
    ** Date:Jan19.2018
    **/
    public class Product
    {
        public Product() { }

        public int ProductID { get; set; }//product id
        public string ProdName { get; set; }//product name

        public override string ToString()
        {
            return "ID: " + ProductID.ToString() +
                   "\nName: " + ProdName;
        }
        

    }
}
