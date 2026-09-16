using System;
using Avalonia.Controls;
using Avalonia.Input;
using Silox.UI.ViewModels;

namespace Silox.UI.Views.PregledToplihObroka;

public partial class PregledToplihObrokaView : UserControl
{
    private readonly PregledToplihObrokaViewModel _viewModel;
    private bool _isMoreLoading = false;

    public PregledToplihObrokaView(PregledToplihObrokaViewModel viewModel)
    {
        InitializeComponent();

        _viewModel = viewModel;
        DataContext = viewModel;
        Loaded += (sender, args) => { _ = viewModel.LoadDataAsync(); };
    }

    private void ScrollEvent(object? sender, PointerWheelEventArgs e)
    {
        if (e.Delta.Y < 0 && !_isMoreLoading)
        {
            Console.WriteLine("End test " + e.Delta.Y);
            _isMoreLoading = true;
        }

        Console.WriteLine("End test " + e.Delta.Y);
    }

    private async void SearchTextBox_KeyDown(object? sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter)
        {
            await _viewModel.SearchAsync();
        }
    }
}