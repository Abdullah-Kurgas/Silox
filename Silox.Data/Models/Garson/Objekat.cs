using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Silox.Data.Models.Garson;

public class Objekat
{
    [Key]
    [Column("ID_OBJEKTA")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long IdObjekta { get; set; }

    [Required]
    [Column("ID_KORISNIKA_KREIRANJA")]
    public long IdKorisnikaKreiranja { get; set; }

    [Required]
    [Column("ID_KORISNIKA_PROMENE")]
    public long IdKorisnikaPromene { get; set; }

    [Required] [Column("VREME_KREIRANJA")] public DateTime VremeKreiranja { get; set; }

    [Required] [Column("VREME_PROMENE")] public DateTime VremePromene { get; set; }

    [Required] [Column("ID_KLASE")] public long IdKlase { get; set; }

    // Navigation Properties
    // [ForeignKey(nameof(IdKorisnikaKreiranja))]
    // public virtual Korisnik KorisnikKreiranja { get; set; } = null!;
    //
    // [ForeignKey(nameof(IdKorisnikaPromene))]
    // public virtual Korisnik KorisnikPromene { get; set; } = null!;
    //
    // [ForeignKey(nameof(IdKlase))]
    // public virtual Klasa Klasa { get; set; } = null!;

    // Optional 1:1 Navigation back to Reprezent
    public virtual Reprezent? Reprezent { get; set; }
}