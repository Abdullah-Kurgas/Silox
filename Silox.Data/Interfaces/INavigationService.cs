using Silox.Data.Enums;

namespace Silox.Data.Interfaces;

public interface INavigationService
{
    object? CurrentView { get; }

    event EventHandler? CurrentViewChanged;

    void Navigate(NavigationTarget target);
}