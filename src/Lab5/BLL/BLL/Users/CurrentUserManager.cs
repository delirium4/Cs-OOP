using Lab5.BLL.Contracts.Users;
using Lab5.BLL.Entities;

namespace Lab5.BLL.Users;

public class CurrentUserManager : ICurrentUserService
{
    public User? User { get; set; }
}