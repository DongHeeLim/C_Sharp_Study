using System;
using System.Collections.Generic;

namespace _220419_7weeks
{
    class Product
    {
        public static int counter = 0;
        public readonly int id; // readonly 선언, 생성자, 매서드 이외에 변경X  Const 는 불변, readonly Class 내에서 작업가능
        public string name;
        public int price;

        public Product(string name, int price)
        {
            Product.counter = counter + 1;
            this.id = counter;
            this.name = name;
            this.price = price;


            printObject();
        }

        private void printObject()
        {

            Console.WriteLine("[" + this.id + "] : " + this.name);
            Console.WriteLine("전체 : " + Product.counter + " 개 생성되었습니다.");
        }
    }


    class Sample
    {
        public static int value;    // 호출된 순간 초기화 작동, static 은 프로그램 시작 시 한번만 생성

        static Sample()     // static 요소 초기화
        {
            value = 10;     
            Console.WriteLine("정적 생성자 호출");
        }
    }

    class Test
    {
        public string name;
        public int price;
        public Test(string name, int price)
        {
            this.name = name;
            this.price = price;
            Console.WriteLine(this.name + "의 생성자 호출");
        }

        ~Test()
        { 
            Console.WriteLine(this.name + "의 소멸자 호출");
        }
    
    }


    class Box
    {
        private int width;
        public int Width
        {
            get { return width; }   // get set 클래스 매서드 대신에 property
            set 
            {
                if (value > 0) { this.width = value; }
                else { Console.WriteLine("너비는 0보다 큰 자연수 입력."); }

            }
        }



        private int height;
        public int Height
        {
            get { return height; }
            set
            {
                if (value > 0) { this.height = value; }
                else { Console.WriteLine("높이는 0보다 큰 자연수 입력."); }
            }
        
        }




        public Box(int width, int height)
        {
            if (width > 0 && height > 0)
            {
                this.width = width;
                this.height = height;
            }
            else
            {
                Console.WriteLine("박스의 너비와 높이는 0보다 큰 자연수 입력.");
            }
        }

        public int Area() { return this.width * this.height; }
    }


    class Fibonacci
    {
        public static int count = 0;
        private static Dictionary<int, long> memo = new Dictionary<int, long>();

        public static long Get(int i)
        {
            if (i <= 0) { return 0; }
            if (i == 1) { return 1; }

            if (memo.ContainsKey(i))
            {
                return memo[i];
            }


            count++;
            long value = Get(i - 2) + Get(i - 1);
            memo[i] = value;
            return value;
        }
    }


    internal class Program
    {
        


        static void Main(string[] args)
        {
            Product productA = new Product("호박고구마", 5000);
            Product productB = new Product("우유", 6000);


            Console.WriteLine("1");
            Console.WriteLine(Sample.value);
            Console.WriteLine("2");
            Sample sample = new Sample();
            Console.WriteLine("3");

            Test testProduct = new("꿀꽈배기", 1500);


            Box box = new Box(-10, 10);

            box.Width = 100;
            box.Height = -100;

            Fibonacci.count = 0;
            Console.WriteLine(Fibonacci.Get(5));
            Console.WriteLine("덧셈횟수 : " + Fibonacci.count);

        }
    }
}
