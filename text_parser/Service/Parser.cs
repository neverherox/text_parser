using System.Linq;
using System.IO;
using text_parser.TextParts;
using text_parser.TextParts.Contracts;
using System.Collections.Generic;
using System.Text;
using text_parser.Service.Contracts;

namespace text_parser
{
    public class Parser : IParser
    {
        private SeparatorContainer separatorContainer;
       
        public Parser()
        {
            separatorContainer = new SeparatorContainer();
        }
        public IText Parse(TextReader reader)
        {
            StringBuilder buffer = new StringBuilder();
            IText resultText = new Text();

            using (reader)
            {
                string line = reader.ReadLine();
                buffer.Append(line);
                while (line != null)
                {
                    var seps = line.SelectMany(x => separatorContainer.SentenceSeparators.Where(y => y.IndexOf(x) >= 0));
                    if (seps != null)
                    {
                        int currentPosition = 0;
                        foreach (var sep in seps)
                        {
                            int endPosition = buffer.ToString().IndexOf(sep) + sep.Length;
                            int length = endPosition - currentPosition;
                            resultText.Add(new Sentence(ParseSentence(buffer.ToString().Substring(currentPosition, length))));
                            buffer.Remove(currentPosition, length);
                            currentPosition += endPosition + 1;     
                        }
                    }
                    line = reader.ReadLine();
                    buffer.Append(line);
                }
                return resultText;
            }
        }
        private List<ISentencePart> ParseSentence(string content)
        {
            List<ISentencePart> parts = new List<ISentencePart>();
            string[] words = content.Split(' ', '\t');
            foreach (var word in words)
            {
                var sep = separatorContainer.AllSeparators.Where(x => word.IndexOf(x) >= 0).FirstOrDefault();
                if (word.Length > 0)
                {
                    if (sep != null)
                    {
                        parts.Add(new Word(word.Remove(word.IndexOf(sep))));
                        parts.Add(new Punctuation(sep.ToString()));
                    }
                    else
                    {
                        parts.Add(new Word(word));
                    }
                }
            }
            return parts;
        }

    }
}

