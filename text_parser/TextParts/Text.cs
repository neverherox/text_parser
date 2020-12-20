using System.Collections;
using System.Collections.Generic;
using System.Text;
using text_parser.TextParts.Contracts;

namespace text_parser
{
    public class Text : IText
    {
        private ICollection<ISentence> sentences;

        public string Content
        {
            get
            {
                StringBuilder resultText = new StringBuilder();
                foreach (var sentence in sentences)
                {
                    resultText.Append(sentence.Content + '\n');
                }
                return resultText.ToString();
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
            sentences.Add(sentence);
        }
     
        public void Remove(ISentence sentence)
        {
            throw new System.NotImplementedException();
        }

       
    }
}
