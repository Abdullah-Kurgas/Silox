using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Silox.Data.Enums;
using Silox.Data.Interfaces;
using Silox.Data.Models.Authorization;
using Silox.Data.Models.UI;
using Silox.Service.Services.Authorization;

namespace Silox.UI.ViewModels;

public partial class SidebarViewModel : ViewModelBase
{
    private readonly INavigationService _navigationService;
    private readonly IPermissionService _permissionService;

    public required User User { get; init; }

    [ObservableProperty] private NavigationItem? _selectedItem;

    public SidebarViewModel(
        UserSession userSession,
        INavigationService navigationService,
        IPermissionService permissionService)
    {
        _navigationService = navigationService;
        _permissionService = permissionService;

        if (userSession.User != null) User = userSession.User;

        Debug.WriteLine(
            $"SIDEBAR USER: {User?.FirstName} {User?.LastName}"
        );
    }

    [RelayCommand]
    private void Navigate(NavigationTarget target)
    {
        _navigationService.Navigate(target);
    }
}