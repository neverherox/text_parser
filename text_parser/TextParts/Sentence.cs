using System.Collections.Generic;
using System.Linq;
using System.Text;
using text_parser.TextParts.Contracts;

namespace text_parser
{
    public class Sentence : ISentence
    {
        private ICollection<ISentencePart> parts;
        public string Content
        {
            get
            {
                StringBuilder resultSentence = new StringBuilder();
                foreach (var part in parts)
                {
                    resultSentence.Append(part.Content + " ");
                }
                return resultSentence.ToString();
            }
        }

        public int Count
        {
            get
            {
                return parts.Count;
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
    }
}
