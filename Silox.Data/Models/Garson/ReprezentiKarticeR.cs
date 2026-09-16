using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Silox.Data.Models.Garson;

public class ReprezentiKarticeR
{
    [Key]
    [Column("ID_STAVKE")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long IdStavke { get; init; }

    [Required] [Column("ID_REPREZENTA")] public long IdReprezenta { get; init; }

    [ForeignKey(nameof(IdReprezenta))] public Reprezent Reprezent { get; init; }

    [Required] [Column("DATUM")] public DateTime Datum { get; init; }

    [Column("ID_DOKUMENTA_VEZE")] public long? IdDokumentaVeze { get; init; }

    [MaxLength(200)] [Column("OPIS")] public string? Opis { get; init; }

    [MaxLength(6)]
    [Column("SIF_VRSTE_DOKUMENTA_VEZE")]
    public string? SifVrsteDokumentaVeze { get; init; }

    [Column("IZNOS", TypeName = "decimal(18,4)")]
    public decimal? Iznos { get; init; }

    [Required] [Column("STORNO")] public int Storno { get; init; }

    [Required]
    [Column("ID_FISKALNOG_PERIODA")]
    public long IdFiskalnogPerioda { get; set; }
}