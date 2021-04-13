using AppCore.Entities;
using AppCore.ViewModel;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserEntity, UserViewModel>()
                .ForMember(des=> des.Id, opt => opt.MapFrom(s=> s.Id.ToString()));
            CreateMap<UserViewModel, UserEntity>();

            CreateMap<CreateUserViewModel, UserEntity>();
            CreateMap<UserEntity, CreateUserViewModel>();

        }
    }
}
