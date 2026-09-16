using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Silox.Data.Models.Garson;

public class ReprezentR
{
    [Key]
    [Column("ID_REPREZENTA")]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public long IdReprezenta { get; init; }

    [Column("IMA_PRIVILEGIJE")] public int ImaPrivilegije { get; init; }

    [Column("ID_CENOVNIKA")] public long? IdCenovnika { get; init; }

    [Column("POPUST", TypeName = "decimal(18,4)")]
    public decimal? Popust { get; init; }

    [ForeignKey(nameof(IdReprezenta))] public virtual Reprezent Reprezent { get; init; } = null!;
}