using System;

namespace _220524_Exception_Handling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] array = { "가", "나" };
            Console.Write("숫자를 입력하세요 : ");
            int input = int.Parse(Console.ReadLine());



            if (input < array.Length)
            {
                Console.WriteLine(array[0].ToString());
                Console.WriteLine("입력한 위치의 값은 '" + array[input] + "'입니다.");

            }
            else 
            {
 
                Console.WriteLine("인덱스 범위를 넘었습니다.");
            }




            Console.Write("입력 : ");
            try
            {
                string input2 = Console.ReadLine();
                int[] array2 = { 52, 273, 32, 103 };
                int index = int.Parse(input2);
                Console.WriteLine("입력 숫자 : " + index);
                Console.WriteLine("배열 요소 : " + array2[index]);
            }
            catch (Exception ex)
            {
                //if (ex is FormatException) 
                //{
                //    Console.WriteLine("포맷 에러");
                //}

                switch (ex)
                {
                    case FormatException:
                        break;

                    case IndexOutOfRangeException:
                        break;
                }



            }
            //catch (FormatException exception)
            //{
            //    Console.WriteLine("FormatException 발생");
            //    Console.WriteLine(exception.GetType() + "이 발생했습니다.");
            //}
            //catch (IndexOutOfRangeException exception)
            //{
            //    Console.WriteLine("IndexOutofRangeException 발생");
            //    Console.WriteLine(exception.GetType() + "이 발생했습니다.");
            //}
            finally
            {
                Console.WriteLine("프로그램이 종료됩니다.");
            }
        }
    }
}
