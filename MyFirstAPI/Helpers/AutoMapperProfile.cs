using AutoMapper;
using MyFirstAPI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstAPI.Helpers
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            //Turn A -> B
            CreateMap<AppUser, MemberDTO>()
                .ForMember(dest => dest.City, options => options.MapFrom(src => src.CityofOrigin))
                .ForMember(dest => dest.Age, options => options.MapFrom(src => src.DateOfBirth.CalculateAge()))
                .ForMember(dest => dest.ProfilePicture, options => options.MapFrom(src => src.Photos.FirstOrDefault(x => x.IsProfilePicture).Url));

                
        }
    }
}
