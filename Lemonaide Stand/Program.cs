using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lemonaide_Stand
{
    class Program
    {
        enum Weather
        {
            Rainy = 0,
            Cold = 1,
            Cloudy = 2,
            Sunny = 3,
            Hot = 4,
        }
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int baseDemand = rnd.Next(0, 2);
            int weather = rnd.Next(0, 5);
            Weather type = (Weather)weather;
            Console.WriteLine("           WELCOME TO YOUR LEMONAIDE STAND!");
            Console.ReadKey();
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Let's check the weather...");
            Thread.Sleep(3000);
            Console.WriteLine("Today is {0}", type);
            Thread.Sleep(1000);
            Console.WriteLine("");
            Console.WriteLine("Let's check your supply next...");
            Thread.Sleep(3000);
            int supply;


            Console.WriteLine("How much should each glass be?");
            Console.WriteLine("----------------");
            Console.WriteLine("1, 2, 3, 4, or 5");
            Console.WriteLine("----------------");
            Console.Write("$");
            int price = Convert.ToInt16(Console.ReadLine());
            int totalDemand = baseDemand + weather + Math.Abs(price-6);
            
            //Console.WriteLine("----");
            //Console.WriteLine(baseDemand);
            //Console.WriteLine(weather);
            //Console.WriteLine(price);
            //Console.WriteLine("----");
            Console.WriteLine(totalDemand);
            Console.ReadKey();

        }
    }
}
