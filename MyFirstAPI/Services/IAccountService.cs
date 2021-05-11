using MyFirstAPI.DTO;
using System.Threading.Tasks;

namespace MyFirstAPI.Services
{
    public interface IAccountService
    {
        Task<UserDTO> RegisterAsync(string username, string password);
        Task<bool> UserExists(string name);
        Task<UserDTO> LoginAsync(string name, string password);
        
    }
}