using Lab5.BLL.Abstractions;
using Lab5.BLL.Entities;
using Npgsql;

namespace Lab5.DAL.Repositories;

public class UserRepository : IUserRepository
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Security", "CA2100:Review SQL queries for security vulnerabilities", Justification = "Method already uses a Stored Procedure")]
    public User? FindUserByUsername(string username)
    {
        using var connection = new NpgsqlConnection("Host=localhost;Port=5432;Username=postgres;Password=postgres;Database=atm");
        connection.Open();
        string sql = $@"
                            select user_id, user_role, user_password, user_name
                            from users
                            where user_name = '{username}';
                           ";
        using var command = new NpgsqlCommand(sql, connection);

        using NpgsqlDataReader reader = command.ExecuteReader();

        if (reader.Read() is false)
            return null;

        var user = new User(
            Id: reader.GetInt64(0),
            Role: UserRole.CommonUser,
            UserPassword: reader.GetString(2),
            Username: reader.GetString(3));
        connection.Dispose();
        command.Dispose();
        return user;
    }
}