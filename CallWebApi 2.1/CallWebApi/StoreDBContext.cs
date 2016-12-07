
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CallWebApi
{
    public class StoreDBContext: DbContext
    {
        public DbSet<Product> Products { get; set; }
    }
}