namespace Silox.Data.Models.Authorization;

public class Role(
    string name,
    IEnumerable<string> permissions)
{
    public string Name { get; } = name;

    public IReadOnlyCollection<string> Permissions { get; } = permissions.ToArray();
}