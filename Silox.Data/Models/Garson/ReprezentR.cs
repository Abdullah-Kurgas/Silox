using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Silox.Data.Models.Garson;

public class ReprezentR
{
    [Key]
    [Column("ID_REPREZENTA")]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public long IdReprezenta { get; set; }

    [Column("IMA_PRIVILEGIJE")] public int ImaPrivilegije { get; set; }

    [Column("ID_CENOVNIKA")] public long? IdCenovnika { get; set; }

    [Column("POPUST", TypeName = "decimal(18,4)")]
    public decimal? Popust { get; set; }

    [ForeignKey(nameof(IdReprezenta))] public virtual Reprezent Reprezent { get; set; } = null!;
    // [ForeignKey(nameof(IdCenovnika))] public virtual Cenovnik? Cenovnik { get; set; }
}