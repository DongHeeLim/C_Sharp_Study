using System;
using System.IO;
using System.Collections.Generic;

namespace Interface_Practice
{
    internal class Program : IBasic
    {   
        // interface 구현
        public int TestProperty { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        class Parent1 { }
        class Parent2 { }   // 클래스 만으로 이중(다중) 상속 안됨 -> 인터페이스 사용


        class Product : Parent1, IComparable // , Parent2  상속 위치 중요 처음에 실제 클래스를 먼저    // Test 1
        {
            public string Name { get; set; }
            public int Price { get; set; }

            public override string ToString()
            {
                return Name + " : " + Price + "원";
            }

            public int CompareTo(Object obj)
            {
                return this.Price.CompareTo((obj as Product).Price);
            }
        }

        class Dummy : IDisposable
        {
            // 상위 using -> 전처리 ,  내부 using -> 범위 구분, 벗어나면 Dispose 작동
            public void Dispose()       // 가비지 콜랙터의 소멸자와 비슷함, 다른 것임
            {
                //throw new NotImplementedException();
                Console.WriteLine("Dispose() 메서드를 호출");
            }

            ~Dummy()    // 소멸자
            {
                Console.WriteLine("Dispose() 소멸자");
            }
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            List<Product> list = new List<Product>()    // Test 1
            {
                new Product() { Name = "FC-01", Price = 150 },
                new Product() { Name = "FC-02", Price = 100 }
            };
            list.Sort();    // IComparable -> class 내부에 정렬이 명확하지 않으니 구현해줘야함

            using (Dummy dummy = new Dummy())
            {
                Console.WriteLine("Dummy 클래스 실행");
            }

            string text = "HELLO WORLD";
            string path = @"D:\C_FileSystem\test.txt";
            File.WriteAllText(path, text);   // 파일을 만들어줘야함
            Console.WriteLine(File.ReadAllText(path));


            
            using (StreamWriter writer = new StreamWriter(path))    // 상속에 Dispose가 있음
            { 
                writer.WriteLine("안녕하세요");
                writer.WriteLine("여러줄 입력");

                for (int i = 0; i < 10; i++) 
                {
                    writer.WriteLine("반복문 - "+ i);
                }

            }

            //Console.WriteLine(File.ReadAllText(path));  // 큰 용량 힘듬
            using (StreamReader reader = new StreamReader(path)) 
            {
                string line;
                while ((line = reader.ReadLine()) != null) 
                {
                    Console.WriteLine(line);
                }
            }
            



        }

        public int TestInstanceMethod()     // interface 구현
        {
            throw new NotImplementedException();
        }
    }
}
