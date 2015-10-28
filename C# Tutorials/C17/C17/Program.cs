using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tabor;

namespace C17
{
    class Program
    {
        static void Main(string[] args)
        {
            //System.IO.StreamReader myStreamReader = new System.IO.StreamReader("");

            //StreamReader myStreamReader = new StreamReader(""); //Bob didn't put in any arguments causing me an error...

            Bob myBob = new Bob();
            Console.WriteLine(myBob.Lookup("http://www.learnvisualstudio.net"));
            Console.ReadLine();

        }
    }
}
