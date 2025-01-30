using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace while_odevi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int Cifttoplam = 0;
            int tekToplam = 0;
            Console.WriteLine("Lütfen sayı gir");
            int sayi = int.Parse(Console.ReadLine());
            while (sayi > 0)
            {
                if (sayi % 2 == 0)
                {
                    Cifttoplam += sayi;
                    sayi--;
                }
                else
                {
                    tekToplam += sayi;
                    sayi--;
                }
            }
            Console.WriteLine($"Tek sayıların toplamı = {tekToplam}");
            Console.WriteLine($"Cift sayıların toplamı = {Cifttoplam}");
            Console.ReadLine();


        }
    }
}
