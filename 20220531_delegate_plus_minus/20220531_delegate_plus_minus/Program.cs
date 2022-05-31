using System;

namespace _20220531_delegate_plus_minus
{
    internal class Program
    {
        public delegate void SendString(string message);
        static void Main(string[] args)
        {
            SendString sayHello, sayGoodbye, multiDelegate;

            sayHello = Hello;
            sayGoodbye = GoodBye;

            multiDelegate = sayHello + sayGoodbye;
            multiDelegate("윤지영");

            Console.WriteLine();

            multiDelegate -= sayGoodbye;
            multiDelegate("박주열");
        }

        private static void GoodBye(string message)
        {
            Console.WriteLine("안녕하세요." + message + "님.");
        }

        private static void Hello(string message)
        {
            Console.WriteLine("잘가세요." + message + "님.");
        }
    }
}
