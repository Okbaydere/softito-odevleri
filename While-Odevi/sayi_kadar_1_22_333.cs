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

            int sayi;
            int i = 1;
            sayi = int.Parse(Console.ReadLine());

            while (i <= sayi)
            {
                int j = 1;
                while (j <= i)
                {
                    Console.Write(i);
                    j++;
                }
                Console.WriteLine();
                i++;
            }

        }
    }
}
