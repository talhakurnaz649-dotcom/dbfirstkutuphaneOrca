namespace dbfirstkutuphane.Models
{
    public class Kullanicilar
    {
        public int KullaniciId { get; set; }
        public string KullaniciAdi { get; set; } = null!;
        public string Sifre { get; set; } = null!;
        public string Ad { get; set; } = null!;
        public string Soyad { get; set; } = null!;
        public string? Email { get; set; }
        public DateTime KayitTarihi { get; set; }
        public int? UyeId { get; set; }
        public Uyeler? Uye { get; set; }
    }
}
