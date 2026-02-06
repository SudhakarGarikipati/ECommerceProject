using App.Application.DTOs;
using App.Application.Repositories;
using App.Application.Services.Abstraction;
using App.Domain.Entities;
using MapsterMapper;

namespace App.Application.Services.Implementation
{
    public class CatalogAppService : ICatalogAppService
    {
        private readonly ICatalogRepository _catalogRepository;
        private readonly IMapper _mapper;

        public CatalogAppService(ICatalogRepository catalogRepository, IMapper mapper) { 
            _catalogRepository = catalogRepository;
            _mapper = mapper;
        }

        public void Add(ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            _catalogRepository.Add(product);
        }

        public void Delete(int id)
        {
            _catalogRepository.Delete(id);
        }

        public IEnumerable<ProductDto> GetAll()
        {
            var products = _catalogRepository.GetAll();
            return _mapper.Map<List<ProductDto>>(products);
        }

        public ProductDto GetById(int id)
        {
           var product = _catalogRepository.GetById(id);
            return _mapper.Map<ProductDto>(product);
        }

        public IEnumerable<ProductDto> GetByIds(int[] ids)
        {
            var products = _catalogRepository.GetByIds(ids);
            return _mapper.Map<List<ProductDto>>(products);
        }

        public void Update(ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            _catalogRepository.Update(product);
        }
    }
}
