using AutoMapper;
using FuncionalTest.Api.ViewModels;
using FuncionalTest.Domain.Models;

namespace FuncionalTest.Api.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Account, AccountModel>()
                .ForMember(c => c.Id, options => options.MapFrom(c => c.Id));
         }
    }
}
