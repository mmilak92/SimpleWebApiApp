using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CallWebApi
{
    public class ProductRepository
    {
        public List<Product> GetProducts()
        {

            StoreDBContext productDBContext = new StoreDBContext();
            try
            {
                var test = productDBContext.Products.ToList();
            }
            catch (Exception err) {
                err.Data.ToString();
            }
            return productDBContext.Products.ToList();
        }
        public Product GetProduct(int id)
        {
            StoreDBContext productDBContext = new StoreDBContext();
            var pro = productDBContext.Products.Where((p) => p.ProductID == id).FirstOrDefault();
            return pro;
        }
    }
}