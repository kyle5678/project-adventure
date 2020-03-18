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
            Color.Text(Color.White);
            Console.WriteLine(message);
            Color.Reset();
            Wait();
        }

        public static void CharacterSays(string name, string message, ConsoleColor type)
        {
            Color.Text(type);
            Console.Write(name);
            Color.Reset();
            Console.WriteLine(": {0}", message);
            Wait();
        }

        public static string Ask(string question)
        {
            Console.Write($"{question} ");
            Color.Text(Color.Green);
            string answer = Console.ReadLine();
            Color.Reset();
            return answer;
        }

        public static string CharacterAsk(string name, string question, ConsoleColor type)
        {
            Color.Text(type);
            Console.Write(name);
            Color.Reset();
            return Ask(": " + question);
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

        public static void Stop()
        {
            Environment.Exit(0);
        }
    }
}
