using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForm_MQTT_Client.Helpers
{
    internal class StringHandler
    {
        private static StringHandler stringHandler;

        // 델리게이트 선언
        public delegate void StrAddHandler(string str);

        // 이벤트 선언
        public event StrAddHandler? ItemStr;

        // 호출 함수 -> 이벤트
        public void AddText(string str) => ItemStr?.Invoke(str);

        public static StringHandler Instance() 
        {
            if (stringHandler == null) 
            {
                stringHandler= new StringHandler();
            }

            return stringHandler;
        }

    }
}
