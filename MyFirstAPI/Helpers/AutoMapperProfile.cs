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
            CreateMap<AppUser, MemberDTO>();

                
        }
    }
}
