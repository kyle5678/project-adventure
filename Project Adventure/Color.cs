using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Adventure
{
    static class Color
    {
        public static void Text(ConsoleColor color)
        {
            Console.ForegroundColor = color;
        }

        public static ConsoleColor Red = ConsoleColor.Red;
    }
}
