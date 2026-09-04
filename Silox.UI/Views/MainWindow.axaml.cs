using Avalonia.Controls;
using Silox.UI.ViewModels;

namespace Silox.UI.Views;

public partial class MainWindow : Window
{
    public MainWindow(MainViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}