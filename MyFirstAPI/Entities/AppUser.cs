using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstAPI
{
    public class AppUser
    {
        public int Id { get; set; }
        public string Name { get; set; }

        
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Interests { get; set; }
        public string CityofOrigin { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime LastModified { get; set; } = DateTime.Now;

        //User has collection of photos
        //One to many relation
        public ICollection<Photo> Photos { get; set; }
    }
}
