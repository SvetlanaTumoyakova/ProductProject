using ProductProjectAPI.Model;
using ProductProjectAPI.Repositories.Interfaces;

namespace OnlineStore.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private static readonly List<Product> products = [];
        public ProductRepository()
        {
            if (products == null || products.Count == 0)
            {
                var initialProducts = new List<Product>
            {
                new Product { Id = 1, Name = "Apple iPhone 14", Description = "Latest model of iPhone with advanced features." },
                new Product { Id = 2, Name = "Samsung Galaxy S23", Description = "High-performance smartphone with excellent camera." },
                new Product { Id = 3, Name = "Sony WH-1000XM4", Description = "Noise-cancelling over-ear headphones." },
                new Product { Id = 4, Name = "Dell XPS 13", Description = "Compact and powerful laptop for professionals." },
                new Product { Id = 5, Name = "Nike Air Max 270", Description = "Stylish and comfortable sneakers." },
                new Product { Id = 6, Name = "Amazon Echo Dot", Description = "Smart speaker with Alexa." },
                new Product { Id = 7, Name = "Fitbit Charge 5", Description = "Advanced fitness tracker with health monitoring." },
                new Product { Id = 8, Name = "GoPro HERO10", Description = "Action camera for adventure enthusiasts." },
                new Product { Id = 9, Name = "Apple MacBook Air", Description = "Lightweight laptop with M1 chip." },
                new Product { Id = 10, Name = "Samsung QLED TV", Description = "High-quality 4K television with vibrant colors." }
            };

                products.AddRange(initialProducts);
            }
        }
        public Product GetById(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            return product;
        }
        public IEnumerable<Product> GetAll()
        {
            return products ?? new List<Product>();
        }
        public IEnumerable<Product> GetRange(int skip, int take)
        {
            return products.Skip(skip).Take(take);
        }
        public void Add(Product product)
        {
            products.Add(product);
        }
        public void Update(Product editableProduct)
        {
            var product = products.FirstOrDefault(p => p.Id == editableProduct.Id);
            product.Name = editableProduct.Name;
            product.Description = editableProduct.Description;
        }
        public void Remove(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            products.Remove(product);
        }
    }
}
