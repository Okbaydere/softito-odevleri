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
            Console.Write("Yıldız sayısı giriniz: ");
            int i = 1;
            int yildiz = Convert.ToInt32(Console.ReadLine());

            while (i <= yildiz)
            {
                int k = yildiz - i;
                while (k > 0)
                {
                    Console.Write(" ");
                    k--;
                }
                int j = 1;
                while (j <= i)
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
