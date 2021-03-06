﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C16
{
    class Program
    {
        static void Main(string[] args)
        {
            Car myNewCar = new Car();

            myNewCar.Make = "BMW";
            myNewCar.Model = "745li";
            myNewCar.Color = "Black";
            myNewCar.Year = 2005;
            
            Truck myTruck = new Truck();
            myTruck.Make = "Ford";
            myTruck.Model = "F950";
            myTruck.Year = 2006;
            myTruck.Color = "Black";
            myTruck.TowingCapacity = 1200;

           // someMethod(myNewCar);
           // someMethod(myTruck);

            myNewCar.PrintMe();
            myTruck.PrintMe();

            Console.ReadLine();

        }
        
            private static void someMethod(Car car)
            {
                Console.WriteLine("From someMethod: {0}",car.Make);
            }

        
    }

    abstract class Vehicle
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }

        public abstract void PrintMe();

    }

    class Car : Vehicle
    {

        //public virtual void PrintMe()
        //{
        //    Console.WriteLine("{0}  -  {1}", this.Make, this.Model);
        //}

        public override void PrintMe()
        { 
            Console.WriteLine("{0}  -  {1}", this.Make, this.Model);
        }

    }

    sealed class Truck : Vehicle
    {
        public int TowingCapacity { get; set; }

        public override void PrintMe()
        {
            Console.WriteLine("{0} - {1}", this.Make,this.TowingCapacity.ToString());
        }
    }

    class ReallyBigtruck : Truck
    {
        
    }

}
