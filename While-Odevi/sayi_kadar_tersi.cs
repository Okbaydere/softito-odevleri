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
       int sayi;
            int i = 1;
            sayi = int.Parse(Console.ReadLine());

            while (i <= sayi)
            {
               int j = sayi;
               while (j >= i)
               {
                   Console.Write(i);
                   j--;
               }
               Console.WriteLine();
               i++;
            }

        }
    }
}
