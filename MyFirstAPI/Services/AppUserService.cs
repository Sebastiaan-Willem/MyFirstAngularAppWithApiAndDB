using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstAPI.Services
{
    public class AppUserService : IAppUserService
    {
        private AppContext _context;
        public AppUserService(AppContext context)
        {
            _context = context;
        }


        //private List<AppUser> _users = new List<AppUser>
        //{
        //    new AppUser{Id = 1, Name = "User1"},
        //    new AppUser{Id = 2, Name = "User2"},
        //    new AppUser{Id = 3, Name = "User3"},
        //    new AppUser{Id = 4, Name = "User4"},
        //    new AppUser{Id = 5, Name = "User5"},
        //};

        public async Task<List<AppUser>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }
        public async Task<AppUser> GetUser(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task AddUser(AppUser user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUser(AppUser user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteUser(int id)
        {
            AppUser user = new AppUser { Id = id };
            _context.Users.Attach(user);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
}
