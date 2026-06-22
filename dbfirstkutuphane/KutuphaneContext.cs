using dbfirstkutuphane.Models;
using Microsoft.EntityFrameworkCore;

namespace dbfirstkutuphane
{
    public class KutuphaneContext : DbContext
    {
        public DbSet<Kitaplar> Kitaplar { get; set; }
        public DbSet<Uyeler> Uyeler { get; set; }
        public DbSet<OduncIslemleri> OduncIslemleri { get; set; }
        public DbSet<Kullanicilar> Kullanicilar { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=KutuphaneDB;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kitaplar>().HasKey(k => k.KitapId);
            modelBuilder.Entity<Uyeler>().HasKey(u => u.UyeId);
            modelBuilder.Entity<OduncIslemleri>().HasKey(o => o.OduncId);
            modelBuilder.Entity<Kullanicilar>().HasKey(k => k.KullaniciId);

            modelBuilder.Entity<Kitaplar>().ToTable("Kitaplar");
            modelBuilder.Entity<Uyeler>().ToTable("Uyeler");
            modelBuilder.Entity<OduncIslemleri>().ToTable("OduncIslemleri");
            modelBuilder.Entity<Kullanicilar>().ToTable("Kullanicilar");

            modelBuilder.Entity<Kullanicilar>()
                .HasOne(k => k.Uye)
                .WithMany()
                .HasForeignKey(k => k.UyeId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<OduncIslemleri>()
                .HasOne(o => o.Kitap)
                .WithMany(k => k.OduncIslemleri)
                .HasForeignKey(o => o.KitapId);

            modelBuilder.Entity<OduncIslemleri>()
                .HasOne(o => o.Uye)
                .WithMany(u => u.OduncIslemleri)
                .HasForeignKey(o => o.UyeId);
        }
    }
}