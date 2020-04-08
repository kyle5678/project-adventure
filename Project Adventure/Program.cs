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

            while (true)
            {
                StoryBranch();
            }
        }

        public static void StoryBranch()
        {
            switch (Story.Current)
            {
                case "Base":
                    Story.Base();
                    break;
                case "A1":
                    Story.A1();
                    break;
                case "A2":
                    Story.A2();
                    break;
                default:
                    Game.Line();
                    Game.StoryMessage("You have reached the end of your story.");
                    string choice = Game.Choice("Do you want to play again?", new string[] { "A: Yes", "B: No" });
                    if (choice == "A")
                        Story.Current = "Base";
                    else
                        Game.End();
                    break;
            }
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
