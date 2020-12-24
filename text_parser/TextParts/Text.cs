using System.Linq;
using System.Collections.Generic;
using System.Text;
using text_parser.TextParts.Contracts;

namespace text_parser
{
    public class Text : IText
    {
        private ICollection<ISentence> sentences;
       
        public ICollection<ISentence> Sentences
        {
            get
            {
                return sentences;
            }
            set
            {
                sentences = value;
            }
        }

        public Text()
        {
            sentences = new List<ISentence>();
        }
        public Text(ICollection<ISentence> source)
        {
            sentences = source;
        }

        public void Add(ISentence sentence)
        {
            if (sentences != null)
            {
                sentences.Add(sentence);
            }
        }

        public void Remove(ISentence sentence)
        {
            if (sentences != null)
            {
                sentences.Remove(sentence);
            }
        }

        public ISentence GetSentence(int index)
        {
            return sentences.ToList()[index];
        }
        public override string ToString()
        {
            StringBuilder resultText = new StringBuilder();
            foreach (var sentence in sentences)
            {
                resultText.Append(sentence.ToString() + '\n');
            }
            return resultText.ToString();
        }
    }
}
