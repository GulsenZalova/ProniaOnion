using AutoMapper;
using ProniaOnion.src.Domain;

namespace ProniaOnion.src.Application
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryItemDTO>();
            CreateMap<Category, GetCategoryDTO>();
            CreateMap<CreateCategoryDTO,Category>();
            CreateMap<UpdateCategoryDTO,Category>().ForMember(c=>c.Id,opt=>opt.Ignore());
        }
    }
}