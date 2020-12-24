using System.Collections.Generic;
using System.Linq;
using System.Text;
using text_parser.TextParts.Contracts;

namespace text_parser
{
    public class Sentence : ISentence
    {
        private ICollection<ISentencePart> parts;
        
        public int Count
        {
            get
            {
                int counter = 0;
                foreach(var part in parts)
                {
                    if (part is IWord)
                    {
                        counter++;
                    }
                }
                return counter;
            }
        }

        public ISentencePart LastPart
        {
            get
            {
                return parts.Last();
            }
        }

        public IEnumerable<IWord> Words
        {
            get
            {
                return parts.Where(x => x is Word).Cast<IWord>();
            }
        }


        public Sentence()
        {
            parts = new List<ISentencePart>();
        }

        public Sentence(ICollection<ISentencePart> source)
        {
            parts = source;
        }
        public void Add(ISentencePart part)
        {
            if (parts != null)
            {
                parts.Add(part);
            }
        }

        public void Remove(ISentencePart part)
        {
            if (parts != null)
            {
                parts.Remove(part);
            }
        }

        public void Replace(IWord oldWord, IWord newWord)
        {
            int index = parts.ToList().IndexOf(oldWord);
            Remove(oldWord);
            var result = parts.ToList();
            result.Insert(index, newWord);
            parts = result;
        }
        public override string ToString()
        {
            StringBuilder resultSentence = new StringBuilder();
            foreach (var part in parts)
            {
                if (part is IWord)
                {
                    resultSentence.Append(" " + part.ToString());
                }
                else
                {
                    resultSentence.Append(part.ToString());
                }
            }
            return resultSentence.ToString();

        }
    }
}
