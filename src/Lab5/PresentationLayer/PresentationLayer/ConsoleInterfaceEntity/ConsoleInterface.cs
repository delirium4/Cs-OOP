using System.Globalization;
using Lab5.BLL.Accounts;
using Lab5.BLL.Contracts.LoginResults;
using Lab5.BLL.Entities;
using Lab5.BLL.Users;
using Lab5.DAL.Repositories;

namespace Lab5.PresentationLayer.ConsoleInterfaceEntity;

public class ConsoleInterface
{
    private UserService _userService = new UserService(new UserRepository(), new CurrentUserManager());
    private AccountService _accountService = new AccountService(new AccountRepository(), new CurrentAccountManager());

    public void Run()
    {
        Console.WriteLine("Log into your user account");
        Console.WriteLine("Your username: \n");
        string username = Console.ReadLine() ?? throw new InvalidOperationException();
        Console.WriteLine("Your password: \n");
        string password = Console.ReadLine() ?? throw new InvalidOperationException();
        LoginResult userLoginResult = _userService.Login(username, password);
        if (userLoginResult is LoginResult.Success)
        {
            Console.WriteLine("Great! Now log into your bank account");
            Console.WriteLine("Your bank account number: \n");
            int id = int.Parse(
                Console.ReadLine() ?? throw new InvalidOperationException(),
                NumberStyles.Any,
                new NumberFormatInfo());
            Console.WriteLine("Your pincode: \n");
            int pincode = int.Parse(
                Console.ReadLine() ?? throw new InvalidOperationException(),
                NumberStyles.Integer,
                new NumberFormatInfo());
            LoginResult accountLoginResult = _accountService.Login(id, pincode, userLoginResult);
            if (accountLoginResult is LoginResult.Success)
            {
                while (true)
                {
                    Console.WriteLine("Great! Now choose an operation by putting a number: \nCreate account(1) \nReplenish balance(2) \nWithdraw cash(3) \nCheck balance(4) \nCheck operations history(5) \nExit(6) \n");
                    int operation = int.Parse(
                        Console.ReadLine() ?? throw new InvalidOperationException(),
                        NumberStyles.Integer,
                        new NumberFormatInfo());
                    if (operation == 1)
                    {
                        Console.WriteLine("Now put a pincode for yout bank account: \n");
                        int newPincode = int.Parse(
                            Console.ReadLine() ?? throw new InvalidOperationException(),
                            NumberStyles.Integer,
                            new NumberFormatInfo());
                        _accountService.CreateAccount(new Account(pincode, newPincode, 0));
                    }
                    else if (operation == 2)
                    {
                        Console.WriteLine("Input sum of money");
                        int money = int.Parse(
                            Console.ReadLine() ?? throw new InvalidOperationException(),
                            NumberStyles.Integer,
                            new NumberFormatInfo());
                        _accountService.ReplenishBalance(money);
                    }
                    else if (operation == 3)
                    {
                        Console.WriteLine("Input sum of money");
                        int money = int.Parse(
                            Console.ReadLine() ?? throw new InvalidOperationException(),
                            NumberStyles.Integer,
                            new NumberFormatInfo());
                        _accountService.WithdrawCash(money);
                    }
                    else if (operation == 4)
                    {
                        Console.WriteLine(_accountService.CheckBalance());
                    }
                    else if (operation == 5)
                    {
                        Console.WriteLine(_accountService.ShowOperationHistory());
                    }
                    else if (operation == 6)
                    {
                        break;
                    }
                }

                return;
            }
        }

        throw new ArgumentException("Invalid username or password");
    }
}