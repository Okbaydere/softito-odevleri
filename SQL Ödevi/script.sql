USE [Kutuphane]
GO
/****** Object:  Table [dbo].[Kitaplar]    Script Date: 2/11/2025 10:36:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kitaplar](
	[KitapID] [int] IDENTITY(1,1) NOT NULL,
	[Baslik] [varchar](255) NULL,
	[YazarID] [int] NOT NULL,
	[TurID] [int] NOT NULL,
	[ISBN] [char](13) NULL,
	[BasimYili] [int] NULL,
	[ToplamKopya] [int] NULL,
	[YayinciID] [int] NULL,
	[PiyasaFiyati] [decimal](10, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[KitapID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OduncAlma]    Script Date: 2/11/2025 10:36:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OduncAlma](
	[OduncID] [int] IDENTITY(1,1) NOT NULL,
	[UyeID] [int] NULL,
	[OduncTarihi] [date] NULL,
	[IadeTarihi] [date] NULL,
	[KitapID] [int] NULL,
	[Adet] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[OduncID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Turler]    Script Date: 2/11/2025 10:36:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Turler](
	[TurID] [int] IDENTITY(1,1) NOT NULL,
	[TurAdi] [varchar](50) NULL,
	[Aciklama] [text] NULL,
PRIMARY KEY CLUSTERED 
(
	[TurID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Uyeler]    Script Date: 2/11/2025 10:36:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Uyeler](
	[UyeID] [int] IDENTITY(1,1) NOT NULL,
	[Ad] [varchar](50) NULL,
	[Soyad] [varchar](50) NULL,
	[Eposta] [varchar](100) NULL,
	[Telefon] [varchar](20) NULL,
	[Adres] [varchar](255) NULL,
	[KayitTarihi] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[UyeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Yayincilar]    Script Date: 2/11/2025 10:36:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Yayincilar](
	[YayinciID] [int] IDENTITY(1,1) NOT NULL,
	[YayinciAdi] [varchar](100) NULL,
	[Adres] [varchar](255) NULL,
	[Telefon] [varchar](20) NULL,
	[Eposta] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[YayinciID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Yazarlar]    Script Date: 2/11/2025 10:36:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Yazarlar](
	[YazarID] [int] IDENTITY(1,1) NOT NULL,
	[Ad] [varchar](50) NULL,
	[Soyad] [varchar](50) NULL,
	[DogumTarihi] [date] NULL,
	[Uyruk] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[YazarID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Kitaplar] ON 

INSERT [dbo].[Kitaplar] ([KitapID], [Baslik], [YazarID], [TurID], [ISBN], [BasimYili], [ToplamKopya], [YayinciID], [PiyasaFiyati]) VALUES (1, N'Masumiyet Müzesi', 1, 1, N'9789750506095', 2008, 35, 1, CAST(57.00 AS Decimal(10, 2)))
INSERT [dbo].[Kitaplar] ([KitapID], [Baslik], [YazarID], [TurID], [ISBN], [BasimYili], [ToplamKopya], [YayinciID], [PiyasaFiyati]) VALUES (2, N'Kürk Mantolu Madonna', 4, 1, N'9789753638021', 1943, 55, 2, CAST(67.00 AS Decimal(10, 2)))
INSERT [dbo].[Kitaplar] ([KitapID], [Baslik], [YazarID], [TurID], [ISBN], [BasimYili], [ToplamKopya], [YayinciID], [PiyasaFiyati]) VALUES (3, N'Harry Potter ve Felsefe Taşı', 3, 3, N'9780747532699', 1997, 70, 4, CAST(25.00 AS Decimal(10, 2)))
INSERT [dbo].[Kitaplar] ([KitapID], [Baslik], [YazarID], [TurID], [ISBN], [BasimYili], [ToplamKopya], [YayinciID], [PiyasaFiyati]) VALUES (4, N'1984', 5, 2, N'9780451524935', 1949, 500, 5, CAST(58.00 AS Decimal(10, 2)))
INSERT [dbo].[Kitaplar] ([KitapID], [Baslik], [YazarID], [TurID], [ISBN], [BasimYili], [ToplamKopya], [YayinciID], [PiyasaFiyati]) VALUES (5, N'Şeker Portakalı', 2, 1, N'9789750718534', 1968, 325, 3, CAST(80.00 AS Decimal(10, 2)))
INSERT [dbo].[Kitaplar] ([KitapID], [Baslik], [YazarID], [TurID], [ISBN], [BasimYili], [ToplamKopya], [YayinciID], [PiyasaFiyati]) VALUES (6, N'Harry Potter ve Sırlar Odası', 3, 3, N'9780747538493', 1998, 800, 4, CAST(92.00 AS Decimal(10, 2)))
INSERT [dbo].[Kitaplar] ([KitapID], [Baslik], [YazarID], [TurID], [ISBN], [BasimYili], [ToplamKopya], [YayinciID], [PiyasaFiyati]) VALUES (7, N'Harry Potter ve Azkaban Tutsağı', 3, 3, N'9780747542155', 1999, 24, 4, CAST(27.00 AS Decimal(10, 2)))
INSERT [dbo].[Kitaplar] ([KitapID], [Baslik], [YazarID], [TurID], [ISBN], [BasimYili], [ToplamKopya], [YayinciID], [PiyasaFiyati]) VALUES (8, N'Harry Potter ve Ateş Kadehi', 3, 3, N'9780747546245', 2000, 660, 4, CAST(57.00 AS Decimal(10, 2)))
INSERT [dbo].[Kitaplar] ([KitapID], [Baslik], [YazarID], [TurID], [ISBN], [BasimYili], [ToplamKopya], [YayinciID], [PiyasaFiyati]) VALUES (9, N'Harry Potter ve Zümrüdüanka Yoldaşlığı', 3, 3, N'9780747551003', 2003, 6, 4, CAST(39.10 AS Decimal(10, 2)))
INSERT [dbo].[Kitaplar] ([KitapID], [Baslik], [YazarID], [TurID], [ISBN], [BasimYili], [ToplamKopya], [YayinciID], [PiyasaFiyati]) VALUES (10, N'Harry Potter ve Melez Prens', 3, 3, N'9780747581086', 2005, 45, 4, CAST(57.50 AS Decimal(10, 2)))
INSERT [dbo].[Kitaplar] ([KitapID], [Baslik], [YazarID], [TurID], [ISBN], [BasimYili], [ToplamKopya], [YayinciID], [PiyasaFiyati]) VALUES (11, N'Harry Potter ve Ölüm Yadigârları', 3, 3, N'9780545010221', 2007, 29, 4, CAST(25.50 AS Decimal(10, 2)))
INSERT [dbo].[Kitaplar] ([KitapID], [Baslik], [YazarID], [TurID], [ISBN], [BasimYili], [ToplamKopya], [YayinciID], [PiyasaFiyati]) VALUES (13, N'Yayıncısız kitap 1', 1, 3, N'9781234567890', 2021, 10, NULL, CAST(52.00 AS Decimal(10, 2)))
INSERT [dbo].[Kitaplar] ([KitapID], [Baslik], [YazarID], [TurID], [ISBN], [BasimYili], [ToplamKopya], [YayinciID], [PiyasaFiyati]) VALUES (14, N'Yayıncısız Kitap 2', 2, 3, N'9780987654321', 2022, 5, NULL, CAST(81.50 AS Decimal(10, 2)))
SET IDENTITY_INSERT [dbo].[Kitaplar] OFF
GO
SET IDENTITY_INSERT [dbo].[OduncAlma] ON 

INSERT [dbo].[OduncAlma] ([OduncID], [UyeID], [OduncTarihi], [IadeTarihi], [KitapID], [Adet]) VALUES (1, 1, CAST(N'2020-04-01' AS Date), CAST(N'2020-04-15' AS Date), 1, 3)
INSERT [dbo].[OduncAlma] ([OduncID], [UyeID], [OduncTarihi], [IadeTarihi], [KitapID], [Adet]) VALUES (2, 2, CAST(N'2020-04-05' AS Date), CAST(N'2020-04-19' AS Date), 2, 2)
INSERT [dbo].[OduncAlma] ([OduncID], [UyeID], [OduncTarihi], [IadeTarihi], [KitapID], [Adet]) VALUES (3, 3, CAST(N'2021-04-10' AS Date), CAST(N'2021-04-24' AS Date), 3, 1)
INSERT [dbo].[OduncAlma] ([OduncID], [UyeID], [OduncTarihi], [IadeTarihi], [KitapID], [Adet]) VALUES (4, 4, CAST(N'2023-04-15' AS Date), CAST(N'2023-04-29' AS Date), 4, 1)
INSERT [dbo].[OduncAlma] ([OduncID], [UyeID], [OduncTarihi], [IadeTarihi], [KitapID], [Adet]) VALUES (5, 5, CAST(N'2023-04-20' AS Date), CAST(N'2023-05-04' AS Date), 5, 5)
INSERT [dbo].[OduncAlma] ([OduncID], [UyeID], [OduncTarihi], [IadeTarihi], [KitapID], [Adet]) VALUES (6, 2, CAST(N'2025-01-01' AS Date), NULL, 6, 1)
INSERT [dbo].[OduncAlma] ([OduncID], [UyeID], [OduncTarihi], [IadeTarihi], [KitapID], [Adet]) VALUES (7, 6, CAST(N'2025-02-02' AS Date), NULL, 11, 2)
INSERT [dbo].[OduncAlma] ([OduncID], [UyeID], [OduncTarihi], [IadeTarihi], [KitapID], [Adet]) VALUES (8, 4, CAST(N'2024-07-04' AS Date), CAST(N'2024-08-14' AS Date), 8, 1)
SET IDENTITY_INSERT [dbo].[OduncAlma] OFF
GO
SET IDENTITY_INSERT [dbo].[Turler] ON 

INSERT [dbo].[Turler] ([TurID], [TurAdi], [Aciklama]) VALUES (1, N'Roman', N'Uzun kurgusal hikaye')
INSERT [dbo].[Turler] ([TurID], [TurAdi], [Aciklama]) VALUES (2, N'Bilim Kurgu', N'Bilim ve teknoloji temalı hikaye')
INSERT [dbo].[Turler] ([TurID], [TurAdi], [Aciklama]) VALUES (3, N'Fantastik', N'Fantastik öğeler içeren hikaye')
INSERT [dbo].[Turler] ([TurID], [TurAdi], [Aciklama]) VALUES (4, N'Tarih', N'Tarihi olayları anlatan hikaye')
INSERT [dbo].[Turler] ([TurID], [TurAdi], [Aciklama]) VALUES (5, N'Biyografi', N'Bir kişinin hayat hikayesi')
INSERT [dbo].[Turler] ([TurID], [TurAdi], [Aciklama]) VALUES (6, N'Aksiyon', N'Vurdulu kırdılı kitaplar')
INSERT [dbo].[Turler] ([TurID], [TurAdi], [Aciklama]) VALUES (7, N'Yeni Kategori', N'Yeni kategori açıklaması')
SET IDENTITY_INSERT [dbo].[Turler] OFF
GO
SET IDENTITY_INSERT [dbo].[Uyeler] ON 

INSERT [dbo].[Uyeler] ([UyeID], [Ad], [Soyad], [Eposta], [Telefon], [Adres], [KayitTarihi]) VALUES (1, N'Ahmet', N'Yılmaz', N'ahmet.yilmaz@example.com', N'555-1234', N'Türkiye,İstanbul', CAST(N'2023-01-15' AS Date))
INSERT [dbo].[Uyeler] ([UyeID], [Ad], [Soyad], [Eposta], [Telefon], [Adres], [KayitTarihi]) VALUES (2, N'Ayşe', N'Kara', N'ayse.kara@example.com', N'555-5678', N'Türkiye,Ankara', CAST(N'2023-02-20' AS Date))
INSERT [dbo].[Uyeler] ([UyeID], [Ad], [Soyad], [Eposta], [Telefon], [Adres], [KayitTarihi]) VALUES (3, N'Mehmet', N'Demir', N'mehmet.demir@example.com', N'555-8765', N'Türkiye,İzmir', CAST(N'2023-03-10' AS Date))
INSERT [dbo].[Uyeler] ([UyeID], [Ad], [Soyad], [Eposta], [Telefon], [Adres], [KayitTarihi]) VALUES (4, N'Fatma', N'Çelik', N'fatma.celik@example.com', N'555-4321', N'Türkiye,Bursa', CAST(N'2023-04-05' AS Date))
INSERT [dbo].[Uyeler] ([UyeID], [Ad], [Soyad], [Eposta], [Telefon], [Adres], [KayitTarihi]) VALUES (5, N'Ali', N'Şahin', N'ali.sahin@example.com', N'555-6789', N'Fransa,Paris', CAST(N'2023-05-12' AS Date))
INSERT [dbo].[Uyeler] ([UyeID], [Ad], [Soyad], [Eposta], [Telefon], [Adres], [KayitTarihi]) VALUES (6, N'Kartal', N'Duman', N'karDu@gmail.com', N'5455550055', N'Japonya,Tokyo', CAST(N'2023-05-10' AS Date))
INSERT [dbo].[Uyeler] ([UyeID], [Ad], [Soyad], [Eposta], [Telefon], [Adres], [KayitTarihi]) VALUES (7, N'Dumon', N'James', N'james@hotmail.com', N'544', NULL, CAST(N'2025-01-01' AS Date))
INSERT [dbo].[Uyeler] ([UyeID], [Ad], [Soyad], [Eposta], [Telefon], [Adres], [KayitTarihi]) VALUES (8, N'Kemal', N'Fahrettin', N'kahkak@examp.com', N'444-444-44', N'Türkiye,İstanbul', CAST(N'2022-01-12' AS Date))
INSERT [dbo].[Uyeler] ([UyeID], [Ad], [Soyad], [Eposta], [Telefon], [Adres], [KayitTarihi]) VALUES (9, N'Emre', N'Kaya', N'emre.kaya@example.com', N'555-1111', N'İstanbul, Türkiye', CAST(N'2024-01-10' AS Date))
INSERT [dbo].[Uyeler] ([UyeID], [Ad], [Soyad], [Eposta], [Telefon], [Adres], [KayitTarihi]) VALUES (10, N'Zeynep', N'Demir', N'zeynep.demir@example.com', N'555-2222', N'Ankara, Türkiye', CAST(N'2024-02-15' AS Date))
INSERT [dbo].[Uyeler] ([UyeID], [Ad], [Soyad], [Eposta], [Telefon], [Adres], [KayitTarihi]) VALUES (11, N'Mert', N'Çelik', N'mert.celik@example.com', N'555-3333', N'İzmir, Türkiye', CAST(N'2024-03-20' AS Date))
INSERT [dbo].[Uyeler] ([UyeID], [Ad], [Soyad], [Eposta], [Telefon], [Adres], [KayitTarihi]) VALUES (12, N'Elif', N'Yılmaz', N'elif.yilmaz@example.com', N'555-4444', N'Bursa, Türkiye', CAST(N'2024-04-25' AS Date))
INSERT [dbo].[Uyeler] ([UyeID], [Ad], [Soyad], [Eposta], [Telefon], [Adres], [KayitTarihi]) VALUES (13, N'Ahmet', N'Şahin', N'ahmet.sahin@example.com', N'555-5555', N'Antalya, Türkiye', CAST(N'2024-05-30' AS Date))
SET IDENTITY_INSERT [dbo].[Uyeler] OFF
GO
SET IDENTITY_INSERT [dbo].[Yayincilar] ON 

INSERT [dbo].[Yayincilar] ([YayinciID], [YayinciAdi], [Adres], [Telefon], [Eposta]) VALUES (1, N'Yapı Kredi Yayınları', N'İstanbul, Türkiye', N'555-1111', N'info@yky.com')
INSERT [dbo].[Yayincilar] ([YayinciID], [YayinciAdi], [Adres], [Telefon], [Eposta]) VALUES (2, N'Can Yayınları', N'İstanbul, Türkiye', N'555-2222', N'info@canyayinlari.com')
INSERT [dbo].[Yayincilar] ([YayinciID], [YayinciAdi], [Adres], [Telefon], [Eposta]) VALUES (3, N'İletişim Yayınları', N'İstanbul, Türkiye', N'555-3333', N'info@iletisim.com')
INSERT [dbo].[Yayincilar] ([YayinciID], [YayinciAdi], [Adres], [Telefon], [Eposta]) VALUES (4, N'Penguin Books', N'Londra, İngiltere', N'555-4444', N'info@penguin.co.uk')
INSERT [dbo].[Yayincilar] ([YayinciID], [YayinciAdi], [Adres], [Telefon], [Eposta]) VALUES (5, N'HarperCollins', N'New York, ABD', N'555-5555', N'info@harpercollins.com')
INSERT [dbo].[Yayincilar] ([YayinciID], [YayinciAdi], [Adres], [Telefon], [Eposta]) VALUES (6, N'Yeni Yayıncı', NULL, N'02122251415', NULL)
SET IDENTITY_INSERT [dbo].[Yayincilar] OFF
GO
SET IDENTITY_INSERT [dbo].[Yazarlar] ON 

INSERT [dbo].[Yazarlar] ([YazarID], [Ad], [Soyad], [DogumTarihi], [Uyruk]) VALUES (1, N'Orhan', N'Pamuk', CAST(N'1952-06-07' AS Date), N'Türk')
INSERT [dbo].[Yazarlar] ([YazarID], [Ad], [Soyad], [DogumTarihi], [Uyruk]) VALUES (2, N'Elif', N'Şafak', CAST(N'1971-10-25' AS Date), N'Türk')
INSERT [dbo].[Yazarlar] ([YazarID], [Ad], [Soyad], [DogumTarihi], [Uyruk]) VALUES (3, N'J.K.', N'Rowling', CAST(N'1965-07-31' AS Date), N'İngiliz')
INSERT [dbo].[Yazarlar] ([YazarID], [Ad], [Soyad], [DogumTarihi], [Uyruk]) VALUES (4, N'Sabahattin', N'Ali', CAST(N'1907-02-25' AS Date), N'Türk')
INSERT [dbo].[Yazarlar] ([YazarID], [Ad], [Soyad], [DogumTarihi], [Uyruk]) VALUES (5, N'George', N'Orwell', CAST(N'1903-06-25' AS Date), N'İngiliz')
SET IDENTITY_INSERT [dbo].[Yazarlar] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Kitaplar__447D36EA668EDF15]    Script Date: 2/11/2025 10:36:52 PM ******/
ALTER TABLE [dbo].[Kitaplar] ADD UNIQUE NONCLUSTERED 
(
	[ISBN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Turler__42910F65AD60EA56]    Script Date: 2/11/2025 10:36:52 PM ******/
ALTER TABLE [dbo].[Turler] ADD UNIQUE NONCLUSTERED 
(
	[TurAdi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Uyeler__03ABA391AF140C7D]    Script Date: 2/11/2025 10:36:52 PM ******/
ALTER TABLE [dbo].[Uyeler] ADD UNIQUE NONCLUSTERED 
(
	[Eposta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Yayincil__03ABA391E3356ADD]    Script Date: 2/11/2025 10:36:52 PM ******/
ALTER TABLE [dbo].[Yayincilar] ADD UNIQUE NONCLUSTERED 
(
	[Eposta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Kitaplar] ADD  DEFAULT ((1)) FOR [ToplamKopya]
GO
ALTER TABLE [dbo].[OduncAlma] ADD  DEFAULT ((1)) FOR [Adet]
GO
ALTER TABLE [dbo].[Kitaplar]  WITH CHECK ADD FOREIGN KEY([TurID])
REFERENCES [dbo].[Turler] ([TurID])
GO
ALTER TABLE [dbo].[Kitaplar]  WITH CHECK ADD FOREIGN KEY([YayinciID])
REFERENCES [dbo].[Yayincilar] ([YayinciID])
GO
ALTER TABLE [dbo].[Kitaplar]  WITH CHECK ADD FOREIGN KEY([YazarID])
REFERENCES [dbo].[Yazarlar] ([YazarID])
GO
ALTER TABLE [dbo].[OduncAlma]  WITH CHECK ADD FOREIGN KEY([KitapID])
REFERENCES [dbo].[Kitaplar] ([KitapID])
GO
ALTER TABLE [dbo].[OduncAlma]  WITH CHECK ADD FOREIGN KEY([UyeID])
REFERENCES [dbo].[Uyeler] ([UyeID])
GO
ALTER TABLE [dbo].[OduncAlma]  WITH CHECK ADD CHECK  (([Adet]>(0)))
GO
