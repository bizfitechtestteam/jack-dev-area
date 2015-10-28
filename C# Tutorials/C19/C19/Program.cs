using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C19
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Type in a super hero's name  to see his nickname:");
            string userValue = Console.ReadLine();

            switch (userValue.ToUpper())
            {
                case "BATMAN":
                    Console.WriteLine("Caped Crusader");
                    break;
                case "SUPERMAN":
                    Console.WriteLine("Man of steel");
                    break;
                case "GREEN LANTERN":
                    Console.WriteLine("Emerald Knight");
                    break;
                default:
                    Console.WriteLine("does not compute");
                    break;
                    
            }
        }
    }
}
