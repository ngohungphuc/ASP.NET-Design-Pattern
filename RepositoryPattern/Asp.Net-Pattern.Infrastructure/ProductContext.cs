using Asp.Net_Pattern.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Asp.Net_Pattern.Infrastructure
{
    public class ProductContext : DbContext
    {
        public ProductContext() : base("name=ProductAppConnectionString")
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}