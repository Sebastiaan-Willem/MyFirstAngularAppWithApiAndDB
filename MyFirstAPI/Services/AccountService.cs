using Microsoft.EntityFrameworkCore;
using MyFirstAPI.DTO;
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

        public async Task<AppUser> LoginAsync(string name, string password)
        {
            //SingleorDefault -> will throw error when it finds more than one instance.
            //(Default will turn it into null when it can't find any, like with FirstorDefault)
            var user = await _context.Users.SingleOrDefaultAsync(x => x.Name == name);

            if(user == null)
            {
                throw new UnauthorizedAccessException("Invalid Username/Password");
            }
            
            //if user is found, compare password HASHES(!) to verify correct password
            //Hash the password based on the user's personal SALT so the hashes match. (otherwise it'll generate a different hash)
            using var hmac = new HMACSHA512(user.PasswordSalt);
            var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

            for (int i = 0; i < hash.Length; i++)
            {
                //compare both byte arrays per element to see if it's an exact match
                if (hash[i] != user.PasswordHash[i])
                {
                    throw new UnauthorizedAccessException("Invalid Username/Password");
                }
            }

            

            //will only return the user if it passes both if checks above.
            return user;
        }

        public async Task<bool> UserExists(string userName)
        {
            return await _context.Users.AnyAsync(x => x.Name == userName.ToLower());
        }

    }
}
