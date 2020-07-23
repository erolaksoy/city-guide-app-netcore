using AutoMapper;
using Study.SehirRehberi.Dto.Concrete.CityDtos;
using Study.SehirRehberi.Dto.Concrete.UserDtos;
using Study.SehirRehberi.Entitiy.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Study.SehirRehberi.WebApi.Mapping.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<City, CityListDto>().ForMember(dest => dest.PhotoUrl, opt => opt.MapFrom(src => src.Photos.FirstOrDefault(src => src.IsMain).Url));
            CreateMap<City, CityAddDto>();
            CreateMap<CityAddDto, City>();

            CreateMap<City, CityDetailDto>();
            CreateMap<CityDetailDto, City>();

            CreateMap<User, UserRegisterDto>();
            CreateMap<UserRegisterDto, User>();
            CreateMap<User, UserLoginDto>();
            CreateMap<UserLoginDto, User>();
        }
    }
}
