using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Adventure
{
    static partial class Game
    {
        public static void Message(string message, ConsoleColor color = ConsoleColor.White)
        {
            Color.Text(color);
            Console.WriteLine(message);
            Color.Reset();
            Wait();
        }

        public static void Dialogue(string name, string message, ConsoleColor type = ConsoleColor.Blue)
        {
            Color.Text(type);
            Console.Write(name);
            Color.Reset();
            Console.WriteLine(": {0}", message);
            Wait();
        }

        public static string Question(string question)
        {
            Console.Write($"{question} ");
            Color.Text(Color.Green);
            string answer = Console.ReadLine();
            Color.Reset();
            return answer;
        }

        public static string Choice(string question, string[] choices /* ex: "(A) This is an option" */ )
        {
            Console.WriteLine($"{question} ");
            foreach (string choice in choices)
            {
                Console.WriteLine($"  {choice}");
            }
            string answer;
            Console.Write("Make your choice: ");
            for (; ; )
            {
                bool end = false;

                Color.Text(Color.Green);
                answer = Console.ReadLine();
                foreach (string choice in choices)
                {
                    if (answer.ToUpper() == choice.Substring(1, 1))
                        end = true;
                }

                if (end)
                    break;
                else
                {
                    Color.Reset();
                    Console.Write("That wasn't an option: ");
                }
            }

            Color.Reset();
            return answer.ToUpper();
        }

        public static string Ask(string name, string question, ConsoleColor type = ConsoleColor.Blue)
        {
            Color.Text(type);
            Console.Write(name);
            Color.Reset();
            return Question(": " + question);
        }

        public static void Camp()
        {
            Line();
            Message("You set up your tent, the campfire crackling outside.");

            for (; ; )
            {
                string choice = Choice("What would you like to do?", new string[] { "(A) Sleep", "(B) Use Item" });

                if (choice == "A")
                    break;
                else if (choice == "B")
                {
                    UseItem();
                }
            }
            Message("Good night.");
            Data.Health = Data.maxHealth;
            Line();
        }

        public static void Manage(Item item)
        {
            item.Announce();
            Data.Items.Add(item);
        }

        public static void Wait()
        {
            Console.ReadKey();
        }

        public static void Line()
        {
            Console.WriteLine();
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine();
        }

        public static void End()
        {
            Environment.Exit(0);
        }



        public static string[] Alphabet = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
        public static string[] ValidItemEffects = new string[] { "health", "attack", "retreat" };
        public static Random rnd = new Random();
    }
}
