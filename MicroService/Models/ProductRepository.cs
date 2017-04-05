using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroService.Models
{
    public class ProductRepository : IProductRepository
    {
        private static readonly List<Product> Repo = new List<Product>();
        public void Add(Product product)
        {
            if (Exist(product.Id)) return;
            Repo.Add(product);
        }

        public void Remove(int id)
        {
            var obj = Repo.FirstOrDefault(p => p.Id == id);
            if (obj != null)
                Repo.Remove(obj);
        }

        public bool Exist(int id)
        {
            return Repo.Any(r => r.Id == id);
        }

        public void Update(Product product)
        {
            var obj = Repo.FirstOrDefault(p => p.Id == product.Id);
            if (obj == null) return;
            var idx = Repo.IndexOf(obj);
            Repo.Remove(obj);
            Repo.Insert(idx, product);
        }

        public Product Get(int id)
        {
            return Repo.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Product> GetAll()
        {
            return Repo;
        }
    }
}
