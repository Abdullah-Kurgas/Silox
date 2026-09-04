namespace Silox.Data.Models.UI;

public class NavigationSection(
    string title,
    IReadOnlyList<NavigationItem> items)
{
    public string Title { get; } = title;

    public IReadOnlyList<NavigationItem> Items { get; } = items;
}