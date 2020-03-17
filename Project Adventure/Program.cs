using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Adventure
{
    class Program
    {
        static void Main(string[] args)
        {
            for (; ; )
            {
                try
                {
                    Console.ReadKey();
                    throw new Exception("yee");
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
