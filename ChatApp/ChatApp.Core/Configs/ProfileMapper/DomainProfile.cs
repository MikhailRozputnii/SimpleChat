using AutoMapper;
using ChatApp.Core.Dto;
using ChatApp.Domains;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatApp.Core.Configs.ProfileMapper
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<UserRole, UserRoleDto>().ReverseMap();
            CreateMap<Role, RoleDto>().ReverseMap();

        }
    }
}
