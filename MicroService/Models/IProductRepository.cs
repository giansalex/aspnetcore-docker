using System.Collections.Generic;

namespace MicroService.Models
{
    public interface IProductRepository
    {
        Product Get(int id);
        IEnumerable<Product> GetAll();
        void Add(Product product);
        void Remove(int id);
        bool Exist(int id);
        void Update(Product product);
    }
}
