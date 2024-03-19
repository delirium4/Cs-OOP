namespace Lab5.BLL.Entities;

public record User(long Id, UserRole Role, string UserPassword, string Username);