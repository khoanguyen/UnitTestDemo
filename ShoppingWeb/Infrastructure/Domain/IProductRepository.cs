using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingWeb.Infrastructure.Domain
{
    public interface IProductRepository
    {
        IEnumerable<Product> AllProducts();
        Product FindById(int id);
    }
}
