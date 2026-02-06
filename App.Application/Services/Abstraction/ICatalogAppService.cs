using App.Application.DTOs;

namespace App.Application.Services.Abstraction
{
    public interface ICatalogAppService
    {
        IEnumerable<ProductDto> GetAll();

        ProductDto GetById(int id);

        void Add(ProductDto product);

        void Update(ProductDto product);

        IEnumerable<ProductDto> GetByIds(int[] ids);

        void Delete(int id);
    }
}
