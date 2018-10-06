using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShopCore2.Models
{
    public class MockProductRepository : IProductRepository
    {
        private List<Product> _products;

        public MockProductRepository()
        {
            if(_products == null)
            {
                InitializeProducts();
            }
        }

        public void InitializeProducts()
        {
            _products = new List<Product>
            {
                new Product{Id=1,Name="Apple",
                    Price =22.95M,ShortDescription="Our best products available for you!!!",
                    LongDescription ="Icing carrot cake jelly-o cheesecake. Sweet marzipa, girl very bad and manager very nice person but it's not true.",
                    ImageUrl ="https://pixabay.com/photo-634572/", IsProductOfTheWeek = false,
                    ImageThumbnailUrl = "https://pixabay.com/photo-634572/"
                },
                new Product { Id = 2, Name = "Orange", Price = 22.95M, ShortDescription = "Our best products available for you!!!", LongDescription = "Icing carrot cake jelly-o cheesecake. Sweet marzipa, girl very bad and manager very nice person but it's not true." },
                new Product{Id=1,Name="Banana", Price=22.95M,ShortDescription="Our best products available for you!!!",LongDescription="Icing carrot cake jelly-o cheesecake. Sweet marzipa, girl very bad and manager very nice person but it's not true."}
            };
    }

        public IEnumerable<Product> GetAllProducts()
        {
            return _products;
        }

        public Product GetProductById(int productId)
        {
            return _products.FirstOrDefault(p => p.Id == productId);

        }
    }
}
