Sadece temel işlemler kullanılarak(Döngüler,karar yapıları,try-catch yapısı,diziler ) yapılan Konsol tabanlı bir restoran sipariş yönetim sistemi.
Menü işlemlerinin tanımı:
[1] Masa Aç (Sipariş Al)
    - Dolu ve boş masaları sıralar. 
    - Boş masalar için menü'den yemek siparişi seçilir
    - Sipariş verebilmek için bir rakama tıkladıktan sonra tekrar istenilen ürünün girilmesi beklenir.Çünkü burada iki farklı input işlemi alıyorum. 
    - Eğer konsol rakam algılarsa "Ürün No:" şeklinde yeni bir input alıyor. Algılamazsa ESC,Space ve sol ok tuşu işlemini gerçekleştiriyor
    - Sol ok tuşu ile verilen siparişteki son ürün siliniyor. Eğer ürün yoksa masa seçimine tekrar dönüyor
[2] Masa İşlemleri (Masa Aktifleştir)
    - Burada restoranın aktifliğine göre masaları aktifleştiriyoruz.
    - Aktif olan masalarda işlem yapılabiliyor.
    - Yani aslında kullanıcının ilk yapması gereken işlem burası.
[3] Masa Hesap
    - Her bir masanın o günkü toplam kazançları hesaplanır.
    -Örneğin
    -Masa 3 - Toplam: 233.00 TL
    -Masa 5 - Toplam: 148.00 TL
[4] Kasa İşlemleri
    - O günkü bütün masaların kazandırdığı toplam kazanç
    -Örneğin
    -Toplam gelir: 381.00 TL