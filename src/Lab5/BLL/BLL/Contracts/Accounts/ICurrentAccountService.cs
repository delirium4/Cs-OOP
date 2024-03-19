using Lab5.BLL.Entities;

namespace Lab5.BLL.Contracts.Accounts;

public interface ICurrentAccountService
{
    Account? Account { get; }
}