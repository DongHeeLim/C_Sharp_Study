using System;

namespace _220322_01
{
    internal class Program
    {

        static void Main(string[] args)
        {

            //long num1 = 2147483647L + 2147483647L;  // overflow
            //int num2 = (int)num1;
            //int num3 = int.Parse("1234");

            //Console.WriteLine(num2);
            //Console.WriteLine(num3);
            //Console.WriteLine(num3.GetType());

            //Console.WriteLine(long.Parse("1523").GetType());
            //Console.WriteLine(float.Parse("1523").GetType());   //  single
            //Console.WriteLine(double.Parse("1523").GetType());  // double

            //Console.WriteLine((3.14529).ToString("0.0"));
            //Console.WriteLine((3.14529).ToString("0.00"));
            //Console.WriteLine((true).ToString());
            //Console.WriteLine((true).ToString().GetType());
            //Console.WriteLine(('a').GetType());
            //Console.WriteLine(('a').ToString().GetType());

            //Console.Write("숫자 입력 : ");
            //int input = int.Parse(Console.ReadLine());

            //if (input % 2 == 0)
            //{
            //    Console.WriteLine("짝수");
            //}
            //else {
            //    Console.WriteLine("홀수");
            //}

            //int currentTime = DateTime.Now.Hour;

            //if (currentTime >= 12)
            //{
            //    Console.WriteLine("오후");
            //}
            //else 
            //{
            //    Console.WriteLine("오전");
            //}

            //Console.WriteLine(DateTime.Now.Hour.GetType()); // Now까지는 DateTime 그 뒤는 숫자

            //if (currentTime < 11)
            //{
            //    Console.WriteLine("아침");
            //}
            //else
            //{
            //    if (currentTime > 15)
            //    {
            //        Console.WriteLine("저녁");
            //    }
            //    else 
            //    {
            //        Console.WriteLine("점심");
            //    }
            //}

            //Console.Write("과목 개수 : ");
            //int subjects = int.Parse(Console.ReadLine());
            //Console.WriteLine(subjects);
            //int count = subjects;

            //while (subjects > 0)
            //{
            //    Console.Write("제" + (count + 1 - subjects) + "과목학점입력 : ");
            //    float grade = float.Parse(Console.ReadLine());

            //    if (grade <= 4.5f && grade >= 0) 
            //    {
            //        subjects--;
            //    }

            //    if (grade == 4.5f) Console.WriteLine("A");
            //    else if (grade >= 4.0f) Console.WriteLine("A-");
            //    else if (grade >= 3.5f) Console.WriteLine("B+");
            //    else if (grade >= 3.0f) Console.WriteLine("B");
            //    else if (grade >= 2.5f) Console.WriteLine("C+");
            //    else if (grade >= 2.0f) Console.WriteLine("C");
            //    else if (grade >= 1.5f) Console.WriteLine("C-");
            //    else Console.WriteLine("D");

            //}

            //Console.WriteLine("이번 달 : " + DateTime.Now.Month.ToString() + "월");
            //Console.Write("계절을 알고 싶은 달 : ");
            //int _month = int.Parse(Console.ReadLine());



            //switch (_month)
            //{
            //    case 12:
            //    case 1:
            //    case 2:
            //        Console.WriteLine("겨울");
            //        break;
            //    case 3:
            //    case 4:
            //    case 5:
            //        Console.WriteLine("봄");
            //        break;
            //    case 6:
            //    case 7:
            //    case 8:
            //        Console.WriteLine("여름");
            //        break;
            //    case 9:
            //    case 10:
            //    case 11:
            //        Console.WriteLine("가을");
            //        break;
            //    default:
            //        Console.WriteLine("달을 잘못 입력");
            //        break;
            //}

            //int number1 = int.Parse(Console.ReadLine());
            //Console.WriteLine(number1 % 2 == 0 ? true : false);


            //Console.WriteLine("안녕하세요".Contains("안녕") ? "포함됨" : "미포함");
            //Console.Write("문자열 : ");
            //Console.WriteLine(Console.ReadLine().Contains("안녕") ? "포함됨" : "미포함");

            Console.WriteLine("키 입력 : ");

            while (true)
            {
                Console.Write("입력된 키 : ");
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                Console.Write(keyInfo.Key);


                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        Console.WriteLine("위");
                        break;
                    case ConsoleKey.LeftArrow:
                        Console.WriteLine("왼쪽");
                        break;
                    case ConsoleKey.RightArrow:
                        Console.WriteLine("오른쪽");
                        break;
                    case ConsoleKey.DownArrow:
                        Console.WriteLine("아래");
                        break;
                    default:
                        Console.WriteLine("방향키가 아님");
                        break;
                }
            }




        }
    }
}
