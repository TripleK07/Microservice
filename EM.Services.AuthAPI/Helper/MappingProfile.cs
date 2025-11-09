using System;
using AutoMapper;
using EM.Core.Models.Dto;
using EM.Services.AuthAPI.Models;

namespace EM.Services.AuthAPI.Helper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<RegisterationRequestDto, ApplicationUser>();
        CreateMap<ApplicationUser, UserDto>();
    }
}
