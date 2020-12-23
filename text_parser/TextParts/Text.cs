using System.Linq;
using System.Collections.Generic;
using System.Text;
using text_parser.Service.Contracts;
using text_parser.TextParts.Contracts;

namespace text_parser
{
    public class Text : IText
    {
        private ICollection<ISentence> sentences;
        private ITextWorker worker;
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

        public ITextWorker Worker { set => worker = value; }

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

        public void Sort()
        {
            if (worker != null)
            {
                sentences = worker.SortSentences(sentences);
            }
        }
        public void PrintWords(int length)
        {
            if (worker != null)
            {
                var interrogatives = worker.SelectInterrogatives(sentences);
                var words = worker.SelectWords(interrogatives, length);
                worker.PrintWords(words);
            }
        }
        public void RemoveWords(int length)
        {
            if (worker != null)
            {
                var words = worker.SelectWords(sentences, length);
                var wordsStartedWithConsonants = worker.SelectWordsStartedWithConsonants(sentences);
                var intersection = words.Intersect(wordsStartedWithConsonants);
                worker.RemoveWords(sentences, intersection.ToList());
            }
        }
    }
}
