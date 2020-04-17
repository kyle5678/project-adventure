using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Adventure
{
    class Data
    {
        public static string Name = "";
        public static int Health = 20;
        public static int maxHealth = 20;

        public static List<Item> Items = new List<Item> { };
        public static List<Enemy> Foes = new List<Enemy> { };
    }
}
