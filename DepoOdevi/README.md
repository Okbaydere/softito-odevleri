# Depo Yönetim Sistemi

Depo Yönetim Sistemi, ürün stoklarını, tedarikçileri, kargo işlemlerini ve stok hareketlerini yönetmeye yarayan bir web uygulamasıdır. ASP.NET MVC mimarisi kullanılarak geliştirilmiştir.

## Proje Yapısı

Proje, katmanlı mimari kullanılarak geliştirilmiştir:

1. **Entity Katmanı**: Veri tabanı varlıklarını ve modelleri içerir.
2. **Data Katmanı**: Veritabanı erişim işlemlerini gerçekleştirir (Entity Framework kullanılmaktadır).
3. **Business Katmanı**: İş mantığı ve doğrulama işlemlerini yönetir.
4. **DepoOdevi (Sunum Katmanı)**: MVC tabanlı web uygulamasıdır.

## Özellikler

### Ürün Yönetimi
- Ürün ekleme, düzenleme, silme ve listeleme
- Stok seviyelerini takip etme
- Düşük stok uyarıları
- Kategorilere ve tedarikçilere göre ürün filtreleme

### Stok Hareketleri
- Stok giriş, çıkış, satış, iade ve sayım işlemleri
- Otomatik stok güncelleme
- Stok hareketlerinin tarihçesi
- Çalışanlara göre stok hareketlerini takip

### Tedarikçi Yönetimi
- Tedarikçi bilgilerini kaydetme ve güncelleme
- Tedarikçiye göre ürün listesi

### Kargo Takibi
- Kargo bilgilerini kaydetme
- Kargo durumunu takip etme
- Ürünlerin kargo durumlarını izleme

### Raporlama Özellikleri
- Düşük stoklu ürünleri listeleme
- Son stok hareketlerini görüntüleme
- Bekleyen kargo işlemlerini listeleme

## Teknolojiler

- ASP.NET MVC 5
- Entity Framework 6
- C#
- HTML, CSS, JavaScript
- Bootstrap
- MS SQL Server

## Veri Modelleri

### Ürün (Product)
- Ürün bilgileri (ad, açıklama, barkod, marka)
- Stok miktarı ve minimum stok seviyesi
- Fiyat bilgileri (alış ve satış fiyatı)
- Kategori ve tedarikçi ilişkileri

### Kategori (Category)
- Kategori adı ve açıklaması
- Kategori-ürün ilişkisi

### Tedarikçi (Supplier)
- Tedarikçi bilgileri (firma adı, iletişim bilgileri)
- Tedarikçi-ürün ilişkisi

### Stok Hareketi (StockMovement)
- Hareket tipi (giriş, çıkış, sayım, satış, iade)
- Ürün ve miktar bilgisi
- Tarih ve işlemi yapan çalışan bilgisi

### Çalışan (Employee)
- Çalışan bilgileri
- Çalışanın gerçekleştirdiği stok hareketleri

### Kargo (Shipping)
- Kargo bilgileri ve durumu
- İlgili ürün bilgileri

## Kullanım

Proje, standart CRUD (Create, Read, Update, Delete) işlemlerini destekleyen bir web arayüzü sunmaktadır. Ürünleri kategorilere göre listeleyebilir, stok sayımı yapabilir ve stok hareketlerini takip edebilirsiniz.

## Geliştirici

Oğuz Kaan Baydere 