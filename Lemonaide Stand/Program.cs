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

            DateTime dDate = DateTime.Now;
            string timeString = dDate.ToString("HH");
            int time = Convert.ToInt16(timeString);
            if (time < 6 && time > 18)
            {
                Console.WriteLine("It is too dark to sell lemonaide now.");
                Console.WriteLine("Have a nice day!");
                Console.ReadKey();
                Environment.Exit(0);
            }
            else
            {           
                Random rnd = new Random();
                int baseDemand = rnd.Next(0, 2);
                int weather = rnd.Next(0, 5);
                Weather type = (Weather)weather;
                int demand = baseDemand + weather;
                Console.WriteLine("               WELCOME TO YOUR LEMONAIDE STAND!");
                Console.ReadKey();
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("Let's check the weather...");
                Thread.Sleep(3000);
                Console.WriteLine("Today is {0}", type);
                Thread.Sleep(1000);
                int money = 5;
                int cups = 5;
                int lemonaide = 5;
                int water = 5;
                Game(cups, lemonaide, water, money, demand, type);
            }
        }

        private static void Game(int cups, int lemonaide, int water, int money, int demand, Weather type)
        {
            Console.WriteLine("");
            Console.WriteLine("Let's check your supply...");
            Thread.Sleep(3000);
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("You have {0} paper cups", cups);
            Console.WriteLine("You have {0} tablespoons of lemonaide", lemonaide);
            Console.WriteLine("You have {0} cups of water", water);
            Console.WriteLine("You have ${0} in petty cash", money);
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
                    buyItems(cups, lemonaide, water, money, demand, type);
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
                product = Math.Min(cups, Math.Min(lemonaide, water));
            }
            Thread.Sleep(1000);
            Console.WriteLine("With your inventory, you can make {0} cups of lemonaide", product);
            Thread.Sleep(500);
            Console.WriteLine("Would you like to purchase supplies?");
            string buy2 = Console.ReadLine();
            Thread.Sleep(1000);
            if (buy2 == "yes")
            {
                buyItems(cups, lemonaide, water, money, demand, type);
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("It is still {0} outside right now...", type);
                Console.WriteLine("");
                Console.WriteLine("Do you want to sell some Lemonaide?");
                string exit = Console.ReadLine();
                if (exit == "no")
                {
                    Console.WriteLine("");
                    Console.WriteLine("Do you want to go home?");
                    string whatToDo = Console.ReadLine();
                    if (whatToDo == "yes")
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Have a nice day!");
                        Console.ReadKey();
                        Environment.Exit(0);
                    }
                    else
                    {
                        Console.WriteLine("");
                        Console.WriteLine("What do you want to do, then?");
                        string whatToDo2 = Console.ReadLine();
                        Console.WriteLine("");
                        if (whatToDo2 == "I don't want to work")
                        {
                            Thread.Sleep(1000);
                            Console.WriteLine("");
                            Console.WriteLine("I WANT TO BANG ON THE DRUM ALL DAY!");
                            Thread.Sleep(1000);
                            Console.WriteLine("");
                            Console.WriteLine("I DON'T WANT TO PLAY!");
                            Thread.Sleep(1000);
                            Console.WriteLine("");
                            Console.WriteLine("I JUST WANT TO BANG ON THE DRUM ALL DAY!!!!");
                            Console.WriteLine("");
                            Thread.Sleep(3000);
                            Console.WriteLine("Go home and make some music MAESTRO!");
                            Console.ReadKey();
                            Environment.Exit(0);

                        }
                        else
                        {
                            Game(cups, lemonaide, water, money, demand, type);
                        }
                    }
                }
                else
                {
                    Thread.Sleep(500);
                    Console.WriteLine("How much should each glass be?");
                    Console.WriteLine("----------------");
                    Console.WriteLine("1, 2, 3, 4, or 5");
                    Console.WriteLine("----------------");
                    Console.Write("$");
                    int price = Convert.ToInt16(Console.ReadLine());
                    Console.WriteLine("");
                    Console.WriteLine("Let's make some Lemonaide!");
                    Thread.Sleep(1000);
                    Console.WriteLine("");
                    Console.WriteLine("With your inventory, you can make {0} cups of lemonaide", product);
                    Thread.Sleep(500);
                    Console.WriteLine("How many cups would you like to make?");
                    int cupsMade = Convert.ToInt16(Console.ReadLine());
                    cups = cups - cupsMade;
                    lemonaide = lemonaide - cupsMade;
                    water = water - cupsMade;
                    Thread.Sleep(3000);
                    Console.WriteLine("");
                    Console.WriteLine("You just made {0} cups of lemonaide.", cupsMade);
                    Thread.Sleep(500);
                    Console.WriteLine("");
                    Console.WriteLine("------------------------------------------");
                    Console.WriteLine("You have {0} paper cups left", cups);
                    Console.WriteLine("You have {0} tablespoons of lemonaide left", lemonaide);
                    Console.WriteLine("You have {0} cups of water left", water);
                    Console.WriteLine("------------------------------------------");
                    Console.WriteLine("");
                    Thread.Sleep(500);
                    Console.WriteLine("Let's sell some Lemonaide!");
                    Console.WriteLine("");
                    Thread.Sleep(3000);
                    Sell(cupsMade, money, demand, price, cups, water, lemonaide, type);
                }
            }
        }

        private static void Sell(int cupsMade, int money, int demand, int price, int cups, int water, int lemonaide, Weather type)
        {
            int totalDemand = demand + Math.Abs(price - 6);
            Console.WriteLine("Your stand is all set up and OPEN for BUSINESS!");
            Thread.Sleep(1000);
            Console.WriteLine("There are people walking down the sidewalk...");
            Thread.Sleep(3000);
            Random demandRnd = new Random();
            
            int cupsSold = 0;
            for (int i=0; i < cupsMade; i++)
            {
                int randomElement = demandRnd.Next(0, totalDemand);
                if (totalDemand - randomElement >= totalDemand / 2)
                {   
                    cupsSold++;   
                }             
            }
            int profit = price * cupsSold;
            money = money + profit;
            Console.WriteLine("It's mid-morning...");
            Thread.Sleep(3000);
            Console.WriteLine("It's noon...");
            Thread.Sleep(3000);
            Console.WriteLine("It's mid-afternoon...");
            Thread.Sleep(3000);
            Console.WriteLine("The sun is going down. Let's see how you did...");
            Thread.Sleep(3000);
            Console.WriteLine("");
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("You sold {0} CUPS of lemonaide and MADE ${1}", cupsSold, profit);
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("");
            Game(cups, lemonaide, water, money, demand, type);
        }

        private static void buyItems(int cups, int lemonaide, int water, int money, int demand, Weather type)
        {
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
            Console.WriteLine("4: Everything");
          
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
                        Console.WriteLine("");
                        Console.WriteLine("You just purchased {0} cups and have {1} in your supply cart", buyCups, cups);
                        Console.WriteLine("You have ${0} in petty cash.", money);
                        Console.WriteLine("");
                        Console.WriteLine("Would you like to buy anything else?");
                        
                        string buyMore = Console.ReadLine();
                        if (buyMore == "yes")
                        {
                            buyItems(cups, lemonaide, water, money, demand, type);
                        }
                        else
                        {
                            Game(cups, lemonaide, water, money, demand, type);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Sorry, you do not have enough money to buy that.");
                        Console.ReadKey();
                        buyItems(cups, lemonaide, water, money, demand, type);
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
                        lemonaide = lemonaide + buyLemonaide;
                        Console.WriteLine("");
                        Console.WriteLine("You just purchased {0} Tbs Lemonaide and have {1} in your supply cart", buyLemonaide, lemonaide);
                        Console.WriteLine("You have ${0} in petty cash.", money);
                        Console.WriteLine("");
                        Console.WriteLine("Would you like to buy anything else?");
                       
                        string buyMore = Console.ReadLine();
                        if (buyMore == "yes")
                        {
                            buyItems(cups, lemonaide, water, money, demand, type);
                        }
                        else
                        {
                            Game(cups, lemonaide, water, money, demand, type);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Sorry, you do not have enough money to buy that.");
                        Console.ReadKey();
                        buyItems(cups, lemonaide, water, money, demand, type);
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
                        water = water + buyWater;
                        Console.WriteLine("");
                        Console.WriteLine("You just purchased {0} cups of water and have {1} in your supply cart", buyWater, water);
                        Console.WriteLine("You have ${0} in petty cash.", money);
                        Console.WriteLine("");
                        Console.WriteLine("Would you like to buy anything else?");
                        
                        string buyMore = Console.ReadLine();
                        if (buyMore == "yes")
                        {
                            
                            buyItems(cups, lemonaide, water, money, demand, type);
                        }
                        else
                        {
                            Game(cups, lemonaide, water, money, demand, type);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Sorry, you do not have enough money to buy that.");
                        Console.ReadKey();
                        buyItems(cups, lemonaide, water, money, demand, type);
                    }
                    Console.WriteLine("");
                    break;
                case 4:
                    Console.WriteLine("");
                    Console.WriteLine("How many units of everything would you like to buy?");
                    int buyEverything = Convert.ToInt16(Console.ReadLine());
                    if (money >= (buyEverything*3))
                    {
                        money = money - (buyEverything*3);
                        water = water + buyEverything;
                        cups = cups + buyEverything;
                        lemonaide = lemonaide + buyEverything;
                        Console.WriteLine("");
                        Console.WriteLine("You just purchased {0} units of everything", buyEverything);
                        Console.WriteLine("You have ${0} in petty cash.", money);
                        Console.WriteLine("");
                        Console.WriteLine("Would you like to buy anything else?");

                        string buyMore = Console.ReadLine();
                        if (buyMore == "yes")
                        {

                            buyItems(cups, lemonaide, water, money, demand, type);
                        }
                        else
                        {
                            Game(cups, lemonaide, water, money, demand, type);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Sorry, you do not have enough money to buy all those items together.");
                        Console.ReadKey();
                        buyItems(cups, lemonaide, water, money, demand, type);
                    }
                    Console.WriteLine("");
                    break;
            }
            Console.ReadKey();
           
        }
    }
}
