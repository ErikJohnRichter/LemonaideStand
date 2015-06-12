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
            int money = 5;
            int cups = 20;
            int lemonaide = 20;
            int water = 20;
            
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("You have {0} paper cups", cups);
            Console.WriteLine("You have {0} tablespoons of lemonaide", lemonaide);
            Console.WriteLine("You have {0} cups of water", water);
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("");
            int product;
            if (cups == 0 || lemonaide == 0 || water == 0)
            {
                product = 0;
                Console.WriteLine("With your inventory, you can make {0} cups of lemonaide", product);
                Console.WriteLine("Would you like to purchase supplies?");
                string buy = Console.ReadLine();
                Console.WriteLine("");
                if (buy == "yes")
                {
                    Thread.Sleep(1000);
                    buyItems(cups, lemonaide, water, money);
                }
                else
                {
                    Console.WriteLine("Do you want to go home?");
                    string exit = Console.ReadLine();
                    Console.WriteLine("");
                    if (exit == "yes")
                    {
                        Console.WriteLine("Have a nice day!");
                        Console.ReadKey();
                        Environment.Exit(0);
                    }
                } 
            }
            else
            {
                product = Math.Max(cups, Math.Max(lemonaide, water));
            }
            Thread.Sleep(1000);
            Console.WriteLine("With your inventory, you can make {0} cups of lemonaide", product);
            Thread.Sleep(3000);
            Console.WriteLine("Would you like to purchase supplies?");
            string buy2 = Console.ReadLine();
            Thread.Sleep(1000);
            if (buy2 == "yes")
            {
                
                buyItems(cups, lemonaide, water, money);
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("How much should each glass be?");
                Console.WriteLine("----------------");
                Console.WriteLine("1, 2, 3, 4, or 5");
                Console.WriteLine("----------------");
                Console.Write("$");
                int price = Convert.ToInt16(Console.ReadLine());
                int totalDemand = baseDemand + weather + Math.Abs(price - 6);

                //Console.WriteLine("----");
                //Console.WriteLine(baseDemand);
                //Console.WriteLine(weather);
                //Console.WriteLine(price);
                //Console.WriteLine("----");
                Console.WriteLine(totalDemand);
                Console.ReadKey();
            }

        }

        private static void buyItems(int cups, int lemonaide, int water, int money)
        {

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("WELCOME TO THE STORE");
            Console.WriteLine("Let's buy some supplies...");
            Console.WriteLine("Right now, you have:");
            Console.WriteLine("-----------------------------");
            Console.WriteLine("{0} paper cups", cups);
            Console.WriteLine("{0} tablespoons of lemonaide", lemonaide);
            Console.WriteLine("{0} cups of water", water);
            Console.WriteLine("-----------------------------");
            Console.WriteLine("");
            Thread.Sleep(1000);
            Console.WriteLine("You have ${0} in petty cash.", money);
            Console.WriteLine("");
           
            Console.WriteLine("Each unit of supplies costs $1.");
            Console.WriteLine("");
            
            Console.WriteLine("What would you like to buy?");
            Console.WriteLine("1: Cups");
            Console.WriteLine("2: Lemonaide");
            Console.WriteLine("3: Water");
          
            int buy = Convert.ToInt16(Console.ReadLine());
            switch (buy)
            {
                case 1:
                    Console.WriteLine("");
                    Console.WriteLine("How many paper cups would you like to buy?");
                    int buyCups = Convert.ToInt16(Console.ReadLine());
                    if (money >= buyCups)
                    {
                        money = money - buyCups;
                        cups = cups + buyCups;
                        Console.WriteLine("You just purchased {0} cups and have {1} in your supply cart", buyCups, cups);
                        Console.WriteLine("You have ${0} in petty cash.", money);
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Sorry, you do not have enough money to buy that.");
                        Console.WriteLine("Would you like to select again?");
                        Console.ReadKey();
                    }
                    Console.WriteLine("");
                    break;
                case 2:
                    Console.WriteLine("");
                    Console.WriteLine("How much lemonaide powder would you like to buy?");
                    int buyLemonaide = Convert.ToInt16(Console.ReadLine());
                    if (money >= buyLemonaide)
                    {
                        money = money - buyLemonaide;
                        cups = cups + buyLemonaide;
                        Console.WriteLine("You just purchased {0} cups and have {1} in your supply cart", buyLemonaide, cups);
                        Console.WriteLine("You have ${0} in petty cash.", money);
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Sorry, you do not have enough money to buy that.");
                        Console.WriteLine("Would you like to select again?");
                        Console.ReadKey();
                    }
                    Console.WriteLine("");
                    break;
                case 3:
                    Console.WriteLine("");
                    Console.WriteLine("How many cups of water would you like to buy?");
                    int buyWater = Convert.ToInt16(Console.ReadLine());
                    if (money >= buyWater)
                    {
                        money = money - buyWater;
                        cups = cups + buyWater;
                        Console.WriteLine("You just purchased {0} cups and have {1} in your supply cart", buyWater, cups);
                        Console.WriteLine("You have ${0} in petty cash.", money);
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Sorry, you do not have enough money to buy that.");
                        Console.WriteLine("Would you like to select again?");
                        Console.ReadKey();
                    }
                    Console.WriteLine("");
                    break;
            }
            Console.ReadKey();
           
        }
    }
}
