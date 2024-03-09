using WebApplication_AuthenticationService.BLL.Models;

namespace WebApplication_AuthenticationService.DAL.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        User GetByLogin(string login);
    }
}
