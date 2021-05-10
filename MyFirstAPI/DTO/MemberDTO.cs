using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstAPI.DTO
{
    public class MemberDTO
    {
        //here we add the data (from the Entity) we might want to show the users of the app.
        //(For Example: we don't need to show the passwordhash/salt.)
        
        public int Id { get; set; }
        public string Name { get; set; }

        public int Age { get; set; }
        public string Gender { get; set; }
        public string Interests { get; set; }
        public string City { get; set; }

        public string ProfilePicture { get; set; }
    }
}
