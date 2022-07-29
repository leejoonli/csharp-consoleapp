using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace battleships
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Ship uss_shwarzenegger = new Ship(20, 5, .7, "Schwarzenegger");
            Ship[] enemy_ships = new Ship[5];
            for (int i = 0; i < enemy_ships.Length; i++)
            {
                enemy_ships[i] = new Ship(Hull(), Firepower(), Accuracy(), "Alien");
            }
            Console.WriteLine("Start Battleship Console Application?");
            string temp = Console.ReadLine();
            if (temp == "yes")
            {
                for (int i = 0; i < enemy_ships.Length; i++)
                {
                    Console.WriteLine("Alien ship {0} incoming.", i+1);
                    while(uss_shwarzenegger.hull > 0 && enemy_ships[i].hull > 0)
                    {
                        Console.WriteLine("Would you like to attack?");
                        string attack = Console.ReadLine();
                        if (attack == "yes")
                        {
                            Battle(uss_shwarzenegger, enemy_ships[i]);
                            if (enemy_ships[i].hull <= 0)
                            {
                                Console.WriteLine("Alien ship {0} destroyed.", i+1);
                                continue;
                            }
                            else
                            {
                                Battle(enemy_ships[i], uss_shwarzenegger);
                                if (uss_shwarzenegger.hull <= 0)
                                {
                                    Console.WriteLine("Defeat!  The USS Schwarzenegger has been destroyed.");
                                    return;
                                }
                            }
                        }
                        else if (attack == "no")
                        {
                            Console.WriteLine("Retreating to resupply.");
                            return;
                        }
                    }
                }
                Console.WriteLine("Congratulations! You've defeated the alien ships.  YOU WIN");
            }
            else if (temp == "no")
            {
                Console.WriteLine("Returning to base.");
                return;
            }
        }

        static double Chance()
        {
            Random rd = new Random();
            double rand_num = rd.NextDouble();
            return rand_num;
        }

        static void Battle(Ship ship_one, Ship ship_two)
        {
            if(Chance() <= ship_one.accuracy)
            {
                ship_two.hull -= ship_one.firepower;
                Console.WriteLine("{0} did {1} damage to {2}!", ship_one.name, ship_one.firepower, ship_two.name);
            }
            else
            {
                Console.WriteLine("{0} missed", ship_one.name);
            }
        }

        static int Hull()
        {
            Random rd = new Random();
            int rInt = rd.Next(3, 7);
            return rInt;
        }

        static int Firepower()
        {
            Random rd = new Random();
            int rInt = rd.Next(2, 5);
            return rInt;
        }

        static double Accuracy()
        {
            Random rd = new Random();
            double rdub = rd.NextDouble() * (.8 - .6) + .6;
            return rdub;
        }
    }

    internal class Ship
    {
        public int hull { get; set; }
        public int firepower { get; set; }
        public double accuracy { get; set; }
        public string name { get; set; }

        public Ship(int hull, int firepower, double accuracy, string name)
        {
            this.hull = hull;
            this.firepower = firepower;
            this.accuracy = accuracy;
            this.name = name;
        }
    }
}
