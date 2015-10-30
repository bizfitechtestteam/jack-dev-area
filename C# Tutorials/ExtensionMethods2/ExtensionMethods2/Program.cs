using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethods2
{
    class Program
    {
        static void Main(string[] args)
        {

            double noVAT = 0;
            List<Product> Products = new List<Product>() //Create list of products
            {
                new Product{ProductName = "White Shoe", ProductPrice = 10}, //set name and price
                new Product{ProductName = "Green Shoe", ProductPrice = 5},
                new Product{ProductName = "Black Shoe", ProductPrice = 15}
            };

            foreach (Product p in Products) // for eaach product in product list, list their name and price.
            {
                //Console.WriteLine("{0} costs {1}", p.ProductName, p.ProductPrice);
                Console.WriteLine("{0} - Without VAT: {1:C} - VAT: {2:C} - Total inc VAT: {3:C}", p.ProductName, p.ProductPrice, p.CalculateVat(),p.CalculateWithVat());
            }
            Console.ReadLine();
        }
    }

    public static class MyExtensions
    {
        public static double CalculateVat(this Product p)
        {
            return (p.ProductPrice * .25);
        }

        public static double CalculateWithVat(this Product p)
        {
            return (p.ProductPrice += (p.ProductPrice * .25));
        }

    }
}
