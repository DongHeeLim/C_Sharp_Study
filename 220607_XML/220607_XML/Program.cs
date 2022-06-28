using System;
using System.Linq;
using System.Xml.Linq;

namespace _220607_XML
{
    class Weather
    {
        public string Hour { get; set; }
        public string Day { get; set; }
        public string Wf { get; set; }
        public string Temp { get; set; }
        public string WdKor { get; set; }
        public string WfKor { get; set; }
        public string Tmn { get; set; }
        public string Tmx { get; set; }
    
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            string url = "http://www.kma.go.kr/wid/queryDFSRSS.jsp?zone=1126058000";
            XElement xElement = XElement.Load(url);
            //Console.WriteLine(xElement);

            var xmlQuery = from item in xElement.Descendants("data")    // data 태그 추출
                           select item;

            var xmlQuery2 = from item in xElement.Descendants("data")
                            select new
                            {
                                Hour = item.Element("hour").Value,
                                Day  = item.Element("day").Value,
                                Temp  = item.Element("temp").Value,
                                WdKor  = item.Element("wdKor").Value,
                                WfKor  = item.Element("wfKor").Value,
                                Tmn  = item.Element("tmn").Value,
                                Tmx  = item.Element("tmx").Value,
                            };

            var xmlQuery3 = from item in xElement.Descendants("data")
                            select new Weather()
                            {
                                Hour = item.Element("hour").Value,
                                Day = item.Element("day").Value,
                                Temp = item.Element("temp").Value,
                                WdKor = item.Element("wdKor").Value,
                                WfKor = item.Element("wfKor").Value,
                                Tmn = item.Element("tmn").Value,
                                Tmx = item.Element("tmx").Value,
                            };

            Console.Write("HOUR" + "\t");
            Console.Write("DAY" + "\t");
            Console.Write("TEMP" + "\t");
            Console.Write("WD" + "\t");
            Console.Write("WF" + "\t");
            Console.Write("TMN" + "\t");
            Console.Write("TMX" + "\t");
            Console.WriteLine();


            foreach (var item in xmlQuery)
            {
                Console.Write(item.Element("hour").Value + "\t");
                Console.Write(item.Element("day").Value + "\t");
                Console.Write(item.Element("temp").Value + "\t");
                Console.Write(item.Element("wdKor").Value + "\t");
                Console.Write(item.Element("wfKor").Value + "\t");
                Console.Write(item.Element("tmn").Value + "\t");
                Console.Write(item.Element("tmx").Value + "\t");
                Console.WriteLine();

            }

            Console.WriteLine("============================================================");


            foreach (var item in xmlQuery2)
            {
                Console.Write(item.Hour + "\t");
                Console.Write(item.Day + "\t");
                Console.Write(item.Temp + "\t");
                Console.Write(item.WdKor + "\t");
                Console.Write(item.WfKor + "\t");
                Console.Write(item.Tmn + "\t");
                Console.Write(item.Tmx + "\t");
                Console.WriteLine();
            }

            Console.WriteLine("============================================================");


            foreach (var item in xmlQuery3)
            {
                Console.Write(item.Hour + "\t");
                Console.Write(item.Day + "\t");
                Console.Write(item.Temp + "\t");
                Console.Write(item.WdKor + "\t");
                Console.Write(item.WfKor + "\t");
                Console.Write(item.Tmn + "\t");
                Console.Write(item.Tmx + "\t");
                Console.WriteLine();
            }
        }
    }
}
