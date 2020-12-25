using System.Linq;
using System.IO;
using text_parser.TextParts;
using text_parser.TextParts.Contracts;
using System.Collections.Generic;
using System.Text;
using text_parser.Service.Contracts;
using System;

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
            IText resultText = new Text();
            StringBuilder buffer = new StringBuilder();
            using (reader)
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    buffer.Append(line);
                    var parts = buffer.ToString().Split(separatorContainer.SentenceSeparators, StringSplitOptions.RemoveEmptyEntries);
                    var separators = buffer.ToString().Split(parts, StringSplitOptions.RemoveEmptyEntries);
                    int i;
                    for (i = 0; i < separators.Length; i++)
                    {
                        int index = buffer.ToString().IndexOf(parts[i]);
                        resultText.Add(new Sentence(ParseSentence(parts[i] + separators[i])));
                        buffer.Remove(index, parts[i].Length + separators[i].Length);
                    }
                    if (i != separators.Length)
                    {
                        buffer.Append(parts[i]);
                    }
                    line = reader.ReadLine();
                }
            }
            return resultText;
        }
        private List<ISentencePart> ParseSentence(string content)
        {
            List<ISentencePart> parts = new List<ISentencePart>();
            string[] words = content.Split(new string[] {" ", "\t"}, StringSplitOptions.RemoveEmptyEntries);
            foreach (var word in words)
            {
                var sep = separatorContainer.AllSeparators.Where(x => word.IndexOf(x) >= 0).FirstOrDefault();
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
            return parts;
        }

    }
}

