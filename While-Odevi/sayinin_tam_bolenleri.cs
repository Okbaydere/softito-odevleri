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
            int i = 1;
            int sayi = int.Parse(Console.ReadLine());
            while (i<= sayi)
            {
               if (sayi%i == 0)
               {
                   Console.WriteLine(i);
               }
               i++;
            }
    }
}
