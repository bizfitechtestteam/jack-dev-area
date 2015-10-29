using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethods1
{
    class Program
    {
        static void Main(string[] args)
        {
          
            var p = new Person {Name = "John", Age = 33};
            var p2 = new Person {Name = "Sally", Age = 35};
            var p3 = new Person {Name= "Adam", Age = 0};
            //p.SayHello(p2);
            p3.AddAge(p,p2);
            Console.ReadLine();
        }
    }

    public static class Extensions
    {
        public static void SayHello(this Person person, Person person2)
        {
            Console.WriteLine("{0} says hello to {1}",person.Name, person2.Name);
        }

        public static void AddAge(this Person person3, Person person,Person person2)
        {
            Console.WriteLine(person3.Age + person.Age + person2.Age);
            return;
        }
    }
}
