using AutoMapper;
using ProniaOnion.src.Domain;

namespace ProniaOnion.src.Application
{
    public class AppUserProfile : Profile
    {
        public AppUserProfile()
        {
             CreateMap<RegisterDTO,AppUser>();
        }
    }
}