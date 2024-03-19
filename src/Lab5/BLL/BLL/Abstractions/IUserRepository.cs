using Lab5.BLL.Entities;

namespace Lab5.BLL.Abstractions;

public interface IUserRepository
{
    User? FindUserByUsername(string username);
}