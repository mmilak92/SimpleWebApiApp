
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;

namespace CallWebApi.Controllers
{
    public class ProductsController : ApiController
    {
        public IEnumerable<Product> getAllProduct() {
            ProductRepository rep = new ProductRepository();
            var data = rep.GetProducts();
            return data;
        }
        [HttpGet]
        [Route("api/products/GetProduct/{name}")]
        public IHttpActionResult GetProduct(string name)
        {
            Product prod = new Product();
            ProductRepository rep = new ProductRepository();
            var data = rep.GetProducts();
            foreach (var dat in data) {
                if (dat.ProductName.Contains(name)) {
                    prod = dat;
                }
            }
            if (prod == null)
            {
                return NotFound();
            }
            return Ok(prod);
        }
        [HttpPost]
        public bool SaveProduct([FromBody]Product product)
        {
            using (var context = new StoreDBContext())
            {
                Product newProduct = new Product();

                newProduct.ProductName = product.ProductName;
                newProduct.ProductCategory = product.ProductCategory;
                newProduct.ProductPrice = product.ProductPrice;
                context.Products.Add(newProduct);
                context.SaveChanges();
            }
            return true;
        }
        [HttpPost]
        public bool DeleteProduct([FromBody]int id)
        {
            using (var context = new StoreDBContext())
            {
                var product = context.Products.SingleOrDefault(p => p.ProductID == id);
                if (product == null)
                    return false;
                context.Products.Remove(product);
                context.SaveChanges();
                return true;
            }
        }

        [HttpPost]
        public bool UpdateProduct([FromBody]Product product)
        {

            int id = product.ProductID;
            using (var context = new StoreDBContext())
            {
                var original = context.Products.SingleOrDefault(p => p.ProductID == id);
                if (original == null) { 
                return false;
                }
                Product updatedUser = new Product();
                updatedUser.ProductID = product.ProductID;
                updatedUser.ProductName = product.ProductName;
                updatedUser.ProductCategory = product.ProductCategory;
                updatedUser.ProductPrice = product.ProductPrice;
                context.Entry(original).CurrentValues.SetValues(updatedUser);
                context.SaveChanges();
                return true;
            }
        }



    }
}
