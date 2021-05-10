using Microsoft.EntityFrameworkCore;
using MyFirstAPI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstAPI.Repositories
{
    public class AppUserRepository : IAppUserRepository
    {
        private AppContext _context;
        public AppUserRepository(AppContext context)
        {
            _context = context;
        }

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
