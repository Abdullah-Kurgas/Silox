using Silox.Data.Enums;
using Silox.Data.Interfaces;

namespace Silox.Service.Services;

public class NavigationService : INavigationService
{
    private NavigationTarget _currentView;
    public object? CurrentView => _currentView;

    public event EventHandler? CurrentViewChanged;

    public void Navigate(NavigationTarget target)
    {
        if (_currentView == target) return;

        _currentView = target;
        CurrentViewChanged?.Invoke(this, EventArgs.Empty);
    }
}