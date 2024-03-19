using Lab5.BLL.Entities;

namespace Lab5.BLL.Abstractions;

public interface IAccountRepository
{
    Account? FindAccountByID(int id);
    ChangeBalanceResult ChangeAccountBalance(Account account, double amountOfCash, OperationType operationType);
    void AddAccount(Account account);
    IEnumerable<string> FindOperationsHistoryOfAccount(Account account);
    long FindAccountBalance(Account account);
}