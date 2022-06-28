using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace XML_Dollar
{
    class Exchange
    {
        // private
        private string url { get; set; }

        // public
        public string tag { get; set; } 
        public IEnumerable<XElement> xmlQuery { get; set; }
        public string text { get; set; }

        public Exchange(string url, string tag)
        {
            this.url = url;
            this.tag = tag;           
        }

        public void getItem()
        {
            this.text = ""; // initialize

            XElement xElement = XElement.Load(this.url);

            this.xmlQuery = from item in xElement.Descendants(this.tag)
                            select item;

            foreach (var item in this.xmlQuery)
            {
                this.text += item.ToString();
            }
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string url = "https://kr.fxexchangerate.com/krw/usd.xml";
            string tag = "item";
            Exchange exchange = new Exchange(url, tag);
            
            exchange.getItem();
            //Console.WriteLine(exchange.text);

            Console.WriteLine();

            exchange.tag = "description";
            exchange.getItem();
            //Console.WriteLine(exchange.text);

            List<string> items;
            items = exchange.text.Split('>', '<', '[', ']', '=').ToList();

            //Console.WriteLine(items.Count);
            
                
            foreach (var item in items)
            {
                //Console.WriteLine(item);
                string temp = item.ToString();
                temp = temp.Trim();
                if (temp.Contains("KRW")) 
                {
                    //Console.WriteLine("KRW 확인");
                    //Console.WriteLine(temp);

                    if (temp.Length > 0) {
                        int idx = 0;
                        do
                        {
                            idx = temp.IndexOf("KRW", idx + 1);
                            
                            if ((idx >= 0))
                            {
                            
                                double result = 0;
                                double.TryParse(temp[..(idx)], out result);
                                if (result > 1) 
                                {
                                    Console.WriteLine("1 USD = " + result + "원");
                                }
                                
                                //Console.WriteLine("TEXT : " + temp[..(idx - 5)]);
                                
                                
                            }


                        } while (idx + 1 < temp.Length && idx != -1);
                    }
                } 

            }



            //if (exchange.text.Length > 0) {
            //    int idx =0, i = 0;
            //    do
            //    {
            //        idx = exchange.text.IndexOf("KRW", idx + 1);
            //        Console.WriteLine("INDEX : " + idx);
            //        Console.WriteLine("TARGET : " + exchange.text[(idx)..(idx + 3)]);
            //    } while (idx + 1 < exchange.text.Length && idx != -1);
            //}


            //Console.WriteLine("TARGET " +items.FindIndex(target => target.Contains("KRW")));

        }
    }
}
