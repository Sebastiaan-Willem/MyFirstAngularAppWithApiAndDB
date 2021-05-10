using MyFirstAPI.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyFirstAPI.Services
{
    public interface IAppUserService
    {
        Task AddUser(AppUser user);
        Task DeleteUser(int id);
        Task<AppUser> GetUser(int id);
        Task<List<AppUser>> GetUsers();
        Task UpdateUser(AppUser user);
        Task<MemberDTO> GetMemberAsync(int id);
    }
}