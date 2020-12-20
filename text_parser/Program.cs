using System;
using System.Configuration;
using System.IO;

namespace text_parser
{
    class Program
    {
        static void Main(string[] args)
        {
            var appSettings = ConfigurationManager.AppSettings;
            string textPath = appSettings["text"];
           
            Parser parser = new Parser();
            IText text = parser.Parse(new StreamReader(textPath));
            Console.WriteLine(text.Content);
            Console.ReadKey();
        }
    }
}
