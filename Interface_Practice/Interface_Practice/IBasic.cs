using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface_Practice
{
    internal interface IBasic   // 메서드 속성 틀 생성, 구현 x
    {
        int TestInstanceMethod();
        int TestProperty { get; set; }

        // 인스턴스 는 못 만드나 다형성은 가능함
        // 다중 상속을 사용하기 위해서 사용, 처음 받는 상속은 인터페이스 말고 다른 클래스

    }
}
