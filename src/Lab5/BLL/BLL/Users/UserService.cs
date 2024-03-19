using Lab5.BLL.Abstractions;
using Lab5.BLL.Contracts.LoginResults;
using Lab5.BLL.Contracts.Users;
using Lab5.BLL.Entities;

namespace Lab5.BLL.Users;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;
    private readonly CurrentUserManager _currentUserManager;

    public UserService(IUserRepository repository, CurrentUserManager currentUserManager)
    {
        _repository = repository;
        _currentUserManager = currentUserManager;
    }

    public LoginResult Login(string username, string password)
    {
        User? user = _repository.FindUserByUsername(username);

        if (user is null)
        {
            return new LoginResult.NotFound();
        }

        if (user.UserPassword != password)
        {
            throw new ArgumentException("Password or Username is incorrect");
        }

        _currentUserManager.User = user;
        return new LoginResult.Success();
    }
}