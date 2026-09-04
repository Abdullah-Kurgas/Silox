using Silox.Data.Enums;

namespace Silox.Data.Models.UI;

public class NavigationItem(
    string title,
    string icon,
    string permission,
    NavigationTarget target)
{
    public string Title { get; } = title;
    public string Icon { get; } = icon;
    public string Permission { get; } = permission;
    public NavigationTarget Target { get; } = target;
}