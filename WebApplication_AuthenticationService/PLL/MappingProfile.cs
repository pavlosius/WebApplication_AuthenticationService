using AutoMapper;
using WebApplication_AuthenticationService.BLL.Models;
using WebApplication_AuthenticationService.BLL.ViewModels;

namespace WebApplication_AuthenticationService.PLL
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserViewModel>().ConstructUsing(v => new UserViewModel(v));
        }

    }
}
