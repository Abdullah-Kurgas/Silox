using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Silox.Data.Models.Garson;

public class ReprezentiKarticeR
{
    [Key]
    [Column("ID_STAVKE")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long IdStavke { get; set; }

    [Required] [Column("ID_REPREZENTA")] public long IdReprezenta { get; set; }

    [Required] [Column("DATUM")] public DateTime Datum { get; set; }

    [Column("ID_DOKUMENTA_VEZE")] public long? IdDokumentaVeze { get; set; }

    [MaxLength(200)] [Column("OPIS")] public string? Opis { get; set; }

    [MaxLength(6)]
    [Column("SIF_VRSTE_DOKUMENTA_VEZE")]
    public string? SifVrsteDokumentaVeze { get; set; }

    [Column("IZNOS", TypeName = "decimal(18,4)")]
    public decimal? Iznos { get; set; }

    [Required] [Column("STORNO")] public int Storno { get; set; }

    [Required]
    [Column("ID_FISKALNOG_PERIODA")]
    public long IdFiskalnogPerioda { get; set; }


    [ForeignKey(nameof(IdReprezenta))] public virtual ReprezentR ReprezentRelacija { get; set; } = null!;

    // [ForeignKey(nameof(IdFiskalnogPerioda))]
    // public virtual FiskalniPeriod FiskalniPeriod { get; set; } = null!;
}