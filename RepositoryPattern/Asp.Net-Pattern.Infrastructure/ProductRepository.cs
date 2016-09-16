using Asp.Net_Pattern.Core;
using Asp.Net_Pattern.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Asp.Net_Pattern.Infrastructure
{
    public class ProductRepository : IProductRepository
    {
        private ProductContext context = new ProductContext();

        public void Add(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
        }

        public void Edit(Product product)
        {
            context.Entry(product).State = System.Data.Entity.EntityState.Modified;
        }

        public Product FindById(int id)
        {
            var result = (from r in context.Products where r.Id == id select r).FirstOrDefault();
            return result;
        }

        public List<Product> GetProducts()
        {
            return context.Products.ToList();
        }

        public void Remove(int id)
        {
            Product p = context.Products.Find(id);
            context.Products.Remove(p);
            context.SaveChanges();
        }
    }
}