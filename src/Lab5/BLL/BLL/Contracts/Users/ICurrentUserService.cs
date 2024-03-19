using Lab5.BLL.Entities;

namespace Lab5.BLL.Contracts.Users;

public interface ICurrentUserService
{
    User? User { get; }
}