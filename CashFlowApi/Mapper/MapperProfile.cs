using AutoMapper;
using CashFlowApi.DTOs;
using CashFlowApi.Models;
using CashFlowApi.ViewModels;

namespace CashFlowApi.Mapper
{
    public class MapperProfile: Profile
    {
        public MapperProfile()
        {
            CreateMap<User, UserViewModel>();
            CreateMap<User, UserDto>()
                .ReverseMap();
        }
    }
}
