using Avalonia.Controls;
using Silox.UI.ViewModels;

namespace Silox.UI.Views.Earhiva;

public partial class EArhiva : Window
{
    public EArhiva()
    {
        InitializeComponent();
    }

    public EArhiva(EArhivaViewModel viewModel) : this()
    {
        DataContext = viewModel;
        Loaded += (sender, args) => { _ = viewModel.LoadDataAsync(); };
    }
}