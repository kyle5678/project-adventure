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

        public static void Back(ConsoleColor color)
        {
            Console.BackgroundColor = color;
        }

        public static void Reset()
        {
            ResetText();
            ResetBack();
        }

        public static void ResetText()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public static void ResetBack()
        {
            Console.BackgroundColor = ConsoleColor.Black;
        }

        public static ConsoleColor Red = ConsoleColor.Red;
        public static ConsoleColor Blue = ConsoleColor.Blue;
    }
}
