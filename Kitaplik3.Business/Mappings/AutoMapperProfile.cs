using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Kitaplik3.Entities.Concrete;
using Kitaplik3.DTOs.UserDTOs;

namespace Kitaplik3.Business.Mappings
{
    public class AutoMapperProfile : Profile 
    {
        public AutoMapperProfile()
        {
            // User Mappings
            CreateMap<User, UserRegisterDto>().ReverseMap();
            CreateMap<User, UserLoginDto>().ReverseMap();
            CreateMap<User, UserListDto>().ReverseMap();
        }
    }
}
