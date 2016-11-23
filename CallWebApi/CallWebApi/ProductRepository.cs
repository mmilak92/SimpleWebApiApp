
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
            
                StoreDBContext productDBContext1 = new StoreDBContext();
                return productDBContext1.Products.ToList();
        }
        public Product GetProduct(int id)
        {
            StoreDBContext productDBContext1 = new StoreDBContext();
            var pro= productDBContext1.Products.Where((p) => p.Id == id).FirstOrDefault();
            return pro;
        }
    }
}