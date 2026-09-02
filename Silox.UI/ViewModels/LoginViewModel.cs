using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Silox.UI.ViewModels;

public partial class LoginViewModel : ObservableObject
{
    public ObservableCollection<string> Users { get; } = new()
    {
        new("Administrator")
    };

    [ObservableProperty] [NotifyCanExecuteChangedFor(nameof(LoginCommand))]
    private string? _selectedUser = null;

    [ObservableProperty] [NotifyCanExecuteChangedFor(nameof(LoginCommand))]
    private string _password = string.Empty;

    [ObservableProperty] private string _versionText = "v1.15.2.0";

    public event Action? LoginSucceeded;

    private bool CanLogin()
    {
        return !string.IsNullOrWhiteSpace(SelectedUser)
               && !string.IsNullOrWhiteSpace(Password);
    }

    [RelayCommand(CanExecute = nameof(CanLogin))]
    private void Login()
    {
        if (SelectedUser is null || string.IsNullOrWhiteSpace(Password))
        {
            return;
        }

        if (SelectedUser == "Administrator" &&
            Password == "admin123")
        {
            LoginSucceeded?.Invoke();
        }
    }
}