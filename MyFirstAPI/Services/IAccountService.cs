using System.Threading.Tasks;

namespace MyFirstAPI.Services
{
    public interface IAccountService
    {
        Task<AppUser> RegisterAsync(string username, string password);
        Task<bool> UserExists(string name);
    }
}