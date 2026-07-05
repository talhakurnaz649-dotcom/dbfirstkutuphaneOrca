# Kütüphane Yönetim Sistemi (Database-First)

Bu proje, veritabanı öncelikli (Database-First) geliştirme yaklaşımını göstermek amacıyla kurulmuş bir kütüphane yönetim altyapısıdır.

## 🚀 Kullanılan Teknolojiler
* **Framework / Dil:** C#, .NET 8/9
* **ORM:** Entity Framework Core (Database-First yaklaşımı ile scaffolding)
* **Veri Tabanı:** SQL Server

## ✨ Özellikler / Yapı
Proje, mevcut bir SQL veritabanı şemasından hareketle otomatik modeller ve DbContext üretilerek kütüphane işlemlerinin (kitap ödünç alma, üye takibi, yazar yönetimi vb.) yönetilmesini hedefler.

## 🛠️ Nasıl Çalıştırılır?
Veritabanı şemasından C# sınıflarını otomatik üretmek için Package Manager Console'da şu komutu çalıştırabilirsiniz:
```bash
dotnet ef dbcontext scaffold "Server=YOUR_SERVER;Database=YOUR_DB;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -o Models
```
