using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SupProd
{ /**Purpose:When select a product.list all of corresponding suppliers
    *Author: David ,Zhu
    *Date:JAn23,2018
    **/
    public static  class OperationPS
    {
        public static int currentProdId;
        public static int currentSupId;
        //  public static List<ProductSupplier> currentPS = new List<ProductSupplier>();
        public static List<ProductSupplier> getCurrentPS(int produtid, string OperationSign)//pass a specific productsupplier object into loadprosupplier function and return all rows with same productID
        {
            currentProdId = produtid;//get current selected product's productId in listbox of product(topleft)

            return ProductSupplierDB.GetAllSuppliersForSelectedProduct(currentProdId);//get all rows where their productID is equal to current selected row's productID
        }    
        public static List<ProductSupplier> getCurrentPS(int produtid, int supplierid,string OperationSign)//pass a specific productsupplier object into loadprosupplier function and return all rows with same productID
        {
            currentProdId = produtid;//get current selected product's productId in listbox of product(topleft)
            currentSupId = supplierid;

           return ProductSupplierDB.GetOneSuppliersForSelectedProduct(currentProdId, currentSupId);//when go to take update or delete operation,only foucuseon on current row

            
        }

    }
}
