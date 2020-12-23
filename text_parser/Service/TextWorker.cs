using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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

        public IEnumerable<IWord> SelectWords(IEnumerable<ISentence> sentences, int length)
        {
            return sentences.SelectMany(x => x.Words.Where(y => y.Count == length));
        }
        public IEnumerable<IWord> SelectWords(ISentence sentence, int length)
        {
            return sentence.Words.Where(x => x.Count == length);
        }
        public IEnumerable<IWord> SelectWordsStartedWithConsonants(IEnumerable<ISentence> sentences)
        {
            string pattern = @"[aeiou]";
            return sentences.SelectMany(x => x.Words.Where(y => Regex.Matches(y.FirstSymbol.Content, pattern).Count == 0));
        }
        public IEnumerable<ISentence> SelectInterrogatives(IEnumerable<ISentence> sentences)
        {
            return sentences.Where(x => x.LastPart.Content.Equals("?"));
        }
        public void RemoveWords(IEnumerable<ISentence> sentences, ICollection<IWord> words)
        {
            foreach (var sentence in sentences)
            {
                foreach (var word in words)
                {
                    sentence.Remove(word);
                }
            }
        }
        public void ReplaceWords(ISentence sentence, int length, string newWord)
        {
            var words = SelectWords(sentence, length);
            foreach(var word in words)
            {
                sentence.Remove(word);
            }
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
