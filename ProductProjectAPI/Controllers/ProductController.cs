using Microsoft.AspNetCore.Mvc;
using ProductProjectAPI.Model;
using ProductProjectAPI.Repositories.Interfaces;

namespace ProductProjectAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        [HttpGet("{id}")]
        public Product GetById(int id)
        {
            return _productRepository.GetById(id);
        }

        [HttpGet]
        public IEnumerable<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        [HttpGet("{skip}/{take}")]
        public IEnumerable<Product> GetRange(int skip, int take)
        {
            return _productRepository.GetRange(skip, take);
        }

        [HttpPost]
        public Product Add(Product product)
        {
            _productRepository.Add(product);
            return product;
        }

        [HttpPut]
        public void Update(Product editableProduct)
        {
            _productRepository.Update(editableProduct);
        }

        [HttpDelete("{id}")]
        public void Remove(int id)
        {
            _productRepository.Remove(id);
        }
    }
}
