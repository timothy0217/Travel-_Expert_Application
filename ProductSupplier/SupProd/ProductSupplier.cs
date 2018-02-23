using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupProd
{ /**Purpose:initial prodcutSupplier Class
    *Author: David ,Zhu
    *Date:JAn23,2018
    **/
    public class ProductSupplier
    {


        public int ProductSupplierId { get; set; }//PSID

        public int ProductID { get; set; }//product ID
        public int SupplierID { get; set; }//supplier ID

        public String ProductName { get; set; }//productname
        public String SupplierName { get; set; }//supplier name
       
        public override string ToString()//display ProductSupplier information
        {
            return "ID: " + ProductSupplierId + " ProductID: " + ProductID +
             " Product Name: " + ProductName + " SupplierID: " + SupplierID + " Supplier Name: " + SupplierName;
        }

    }
}
