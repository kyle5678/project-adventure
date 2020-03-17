using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Adventure
{
    class Program
    {
        public static void Play()
        {
            Game.StoryMessage("Welcome to Project Adventure!!!");
            Console.ReadKey();
        }

        static void Main(string[] args)
        {
            for (; ; )
            {
                try
                {
                    Play();
                }

                catch (Exception e)
                {
                    Color.Text(Color.Red);
                    Console.WriteLine("Whoops, something went wrong!");
                    Console.WriteLine(e);
                }
            }
        }
    }
}
