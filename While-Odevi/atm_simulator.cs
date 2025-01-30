using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ilkders
{
    internal class Program
    {
        static void Main(string[] args)
        {  
    int bakiye = 10000;
            string sifre = "1234";
            string girilen;
            int hak = 3;

            while (hak > 0)
            {
               Console.Write("Şifrenizi Girin: ");
               girilen = Console.ReadLine();

               if (girilen == sifre)
               {
                   Console.WriteLine("Giriş başarılı!\n");
                   break;
               }

               hak--;
               Console.WriteLine($"Hatalı şifre. Kalan hakkınız: {hak}");
               if (hak == 0)
               {
                   Console.WriteLine("Giriş hakkınız bitti. Programdan çıkılıyor.");
                   return;
               }
            }

            bool cikis = false;
            while (!cikis)
            {
               Console.WriteLine("\n1. Para Çekme\n2. Para Gönderme\n3. Bakiye Kontrol\n4. Bakiye Yükle\n5. Çıkış");
               Console.Write("Seçiminiz: ");
               string secim = Console.ReadLine();

               if (secim == "1" || secim == "2" || secim == "4")
               {
                   Console.WriteLine($"Güncel bakiyeniz: {bakiye} TL");
                   Console.Write("Tutarı girin: ");
                   if (int.TryParse(Console.ReadLine(), out int tutar) && tutar > 0)
                   {
                       if (secim == "1" || secim == "2") // Para Çekme ve Gönderme
                       {
                           if (tutar > bakiye)
                           {
                               Console.WriteLine("Yetersiz bakiye.");
                           }
                           else
                           {
                               bakiye -= tutar;  
                               Console.WriteLine($"İşlem başarılı. Güncel bakiye: {bakiye} TL");
                           }
                       }
                       else if (secim == "4") // Bakiye Yükleme
                       {
                           bakiye += tutar;
                           Console.WriteLine($"Başarıyla {tutar} TL yüklendi. Güncel bakiye: {bakiye} TL");
                       }
                   }
                   else
                   {
                       Console.WriteLine("Geçersiz tutar.");
                   }
               }
               else if (secim == "3")
               {
                   Console.WriteLine($"Güncel bakiyeniz: {bakiye} TL");
               }
               else if (secim == "5")
               {
                   cikis = true;
                   Console.WriteLine("Çıkış yapılıyor. Hoşçakalın!");
               }
               else
               {
                   Console.WriteLine("Geçersiz seçenek. Lütfen tekrar deneyin.");
               }
            }
        }
    }
}
