using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstAPI.Services
{
    public class AccountService : IAccountService
    {
        private AppContext _context;
        public AccountService(AppContext appContext)
        {
            _context = appContext;
        }
        public async Task<AppUser> RegisterAsync(string username, string password)
        {
            //HMACSHA512 -> built in library to encrypt data (for our passwords in this case)
            using var hmac = new HMACSHA512();
            //using statement to force garbage collector (dispose) on this object when we're done with it

            var user = new AppUser
            {
                Name = username.ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)),
                PasswordSalt = hmac.Key,
            };


            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<bool> UserExists(string userName)
        {
            return await _context.Users.AnyAsync(x => x.Name == userName.ToLower());
        }
    }
}
