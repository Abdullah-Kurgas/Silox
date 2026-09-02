using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Silox.UI.ViewModels;

namespace Silox.UI.Views.Login;

public partial class LoginWindow : Window
{
    public LoginWindow(LoginViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;

        viewModel.LoginSucceeded += OnLoginSucceeded;
    }

    private void OnLoginSucceeded()
    {
        Close(true);
    }

    private void CloseLogin(object? sender, RoutedEventArgs e)
    {
        Close(false);
    }

    private void UserListBox_OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        if (UserListBox.SelectedItem != null)
        {
            PasswordTextBox.Focus();
        }
    }
}