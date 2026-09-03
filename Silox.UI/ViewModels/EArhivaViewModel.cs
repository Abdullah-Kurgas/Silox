using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Avalonia.Media.Imaging;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Silox.Data.DTOs;
using Silox.Data.Interfaces;
using Silox.Data.Models;

namespace Silox.UI.ViewModels;

public partial class EArhivaViewModel(IEArhivaService service) : ObservableObject
{
    [ObservableProperty] private ObservableCollection<EArhivaDTO> _data = new();
    [ObservableProperty] private EArhivaDTO? _selectedItem;
    [ObservableProperty] private EArhiva? _selectedItemDetails;
    [ObservableProperty] private Bitmap? selectedImage;
    [ObservableProperty] private bool _isDataLoading = false;
    [ObservableProperty] private bool _isDataLoadingDetails = false;
    [ObservableProperty] private int _currentPage = 1;
    [ObservableProperty] private int _pageSize = 50;
    [ObservableProperty] private bool _isLastPage = false;

    private List<string> _imagePaths = new();
    private int _currentImageIndex;


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

    private async Task GetItemDetailsAsync(int id)
    {
        try
        {
            SelectedItemDetails = await service.GetItemDetailsAsync(id);
            if (SelectedItemDetails != null) LoadImages(SelectedItemDetails.Slika);
        }
        finally
        {
            IsDataLoadingDetails = false;
        }
    }

    partial void OnSelectedItemChanged(EArhivaDTO? value)
    {
        if (value == null) return;
        if (IsDataLoadingDetails) return;
        IsDataLoadingDetails = true;

        _ = GetItemDetailsAsync(value.Id);
    }

    private void LoadImages(string? slika)
    {
        SelectedImage?.Dispose();
        SelectedImage = null;

        _imagePaths.Clear();
        _currentImageIndex = 0;

        if (string.IsNullOrWhiteSpace(slika))
            return;

        _imagePaths = slika
            .Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(x => x.Trim())
            // .Where(File.Exists)
            .ToList();

        if (_imagePaths.Count > 0)
            LoadCurrentImage();
    }

    private void LoadCurrentImage()
    {
        SelectedImage?.Dispose();
        SelectedImage = null;

        if (_currentImageIndex < 0 ||
            _currentImageIndex >= _imagePaths.Count)
            return;

        var path = @"\\earhiva\eArhiva\2026\08\Protokol_Ulaznafaktura_2671_02-238_Verzija001_Strana001.jpg";

        Console.WriteLine($"Directory exists: {Directory.Exists(@"\\earhiva\eArhiva")}");
        Console.WriteLine($"File exists: {File.Exists(path)}");

        SelectedImage = new Bitmap(_imagePaths[_currentImageIndex]);
    }
}