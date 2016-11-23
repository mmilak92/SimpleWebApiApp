using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace CallWebApi
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductCategory { get; set; }
        public int ProductPrice { get; set; }
    }
}