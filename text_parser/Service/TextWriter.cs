using System.IO;
using text_parser.Service.Contracts;

namespace text_parser.Service
{
    public class TextWriter : ITextWriter
    {

        public void WriteText(IText text, string fileName)
        {
            System.IO.TextWriter textWriter = new StreamWriter(fileName);
            using (textWriter)
            {
                textWriter.WriteLine(text.ToString());
            }
        }
       
    }
}
