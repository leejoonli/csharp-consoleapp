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
            Ship[] enemy_ships = new Ship[2];
            //int idx = 0;
            for (int i = 0; i < enemy_ships.Length; i++)
            {
                enemy_ships[i] = new Ship(3, 2, .6, "Alien");
            }
            Console.WriteLine("Start?");
            string temp = Console.ReadLine();
            if (temp == "yes")
            {
                //Console.WriteLine("Engaging enemy.  Ship incoming.");
                for (int i = 0; i < enemy_ships.Length; i++)
                {
                    while(uss_shwarzenegger.hull > 0 && enemy_ships[i].hull > 0)
                    {
                        Console.WriteLine("Would you like to attack?");
                        string attack = Console.ReadLine();
                        if (attack == "yes")
                        {
                            Battle(uss_shwarzenegger, enemy_ships[i]);
                            if (enemy_ships[i].hull <= 0)
                            {
                                continue;
                            }
                            else
                            {
                                Battle(enemy_ships[i], uss_shwarzenegger);
                                if (uss_shwarzenegger.hull <= 0)
                                {
                                    Console.WriteLine("Defeat!");
                                    return;
                                }
                            }
                        }
                        else if (attack == "no")
                        {
                            Console.WriteLine("Fleeing from combat.");
                            return;
                        }
                    }
                }
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
            //if(ship_one.name == "Schwarzenegger")
            //{
            //    if(Chance() >= ship_one.accuracy)
            //    {
            //        ship_two.hull -= ship_one.firepower;
            //    }
            //}
            //else if (ship_one.name == "Alien")
            //{
            //    if (Chance() >= ship_one.accuracy)
            //    {
            //        ship_two.hull -= ship_one.firepower;
            //    }
            //}
            if(Chance() >= ship_one.accuracy)
            {
                ship_two.hull -= ship_one.firepower;
                Console.WriteLine("{0} did {1} damage to {2}!", ship_one.name, ship_one.firepower, ship_two.name);
            }
            else
            {
                Console.WriteLine("{0} missed", ship_one.name);
            }
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
