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
            Ship uss_shwarzenegger = new Ship(20, 5, .7);
            //Console.WriteLine("{0}, {1}, {2}", uss_shwarzenegger.hull, uss_shwarzenegger.firepower, uss_shwarzenegger.accuracy);
            Ship[] enemy_ships = new Ship[5];
            for (int i = 0; i < enemy_ships.Length; i++)
            {
                enemy_ships[i] = new Ship(3, 2, .6);
            }
            //Console.WriteLine(enemy_ships[0].accuracy);
            Console.WriteLine("Start?");
            string temp = Console.ReadLine();
            if (temp == "yes")
            {
                Console.WriteLine("begin\nattack?");
                string begin = Console.ReadLine();
                if(begin == "yes")
                {
                    Console.WriteLine("light em up");
                }
            }
        }
    }

    internal class Ship
    {
        public int hull { get; set; }
        public int firepower { get; set; }
        public double accuracy { get; set; }

        public Ship(int hull, int firepower, double accuracy)
        {
            this.hull = hull;
            this.firepower = firepower;
            this.accuracy = accuracy;
        }
    }
}
