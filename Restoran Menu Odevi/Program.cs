using System;

namespace RestaurantMenu
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] masalar = new int[10];
            double[] masaToplamFiyatlari = new double[10];
            string[] siparisler = new string[200]; // Her masa için 20 sipariş, toplam 10 masa = 200
            int[] masaSiparisSayilari = new int[10];

            // Menü öğeleri ve fiyatları
            string[] menu = {
                "Köfte", "Biftek", "Tavuk Şiş", "Adana Kebap",
                "Margarita Pizza", "Pepperoni Pizza", "Karışık Pizza", "Sade Pizza",
                "Kola", "Fanta", "Su", "Ayran",
                "Türk Kahvesi", "Latte", "Çay", "Sıcak Çikolata"
            };

            double[] fiyatlar = {
                25.0, 40.0, 20.0, 30.0,
                30.0, 35.0, 40.0, 35.0,
                5.0, 5.0, 2.0, 7.0,
                8.0, 10.0, 3.0, 9.0
            };

            while (true)
            {
                Console.Clear();
                Console.WriteLine("\n[1] Masa Aç (Sipariş Al)");
                Console.WriteLine("[2] Masa İşlemleri (Masa Aktifleştir)");
                Console.WriteLine("[3] Masa Hesap");
                Console.WriteLine("[4] Kasa İşlemleri");
                Console.WriteLine("[0] Çıkış");
                Console.Write("\nBir seçenek seçin: ");

                int islem;
                try
                {
                    islem = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {

                    Console.WriteLine("Böyle bir işlem yok. Devam etmek için herhangi bir tuşa basın...");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }

                if (islem == 0)
                    break;

                switch (islem)
                {
                    case 1: // Masa Aç / Sipariş Al
                        Console.Clear();
                        // Dolu masa kontrolü
                        bool doluMu = false;
                        for (int i = 0; i < masalar.Length; i++)
                        {
                            if (masalar[i] == 1)
                            {
                                doluMu = true;
                                break;
                            }
                        }
                        if (doluMu == false)
                        {
                            Console.Clear();
                            Console.WriteLine("Aktif masa mevcut değil. Lütfen Masa İşlemleri(2)'nden masa aktifleştirin!");
                            Console.WriteLine("Devam etmek için herhangi bir tuşa basın...");
                            Console.ReadKey();
                            continue;
                        }

                        Console.Clear();
                        Console.WriteLine("Mevcut Masalar:");
                        for (int i = 0; i < masalar.Length; i++)
                        {
                            if (masalar[i] == 1) // 1 ise aktif ve boş
                                Console.WriteLine($"{i + 1}. Masa (Boş)");
                            else if (masalar[i] == 2) // 2 ise aktif ve dolu
                                Console.WriteLine($"{i + 1}. Masa (Dolu)");
                        }

                        Console.Write("Müşteri hangi masaya oturacak? (Masa numarasını girin): ");
                        int masaNumarasi;
                        try
                        {
                            masaNumarasi = int.Parse(Console.ReadLine());
                            if (masaNumarasi < 1 || masaNumarasi > masalar.Length)
                            {
                                Console.WriteLine("Lütfen dolu masalardan birini seçiniz!");
                                Console.Read();
                                continue;

                            }
                        }
                        catch (Exception)
                        {

                            Console.WriteLine("Geçersiz masa numarası! Devam etmek için herhangi bir tuşa basın...");
                            Console.ReadKey();
                            Console.Clear();
                            continue;
                        }

                        if (masalar[masaNumarasi - 1] == 1)
                        {
                            double toplamFiyat = 0;
                            int siparisSayisi = 0;

                            while (true)
                            {
                                Console.Clear();
                                // Yemek menüsü Arayüzü 
                                // ----------------------------------------------
                                // Menüyü iki sütun olarak göster
                                int solSutun = 3;
                                int sagSutun = Console.WindowWidth / 2 + 3;
                                int solSatir = 3;
                                int sagSatir = 3;

                                // Menü başlıkları
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.SetCursorPosition(solSutun, solSatir++);
                                Console.WriteLine("YEMEK MENÜSÜ");
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.SetCursorPosition(solSutun, solSatir++);
                                Console.WriteLine("Et Yemekleri:");
                                Console.ForegroundColor = ConsoleColor.White;
                                for (int i = 0; i < 4; i++)
                                {
                                    Console.SetCursorPosition(solSutun, solSatir++);
                                    Console.WriteLine($"{i + 1}. {menu[i]} - {fiyatlar[i]} TL");
                                }
                                solSatir++;
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.SetCursorPosition(solSutun, solSatir++);
                                Console.WriteLine("Pizzalar:");
                                Console.ForegroundColor = ConsoleColor.White;
                                for (int i = 4; i < 8; i++)
                                {
                                    Console.SetCursorPosition(solSutun, solSatir++);
                                    Console.WriteLine($"{i + 1}. {menu[i]} - {fiyatlar[i]} TL");
                                }

                                // İçecekler
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.SetCursorPosition(sagSutun, sagSatir++);
                                Console.WriteLine("İÇECEKLER");
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.SetCursorPosition(sagSutun, sagSatir++);
                                Console.WriteLine("Soğuk İçecekler:");
                                Console.ForegroundColor = ConsoleColor.White;
                                for (int i = 8; i < 12; i++)
                                {
                                    Console.SetCursorPosition(sagSutun, sagSatir++);
                                    Console.WriteLine($"{i + 1}. {menu[i]} - {fiyatlar[i]} TL");
                                }
                                sagSatir++;
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.SetCursorPosition(sagSutun, sagSatir++);
                                Console.WriteLine("Sıcak İçecekler:");
                                Console.ForegroundColor = ConsoleColor.White;
                                for (int i = 12; i < 16; i++)
                                {
                                    Console.SetCursorPosition(sagSutun, sagSatir++);
                                    Console.WriteLine($"{i + 1}. {menu[i]} - {fiyatlar[i]} TL");
                                }
                                Console.ResetColor();
                                //---------------------------------------------------------------------

                                // Verilen siparişlerin listelendiği kısım
                                // ----------------------------------------------
                                Console.WriteLine("\nMevcut Sipariş:");
                                Console.WriteLine($"Masa {masaNumarasi} Siparişleri:");
                                int baslangicIndex = (masaNumarasi - 1) * 20; // Her masa için maksimum 20 sipariş alabilir
                                // 
                                for (int i = 0; i < masaSiparisSayilari[masaNumarasi - 1]; i++)
                                {
                                    Console.WriteLine($" {siparisler[baslangicIndex + i]}");
                                }
                                Console.WriteLine($"Toplam: {toplamFiyat} TL\n");

                                Console.WriteLine("Talimatlar:");
                                Console.WriteLine("SPACE: Siparişi Tamamla");
                                Console.WriteLine("ESC: Siparişi İptal Et");
                                Console.WriteLine("<-(sol ok tuşu): Son Siparişi Sil");
                                Console.WriteLine("Ürün numarası girerek sipariş ekleyin");
                                Console.Write("\nSeçiminiz: ");

                                var keyInfo = Console.ReadKey(true);

                                if (keyInfo.Key == ConsoleKey.Spacebar)
                                {
                                    Console.Clear();
                                    if (siparisSayisi == 0)
                                    {
                                        Console.WriteLine("Hiç sipariş alınmadı. Ana menüye dönmek için herhangi bir tuşa basın...");
                                        Console.ReadKey();
                                        break;
                                    }
                                    Console.WriteLine($"\nMasa {masaNumarasi} sipariş toplamı: {toplamFiyat} TL");
                                    masalar[masaNumarasi - 1] = 2; // seçilen masayı dolu olarak işaretle
                                    masaToplamFiyatlari[masaNumarasi - 1] = toplamFiyat;// masa işlemleri için toplam fiyatı kaydet
                                    Console.WriteLine("Ana menüye dönmek için herhangi bir tuşa basın...");
                                    Console.ReadKey();
                                    break;
                                }
                                else if (keyInfo.Key == ConsoleKey.Escape)
                                {
                                    Console.WriteLine("Sipariş iptal edildi. Geri dönmek için herhangi bir tuşa basın...");
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;
                                }
                                else if (keyInfo.Key == ConsoleKey.LeftArrow)
                                {
                                    if (masaSiparisSayilari[masaNumarasi - 1] > 0)
                                    {
                                        // Son siparişin fiyatını bul ve toplam fiyattan çıkar
                                        int sonSiparisIndex = (masaNumarasi - 1) * 20 + masaSiparisSayilari[masaNumarasi - 1] - 1;
                                        string sonSiparis = siparisler[sonSiparisIndex];
                                        int fiyatIndex = sonSiparis.LastIndexOf('-') + 1;
                                        string fiyatStr = sonSiparis.Substring(fiyatIndex, sonSiparis.Length - fiyatIndex - 3); // " TL" kısmını çıkar
                                        double silinecekFiyat = double.Parse(fiyatStr);

                                        toplamFiyat -= silinecekFiyat;
                                        siparisSayisi--;

                                        // Son siparişi kaldır
                                        siparisler[sonSiparisIndex] = null;
                                        masaSiparisSayilari[masaNumarasi - 1]--;

                                        Console.WriteLine("Son öğe kaldırıldı. Devam etmek için herhangi bir tuşa basın...");
                                        Console.ReadKey();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Kaldırılacak öğe yok. Masa seçimine dönülüyor...");
                                        Console.ReadKey();
                                        masalar[masaNumarasi - 1] = 1; // Masayı tekrar aktif hale getir
                                        goto case 1; // Masa seçim ekranına dön
                                    }
                                }
                                // Rakam girildiginde sipariş eklenir
                                // Rakama tıkladıktan sonra ürün no, şeklinde bir çıktı geliyor
                                // Daha sonra siparişin numarası girilip işlem gerçekleştiriliyor
                                // Diğer türlü nasıl yapacağımı bulamadım.

                                else if (char.IsDigit(keyInfo.KeyChar))
                                {
                                    Console.Write("Ürün No: ");
                                    string input = Console.ReadLine();

                                    try
                                    {
                                        if (string.IsNullOrEmpty(input))
                                        {
                                            continue;
                                        }

                                        int secim = int.Parse(input);
                                        if (secim >= 1 && secim <= menu.Length)
                                        {
                                            toplamFiyat += fiyatlar[secim - 1];

                                            // Siparişi diziye ekle
                                            int siparisIndex = (masaNumarasi - 1) * 20 + masaSiparisSayilari[masaNumarasi - 1];
                                            siparisler[siparisIndex] = $"{menu[secim - 1]} - {fiyatlar[secim - 1]} TL";
                                            masaSiparisSayilari[masaNumarasi - 1]++;

                                            siparisSayisi++;
                                        }
                                        else
                                        {
                                            Console.WriteLine("\nGeçersiz ürün numarası! Devam etmek için herhangi bir tuşa basın...");
                                            Console.ReadKey();
                                        }
                                    }
                                    catch (Exception)
                                    {
                                        Console.WriteLine("\nGeçersiz ürün numarası! Devam etmek için herhangi bir tuşa basın...");
                                        Console.ReadKey();
                                    }
                                }
                            }
                        }
                        else if (masalar[masaNumarasi - 1] == 0)
                        {
                            Console.WriteLine("Seçilen masa aktif değil!");
                            Console.WriteLine("Devam etmek için herhangi bir tuşa basın...");
                            Console.ReadKey();
                        }
                        else if (masalar[masaNumarasi - 1] == 2)
                        {
                            Console.WriteLine("Seçilen masa zaten dolu!");
                            Console.WriteLine("Devam etmek için herhangi bir tuşa basın...");
                            Console.ReadKey();
                        }
                        break;

                    case 2: // Masa İşlemleri - Masa Aktifleştir
                        Console.Clear();
                        Console.WriteLine("Masaları Aktifleştir:");
                        while (true)
                        {
                            bool herhangiPasif = false;
                            for (int i = 0; i < masalar.Length; i++)
                            {
                                if (masalar[i] == 0)
                                {
                                    Console.WriteLine($"{i + 1}. Masa");
                                    herhangiPasif = true;
                                }
                            }
                            if (!herhangiPasif)
                            {
                                Console.WriteLine("Aktifleştirilecek pasif masa kalmadı.");
                            }
                            Console.WriteLine("Ana menüye dönmek için 0'a basın...");
                            try
                            {
                                int masaSecimi = int.Parse(Console.ReadLine());
                                if (masaSecimi == 0)
                                    break;

                                int masaSecimiIndex = masaSecimi - 1;
                                if (masaSecimiIndex >= 0 && masaSecimiIndex < masalar.Length)
                                {
                                    if (masalar[masaSecimiIndex] == 0)
                                    {
                                        masalar[masaSecimiIndex] = 1;
                                        Console.Clear();
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Masa {masaSecimi} zaten aktif.");
                                        Console.WriteLine("Devam etmek için herhangi bir tuşa basın...");
                                        Console.ReadKey();
                                        Console.Clear();
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Geçersiz masa numarası!");
                                    Console.WriteLine("Devam etmek için herhangi bir tuşa basın...");
                                    Console.ReadKey();
                                    Console.Clear();
                                }
                            }
                            catch (Exception)
                            {
                                Console.Clear();
                                Console.WriteLine("Geçersiz giriş. Devam etmek için herhangi bir tuşa basın...");
                                Console.ReadKey();
                                continue;
                            }
                        }
                        break;

                    case 3: // Masa Hesap
                        Console.Clear();
                        bool siparisBulundu = false;
                        for (int i = 0; i < masaToplamFiyatlari.Length; i++)
                        {
                            if (masalar[i] == 2)
                            {
                                siparisBulundu = true;
                                Console.WriteLine($"Masa {i + 1} - Toplam: {masaToplamFiyatlari[i]:N2} TL");
                            }
                        }
                        if (!siparisBulundu)
                        {
                            Console.WriteLine("Hiç sipariş alınmadı.");
                        }
                        Console.WriteLine("Devam etmek için herhangi bir tuşa basın...");
                        Console.ReadKey();
                        break;

                    case 4: // Kasa İşlemleri - Toplam Gelir
                        Console.Clear();
                        double kasaToplam = 0;
                        for (int i = 0; i < masaToplamFiyatlari.Length; i++)
                        {
                            kasaToplam += masaToplamFiyatlari[i];
                        }
                        Console.WriteLine($"Toplam gelir: {kasaToplam:N2} TL");
                        Console.WriteLine("Devam etmek için herhangi bir tuşa basın...");
                        Console.ReadKey();
                        break;

                    default:
                        Console.WriteLine("Geçersiz işlem!");
                        Console.WriteLine("Devam etmek için herhangi bir tuşa basın...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }
        }
    }
}