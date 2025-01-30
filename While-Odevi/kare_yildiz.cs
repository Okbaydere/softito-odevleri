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
            int i = 0;
            Console.WriteLine("Kaç yıldızlı kare olsun?");
            int yildiz = int.Parse(Console.ReadLine());
            while (i < yildiz)
            {
                int j = 0;
                while (j < yildiz)
                {
                    Console.Write("*");
                    j++;
                }
                Console.WriteLine();
                i++;
            }

        }
    }
}
