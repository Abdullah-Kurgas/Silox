namespace Silox.Data.Interfaces;

public interface IPermissionService
{
    bool HasPermission(string permission);
}