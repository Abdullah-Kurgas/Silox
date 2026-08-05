using Avalonia.Controls;
using Avalonia.Interactivity;

namespace Silox.UI.Views.Login;

public partial class LoginWindow : Window
{
    public LoginWindow()
    {
        InitializeComponent();
        
        UserListBox.ItemsSource = new[] {
            "Harun Salihovic",
            "Hasan Hasanovic",
            "Hasija Dubicic",
            "HORECA Account",
            "Ibrahim Mujanovic",
            "Interne PJ",
            "Irisa Alic",
            "Irma Burdzovic",
            "Ismet Krlic",
            "Izvoz Sector",
            "Jasmin Katica",
            "Jasmina Latifovic",
            "Kenan Hadzic",
            "Lejla Begic",
            "Mirza Mesic",
            "Nedim Omerovic",
            "Selma Selimovic",
            "Tarik Imamovic"
        };
    }

    private void CloseLogin(object? sender, RoutedEventArgs e)
    {
        Close();
    }
}