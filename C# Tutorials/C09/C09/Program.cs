using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C09
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] numbers = new int[5];
            //numbers[0] = 4;
            //numbers[1] = 8;
            //numbers[2] = 15;
            //numbers[3] = 16;
            //numbers[4] = 23;
            //numbers[5] = 42;

            int[] numbers = {4, 8, 15, 16, 23};

            for (int i = 0; i < numbers.Length; i++)
            {
               Console.WriteLine(numbers[i].ToString());
            }

            string[] names = {"Bob", "Steve", "Brian", "Chuck"};

            foreach (var name in names)
            {
                Console.WriteLine(name);
            }

            string myText = "Now is the time for all good men to come to the aid of their country.";
            char[] charArray = myText.ToCharArray();
            Array.Reverse(charArray);

            foreach (var myChar in charArray)
            {
                Console.Write(myChar);
            }

            //Console.WriteLine((numbers[1].ToString()));
            Console.ReadLine();
        }
    }
}
