using Silox.Data.Models.Authorization;

namespace Silox.Service.Services.Authorization;

public class UserSession
{
    public User? User { get; private set; }

    private IReadOnlyCollection<Role> Roles { get; set; } = Array.Empty<Role>();

    private IReadOnlyCollection<string> Permissions =>
        Roles
            .SelectMany(x => x.Permissions)
            .Distinct()
            .ToArray();

    public void Login(User user, IEnumerable<Role> roles)
    {
        User = new User()
        {
            FirstName = user.FirstName,
            LastName = user.LastName,
            Username = user.Username
        };

        Roles = roles.ToArray();
    }

    public void Logout()
    {
        User = null;
        Roles = Array.Empty<Role>();
    }

    public bool HasPermission(string permission)
    {
        return Permissions.Contains(permission);
    }
}