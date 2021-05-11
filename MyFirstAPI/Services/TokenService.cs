using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstAPI.Services
{
    public class TokenService : ITokenService
    {
        /**
         *
         *  Login Tokens (More info on https://jwt.io/)
         *   
         *  These allow login sessions for users, like a "pass" for an event,
         *  as long as the pass is valid, the user can access the application
         */

        private readonly SymmetricSecurityKey _key;

        public TokenService(IConfiguration config)
        {
            _key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(config["TokenKey"]));
            //TokenKey -> custom string that will be used to encrypt and decrypt the tokens
            //defined in appsettings.json
            
        }

        public string CreateToken(AppUser user)
        {
            //Define new Claim, based on the matching of the Name property
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.NameId, user.Name)
            };

            //Choose an encryption algorithm (TOKEN HEADER)
            var creds = new SigningCredentials(
                _key, SecurityAlgorithms.HmacSha512);

            //Define (TOKEN PAYLOAD)
            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescription);

            return tokenHandler.WriteToken(token);

            //TOKEN SIGNATURE will verify the validity of the token based on the encryption selected in the HEADER
            //(Framework will do this for us, we don't have to manually set this up)
        }
    }
}
