using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Silox.Data.DTOs;
using Silox.Data.Interfaces;

namespace Silox.UI.ViewModels;

public partial class EArhivaViewModel(IEArhivaService service) : ObservableObject
{
    [ObservableProperty] private ObservableCollection<EArhivaDTO> _data = new();
    [ObservableProperty] private int _currentPage = 1;
    [ObservableProperty] private int _pageSize = 50;
    [ObservableProperty] private bool _isLastPage = false;
    [ObservableProperty] private bool _isDataLoading = false;

    [RelayCommand]
    public async Task LoadDataAsync()
    {
        if (IsDataLoading) return;
        IsDataLoading = true;

        try
        {
            var data = await service.GetPagedAsync(CurrentPage, PageSize);
            Data = new ObservableCollection<EArhivaDTO>(data);
        }
        finally
        {
            IsDataLoading = false;
            IsLastPage = Data.Count < PageSize;
        }
    }

    [RelayCommand]
    private void NextPage()
    {
        if (IsDataLoading || IsLastPage) return;

        CurrentPage += 1;
        _ = LoadDataAsync();
    }

    [RelayCommand]
    private void PreviousPage()
    {
        if (IsDataLoading || CurrentPage <= 1) return;

        CurrentPage -= 1;
        _ = LoadDataAsync();
    }
}