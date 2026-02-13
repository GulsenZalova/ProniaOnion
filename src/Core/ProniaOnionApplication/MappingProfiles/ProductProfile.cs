using AutoMapper;
using ProniaOnion.src.Domain;

namespace ProniaOnion.src.Application
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product,ProductItemDTO>();

        }
    }
}