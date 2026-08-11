using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Silox.UI.ViewModels;

public record UserModel(string Name);

public partial class LoginViewModel : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<UserModel> _users = new();

    [ObservableProperty]
    private UserModel? _selectedUser;

    [ObservableProperty]
    private string _password = string.Empty;

    [ObservableProperty]
    private bool _rememberMe;

    [ObservableProperty]
    private string _versionText = "v1.15.2.0";

    public LoginViewModel()
    {
        // Load initial users list matching the dialog
        Users = new ObservableCollection<UserModel>
        {
            new("Harun Salihovic"),
            new("Hasan Hasanovic"),
            new("Hasija Dubicic"),
            new("HORECA"),
            new("Ibrahim Mujanovic"),
            new("Interne PJ"),
            new("Irisa Alic"),
            new("Irma Burdzovic"),
            new("Ismet Krlic"),
            new("Izvoz"),
            new("Jasmin Katica"),
            new("Jasmina Latifovic")
        };
    }

    [RelayCommand]
    private async Task OkAsync()
    {
        if (SelectedUser is null || string.IsNullOrWhiteSpace(Password))
        {
            return;
        }

        // Perform authentication against AD or DB
    }
}