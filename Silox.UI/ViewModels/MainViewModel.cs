using System;
using CommunityToolkit.Mvvm.ComponentModel;
using Silox.Data.Interfaces;

namespace Silox.UI.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    private readonly INavigationService _navigationService;

    public SidebarViewModel Sidebar { get; }

    [ObservableProperty] private object? _currentView;

    public MainViewModel(
        INavigationService navigationService,
        SidebarViewModel sidebar
    )
    {
        _navigationService = navigationService;
        Sidebar = sidebar;

        _navigationService.CurrentViewChanged += OnCurrentViewChanged;
    }

    private void OnCurrentViewChanged(object? sender, EventArgs e)
    {
        CurrentView = _navigationService.CurrentView;
    }
}