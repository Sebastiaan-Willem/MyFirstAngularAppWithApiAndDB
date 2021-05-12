using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyFirstAPI.DTO;
using MyFirstAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstAPI.Services
{
    public class AppUserService : IAppUserService
    {
        private IAppUserRepository _repo;
        private IMapper _mapper;
        public AppUserService(IAppUserRepository repo, IMapper mapper)
        {
            _repo = repo;
            //inject automapper(see startup.cs)
            _mapper = mapper;
        }


        public async Task<List<AppUser>> GetUsers()
        {
            return await _repo.GetUsers();
        }
        public async Task<AppUser> GetUser(int id)
        {
            return await _repo.GetUser(id);
        }

        public async Task AddUser(AppUser user)
        {
            await _repo.AddUser(user);
        }
        public async Task UpdateUser(AppUser user)
        {
            await _repo.UpdateUser(user);
        }
        public async Task DeleteUser(int id)
        {
            await _repo.DeleteUser(id);
        }


        public async Task<MemberDTO> GetMemberAsync(int id)
        {
            //get user
            AppUser user = await _repo.GetUser(id);

            //transform user to a member using Automapper
            MemberDTO member = _mapper.Map<MemberDTO>(user);
            return member;
        }

        public async Task<ICollection<MemberDTO>> GetMembersAsync()
        {
            List<AppUser> users = await _repo.GetUsers();

            //automapper can just as easily map a list as a single object
            List<MemberDTO> members = _mapper.Map<List<MemberDTO>>(users);

            return members;


        }
    }
}
