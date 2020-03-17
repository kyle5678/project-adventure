using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Adventure
{
    static class Game
    { 
        public static void StoryMessage(string message)
        {
            Color.Text(Color.Blue);
            Console.WriteLine(message);
            Color.Reset();
        }
    }
}
