using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Adventure
{
    static class Game
    {
        public static void Message(string message, ConsoleColor color = ConsoleColor.White)
        {
            Color.Text(color);
            Console.WriteLine(message);
            Color.Reset();
            Wait();
        }

        public static void Dialogue(string name, string message, ConsoleColor type)
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

        public static string Ask(string name, string question, ConsoleColor type)
        {
            Color.Text(type);
            Console.Write(name);
            Color.Reset();
            return Question(": " + question);
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
    }
}
