using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShopCore2.Models
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts();

        Product GetProductById(int productId);
    }
}
