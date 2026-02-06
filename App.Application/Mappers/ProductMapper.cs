using App.Application.DTOs;
using Mapster;

namespace App.Application.Mappers
{
    public class ProductMapper : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Domain.Entities.Product, ProductDto>()
                .Map(dest => dest.Category.Name, src => src.Category.Name);
        }
    }
}
