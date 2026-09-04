namespace Silox.Data.Models.Authorization;

public class User
{
    public string FirstName { get; init; } = "";
    public string LastName { get; init; } = "";
    public string Username { get; init; } = "";
    public string? Password { get; init; } = "";

    public string FullName => $"{FirstName} {LastName}";
}