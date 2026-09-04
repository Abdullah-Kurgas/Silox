using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Silox.Data.Models.Authorization;
using Silox.Service.Services.Authorization;

namespace Silox.UI.ViewModels;

public partial class LoginViewModel(UserSession session) : ObservableObject
{
    public ObservableCollection<User> Users { get; } =
    [
        new()
        {
            FirstName = "Administrator",
            LastName = "Admin",
            Username = "admin",
            Password = "admin123"
        },

        new()
        {
            FirstName = "Abdullah",
            LastName = "Kurgas",
            Username = "abdullah",
            Password = "abdullah123"
        }
    ];

    [ObservableProperty] [NotifyCanExecuteChangedFor(nameof(LoginCommand))]
    private User? _selectedUser;

    [ObservableProperty] [NotifyCanExecuteChangedFor(nameof(LoginCommand))]
    private string _password = string.Empty;

    [ObservableProperty] private string _versionText = "v1.15.2.0";

    public event Action? LoginSucceeded;

    private bool CanLogin()
    {
        return !string.IsNullOrWhiteSpace(SelectedUser?.Username)
               && !string.IsNullOrWhiteSpace(Password);
    }

    [RelayCommand(CanExecute = nameof(CanLogin))]
    private void Login()
    {
        if (SelectedUser is null || string.IsNullOrWhiteSpace(Password)) return;
        if (Password != SelectedUser.Password) return;

        session.Login(SelectedUser!, [RoleConstants.Administrator]);
        LoginSucceeded?.Invoke();
    }
}