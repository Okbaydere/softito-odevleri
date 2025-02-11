## Menü İşlemleri

### 1. Masa Aç (Sipariş Al)
- Sistemdeki dolu ve boş masaların listesi görüntülenir
- Boş masalar için menüden yemek siparişi seçilebilir
- Sipariş süreci:
  - İlk olarak masa numarası için rakam girişi beklenir
  - Ardından seçilen ürünün numarası için ikinci bir giriş beklenir
  - Giriş rakam değilse, aşağıdaki özel tuş işlemleri gerçekleşir:
    - `ESC`: İşlemi sonlandırır
    - `Space`: Boşluk tuşu işlemi
    - `←` (Sol ok): Son eklenen ürünü siler
      - Silinecek ürün yoksa masa seçimine geri döner

### 2. Masa İşlemleri (Masa Aktifleştir)
- Restoranın çalışma durumuna göre masaları aktif yapma
- Sistemde işlem yapmadan önce ilk olarak masaların aktifleştirilmesi gerekir

### 3. Masa Hesap
- Her masanın günlük toplam kazancını görüntüleme
- Örnek çıktı:
```
Masa 3 - Toplam: 233.00 TL
Masa 5 - Toplam: 148.00 TL
```

### 4. Kasa İşlemleri
- Günlük tüm masaların toplam kazancını görüntüleme
- Örnek çıktı:
```
Toplam gelir: 381.00 TL
```
