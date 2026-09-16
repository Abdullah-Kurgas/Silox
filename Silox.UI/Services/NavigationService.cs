using System;
using Microsoft.Extensions.DependencyInjection;
using Silox.Data.Enums;
using Silox.Data.Interfaces;
using Silox.UI.ViewModels;

namespace Silox.UI.Services;

public class NavigationService(IServiceProvider serviceProvider) : INavigationService
{
    private object? _currentView;

    public object? CurrentView => _currentView;

    public event EventHandler? CurrentViewChanged;

    public void Navigate(NavigationTarget target)
    {
        _currentView = target switch
        {
            // NavigationTarget.Poslovnice => serviceProvider.GetRequiredService<PoslovniceViewModel>(),
            // NavigationTarget.Radnici => serviceProvider.GetRequiredService<RadniciViewModel>(),

            NavigationTarget.TopliObroci => serviceProvider.GetRequiredService<PregledToplihObrokaViewModel>(),
            NavigationTarget.EArhivaDokumenti => serviceProvider.GetRequiredService<EArhivaViewModel>(),

            // NavigationTarget.Postavke => serviceProvider.GetRequiredService<SystemSettingsViewModel>(),
            _ => throw new ArgumentOutOfRangeException(nameof(target))
        };

        CurrentViewChanged?.Invoke(this, EventArgs.Empty);
    }
}