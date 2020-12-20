using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using text_parser.Service.Contracts;
using text_parser.TextParts.Contracts;

namespace text_parser.Service
{
    public class TextWorker : ITextWorker
    {
        public ICollection<ISentence> SortSentences(IEnumerable<ISentence> sentences)
        {
            return sentences.OrderBy(x => x.Count).ToList();
        }

        public ICollection<ISentencePart> SelectWords(IEnumerable<ISentence> sentences, int length)
        {
            return sentences.SelectMany(x => x.Words.Where(y => y.Content.Length == length)).ToList();
        }
        public ICollection<ISentence> SelectInterrogatives(IEnumerable<ISentence> sentences)
        {
            return sentences.Where(x => x.LastPart.Content.Equals("?")).ToList();
        }
        public ICollection<ISentencePart> RemoveWords(IEnumerable<ISentence> sentences, int length)
        {
            return null;
        }
        public void PrintWords(IEnumerable<ISentencePart> words)
        {
            foreach (var word in words)
            {
                Console.WriteLine(word.Content);
            }
        }
    }
}
