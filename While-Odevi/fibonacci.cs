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

            int a = 1;
            int b = 1;
            int i = 0;
            Console.Write("Gösterilecek Fibonacci Adım Sayısını Girin: ");
            int sayi = int.Parse(Console.ReadLine());
            while (i < sayi)
            {
                Console.Write(a + " ");
                int adim = a + b;
                a = b;
                b = adim;
                i++;
            }

        }
    }
}
