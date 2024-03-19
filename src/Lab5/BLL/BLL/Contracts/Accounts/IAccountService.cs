using Lab5.BLL.Contracts.LoginResults;
using Lab5.BLL.Entities;

namespace Lab5.BLL.Contracts.Accounts;

public interface IAccountService
{
    LoginResult Login(int id, int pincode, LoginResult userLoginResult);
    ChangeBalanceResult WithdrawCash(double amountOfCash);
    void ReplenishBalance(double amountOfCash);
    double CheckBalance();
    void CreateAccount(Account account);
    IEnumerable<string> ShowOperationHistory();
}