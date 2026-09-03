using Avalonia.Controls;
using Silox.UI.ViewModels;

namespace Silox.UI.Views.Earhiva;

public partial class EArhivaView : Window
{
    public EArhivaView()
    {
        InitializeComponent();
    }

    public EArhivaView(EArhivaViewModel viewModel) : this()
    {
        DataContext = viewModel;
        Loaded += (sender, args) => { _ = viewModel.LoadDataAsync(); };
    }
}