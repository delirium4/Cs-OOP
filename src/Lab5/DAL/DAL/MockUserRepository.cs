using Lab5.BLL.Abstractions;
using Lab5.BLL.Entities;

namespace Lab5.DAL;

public class MockUserRepository : IUserRepository
{
    public User? FindUserByUsername(string username)
    {
        return new User(1, UserRole.CommonUser, "123", "Ivan");
    }
}