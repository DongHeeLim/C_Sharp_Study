using System;

namespace _220524_value_Exception
{
    class CustomException : Exception
    {
        public CustomException(string message) : base(message)
        {

        }
    }

    class Box
    {
        private int width;
        public int Width
        {
            get { return width; }
            set
            {
                if (value > 0) { width = value; }
                else { throw new Exception("너비는 자연수를 입력하세요"); }
            }
        }

        private int height;
        public int Height
        {
            get { return height; }
            set
            {
                if (value > 0) { height = value; }
                else { throw new Exception("높이는 자연수를 입력해주세요"); }
            }
        }

        public Box(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public int Area() { return this.width * this.height; }


    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //Box box1 = new Box(-10, -20);    // Exception Check
            //Box box2 = new Box(10, -20);    // Exception Check


            try
            {
                throw new CustomException("사용자 정의 예외");
            }
            catch (CustomException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }


    }
}
