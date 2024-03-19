using Lab5.BLL;
using Lab5.BLL.Abstractions;
using Lab5.BLL.Entities;

namespace Lab5.DAL;

public class MockAccountRepository : IAccountRepository
{
    public Account? FindAccountByID(int id)
    {
        return new Account(1, 1234, 1000);
    }

    public ChangeBalanceResult ChangeAccountBalance(Account account, double amountOfCash, OperationType operationType)
    {
        if (account != null && operationType == OperationType.Withdraw && account.Balance < amountOfCash)
        {
            return ChangeBalanceResult.Error;
        }

        return ChangeBalanceResult.Success;
    }

    public void AddAccount(Account account)
    {
        return;
    }

    public IEnumerable<string> FindOperationsHistoryOfAccount(Account account)
    {
        return new List<string>() { "id - 1, created account" };
    }

    public long FindAccountBalance(Account account)
    {
        return 1100;
    }
}