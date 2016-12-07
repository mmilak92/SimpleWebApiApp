using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace CallWebApi
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductCategory { get; set; }
        public decimal ProductPrice { get; set; }
    }
}