using AutoMapper;

namespace WebApplication_AuthenticationService
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<User, UserViewModel>().ConstructUsing(v=>new UserViewModel(v));
        }

    }
}
