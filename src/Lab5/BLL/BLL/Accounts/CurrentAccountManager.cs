using Lab5.BLL.Contracts.Accounts;
using Lab5.BLL.Entities;

namespace Lab5.BLL.Accounts;

public class CurrentAccountManager : ICurrentAccountService
{
    public Account? Account { get; set; }
}