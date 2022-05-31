using System;
using System.Threading;

namespace _20220531_Thread
{
    internal class Program
    {
        static void Main(string[] args)
        {   
            // 메소드
            Thread threadA = new Thread(TestMethod);
            // delegate
            Thread threadB = new Thread(delegate () 
            {
                for (int i = 0; i < 1000; i++)
                {
                    Console.Write("B");
                }
            });
            // 람다
            Thread threadC = new Thread(() =>
            {
                for (int i = 0; i < 1000; i++)
                {
                    Console.Write("C");
                }
            });

            threadA.Start();
            threadB.Start();
            threadC.Start();
        }

        private static void TestMethod(object obj)
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.Write("A");
            }
        }
    }
}
