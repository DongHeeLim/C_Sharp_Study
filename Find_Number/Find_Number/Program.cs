//#define TEST

using System;

namespace Find_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            ConsoleKeyInfo keyInfo;

            int targetNumber = 0;
            targetNumber = random.Next(1, 100);
            int exitFlag = 0;
            int count;
            int inputNum;
#if TEST
            Console.WriteLine("답 --->  " + targetNumber);
#endif
            int[] numArray = new int[3];
            int length = numArray.Length;
            Console.WriteLine("입력 가능한 길이 : " + length);


            do
            {



                Console.WriteLine("\n===========================");
                Console.Write("\n숫자를 입력하세요 : ");
                count = 0;
                inputNum = 0;

                do
                {
                    keyInfo = Console.ReadKey();

#if TEST
                    Console.WriteLine("\nKEY : " + keyInfo.Key);
#endif
                    if (keyInfo.Key != ConsoleKey.Enter)
                    {
                        if ((keyInfo.Key <= ConsoleKey.D9 && keyInfo.Key >= ConsoleKey.D0)  || (keyInfo.Key <= ConsoleKey.NumPad9 && keyInfo.Key >= ConsoleKey.NumPad0))
                        {
                            numArray[count] = Int32.Parse(keyInfo.KeyChar.ToString());
                            count++;
                        }
                        else
                        {
                            if (keyInfo.Key == ConsoleKey.Escape)
                            {
                                Console.Write("\n-->종료하시겠습니까 Y/N : ");
                                exitFlag = 1;
                                break;
                            }
                            Console.WriteLine("\n숫자를 다시 입력해주세요");
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("\n숫자를 다시 입력해주세요");
                        break;
                    }


#if TEST
                    Console.WriteLine("count : " + count);
#endif

                    if (count == length)
                    {
                        break;
                    }
                    else if (count > 0)
                    {
#if TEST
                        Console.WriteLine("count > 0");
#endif
                    }
                    else
                    {
#if TEST
                        Console.WriteLine("count 안찍힘");
#endif
                    }


                } while (true);

                while (exitFlag == 1)
                {
                    keyInfo = Console.ReadKey();
                    if (keyInfo.Key == ConsoleKey.Y) break;
                    else if (keyInfo.Key == ConsoleKey.N)
                    {
                        exitFlag = 0;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\n    아무 버튼이나 눌러 처음으로 돌아갑니다.");
                        break;
                    }
                }
                if (exitFlag == 1) break;

                if (exitFlag == 0 && keyInfo.Key != ConsoleKey.N)
                {
#if TEST
                    Console.WriteLine("\ncount : " + count);

                    Console.Write("\n입력된 숫자 : ");
#endif
                    for (int i = 0; i < count; i++)
                    {
#if TEST
                        Console.Write(numArray[i]);
#endif
                        inputNum += numArray[count - i - 1] * int.Parse(Math.Pow(10, i).ToString());
                    }
                    Console.WriteLine();

                    Console.WriteLine("NUMBER : " + inputNum);


                    if (inputNum > targetNumber) Console.WriteLine(inputNum + "이(가) 정답보다 크다");
                    else if (inputNum < targetNumber) Console.WriteLine(inputNum + "이(가) 정답보다 작다");
                    else break;
                }

         

            } while (true);

            Console.WriteLine("\n===========================");
            Console.WriteLine("정답 -> " + targetNumber);
            Console.WriteLine("===========================");





        }
    }
}
