using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Silox.Data.Models;

public class EArhiva
{
    /// Jedinstveni ID sloga (auto increment)
    [Key]
    [Column("id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    /// ID sloga dokumenta za koji se tekući dokument veže (otpremnica na osnovu koje je napravljen račun ili slično...)
    [Column("vezaid")]
    public int VezaId { get; set; } = 0;

    /// Bar kod dokumenta, može sadržati razne simbole (jedinstveni kod za izvor+vrstadokumenta)
    [Column("barcode")]
    [StringLength(50)]
    public string Barcode { get; set; } = string.Empty;

    /// Bar kod dokumenta za koji se tekući dokument veže
    [Column("vezabarcode")]
    [StringLength(50)]
    public string VezaBarcode { get; set; } = string.Empty;

    /// Oznaka programa (oap, bk5, bkdos, ...)
    [Column("izvor")]
    [StringLength(50)]
    public string Izvor { get; set; } = string.Empty;

    /// ID poslovnog partnera (radi automatskog slanja pošte, e-maila, faxa, telefonskog poziva...)
    [Column("sifrapp")]
    [StringLength(20)]
    public string SifraPp { get; set; } = string.Empty;

    /// Naziv poslovnog partnera
    [Column("nazivpp")]
    [StringLength(100)]
    public string NazivPp { get; set; } = string.Empty;

    /// Adresa poslovnog partnera
    [Column("adresapp")]
    [StringLength(100)]
    public string AdresaPp { get; set; } = string.Empty;

    /// Mjesto poslovnog partnera
    [Column("mjestopp")]
    [StringLength(50)]
    public string MjestoPp { get; set; } = string.Empty;

    /// Telefon poslovnog partnera
    [Column("telefonpp")]
    [StringLength(50)]
    public string TelefonPp { get; set; } = string.Empty;

    /// Fax poslovnog partnera
    [Column("faxpp")]
    [StringLength(50)]
    public string FaxPp { get; set; } = string.Empty;

    /// Email poslovnog partnera
    [Column("emailpp")]
    [StringLength(50)]
    public string EmailPp { get; set; } = string.Empty;

    /// Ukoliko ima (r01, h01, h02...)
    [Column("isporuka")]
    [StringLength(50)]
    public string Isporuka { get; set; } = string.Empty;

    /// Virmansko plaćanje, gotovinsko plaćanje, ...
    [Column("nacinplacanja")]
    [StringLength(50)]
    public string NacinPlacanja { get; set; } = string.Empty;

    /// Originalni broj dokumenta
    [Column("brojdokumenta")]
    [StringLength(50)]
    public string BrojDokumenta { get; set; } = string.Empty;

    /// Tekstualni opis vrste dokumenta (račun, otpremnica, ulazni račun, povrat,...)
    [Column("vrstadokumenta")]
    [StringLength(50)]
    public string VrstaDokumenta { get; set; } = string.Empty;

    /// Datum dokumenta
    [Column("datumdokumenta", TypeName = "date")]
    public DateOnly DatumDokumenta { get; set; }

    /// Da li je dokument vraćen
    [Column("vracen")]
    public bool Vracen { get; set; } = false;

    /// Da li je prošao fazu skeniranja
    [Column("skeniran")]
    public bool Skeniran { get; set; } = false;

    /// Iznos dokumenta
    [Column("iznos", TypeName = "numeric(20,2)")]
    public decimal Iznos { get; set; } = 0m;

    /// Iznos plaćenog dijela
    [Column("iznosz", TypeName = "numeric(20,2)")]
    public decimal IznosZ { get; set; } = 0m;

    /// Iznos uplate
    [Column("iznosuplate", TypeName = "numeric(20,2)")]
    public decimal IznosUplate { get; set; } = 0m;

    /// Da li je plaćen u potpunosti
    [Column("uplaceno")]
    public bool Uplaceno { get; set; } = false;

    /// Broj strane dokumenta
    [Column("strana")]
    public int Strana { get; set; } = 1;

    /// Verzija (ukoliko je isti dokument skeniran više puta...)
    [Column("verzija")]
    public int Verzija { get; set; } = 1;

    /// Vrijeme izdavanja dokumenta
    [Column("vrijeme")]
    public DateTime Vrijeme { get; set; }

    /// Ime vozača koji je dokument odnio na ovjeru
    [Column("imevozaca")]
    [StringLength(50)]
    public string ImeVozaca { get; set; } = string.Empty;

    /// Slika dokumenta (u jpg formatu)
    [Column("slika")]
    public string Slika { get; set; } = string.Empty;

    /// OCR tekst prepoznat sa slike dokumenta
    [Column("tekst")]
    public string Tekst { get; set; } = string.Empty;

    /// Polje za ručni unos komentara
    [Column("komentar")]
    public string Komentar { get; set; } = string.Empty;

    /// Za internu upotrebu
    [Column("ok")]
    public bool Ok { get; set; } = false;

    /// ID dokumenta predaje pazara
    [Column("uplataid")]
    public int? UplataId { get; set; }

    /// Vrijeme predaje pazara
    // [Column("vrijemeuplate")]
    // public DateTime? VrijemeUplate { get; set; }

    [Column("spoiz")]
    [StringLength(20)]
    public string? SpoIz { get; set; }

    [Column("spoizopis")]
    [StringLength(100)]
    public string? SpoIzOpis { get; set; }

    [Column("spou")] [StringLength(20)] public string? SpoU { get; set; }

    [Column("spouopis")]
    [StringLength(100)]
    public string? SpoUOpis { get; set; }

    [Column("firma")] [StringLength(50)] public string Firma { get; set; } = string.Empty;

    [Column("rstanica")]
    [StringLength(50)]
    public string? RStanica { get; set; }

    [Column("brojprotokola")]
    [StringLength(50)]
    public string? BrojProtokola { get; set; }

    /// Komentar - ForeColor
    [Column("komentarfc")]
    public int? KomentarFc { get; set; }

    /// Komentar - BackColor
    [Column("komentarbc")]
    public int? KomentarBc { get; set; }

    // [Column("komentaraktuelando", TypeName = "date")]
    // public DateTime? KomentarAktuelanDo { get; set; }

    [Column("komentaruser")]
    [StringLength(100)]
    public string? KomentarUser { get; set; }

    /// Indikator izmjena u slogu
    [Column("imaizmjena")]
    public bool ImaIzmjena { get; set; } = true;

    [Column("tekstzamjenski")] public string TekstZamjenski { get; set; } = string.Empty;

    [Column("komentarchar")]
    [StringLength(10)]
    public string? KomentarChar { get; set; }

    [Column("naslovoriginala")] public string? NaslovOriginala { get; set; }
}