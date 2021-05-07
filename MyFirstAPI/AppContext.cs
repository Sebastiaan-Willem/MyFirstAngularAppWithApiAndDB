using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstAPI
{
    public class AppContext: DbContext
    {
        public DbSet<AppUser> Users { get; set; }

        public AppContext(DbContextOptions options):base(options)
        {

        }
    }
}
