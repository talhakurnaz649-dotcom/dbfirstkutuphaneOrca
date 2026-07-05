# KÃ¼tÃ¼phane YÃ¶netim Sistemi (Database-First)

Bu proje, veritabanÄ± Ã¶ncelikli (Database-First) geliÅŸtirme yaklaÅŸÄ±mÄ±nÄ± gÃ¶stermek amacÄ±yla kurulmuÅŸ bir kÃ¼tÃ¼phane yÃ¶netim altyapÄ±sÄ±dÄ±r.

## ğŸš€ KullanÄ±lan Teknolojiler
* **Framework / Dil:** C#, .NET 8/9
* **ORM:** Entity Framework Core (Database-First yaklaÅŸÄ±mÄ± ile scaffolding)
* **Veri TabanÄ±:** SQL Server

## âœ¨ Ã–zellikler / YapÄ±
Proje, mevcut bir SQL veritabanÄ± ÅŸemasÄ±ndan hareketle otomatik modeller ve DbContext Ã¼retilerek kÃ¼tÃ¼phane iÅŸlemlerinin (kitap Ã¶dÃ¼nÃ§ alma, Ã¼ye takibi, yazar yÃ¶netimi vb.) yÃ¶netilmesini hedefler.

## ğŸ› ï¸ NasÄ±l Ã‡alÄ±ÅŸtÄ±rÄ±lÄ±r?
VeritabanÄ± ÅŸemasÄ±ndan C# sÄ±nÄ±flarÄ±nÄ± otomatik Ã¼retmek iÃ§in Package Manager Console'da ÅŸu komutu Ã§alÄ±ÅŸtÄ±rabilirsiniz:
```bash
dotnet ef dbcontext scaffold "Server=YOUR_SERVER;Database=YOUR_DB;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -o Models
```