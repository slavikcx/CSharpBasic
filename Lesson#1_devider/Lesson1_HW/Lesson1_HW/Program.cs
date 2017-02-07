using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1_HW
{
    class Program
    {
        static void Main(string[] args)
        {
            int x, y;

            Console.Write("Please enter first number: ");
            x = Convert.ToInt32(Console.ReadLine());

            Console.Write("PLease enter second number: ");
            y = Convert.ToInt32(Console.ReadLine());

            if (x%y==0)
            {
                Console.WriteLine("{0} is devider of {1}", y, x);
            }
            else
            {
                Console.WriteLine("{0} is NOT devider of {1}", y, x);
            }

            Console.ReadKey();
        }
    }
}
