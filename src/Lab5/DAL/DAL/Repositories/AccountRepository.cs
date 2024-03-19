using Lab5.BLL;
using Lab5.BLL.Abstractions;
using Lab5.BLL.Entities;
using Npgsql;

namespace Lab5.DAL.Repositories;

public class AccountRepository : IAccountRepository
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Security",
        "CA2100:Review SQL queries for security vulnerabilities",
        Justification = "Method already uses a Stored Procedure")]
    public Account? FindAccountByID(int id)
    {
        using var connection = new NpgsqlConnection("Host=localhost;Port=5432;Username=postgres;Password=postgres;Database=atm");
        connection.Open();
        string sql = $@"
                            select account_id, account_pin, balance
                            from accounts
                            where account_id = {id};
                           ";
        using var command = new NpgsqlCommand(sql, connection);

        using NpgsqlDataReader reader = command.ExecuteReader();

        if (reader.Read() is false)
            return null;

        var account = new Account(
            Id: reader.GetInt64(0),
            Pincode: reader.GetInt64(1),
            Balance: reader.GetInt64(2));
        connection.Dispose();
        command.Dispose();
        return account;
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Security",
        "CA2100:Review SQL queries for security vulnerabilities",
        Justification = "Method already uses a Stored Procedure")]
    public ChangeBalanceResult ChangeAccountBalance(Account account, double amountOfCash, OperationType operationType)
    {
        using var connection = new NpgsqlConnection("Host=localhost;Port=5432;Username=postgres;Password=postgres;Database=atm");
        connection.Open();
        if (operationType == OperationType.Withdraw)
        {
            if (account != null && account.Balance > amountOfCash)
            {
                string sql = $@"update accounts
                            set balance = balance - {amountOfCash} 
                            where account_id = {account.Id};
                            insert into operations_history values(
                                 {account.Id},
                                 'withdraw';
                            )
                            ";
                using var command = new NpgsqlCommand(sql, connection);
                command.ExecuteReader();
                command.Dispose();
                connection.Dispose();
                return ChangeBalanceResult.Success;
            }

            connection.Dispose();
            return ChangeBalanceResult.Error;
        }

        if (account != null)
        {
            string sql = $@"update accounts
                        set balance = balance + {amountOfCash} 
                        where account_id = {account.Id};
                        insert into operations_history values(
                                 {account.Id},
                                 'replenishment'
                            )
                           ";
            using var command = new NpgsqlCommand(sql, connection);
            command.ExecuteReader();
            command.Dispose();
            connection.Dispose();
            return ChangeBalanceResult.Success;
        }

        connection.Dispose();
        return ChangeBalanceResult.Success;
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Security",
        "CA2100:Review SQL queries for security vulnerabilities",
        Justification = "Method already uses a Stored Procedure")]
    public void AddAccount(Account account)
    {
        using var connection = new NpgsqlConnection("Host=localhost;Port=5432;Username=postgres;Password=postgres;Database=atm");
        connection.Open();
        if (account != null)
        {
            string sql = $@"
                            insert into accounts values(
                                {account.Id},
                                {account.Pincode},
                                balance = 0                                                        
                            );
                            insert into operations_history values(
                                 {account.Id},
                                 'creation';
                            )
                           ";
            using var command = new NpgsqlCommand(sql, connection);
            command.ExecuteReader();
            command.Dispose();
            connection.Dispose();
        }
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Security",
        "CA2100:Review SQL queries for security vulnerabilities",
        Justification = "Method already uses a Stored Procedure")]
    public IEnumerable<string> FindOperationsHistoryOfAccount(Account account)
    {
        using var connection = new NpgsqlConnection("Host=localhost;Port=5432;Username=postgres;Password=postgres;Database=atm");
        connection.Open();
        if (account is not null)
        {
            string sql = $@"
                            select account_id, operation_type
                            from operations_history
                            where account_id = {account.Id}                                                        
                           ";
            using var command = new NpgsqlCommand(sql, connection);
            using NpgsqlDataReader reader = command.ExecuteReader();
            IEnumerable<string> operationsHistory = new List<string>();
            while (reader.Read())
            {
                operationsHistory = operationsHistory.Append(reader.GetString(0) + reader.GetString(1));
            }

            command.Dispose();
            connection.Dispose();
            return operationsHistory;
        }

        throw new InvalidOperationException();
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Security",
        "CA2100:Review SQL queries for security vulnerabilities",
        Justification = "Method already uses a Stored Procedure")]
    public long FindAccountBalance(Account account)
    {
        using var connection = new NpgsqlConnection("Host=localhost;Port=5432;Username=postgres;Password=postgres;Database=atm");
        connection.Open();
        if (account is not null)
        {
            string sql = $@"
                            select balance
                            from accounts
                            where account_id = {account.Id}                                                        
                           ";
            using var command = new NpgsqlCommand(sql, connection);
            using NpgsqlDataReader reader = command.ExecuteReader();
            return reader.GetInt32(0);
        }

        throw new InvalidOperationException();
    }
}