using System;
using System.Configuration;
using System.IO;
using text_parser.Service;
using text_parser.Service.Contracts;

namespace text_parser
{
    class Program
    {
        static void Main(string[] args)
        {
            var appSettings = ConfigurationManager.AppSettings;
            Parser parser = new Parser();
            IText text = parser.Parse(new StreamReader(appSettings["text"]));
            ITextService textService = new TextService();
            ITextWriter textWriter = new Service.TextWriter();
            textWriter.WriteText(text, appSettings["restored"]);
            Console.WriteLine(text.ToString());
            Console.ReadKey();
        }
    }
}
