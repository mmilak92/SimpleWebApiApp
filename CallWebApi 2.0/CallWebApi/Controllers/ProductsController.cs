
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
        public bool SaveProduct([FromBody]string data)
        {
            string[] split = data.Split('-');
            using (var context = new StoreDBContext())
            {
                Product product = new Product();
                product.ProductName = split[0];
                product.ProductCategory = split[1];
                product.ProductPrice =Convert.ToDecimal(split[2]);
                context.Products.Add(product);
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
        public bool UpdateProduct([FromBody]string data2)
        {
            string[] split = data2.Split('-');
            int id = Convert.ToInt32(split[0]);
            using (var context = new StoreDBContext())
            {
                var original = context.Products.SingleOrDefault(p => p.ProductID == id);
                if (original == null) { 
                return false;
                }
                Product updatedUser = new Product();
                updatedUser.ProductID = Convert.ToInt32(split[0]);
                updatedUser.ProductName = split[1];
                updatedUser.ProductCategory = split[2];
                updatedUser.ProductPrice =Convert.ToDecimal(split[3]);
                context.Entry(original).CurrentValues.SetValues(updatedUser);
                context.SaveChanges();
                return true;
            }
        }



    }
}
