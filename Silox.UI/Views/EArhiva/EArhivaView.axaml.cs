using Avalonia.Controls;
using Silox.UI.ViewModels;

namespace Silox.UI.Views.EArhiva;

public partial class EArhivaView : UserControl
{
    public EArhivaView(EArhivaViewModel viewModel)
    {
        InitializeComponent();

        DataContext = viewModel;
        Loaded += (sender, args) => { _ = viewModel.LoadDataAsync(); };
    }
}