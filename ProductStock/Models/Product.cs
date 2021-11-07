using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProductStock.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string NameOfProduct { get; set; }
        public string Description { get; set; }
        public string InStock { get; set; }

        public string Category { get; set; }

    }

    public class ProductDBContext : DbContext
    {
        public ProductDBContext()
        { }
        public DbSet<Product> Products { get; set; }
    }
}