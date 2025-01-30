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
            int i = 2;
            Console.WriteLine("Kaça kadar bakmak istersin?");
            int step = Convert.ToInt32(Console.ReadLine());
            while (i <= step)
            {
                bool asalMi = true;
                int j = 2;
                while (j <= i / 2)
                {
                    if (i % j == 0)
                    {
                        asalMi = false;
                        break;
                    }

                    j++;
                }
                if (asalMi)
                {
                    Console.WriteLine(i);
                }
                i++;
            }

        }
    }
}
