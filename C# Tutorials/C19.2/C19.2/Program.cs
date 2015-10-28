using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C19._2
{
    class Program
    {
        private static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            //Superhero myValue = Superhero.Batman;
            //Console.WriteLine("Hello World!");
            Console.WriteLine("Type in a super heros name to see his nickname");
            string userValue = Console.ReadLine();

            Superhero myValue = 0;
            if (Enum.TryParse<Superhero>(userValue, true, out myValue))
            {

                switch (myValue)
                {
                    case Superhero.Batman:
                        Console.WriteLine("Caped Crusader");
                        break;
                    case Superhero.Superman:
                        Console.WriteLine("Man of Steel");
                        break;
                    case Superhero.GreenLantern:
                        Console.WriteLine("Emerald Knight");
                        break;
                        Default:
                        Console.WriteLine("Does not compute");
                        break;
                        
                }
            }
            else
            {
                Console.WriteLine("Does not compute");
            }
    }
    }

    enum Superhero
    {
        Batman,
        Superman,
        GreenLantern
    }
}
