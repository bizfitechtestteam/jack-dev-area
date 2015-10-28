using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C18
{
    class Program
    {

        //private static string k = "";
        static void Main(string[] args)
        {
           /* string j = "";
            for (int i = 0; i < 10; i++)
            {
                j = i.ToString();
                k = i.ToString();
                Console.WriteLine(i);

                if (i == 9)
                {
                    string l = i.ToString();
                }

                //Console.WriteLine(l);
                
            }

            Console.WriteLine("outside of for: "+j);
            //Console.WriteLine("k: " + k);

            helperMethod();
            */
            Car car = new Car();
            car.DoSomething();
            Console.ReadLine();
        }

        //static void helperMethod()
        //{
        //    Console.WriteLine("K from helpermethod"+k);
        //}
    }

    class Car
    {
        public void DoSomething()
        {
            Console.WriteLine(helperMethod());
        }

        private string helperMethod()
        {
            return "Hello World!";
        }
    }
}
