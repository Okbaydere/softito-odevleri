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
   int body = int.Parse(Console.ReadLine());
            int satir;
            satir = (body * 2) - 1; 
            int i = 1;
            while (i <= satir)
            {
               Console.WriteLine();
               int bosluk = (satir - i) / 2;
               int j = 0;
               while (j < bosluk)
               {
                   Console.Write(" ");
                   j++;
               }
               int k = 0;
               while (k < i)
               {
                   Console.Write("*");
                   k++;
               }
               i += 2;
            }
            int l = 0;
            while (l < (satir - 1) / 2) {
               Console.WriteLine();
               int t = 0;
               while (t < (satir - 3) / 2) {
                   Console.Write(" ");
                   t++;
               }
               int m = 0;
               while (m < 3)
               {
                   Console.Write("*");
                   m++;
               }
               l++;
            }

        }
    }
}
