namespace dbfirstkutuphane.Models
{
    public class Kitaplar
    {
        public int KitapId { get; set; }
        public string Ad { get; set; } = null!;
        public string Yazar { get; set; } = null!;
        public string? ISBN { get; set; }
        public string? ResimUrl { get; set; }
        public int Stok { get; set; }
        public ICollection<OduncIslemleri> OduncIslemleri { get; set; } = new List<OduncIslemleri>();
    }
}