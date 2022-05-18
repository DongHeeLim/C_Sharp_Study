
using System;
using System.Threading;

namespace KEYboard_input
{

    class KeyInput
    {
        protected static bool exitThread = true;
        protected static int x = 1;
        protected static bool direction = true;
        protected static bool state = true;

        protected static void Func(object obj)
        {
            while (exitThread)
            {
                ConsoleKeyInfo info = Console.ReadKey();

                switch (info.Key)
                {
                    case ConsoleKey.LeftArrow:
                        x--;
                        direction = false;
                        break;
                    case ConsoleKey.RightArrow:
                        x++;
                        direction = true;
                        break;
                    case ConsoleKey.X:
                        state = false;
                        break;
                }
            }
        }
    }

    internal class Program : KeyInput
    {
        static void Main(string[] args)
        {
            // 변수의 선언
            Thread myTh = new Thread(Func);
            myTh.Start();

            while (state)
            {
                if (x < 0)
                    x = 0;
                else if (x > 50)
                    x = 50;

                Console.Clear();
                Console.SetCursorPosition(x, 5);

                if (x % 3 == 0)
                {
                    if (direction == true)
                        Console.WriteLine(" __@");
                    else
                        Console.WriteLine("@__ ");
                }
                else if (x % 3 == 1)
                {
                    if (direction == true)
                        Console.WriteLine("_^@");
                    else
                        Console.WriteLine("@^_");
                }
                else
                {
                    if (direction == true)
                        Console.WriteLine("^_@");
                    else
                        Console.WriteLine("@_^");
                }

                Thread.Sleep(100);
            }

        }
    }

}
