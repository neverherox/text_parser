using System.Collections.Generic;
using System.Text;
using text_parser.TextParts.Contracts;

namespace text_parser
{
    public class Sentence : ISentence
    {
        private ICollection<ISentencePart> parts;

        public Sentence()
        {
            parts = new List<ISentencePart>();
        }

        public Sentence(ICollection<ISentencePart> source)
        {
            parts = source;
        }

        public string Content
        {
            get
            {
                StringBuilder resultSentence = new StringBuilder();
                foreach (var part in parts)
                {
                    resultSentence.Append(part.Content);
                }
                return resultSentence.ToString();
            }
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
