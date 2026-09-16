using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Silox.Data.DTOs.Garson;
using Silox.Data.Interfaces;

namespace Silox.UI.ViewModels;

public partial class PregledToplihObrokaViewModel(IGarsonService service) : ViewModelBase
{
    [ObservableProperty] private ObservableCollection<SumarniTopliObrokRadnikaDTO> _data = new();
    [ObservableProperty] private string _searchText = string.Empty;

    private int _pageIndex = 1;
    private const int PageSize = 20;
    private bool _isDataLoading = false;
    private bool _hasMore = true;


    [RelayCommand]
    public async Task LoadDataAsync()
    {
        if (_isDataLoading || !_hasMore) return;
        _isDataLoading = true;

        try
        {
            var data = await service.GetReprezentiKarticePagedAsync(
                _pageIndex,
                PageSize,
                SearchText,
                new DateTime(2026, 9, 1)
            );
            Data = new ObservableCollection<SumarniTopliObrokRadnikaDTO>(data);

            // if (data.Count < PageSize)
            //     _hasMore = false;
            // else
            //     _pageIndex++;
        }
        finally
        {
            _isDataLoading = false;
            Console.WriteLine("Searching... " + _isDataLoading);
        }
    }

    public async Task SearchAsync()
    {
        _pageIndex = 1;

        Console.WriteLine("Searching...");
        await LoadDataAsync();
    }
}