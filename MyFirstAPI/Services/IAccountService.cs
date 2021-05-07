using System.Threading.Tasks;

namespace MyFirstAPI.Services
{
    public interface IAccountService
    {
        Task<AppUser> Register(string username, string password);
    }
}