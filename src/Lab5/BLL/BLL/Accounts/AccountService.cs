using Lab5.BLL.Abstractions;
using Lab5.BLL.Contracts.Accounts;
using Lab5.BLL.Contracts.LoginResults;
using Lab5.BLL.Entities;

namespace Lab5.BLL.Accounts;

public class AccountService : IAccountService
{
    private readonly IAccountRepository _repository;
    private readonly CurrentAccountManager _currentAccountManager;

    public AccountService(IAccountRepository repository, CurrentAccountManager currentAccountManager)
    {
        _repository = repository;
        _currentAccountManager = currentAccountManager;
    }

    public LoginResult Login(int id, int pincode, LoginResult userLoginResult)
    {
        if (userLoginResult is Success)
        {
            Account? account = _repository.FindAccountByID(id);
            if (account is null)
            {
                return new NotFound();
            }

            if (account.Pincode != pincode)
            {
                throw new ArgumentException("Pincode is incorrect");
            }

            _currentAccountManager.Account = account;
            return new Success();
        }

        throw new InvalidOperationException("You should log in first");
    }

    public ChangeBalanceResult WithdrawCash(double amountOfCash)
    {
        if (_currentAccountManager.Account is not null)
            return _repository.ChangeAccountBalance(_currentAccountManager.Account, amountOfCash, OperationType.Withdraw);
        throw new InvalidOperationException();
    }

    public void ReplenishBalance(double amountOfCash)
    {
        if (_currentAccountManager.Account != null)
            _repository.ChangeAccountBalance(_currentAccountManager.Account, amountOfCash, OperationType.Replenishment);
    }

    public double CheckBalance()
    {
        if (_currentAccountManager.Account != null)
        {
            return _repository.FindAccountBalance(_currentAccountManager.Account);
        }

        throw new InvalidOperationException("You have not logged into your Bank account");
    }

    public void CreateAccount(Account account)
    {
        _repository.AddAccount(account);
    }

    public IEnumerable<string> ShowOperationHistory()
    {
        if (_currentAccountManager.Account != null)
        {
           return _repository.FindOperationsHistoryOfAccount(_currentAccountManager.Account);
        }

        throw new InvalidOperationException("You have not logged into your Bank account");
    }
}