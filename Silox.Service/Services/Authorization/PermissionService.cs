using Silox.Data.Interfaces;

namespace Silox.Service.Services.Authorization;

public class PermissionService(UserSession session) : IPermissionService
{
    public bool HasPermission(string permission)
    {
        return session.HasPermission(permission);
    }
}