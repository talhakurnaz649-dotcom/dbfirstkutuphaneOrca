namespace dbfirstkutuphane.Models
{
    public class Uyeler
    {
        public int UyeId { get; set; }
        public string Ad { get; set; } = null!;
        public string Soyad { get; set; } = null!;
        public string? Email { get; set; }
        public string? Telefon { get; set; }
        public ICollection<OduncIslemleri> OduncIslemleri { get; set; } = new List<OduncIslemleri>();
    }
}