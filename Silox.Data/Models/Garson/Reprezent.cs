using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Silox.Data.Models.Garson;

public class Reprezent
{
    [Key]
    [Column("ID_REPREZENTA")]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public long IdReprezenta { get; set; }

    [Required]
    [MaxLength(6)]
    [Column("SIF_REPREZENTA")]
    public string SifReprezenta { get; set; } = string.Empty;

    [Required]
    [MaxLength(50)]
    [Column("IME")]
    public string Ime { get; set; } = string.Empty;

    [Column("AKTIVAN")] public int Aktivan { get; set; }

    [ForeignKey(nameof(IdReprezenta))] public virtual Objekat Objekat { get; set; } = null!;
}