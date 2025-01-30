using System;

namespace cozum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region çift tek toplamı
            //int Cifttoplam = 0;
            //int tekToplam = 0;
            //Console.WriteLine("Lütfen sayı gir");
            //int sayi = int.Parse(Console.ReadLine());
            //while (sayi > 0)
            //{
            //    if (sayi % 2 == 0)
            //    {
            //        Cifttoplam += sayi;
            //        sayi--;
            //    }
            //    else
            //    {
            //        tekToplam += sayi;
            //        sayi--;
            //    }
            //}
            //Console.WriteLine($"Tek sayıların toplamı = {tekToplam}");
            //Console.WriteLine($"Cift sayıların toplamı = {Cifttoplam}");
            //Console.ReadLine();

            #endregion
            #region sayı kadar 1 22 333
            //int sayi;
            //int i = 1;
            //sayi = int.Parse(Console.ReadLine());

            //while (i <= sayi)
            //{
            //    int j = 1;
            //    while (j <= i)
            //    {
            //        Console.Write(i);
            //        j++;
            //    }
            //    Console.WriteLine();
            //    i++;
            //}

            #endregion
            #region Sayı kadar Ters 111 22 3

            //int sayi;
            //int i = 1;
            //sayi = int.Parse(Console.ReadLine());

            //while (i <= sayi)
            //{
            //    int j = sayi;
            //    while (j >= i)
            //    {
            //        Console.Write(i);
            //        j--;
            //    }
            //    Console.WriteLine();
            //    i++;
            //}


            #endregion
            #region Çam ağacı

            //int body = int.Parse(Console.ReadLine());
            //int satir;
            //satir = (body * 2) - 1; 
            //int i = 1;
            //while (i <= satir)
            //{
            //    Console.WriteLine();
            //    int bosluk = (satir - i) / 2;
            //    int j = 0;
            //    while (j < bosluk)
            //    {
            //        Console.Write(" ");
            //        j++;
            //    }
            //    int k = 0;
            //    while (k < i)
            //    {
            //        Console.Write("*");
            //        k++;
            //    }
            //    i += 2;
            //}
            //int l = 0;
            //while (l < (satir - 1) / 2) {
            //    Console.WriteLine();
            //    int t = 0;
            //    while (t < (satir - 3) / 2) {
            //        Console.Write(" ");
            //        t++;
            //    }
            //    int m = 0;
            //    while (m < 3)
            //    {
            //        Console.Write("*");
            //        m++;
            //    }
            //    l++;
            //}

            #endregion
            #region elmas
            //int bosluk;
            //int yildiz;
            //int n;
            //while (true)
            //{
            //    Console.WriteLine("Orta satırdaki * sayısını girin (tek sayı):");
            //    n = int.Parse(Console.ReadLine());
            //    if (n % 2 != 0)
            //    {
            //        break;
            //    }
            //    Console.WriteLine("Lütfen tek sayı girin.");
            //}

            //int i = 1;
            //while (i <= n)
            //{
            //    bosluk = (n - i) / 2;
            //    yildiz = i;

            //    int j = 0;
            //    while (j < bosluk)
            //    {
            //        Console.Write(" ");
            //        j++;
            //    }

            //    int k = 0;
            //    while (k < yildiz)
            //    {
            //        Console.Write("*");
            //        k++;
            //    }

            //    Console.WriteLine();
            //    i += 2;
            //}

            //i = n - 2;
            //while (i >= 1)
            //{
            //    bosluk = (n - i) / 2;
            //    yildiz = i;

            //    int j = 0;
            //    while (j < bosluk)
            //    {
            //        Console.Write(" ");
            //        j++;
            //    }

            //    int k = 0;
            //    while (k < yildiz)
            //    {
            //        Console.Write("*");
            //        k++;
            //    }

            //    Console.WriteLine();
            //    i -= 2;
            //}

            #endregion
            #region sağa dayalı yıldız
            //Console.Write("Yıldız sayısı giriniz: ");
            //int i = 1;
            //int yildiz = Convert.ToInt32(Console.ReadLine());

            //while (i <= yildiz)
            //{
            //    int k = yildiz - i;
            //    while (k > 0)
            //    {
            //        Console.Write(" ");
            //        k--;
            //    }
            //    int j = 1;
            //    while (j <= i)
            //    {
            //        Console.Write("*");
            //        j++;
            //    }
            //    Console.WriteLine();
            //    i++;

            //}

            // #endregion
            // #region Kare yıldız
            // int i = 0;
            // Console.WriteLine("Kaç yıldızlı kare olsun?");
            // int yildiz = int.Parse(Console.ReadLine());
            // while (i < yildiz)
            // {
            //     int j = 0;
            //     while (j < yildiz)
            //     {
            //         Console.Write("*");
            //         j++;
            //     }
            //     Console.WriteLine();
            //     i++;
            // }



            #endregion
            #region Fibonacci

            //int a = 1;
            //int b = 1;
            //int i = 0;
            //Console.Write("Gösterilecek Fibonacci Adım Sayısını Girin: ");
            //int sayi = int.Parse(Console.ReadLine());
            //while (i < sayi)
            //{
            //    Console.Write(a+ " ");
            //    int adim = a + b;
            //    a = b;
            //    b = adim;
            //    i++;
            //}

            #endregion
            #region asal sayılar

            //int i = 2;
            //Console.WriteLine("Kaça kadar bakmak istersin?"); // diyelim ki 10 koyduk. 2,3,5,7 çıkması lazım. 
            //int step = Convert.ToInt32(Console.ReadLine());
            //while (i <= step)
            //{
            //    bool asalMi = true;
            //    int j = 2;
            //    while (j <= i / 2)
            //    {
            //        if (i % j == 0)
            //        {
            //            asalMi = false;
            //            break;
            //        }

            //        j++;
            //    }
            //    if (asalMi)
            //    {
            //        Console.WriteLine(i);
            //    }
            //    i++;
            //}

            #endregion
            #region 1000 sayısının bölenleri
            //int i = 1;
            //while (i<= 1000)
            //{
            //    if (1000%i == 0)
            //    {
            //        Console.WriteLine(i);
            //    }
            //    i++;
            //}
            #endregion
            #region 3 kere giriş hakkı  para çekme, para gönderme, bakiye kontrol, çıkış
            //int bakiye = 10000;
            //string sifre = "1234";
            //string girilen;
            //int hak = 3;

            //while (hak > 0)
            //{
            //    Console.Write("Şifrenizi Girin: ");
            //    girilen = Console.ReadLine();

            //    if (girilen == sifre)
            //    {
            //        Console.WriteLine("Giriş başarılı!\n");
            //        break;
            //    }

            //    hak--;
            //    Console.WriteLine($"Hatalı şifre. Kalan hakkınız: {hak}");
            //    if (hak == 0)
            //    {
            //        Console.WriteLine("Giriş hakkınız bitti. Programdan çıkılıyor.");
            //        return;
            //    }
            //}

            //bool cikis = false;
            //while (!cikis)
            //{
            //    Console.WriteLine("\n1. Para Çekme\n2. Para Gönderme\n3. Bakiye Kontrol\n4. Bakiye Yükle\n5. Çıkış");
            //    Console.Write("Seçiminiz: ");
            //    string secim = Console.ReadLine();

            //    if (secim == "1" || secim == "2" || secim == "4")
            //    {
            //        Console.WriteLine($"Güncel bakiyeniz: {bakiye} TL");
            //        Console.Write("Tutarı girin: ");
            //        if (int.TryParse(Console.ReadLine(), out int tutar) && tutar > 0)
            //        {
            //            if (secim == "1" || secim == "2") // Para Çekme ve Gönderme
            //            {
            //                if (tutar > bakiye)
            //                {
            //                    Console.WriteLine("Yetersiz bakiye.");
            //                }
            //                else
            //                {
            //                    bakiye -= tutar;  
            //                    Console.WriteLine($"İşlem başarılı. Güncel bakiye: {bakiye} TL");
            //                }
            //            }
            //            else if (secim == "4") // Bakiye Yükleme
            //            {
            //                bakiye += tutar;
            //                Console.WriteLine($"Başarıyla {tutar} TL yüklendi. Güncel bakiye: {bakiye} TL");
            //            }
            //        }
            //        else
            //        {
            //            Console.WriteLine("Geçersiz tutar.");
            //        }
            //    }
            //    else if (secim == "3")
            //    {
            //        Console.WriteLine($"Güncel bakiyeniz: {bakiye} TL");
            //    }
            //    else if (secim == "5")
            //    {
            //        cikis = true;
            //        Console.WriteLine("Çıkış yapılıyor. Hoşçakalın!");
            //    }
            //    else
            //    {
            //        Console.WriteLine("Geçersiz seçenek. Lütfen tekrar deneyin.");
            //    }
            //}
            #endregion

        }
    }
}
