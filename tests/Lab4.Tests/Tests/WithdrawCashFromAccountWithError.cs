using Lab5.BLL;
using Lab5.BLL.Accounts;
using Lab5.BLL.Users;
using Lab5.DAL;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests.Tests;

public class WithdrawCashFromAccountWithError
{
    [Fact]
    public void RunTest()
    {
        var userService = new UserService(new MockUserRepository(), new CurrentUserManager());
        var accountService = new AccountService(new MockAccountRepository(), new CurrentAccountManager());
        accountService.Login(1, 1234,  userService.Login("Ivan", "123"));
        ChangeBalanceResult result = accountService.WithdrawCash(2000);
        Assert.True(result is ChangeBalanceResult.Error);
    }
}