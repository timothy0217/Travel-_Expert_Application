using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace supSupplier
{
    public class ProductSupplier
    {


        public int ProductSupplierId { get; set; }

        public int ProductID { get; set; }
        public int SupplierID { get; set; }

        public String ProductName { get; set; }
        public String SupplierName { get; set; }
       
        public override string ToString()
        {
            return "ID: " + ProductSupplierId + " ProductID: " + ProductID +
             " Product Name: " + ProductName + " SupplierID: " + SupplierID + " Supplier Name: " + SupplierName;
        }

    }
}
