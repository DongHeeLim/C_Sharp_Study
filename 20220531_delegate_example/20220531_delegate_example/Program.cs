using System;
using System.Collections.Generic;

namespace _20220531_delegate_example
{
    internal class Program
    {
        class Student
        { 
            public string Name { get; set; }
            public double Score { get; set; }

            // 생성자
            public Student(string name, double scode)
            { 
                this.Name = name;
                this.Score = scode;
            }

            // 다른 자료형 출력
            public override string ToString()
            {
                return this.Name + " : "  + this.Score;
            }
        }

        class Students 
        {   
            // Student 클래스 리스트
            private List<Student> listOfStudent = new List<Student>();

            // student 클래스 인스턴스 넣는 델리게이트
            public delegate void PrintProcess(Student list);

            // 리스트 항목 추가
            public void Add(Student student)
            { 
                listOfStudent.Add(student);
            }

            // 람다 사용, 아래 함수 간단하게 표현
            public void Print() 
            {
                Print((student_member) => { Console.WriteLine(student_member); });
            }

            // 매개변수 delegate, 오버로딩
            public void Print(PrintProcess process)
            {
                // 출력 구현 부분을 해줘야함 따로 delegate 구현 X
                foreach (var item in listOfStudent)
                {
                    process(item);  // 리스트에서 student를 하나씩 넣어주는 기능 
                }
            }
        }

        static void Main(string[] args)
        {
            Students students = new Students();
            students.Add(new Student("김강현", 4.5));
            students.Add(new Student("이광필", 4.5));

            students.Print();   // ToString

            // 람다, 오버로딩 한 Print 사용
            students.Print((student) =>
            {
                Console.WriteLine();
                Console.WriteLine("이름 -> " + student.Name);
                Console.WriteLine("학점 -> " + student.Score);
            });
        }
    }
}
