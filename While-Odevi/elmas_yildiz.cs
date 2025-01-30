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
            int bosluk;
            int yildiz;
            int n;
            while (true)
            {
                Console.WriteLine("Orta satırdaki * sayısını girin (tek sayı):");
                n = int.Parse(Console.ReadLine());
                if (n % 2 != 0)
                {
                    break;
                }
                Console.WriteLine("Lütfen tek sayı girin.");
            }

            int i = 1;
            while (i <= n)
            {
                bosluk = (n - i) / 2;
                yildiz = i;

                int j = 0;
                while (j < bosluk)
                {
                    Console.Write(" ");
                    j++;
                }

                int k = 0;
                while (k < yildiz)
                {
                    Console.Write("*");
                    k++;
                }

                Console.WriteLine();
                i += 2;
            }

            i = n - 2;
            while (i >= 1)
            {
                bosluk = (n - i) / 2;
                yildiz = i;

                int j = 0;
                while (j < bosluk)
                {
                    Console.Write(" ");
                    j++;
                }

                int k = 0;
                while (k < yildiz)
                {
                    Console.Write("*");
                    k++;
                }

                Console.WriteLine();
                i -= 2;
            }

        }
    }
}
