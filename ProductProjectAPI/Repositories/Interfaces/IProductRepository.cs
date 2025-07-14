using ProductProjectAPI.Model;

namespace ProductProjectAPI.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Product GetById(int id);
        IEnumerable<Product> GetAll();
        IEnumerable<Product> GetRange(int skip, int take);
        void Add(Product product);
        void Update(Product editableProduct);
        void Remove(int id);
    }
}
