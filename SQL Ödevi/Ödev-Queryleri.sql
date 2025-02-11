--select * from Kitaplar k

--select * from Yazarlar
--select LEFT(y.Ad,1) + '.' + y.Soyad TamÝsim from Yazarlar y

--select * from Kitaplar k
--where k.YazarID = 3

--select k.Baslik,k.ISBN,k.BasimYili from Kitaplar k

--select k.Baslik,k.YazarID from Kitaplar k 
--Where k.YazarID != 3

--select y.Ad,y.Soyad,y.DogumTarihi from Yazarlar y
--where y.DogumTarihi > '01.01.1945'

--select * from Kitaplar k
--where k.ToplamKopya > 4 and ToplamKopya <7

--select LEFT(y.Ad,1) + '.' + y.Soyad TamÝsim,y.Uyruk,DATEDIFF(year,y.DogumTarihi,GETDATE()) GecenSure from Yazarlar y
--where DATEDIFF(year,y.DogumTarihi,GETDATE()) > = 70 and y.Uyruk != 'Türk'

--select * from OduncAlma o
--where o.Adet > 2 and YEAR(o.OduncTarihi) >=2022 and o.UyeID != 2

--SELECT * FROM OduncAlma o
--WHERE o.IadeTarihi IS NULL;

--SELECT * FROM Uyeler u
--WHERE u.Adres IS NULL;

--select LEFT(u.Ad,1)+'.' + u.Soyad Ýsim, u.Eposta  from Uyeler u
--where u.Telefon is null

---------------------------ORDER BY------------------------------------------

--SELECT o.UyeID, o.KitapID, o.OduncTarihi, o.IadeTarihi, o.OduncID
--FROM OduncAlma o
--WHERE (o.UyeID = 6 OR o.UyeID = 4) AND o.Adet != 1 AND o.KitapID = 11 AND o.IadeTarihi IS NULL
--ORDER BY o.UyeID ASC;

--SELECT LEFT(y.Ad, 1) + '.' + y.Soyad AdSoyad
--FROM Yazarlar y
--ORDER BY AdSoyad;

--select * from Yazarlar y
--where y.Uyruk = 'Türk'
--order by y.YazarID DESC

-- En az kopyasý olan kitap
--SELECT TOP 1 k.Baslik, k.ISBN, k.ToplamKopya
--FROM Kitaplar k
--ORDER BY k.ToplamKopya;

--SELECT k.Baslik, k.ToplamKopya, k.ISBN
--FROM Kitaplar k
--WHERE k.ToplamKopya BETWEEN 20 AND 49
--ORDER BY k.ISBN;

--SELECT * FROM OduncAlma o
--WHERE o.OduncTarihi BETWEEN '2023-01-01' AND '2023-06-06';

--SELECT k.Baslik,k.ISBN,k.ToplamKopya,k.BasimYili
--FROM Kitaplar k
--WHERE LEFT(k.Baslik, 1) = 'H' AND k.BasimYili BETWEEN 1990 AND 2000 AND k.ToplamKopya > 300
--ORDER BY k.ISBN ASC, k.ToplamKopya DESC;

--SELECT * FROM OduncAlma o
--WHERE DATENAME(WEEKDAY, o.OduncTarihi) = 'Wednesday' AND o.IadeTarihi IS NOT NULL
--ORDER BY o.OduncTarihi DESC;

-----------------------------LIKE--------------------------------------

--SELECT u.Adres FROM Uyeler u WHERE u.Adres LIKE 'T%';
--SELECT * FROM Uyeler u WHERE u.Adres LIKE '%kar%';
--SELECT * FROM Uyeler u WHERE u.Ad LIKE '__met';
--SELECT * FROM Uyeler u WHERE u.Ad LIKE '[AS]%';
--SELECT * FROM Uyeler u WHERE u.Ad LIKE '[A-K]%';
--SELECT * FROM Uyeler u WHERE u.Ad LIKE 'a[^n]%';
	
--SELECT y.Ad, y.Soyad, y.DogumTarihi
--FROM Yazarlar y
--WHERE y.Uyruk != 'Ýngiliz' AND y.Ad LIKE 'O%' AND y.Soyad LIKE '%k' AND YEAR(y.DogumTarihi) < 1985;

-----------------------------------AGGREGATE----------------------------------
--SELECT COUNT(*) 'Stokta Olan Kitap'
--FROM Kitaplar k
--WHERE k.ToplamKopya > 0;

--SELECT COUNT(*) AS 'Stokta Olmayan Kitap'
--FROM Kitaplar k
--WHERE k.ToplamKopya = 0;

--SELECT COUNT(*) AS 'Alýnan Ödünç Alma Sayýsý'
--FROM OduncAlma o
--WHERE YEAR(o.OduncTarihi) > 2022;

--SELECT u.Adres, COUNT(u.Adres) AS 'Adres'
--FROM Uyeler u
--GROUP BY u.Adres;

--SELECT SUM(k.PiyasaFiyati) AS 'Toplam Deðer' FROM Kitaplar k;
--SELECT SUM(k.PiyasaFiyati*k.ToplamKopya) AS 'Toplam Deðer' FROM Kitaplar k;

--SELECT AVG(k.PiyasaFiyati * o.Adet) AS 'Ortalama Piyasa Deðeri' 
--FROM OduncAlma o
--JOIN Kitaplar k ON o.KitapID = k.KitapID;

--SELECT SUM(k.PiyasaFiyati * o.Adet) AS 'Toplam Ciro' 
--FROM OduncAlma o
--JOIN Kitaplar k ON o.KitapID = k.KitapID;

--SELECT u.Adres, AVG(k.PiyasaFiyati * o.Adet) AS 'Adres Baþýna deðer' 
--FROM OduncAlma o
--JOIN Kitaplar k ON o.KitapID = k.KitapID
--JOIN Uyeler u ON o.UyeID = u.UyeID
--GROUP BY u.Adres;

--SELECT MAX(k.PiyasaFiyati) 'En pahalý kitap' FROM Kitaplar k;

--SELECT TOP 1 k.PiyasaFiyati 'En ucuz kitap' FROM Kitaplar k
--ORDER BY k.PiyasaFiyati ASC;
--SELECT MIN(PiyasaFiyati) FROM Kitaplar;

--SELECT u.Adres, COUNT(u.Adres) 'Üye Sayýsý' 
--FROM Uyeler u
--GROUP BY u.Adres;
-------------------------------------JOIN-----------------------------------------------------------------


--SELECT MIN(k.PiyasaFiyati) 'Minimum Piyasa Deðeri' 
--FROM OduncAlma o
--JOIN Uyeler u ON o.UyeID = u.UyeID
--JOIN Kitaplar k ON o.KitapID = k.KitapID
--WHERE u.Ad LIKE '[A-K]%' AND o.OduncTarihi BETWEEN '2020-01-01' AND '2021-06-06';

--SELECT MAX(k.PiyasaFiyati )  'Ödünç alýnan en pahalý kitap' 
--FROM OduncAlma o
--JOIN Kitaplar k ON o.KitapID = k.KitapID;

--SELECT MAX(k.PiyasaFiyati * o.Adet) 'Çarþamba Azami Deðer' 
--FROM OduncAlma o
--JOIN Kitaplar k ON o.KitapID = k.KitapID
--WHERE o.UyeID IN (1, 2) AND YEAR(o.OduncTarihi) = 2025 AND DATENAME(WEEKDAY, o.OduncTarihi) = 'Wednesday';

--SELECT TOP 3 u.Adres, COUNT(o.OduncID) 'En çok Ödünç alan' 
--FROM OduncAlma o
--JOIN Uyeler u ON o.UyeID = u.UyeID
--GROUP BY u.Adres
--ORDER BY  'En çok Ödünç alan' DESC;

--SELECT o.UyeID, COUNT(*) 'Kitap Alma Sayýsý' 
--FROM OduncAlma o
--GROUP BY o.UyeID
--ORDER BY 'Kitap Alma Sayýsý'  DESC;

---------------------------------------INNER JOIN-----------------------------------------------

--SELECT k.Baslik, t.TurAdi 
--FROM Kitaplar k 
--INNER JOIN Turler t ON k.TurID = t.TurID;

--SELECT k.Baslik, y.YayinciAdi 
--FROM Kitaplar k 
--INNER JOIN Yayincilar y ON k.YayinciID = y.YayinciID;

--SELECT k.Baslik, o.OduncID, o.OduncTarihi 
--FROM OduncAlma o 
--INNER JOIN Kitaplar k ON o.KitapID = k.KitapID;

--SELECT LEFT(u.Ad, 1) + '.' + u.Soyad 'Ad Soyad', u.Eposta, o.OduncTarihi 
--FROM Uyeler u 
--INNER JOIN OduncAlma o ON u.UyeID = o.UyeID;

--SELECT u.Ad,u.Soyad, k.Baslik, (k.PiyasaFiyati * o.Adet) AS 'Kaç liralýk kitap ödünç almýþ' 
--FROM Uyeler u 
--INNER JOIN OduncAlma o ON u.UyeID = o.UyeID 
--INNER JOIN Kitaplar k ON o.KitapID = k.KitapID;

--SELECT LEFT(u.Ad, 1) + '.' + u.Soyad AS 'Ad Soyad', t.TurAdi, k.Baslik 
--FROM Turler t 
--INNER JOIN Kitaplar k ON t.TurID = k.TurID 
--INNER JOIN OduncAlma o ON k.KitapID = o.KitapID 
--INNER JOIN Uyeler u ON o.UyeID = u.UyeID;

--SELECT k.Baslik, t.TurAdi 
--FROM Kitaplar k 
--INNER JOIN Turler t ON k.TurID = t.TurID 
--WHERE t.TurAdi = 'Roman' AND k.ToplamKopya > 0;

--SELECT SUM(k.PiyasaFiyati * o.Adet) AS 'Toplam Piyasa Deðeri'
--FROM OduncAlma o
--JOIN Uyeler u ON o.UyeID = u.UyeID
--JOIN Kitaplar k ON o.KitapID = k.KitapID
--JOIN Yayincilar y on y.YayinciID = k.YayinciID
--WHERE y.YayinciAdi LIKE '%a%' AND u.Ad IN ('Ahmet', 'Mehmet', 'Ayþe');

--SELECT o.OduncID, u.Ad, 'Elden almýþ' AlýþBiçimi 
--FROM Uyeler u
--JOIN OduncAlma o ON u.UyeID = o.UyeID
--WHERE u.Ad = 'Fatma';

--SELECT TOP 3 y.YayinciAdi, COUNT(k.KitapID) AS 'Ürün Sayýsý'
--FROM Kitaplar k
--JOIN Yayincilar y ON k.YayinciID = y.YayinciID
--GROUP BY y.YayinciAdi
--ORDER BY COUNT(k.KitapID) DESC;

--SELECT t.TurAdi, k.Baslik, SUM(k.PiyasaFiyati * o.Adet) AS  'Toplam' --'Toplam Piyasa Deðeri (toplam adet * birim fiyatý)'
--FROM Turler t
--JOIN Kitaplar k ON t.TurID = k.TurID
--JOIN OduncAlma o ON k.KitapID = o.KitapID
--GROUP BY k.Baslik, t.TurAdi
--ORDER BY 'Toplam' DESC;


----------------------------------------------------------------------------------------------------
--SELECT * FROM Kitaplar k
--LEFT JOIN Yayincilar y ON k.YayinciID = y.YayinciID
--WHERE y.YayinciID IS NULL;

--SELECT * FROM Turler t
--LEFT JOIN Kitaplar k ON t.TurID = k.TurID
--WHERE k.KitapID IS NULL;

--SELECT k.Baslik, u.Ad, o.OduncTarihi
--FROM Kitaplar k
--JOIN OduncAlma o ON k.KitapID = o.KitapID
--LEFT JOIN Uyeler u ON o.UyeID = u.UyeID;

--SELECT t.TurAdi, SUM(k.PiyasaFiyati * o.Adet) AS 'Toplam'
--FROM Turler t
--LEFT JOIN Kitaplar k ON t.TurID = k.TurID
--LEFT JOIN OduncAlma o ON k.KitapID = o.KitapID
--GROUP BY t.TurAdi
--ORDER BY 'Toplam' DESC;

--SELECT u.Ad, SUM(k.PiyasaFiyati * o.Adet) AS 'Toplam'
--FROM Uyeler u
--LEFT JOIN OduncAlma o ON u.UyeID = o.UyeID
--LEFT JOIN Kitaplar k ON o.KitapID = k.KitapID
--GROUP BY u.Ad
--ORDER BY 'Toplam' DESC;

--SELECT LEFT(u.Ad, 1) + '.' + u.Soyad AS 'Ad Soyad', k.Baslik, SUM(k.PiyasaFiyati * o.Adet) AS 'Toplam'
--FROM Kitaplar k
--JOIN OduncAlma o ON k.KitapID = o.KitapID
--JOIN Uyeler u ON o.UyeID = u.UyeID
--GROUP BY LEFT(u.Ad, 1) + '.' + u.Soyad, k.Baslik
--ORDER BY 'Toplam' DESC;

------------------------------HAVING-------------------------------
--SELECT k.Baslik, SUM(o.Adet) AS siparis_miktari 
--FROM OduncAlma o 
--INNER JOIN Kitaplar k ON k.KitapID = o.KitapID
--GROUP BY k.Baslik
--HAVING SUM(o.Adet) > 2
--ORDER BY siparis_miktari DESC;

--SELECT LEFT(u.Ad, 1) + '.' + u.Soyad  AdSoyad, k.Baslik, SUM(k.PiyasaFiyati * o.Adet) AS Toplam
--FROM Kitaplar k
--LEFT JOIN OduncAlma o ON k.KitapID = o.KitapID
--LEFT JOIN Uyeler u ON u.UyeID = o.UyeID
--GROUP BY LEFT(u.Ad, 1) + '.' + u.Soyad, k.Baslik
--HAVING SUM(k.PiyasaFiyati * o.Adet) > 100
--ORDER BY Toplam DESC;

--SELECT u.Ad, COUNT(o.Adet) AS OduncSayýsý, u.Telefon 
--FROM Uyeler u 
--INNER JOIN OduncAlma o ON u.UyeID = o.UyeID
--GROUP BY u.Ad, u.Telefon
--HAVING COUNT(o.Adet) > 1;

--INSERT INTO Turler (TurAdi, Aciklama) 
--VALUES ('Aksiyon', 'Vurdulu kýrdýlý kitaplar');

--SELECT k.Baslik, u.Ad, y.YayinciAdi 
--FROM Uyeler u
--JOIN OduncAlma o ON u.UyeID = o.UyeID
--JOIN Kitaplar k ON o.KitapID = k.KitapID
--JOIN Yayincilar y ON k.YayinciID = y.YayinciID
--WHERE y.YayinciAdi = 'Yapý Kredi Yayýnlarý' AND u.Ad = 'Ahmet';

--SELECT SUM(k.PiyasaFiyati * o.Adet) AS 'Toplam Piyasa Deðeri'
--FROM OduncAlma o
--JOIN Uyeler u ON o.UyeID = u.UyeID
--JOIN Kitaplar k ON o.KitapID = k.KitapID
--JOIN Yayincilar y ON k.YayinciID = y.YayinciID
--WHERE y.YayinciAdi = 'Penguin Books' AND u.Ad IN ('Ahmet', 'Ayþe', 'Fatma');

--SELECT k.Baslik, t.TurAdi, SUM(o.Adet) AS Toplam
--FROM Turler t
--INNER JOIN Kitaplar k ON k.TurID = t.TurID
--INNER JOIN OduncAlma o ON k.KitapID = o.KitapID
--GROUP BY k.Baslik, t.TurAdi;


--SELECT LEFT(u.Ad, 1) + '.' + u.Soyad AS AD_Soyad, k.Baslik, SUM(k.PiyasaFiyati * o.Adet) AS Toplam
--FROM Kitaplar k
--LEFT JOIN OduncAlma o ON k.KitapID = o.KitapID
--LEFT JOIN Uyeler u ON u.UyeID = o.UyeID
--GROUP BY LEFT(u.Ad, 1) + '.' + u.Soyad, k.Baslik
--HAVING SUM(k.PiyasaFiyati * o.Adet) > 150
--ORDER BY Toplam DESC;

--UPDATE Uyeler 
--SET Telefon = '5455550055', Adres = 'Japonya,Tokyo'
--WHERE Ad = 'Kartal';

--UPDATE Kitaplar 
--SET PiyasaFiyati = PiyasaFiyati + PiyasaFiyati * 0.06 
--WHERE ToplamKopya < 10;

 --CREATE VIEW TurkUye as 
 --SELECT u.UyeID, u.Ad, u.Soyad, u.Adres 
 --FROM OduncAlma o 
 --INNER JOIN Uyeler u ON u.UyeID = o.UyeID
 --where u.Adres Like '%Türkiye%'
 --select * from TurkUye

--ALTER VIEW OduncTarihi AS
--SELECT o.OduncID, o.OduncTarihi, y.YayinciAdi, u.Ad, u.UyeID 
--FROM OduncAlma o 
--INNER JOIN Uyeler u ON o.UyeID = u.UyeID
--INNER JOIN Kitaplar k ON o.KitapID = k.KitapID
--INNER JOIN Yayincilar y ON k.YayinciID = y.YayinciID
--WHERE u.Ad IN ('Mehmet', 'Ayþe', 'Ahmet') AND y.YayinciAdi = 'Yapý Kredi Yayýnlarý'
--AND DATENAME(WEEKDAY, o.OduncTarihi) = 'Wednesday'
--AND u.UyeID IN (1, 2);

--CREATE VIEW DetayliSatisRaporu AS
--SELECT LEFT(u.Ad, 1) + '.' + u.Soyad AS AdSoyad, k.Baslik, u.Eposta 
--FROM Kitaplar k 
--LEFT JOIN OduncAlma o ON o.KitapID = k.KitapID
--LEFT JOIN Uyeler u ON u.UyeID = o.UyeID;

--SELECT * FROM DetayliSatisRaporu;

--CREATE VIEW urunKategori WITH SCHEMABINDING AS
--SELECT k.Baslik, t.TurAdi 
--FROM dbo.Kitaplar k 
--LEFT JOIN dbo.Turler t ON k.TurID = t.TurID;

--SELECT * FROM urunKategori;

--CREATE VIEW TumYayinci WITH SCHEMABINDING, ENCRYPTION AS
--SELECT YayinciAdi, Telefon 
--FROM dbo.Yayincilar;

--SELECT * FROM TumYayinci;

--CREATE VIEW KategoriUrun WITH SCHEMABINDING, ENCRYPTION AS
--SELECT t.TurAdi, k.Baslik, k.PiyasaFiyati, y.Adres, (k.PiyasaFiyati * 1.18) AS KDV, k.ToplamKopya 
--FROM dbo.Turler t
--INNER JOIN dbo.Kitaplar k ON t.TurID = k.TurID
--INNER JOIN dbo.Yayincilar y ON y.YayinciID = k.YayinciID
--WHERE t.TurAdi = 'Roman' AND y.Adres LIKE '%Türkiye%' AND k.ToplamKopya > 0;

--SELECT * FROM KategoriUrun
--ORDER BY ToplamKopya DESC;


-------------------------------------PROCEDURE---------------------------------------
--GO
--CREATE PROCEDURE YayýncýEkle
--(
--    @kAdi NVARCHAR(25),
--    @tel NVARCHAR(20)
--)
--AS
--BEGIN
--    INSERT INTO Yayincilar (YayinciAdi, Telefon) VALUES (@kAdi, @tel);
--END
--GO

--EXEC YayýncýEkle 'Yeni Yayýncý', '02122251415';
--SELECT * FROM Yayincilar;

--GO
--CREATE PROCEDURE ZamYapici
--(
--    @miktar DECIMAL(10, 2)
--)
--AS
--BEGIN
--    UPDATE Kitaplar SET PiyasaFiyati = PiyasaFiyati + @miktar;
--END

--GO
--EXEC ZamYapici 2;

--SELECT * FROM Kitaplar ORDER BY PiyasaFiyati;
--GO
--CREATE PROCEDURE KategoriyeGoreGetir
--(
--    @add NVARCHAR(20)
--)
--AS
--BEGIN
--    SELECT k.Baslik, t.TurAdi 
--    FROM Kitaplar k 
--    INNER JOIN Turler t ON k.TurID = t.TurID
--    WHERE t.TurAdi = @add;
--END
--GO
--EXEC KategoriyeGoreGetir 'Bilim Kurgu';

--GO
--CREATE PROCEDURE HarfGiris
--(
--    @harfGir NVARCHAR(10)
--)
--AS
--BEGIN
--    SELECT u.Ad, o.OduncID 
--    FROM Uyeler u 
--    INNER JOIN OduncAlma o ON u.UyeID = o.UyeID
--    WHERE u.Ad LIKE @harfGir;
--END
--GO
--EXEC HarfGiris '%a%';

--GO
--CREATE PROCEDURE Rapor
--(
--    @a SMALLINT,
--    @b SMALLINT,
--    @c DECIMAL(10, 2),
--    @d DECIMAL(10, 2),
--    @e NVARCHAR(20)
--)
--AS
--BEGIN
--    SELECT k.Baslik, k.PiyasaFiyati, y.YayinciAdi, (k.PiyasaFiyati * 1.18) AS KDVliFiyat, k.ToplamKopya 
--    FROM Yayincilar y 
--    INNER JOIN Kitaplar k ON k.YayinciID = y.YayinciID
--    WHERE k.ToplamKopya BETWEEN @a AND @b
--    AND k.PiyasaFiyati BETWEEN @c AND @d
--    AND y.YayinciAdi LIKE @e;
--END

--GO
--EXEC Rapor 10, 40, 40, 110, '%yayýn%';

--GO
--CREATE PROCEDURE KategoriEkle
--(
--    @ad NVARCHAR(20),
--    @tanim NVARCHAR(30)
--)
--AS
--BEGIN
--    IF NOT EXISTS (SELECT * FROM Turler WHERE TurAdi = @ad)
--    BEGIN
--        INSERT INTO Turler (TurAdi, Aciklama) VALUES (@ad, @tanim);
--    END
--    ELSE
--    BEGIN
--        PRINT 'Zaten böyle bir kategori var';
--    END
--END
--GO
--EXEC KategoriEkle 'Yeni Kategori', 'Yeni kategori açýklamasý';

--SELECT * FROM Turler;

--GO
--CREATE PROCEDURE StokEkle
--(
--    @id INT,
--    @stok INT
--)
--AS
--BEGIN
--    UPDATE Kitaplar SET ToplamKopya = ToplamKopya + @stok WHERE KitapID = @id;
--    SELECT * FROM Kitaplar;
--END
--GO
--EXEC StokEkle 12, 5;

--GO
--CREATE FUNCTION kayitHesap
--(
--    @tarih DATE
--)
--RETURNS INT
--AS
--BEGIN
--    DECLARE @kayit INT;
--    SET @kayit = DATEDIFF(YEAR, @tarih, GETDATE());
--    RETURN @kayit;
--END
--GO

---- Kullaným:
--SELECT u.Ad, u.Soyad, dbo.kayitHesap(u.KayitTarihi) AS 'UyelikYýlý' FROM Uyeler u;

--GO
--CREATE FUNCTION KDVdahil
--(
--    @fiyat DECIMAL(10, 2),
--    @adet INT,
--    @indirim REAL
--)
--RETURNS DECIMAL(10, 2)
--AS
--BEGIN
--    RETURN @fiyat * @adet * (1 - @indirim) * 1.18;
--END
--GO

---- Kullaným:
--SELECT k.PiyasaFiyati, o.Adet, 0.18 AS KDVOrani, dbo.KDVdahil(k.PiyasaFiyati, o.Adet, 0) AS 'KDV dahil toplam fiyat' 
--FROM Kitaplar k 
--INNER JOIN OduncAlma o ON k.KitapID = o.KitapID;

--GO
--CREATE FUNCTION SiparisBilgisi
--(
--    @ad NVARCHAR(25)
--)
--RETURNS TABLE
--AS
--RETURN 
--(
--    SELECT o.OduncID, o.OduncTarihi, u.Ad + ' ' + u.Soyad AS 'Ad Soyad'
--    FROM Uyeler u 
--    INNER JOIN OduncAlma o ON o.UyeID = u.UyeID
--    WHERE u.Ad = @ad
--);
--GO

---- Kullaným:
--SELECT * FROM dbo.SiparisBilgisi('Ayþe');

--GO
--CREATE FUNCTION YayinciSiparisleri
--(
--    @yayinci NVARCHAR(30)
--)
--RETURNS TABLE
--AS
--RETURN 
--(
--    SELECT o.OduncID, o.OduncTarihi, y.YayinciAdi
--    FROM OduncAlma o 
--    INNER JOIN Kitaplar k ON k.KitapID = o.KitapID
--    INNER JOIN Yayincilar y ON y.YayinciID = k.YayinciID
--    WHERE y.YayinciAdi = @yayinci
--);
--GO

---- Kullaným:
--SELECT * FROM dbo.YayinciSiparisleri('Penguin Books');






