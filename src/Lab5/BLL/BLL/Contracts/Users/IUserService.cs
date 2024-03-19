using Lab5.BLL.Contracts.LoginResults;

namespace Lab5.BLL.Contracts.Users;

public interface IUserService
{
    LoginResult Login(string username, string password);
}