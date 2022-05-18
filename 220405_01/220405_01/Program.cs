#define TEST

using System;
using System.Collections.Generic;


namespace _220405_01
{

    internal class Program
    {
        class Student
        {
            public string id;
            public string name;
            public int grade;
        }

        static void Main(string[] args)
        {
            Random random = new Random();
            int targetNumber = 0;
            targetNumber = random.Next(1, 10);
            ConsoleKeyInfo keyInfo;
            int exitFlag = 0;
            int count;
            int inputNum;
            Console.WriteLine("답 --->  " + targetNumber);
            int[] numArray = new int[2];
            int length = numArray.Length;
            Console.WriteLine("입력 가능한 길이 : " + length);
            


            do
            {
                while (exitFlag == 1) 
                {   
                    keyInfo = Console.ReadKey();
                    if (keyInfo.Key == ConsoleKey.Y) break;
                    else if (keyInfo.Key == ConsoleKey.N) { 
                        exitFlag = 0;
                        break;
                    }
                }
                if (exitFlag == 1) break;

                Console.WriteLine("===========================");
                Console.Write("\n숫자를 입력하세요 : ");
                count = 0;
                inputNum = 0;

                do
                {
                    keyInfo = Console.ReadKey();
                    if (keyInfo.Key == ConsoleKey.Escape) 
                    {   
                        Console.WriteLine("\n-->종료하시겠습니까 Y/N");
                        exitFlag = 1;
                        break;
                    }

#if TEST
                    Console.WriteLine("\nKEY : " + keyInfo);
#endif
                    if (keyInfo.Key != ConsoleKey.Enter)
                    {
                        numArray[count] = Int32.Parse(keyInfo.KeyChar.ToString());
                        count++;
                    }
                    else
                    {
                        Console.WriteLine("\n숫자를 다시 입력해주세요");
                        break;
                    } 
                    
                    //Console.WriteLine("count : " + count);
                    if (count == length)
                    {
                        break;
                    }
                    else if (count > 0)
                    {
                        //Console.WriteLine("count > 0");
                    }
                    else
                    { 
                        //Console.WriteLine("count 안찍힘");
                    }
                    

                } while (true);

                Console.WriteLine("\ncount : " + count);
                Console.Write("\n입력된 숫자 : ");
                for (int i = 0; i < count; i++)
                {
                    Console.Write(numArray[i]);
                    inputNum += numArray[count - i -1] * int.Parse(Math.Pow(10, i).ToString());
                }
                Console.WriteLine();

                Console.WriteLine("NUMBER : " + inputNum);


                if (inputNum > targetNumber) Console.WriteLine(inputNum + "이(가) 정답보다 크다");
                else if (inputNum < targetNumber) Console.WriteLine(inputNum + "이(가) 정답보다 작다");
                else break;

            } while(true);

            Console.WriteLine("\n정답입니다 -> " + targetNumber);

            Console.WriteLine("===========================");

            List<int> list = new List<int>();

            list.Add(52);
            list.Add(123);
            list.Add(1512);
            list.Add(56);

            foreach (var item in list)
            {
                Console.WriteLine("Count : " + list.Count + "\titem : " + item);
            }

            Console.WriteLine();

            List<int> list2 = new List<int>() {5, 3, 2, 4, 1};


            list2.Remove(4);
            list2.Remove(6);

            foreach (var item in list2)
            {
                Console.WriteLine("Count : " + list2.Count + "\titem : " + item);
            }

            Product product = new Product();

            Console.WriteLine("===========================");

            List<Student> list3 = new List<Student>();

            list3.Add(new Student() { id = "POLYMAN", name = "COOLDONG", grade = 1});
            list3.Add(new Student() { id = "POLYMAN", name = "RCNAM", grade = 2});
            list3.Add(new Student() { id = "POLYBOY", name = "RCNAM2", grade = 2});
            list3.Add(new Student() { id = "POLYMAN", name = "RCNAM3", grade = 1});


            //// 리스트는 삭제하면 앞으로 당겨짐 그래서 동일한 값이 연속한 경우 제거 안될 수 있음
            //for (int i = 0; i < list3.Count; i++)
            //{
            //    if (list3[i].name == "COOLDONG") list3.RemoveAt(i);
            //}

            // for 문을 역으로 돌려 제거
            for (int i = list3.Count -1; i >= 0; i--)
            {
                if (list3[i].grade == 2)
                {
                    list3.RemoveAt(i);
                }
            }


            foreach (var item in list3)
            {
                Console.WriteLine(item.id + " : " + item.name + " : " + item.grade);
            }
        }
    }
}
