using App.Application.Repositories;
using App.Domain.Entities;

namespace App.Infrastructure.Persistance.Repositories
{
    public class CatalogRepository : ICatalogRepository
    {
        private readonly CatalogServiceDbContext _context;
        public CatalogRepository(CatalogServiceDbContext context) {
            _context = context;
        }

        public void Add(Product product)
        {
            _context.Products.Add(product);
        }

        public void Delete(int id)
        {
            var product = GetById(id);
            if (product != null)
            {
                _context.Products.Remove(product);
            }
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public Product GetById(int id)
        {
            return _context.Products.Find(id);
        }

        public IEnumerable<Product> GetByIds(int[] ids)
        {
            return _context.Products.Where(p => ids.Contains(p.ProductId)).ToList();
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public void Update(Product product)
        {
           _context.Products.Update(product);
        }
    }
}
