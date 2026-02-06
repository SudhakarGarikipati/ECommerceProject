using App.Domain.Entities;

namespace App.Application.Repositories
{
    public interface ICatalogRepository
    {
        IEnumerable<Product> GetAll();

        Product GetById(int id);

        void Add(Product product);

        void Update(Product product);

        IEnumerable<Product> GetByIds(int[] ids);

        void Delete(int id);

        int SaveChanges();
    }
}
