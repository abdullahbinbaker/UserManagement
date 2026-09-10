using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using UserManagement.Application.DTOs;
using UserManagement.Domain.Entities;

namespace UserManagement.Application.Mappers
{
    public class UserProfile : Profile
    {
public UserProfile()
        {
            CreateMap<UserDto, User>().ReverseMap();
        }
    }
}
