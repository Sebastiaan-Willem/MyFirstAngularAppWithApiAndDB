using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyFirstAPI.Repositories
{
    public interface IAppUserRepository
    {
        Task AddUser(AppUser user);
        Task DeleteUser(int id);
        Task<AppUser> GetUser(int id);
        Task<List<AppUser>> GetUsers();
        Task UpdateUser(AppUser user);
    }
}