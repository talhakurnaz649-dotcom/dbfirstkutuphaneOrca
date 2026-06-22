namespace dbfirstkutuphane.Models
{
    public class OduncIslemleri
    {
        public int OduncId { get; set; }
        public int KitapId { get; set; }
        public int UyeId { get; set; }
        public DateTime OduncTarihi { get; set; }
        public DateTime? IadeTarihi { get; set; }
        public Kitaplar Kitap { get; set; } = null!;
        public Uyeler Uye { get; set; } = null!;
    }
}