using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _220607_Linq
{
    internal class Program
    {
        class Product
        { 
            public string Name { get; set; }
            public int Price { get; set; }

            public bool compareASCII(string name)
            {
                byte[] byteArray = Encoding.Default.GetBytes(Name);
                Console.WriteLine(byteArray[0]);
                int value = Convert.ToInt32(byteArray[0].ToString());

                if(value > 127)
                    return true;
                else
                    return false;
            }


            public override string ToString()
            {
                //return String.Format("{0, -10}", Name) + " : " + Price + "원";

                if (compareASCII(Name))
                {
                    return Name.PadRight(10, '-') + " : " + Price + "원";    // 한글
                }
                else
                { 
                    return Name.PadRight(10, '-') + " : " + Price + "원";    // 그 외
                }

                
            }
        }


        static void Main(string[] args)
        {
            List<int> input = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            List<Product> input2 = new List<Product>()
            { 
                new Product() {Name = "고구마", Price = 1500 },
                new Product() {Name = "사과", Price = 2400 },
                new Product() {Name = "바나나", Price = 1000 },
                new Product() {Name = "배", Price = 3000 },
                new Product() {Name = "감자", Price = 1000 },
                new Product() {Name = "토마토", Price = 2000 },
                new Product() {Name = "옥수수", Price = 1500 },
                new Product() {Name = "자두", Price = 500 },
                new Product() {Name = "strawberry", Price = 2500 },
            };


            var output  = from item in input                    // 대상
                          where (item > 5) && (item % 2 == 0)   // 조건
                          orderby item descending               // 정렬
                          select item;                          // 선택

            var output2 = from item in output
                          where (item % 2 == 0)
                          select new                            // 클래스 생성없이 객체에 클래스 변수 생성 -> 리스트 형태
                          {
                              A = item * 2,
                              B = item * item,
                              C = 100
                          };

            var output3 = from item in input2
                          where item.Price > 1500
                          orderby item.Name ascending
                          select item;


            foreach (var item in output)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("=========================");

            foreach (var item in output2)
            {
                Console.WriteLine(item);
                Console.WriteLine(item.A);
                Console.WriteLine(item.B);
                Console.WriteLine(item.C);
                Console.WriteLine();
            }

            Console.WriteLine("=========================");

            foreach (var item in output3)
            {
                Console.WriteLine(item);
            }


        }
    }
}
