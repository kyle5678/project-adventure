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
            Game.Wait();
            Game.Line();

            Game.StoryMessage("You wake up on a soft bed, light streaming through the windows nearby.");
            Game.StoryMessage("Where are you? You get out of bed and peer through a window.");
            Game.StoryMessage("You seem to be in a small village, with children playing outside");
            Game.StoryMessage("A door behind you creaks open. Someone comes in.");
            Game.CharacterSays("???", "So, you finally decided to wake up?", Color.Blue);
            Game.StoryMessage("You silently nod. You wonder who this woman is. You also wonder who you are.");
            string Name = Game.CharacterAsk("???", "So, what's your name?", Color.Blue);
            Game.CharacterSays("???", $"So your name is {Name}, eh? Interesting...", Color.Blue);
            Game.CharacterSays("???", $"Well, my name's Magda. Nice to meet you, {Name}. Breakfast's ready outside.", Color.Blue);

            Game.Line();

            Game.StoryMessage("You leave the bedroom and meet Magda outside the house.");
            Game.StoryMessage("The villagers are all having breakfast together. You sit down to join them.");

            Game.Stop();
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
