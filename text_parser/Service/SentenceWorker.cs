using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using text_parser.Service.Contracts;
using text_parser.TextParts.Contracts;

namespace text_parser.Service
{
    public static class SentenceWorker
    {
        public static ICollection<ISentence> SortSentences(IEnumerable<ISentence> sentences)
        {
            return sentences.OrderBy(x => x.Count).ToList();
        }

        public static IEnumerable<IWord> SelectWords(IEnumerable<ISentence> sentences, int length)
        {
            return sentences.SelectMany(x => x.Words.Where(y => y.Count == length));
        }
        public static IEnumerable<IWord> SelectWords(ISentence sentence, int length)
        {
            return sentence.Words.Where(x => x.Count == length);
        }
        public static IEnumerable<IWord> SelectWordsStartedWithConsonants(IEnumerable<ISentence> sentences)
        {
            string pattern = @"[aeiou]";
            return sentences.SelectMany(x => x.Words.Where(y => Regex.Matches(y.FirstSymbol.Content, pattern).Count == 0));
        }
        public static IEnumerable<ISentence> SelectInterrogatives(IEnumerable<ISentence> sentences)
        {
            return sentences.Where(x => x.LastPart.ToString().Equals("?"));
        }
        public static void RemoveWords(IEnumerable<ISentence> sentences, ICollection<IWord> words)
        {
            foreach (var sentence in sentences)
            {
                foreach (var word in words)
                {
                    sentence.Remove(word);
                }
            }
        }
        public static void ReplaceWords(ISentence sentence, int length, string newWord)
        {
            var words = SelectWords(sentence, length);
            foreach (var word in words.ToList())
            {
                sentence.Replace(word, new Word(newWord));
            }
        }
        public static void PrintWords(IEnumerable<ISentencePart> words)
        {
            foreach (var word in words)
            {
                Console.WriteLine(word.ToString());
            }
        }
    }
}
