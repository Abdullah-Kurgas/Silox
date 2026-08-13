using CommunityToolkit.Mvvm.ComponentModel;

namespace Silox.Data.DTOs;

public partial class EArhivaDTO : ObservableObject
{
    [ObservableProperty] private bool _isSelected;

    public int Id { get; set; }
    public string? ImeVozaca { get; set; }
    public string Izvor { get; set; } = string.Empty;
    public string SifraPp { get; set; } = string.Empty;
    public string NazivPp { get; set; } = string.Empty;
    public string BrojDokumenta { get; set; } = string.Empty;
    public string VrstaDokumenta { get; set; } = string.Empty;
    public DateOnly DatumDokumenta { get; set; }
    public decimal Iznos { get; set; }
    public int Verzija { get; set; }
    public DateTime Vrijeme { get; set; }
    public string? Isporuka { get; set; }
}