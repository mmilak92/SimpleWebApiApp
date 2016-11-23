
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
            //DeleteProduct(1);
            return data;
        }
        
        public IHttpActionResult GetProduct(int id, int br)
        {
            Product prod = new Product();
            ProductRepository rep = new ProductRepository();
            var data = rep.GetProducts();
            foreach (var dat in data) {
                if (dat.Id == id) {
                    prod = dat;
                }
            }
            if (prod == null)
            {
                return NotFound();
            }
            return Ok(prod);
        }

        [System.Web.Http.AcceptVerbs("GET", "POST")]
        [Route("api/products/PostNewItem/{id}/{name}/{category}/{price}")]
        public IHttpActionResult PostNewItem(int id, string name, string category, int price)
        {
            StoreDBContext db = new StoreDBContext();
            Product product = new Product();
            product.Id = id;
            product.ProductName = name;
            product.ProductCategory = category;
            product.ProductPrice = price;
            db.Products.Add(product);
            db.SaveChanges();

            return Ok();
        }

        public void DeleteProduct(int index) {
            ProductRepository rep = new ProductRepository();
            StoreDBContext db = new StoreDBContext();
            Product product = rep.GetProduct(index);
            db.Products.Remove(product);
            db.SaveChanges();
        }
    }
}
