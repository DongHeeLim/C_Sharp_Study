using System;
using System.Threading;



namespace _220329_01
{

    internal class Program
    {
        static void Delay(int ms)
        {
            DateTime dateTimeNow = DateTime.Now;
            TimeSpan duration = new TimeSpan(0, 0, 0, 0, ms);
            DateTime dateTimeAdd = dateTimeNow.Add(duration);
            while (dateTimeAdd >= dateTimeNow)
            {
                dateTimeNow = DateTime.Now;
            }
            return;
        }

        public class Point
        {
            protected int x = 25;
            protected int y = 25;

            public int X { get { return x; } set { if (value > 0) x = value;}}
            public int Y { get { return y; } set { if (value > 0) y = value;}}
        }


        public class monitor : Point
        { 
    
        }

        public class KeyData : Point
        {
            private static ConsoleKeyInfo keyInfo;


            public ConsoleKeyInfo KeyInfo_property
            { 
                get { return keyInfo; }
                set { keyInfo = value; }

            }

            //public void changePosition()
            //{
            //    if (keyInfo.Key == ConsoleKey.RightArrow)
            //    {
            //        x++;
            //        Console.WriteLine(x);
            //    }
            //    else if (keyInfo.Key == ConsoleKey.RightArrow)
            //    {
            //        x--;
            //        Console.WriteLine(x);
            //    }
            //    else if (keyInfo.Key == ConsoleKey.UpArrow)
            //    {
            //        y++;
            //        Console.WriteLine(y);
            //    }
            //    else if (keyInfo.Key == ConsoleKey.DownArrow)
            //    {
            //        y--;
            //        Console.WriteLine(y);
            //    }
            //}


            public static void ThreadKeyInput()
            {

                while (true)
                {
                    keyInfo = Console.ReadKey();
                    Console.WriteLine(keyInfo.Key);
                    Thread.Sleep(0);

                    if (keyInfo.Key == ConsoleKey.RightArrow)
                    {
                        x++;
                        Console.WriteLine(x);
                    }
                    else if (keyInfo.Key == ConsoleKey.RightArrow)
                    {
                        x--;
                        Console.WriteLine(x);
                    }
                    else if (keyInfo.Key == ConsoleKey.UpArrow)
                    {
                        y++;
                        Console.WriteLine(y);
                    }
                    else if (keyInfo.Key == ConsoleKey.DownArrow)
                    {
                        y--;
                        Console.WriteLine(y);
                    }

                }
            }
        }



        static void Main(string[] args)
        {


            int[] intArray = {52, 273, 32, 65, 103 };
            int intArraySize = intArray.Length;


            for (int i = 0; i < intArraySize; i++)
            { 
                Console.WriteLine(intArray[i]);
            }

            int[] intArray2 = new int[100];
            Console.WriteLine(intArray2[0]);

            int intArray2Size = intArray2.Length;
            int cnt = 0;
            char[] str = new char[20]; 
            while (intArray2Size > cnt)
            {
                Console.Write((cnt+1) + " : ");
                Console.WriteLine(intArray2[cnt]);
        
                cnt++;
            }

            long start = DateTime.Now.Ticks;
            long count = 0;

            while (start + 1000000 > DateTime.Now.Ticks)
            {
                count++;
            }

            Console.WriteLine(count + "만큼 반복");

            Thread t = new Thread(new ThreadStart(KeyData.ThreadKeyInput));
            t.Start();


            //t.Join(5000);   // 쓰레드 작업만 하는 것으로 넘어가고 5초 후에 종료
            //Console.WriteLine("언제될까");

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (j >= 10-i) 
                    {
                        Console.Write('*');
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }

            KeyData keyData = new KeyData();

            Console.WriteLine("  ㅅ ");
            Console.WriteLine("↗◆↖");
            Console.WriteLine("◁ㅁ▷");
            Console.WriteLine("§§§");

            while (true)
            {
                Console.WriteLine(DateTime.Now.Ticks);
                Delay(10);

                

                if (keyData.KeyInfo_property.Key == ConsoleKey.RightArrow)
                {

                }

                if (keyData.KeyInfo_property.Key == ConsoleKey.Escape)
                {
                    break;
                }
            }


            Console.WriteLine("탈출");
        }
    }
}
