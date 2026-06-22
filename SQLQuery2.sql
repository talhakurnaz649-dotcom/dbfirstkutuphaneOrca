USE KutuphaneDB;
GO

IF (SELECT COUNT(*) FROM Kitaplar) < 20
INSERT INTO Kitaplar (Ad, Yazar, ISBN, Stok) VALUES
('Suç ve Ceza', 'Dostoyevski', '978-1', 5),
('1984', 'Orwell', '978-2', 6),
('Simyacý', 'Coelho', '978-3', 8),
('Küçük Prens', 'Saint-Exupéry', '978-4', 10),
('Çalýkuþu', 'Reþat Nuri', '978-5', 5),
('Tutunamayanlar', 'Oðuz Atay', '978-6', 3),
('Ýnce Memed', 'Yaþar Kemal', '978-7', 4),
('Kürk Mantolu Madonna', 'Sabahattin Ali', '978-8', 6),
('Sefiller', 'Hugo', '978-9', 4),
('Dönüþüm', 'Kafka', '978-10', 5),
('Satranç', 'Zweig', '978-11', 7),
('Hayvan Çiftliði', 'Orwell', '978-12', 8),
('Yabancý', 'Camus', '978-13', 5),
('Sofie''nin Dünyasý', 'Gaarder', '978-14', 6),
('Serenad', 'Livaneli', '978-15', 5),
('Beyaz Diþ', 'London', '978-16', 7),
('Anna Karenina', 'Tolstoy', '978-17', 4),
('Savaþ ve Barýþ', 'Tolstoy', '978-18', 3),
('Fareler ve Ýnsanlar', 'Steinbeck', '978-19', 6),
('Saatleri Ayarlama Enstitüsü', 'Tanpýnar', '978-20', 4);