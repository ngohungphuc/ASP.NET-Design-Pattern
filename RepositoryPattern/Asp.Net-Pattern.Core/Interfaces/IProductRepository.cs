using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asp.Net_Pattern.Core.Interfaces
{
    public interface IProductRepository
    {
        void Add(Product product);

        void Edit(Product product);

        void Remove(int id);

        List<Product> GetProducts();

        Product FindById(int id);
    }
}