using Avalonia.Controls;
using Avalonia.Interactivity;
using Silox.UI.Views.Login;

namespace Silox.UI.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void OpenLoginDialog(object? sender, RoutedEventArgs e)
    {
        LoginWindow loginDialog = new LoginWindow();
        loginDialog.ShowDialog(this);
    }
}