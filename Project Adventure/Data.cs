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
        public static int Health
        {
            get
            {
                if (_health < 0)
                    return 0;
                else
                    return _health;
            }

            set
            {
                _health = value;
            }
        }
        private static int _health = 20;
        public static int maxHealth = 20;

        public static List<Item> Items = new List<Item> { };
        public static List<Enemy> Foes = new List<Enemy> { };

        public static Item LastUsedItem;
    }
}
