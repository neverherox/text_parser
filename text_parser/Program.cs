﻿using System;
using System.Configuration;
using System.IO;
using text_parser.Service;

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
            text.Worker = new TextWorker();
            text.Sort();
            text.RemoveWords(2);
            Console.WriteLine(text.Content);

            Console.ReadKey();
        }
    }
}
