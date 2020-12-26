using System.Linq;
using text_parser.Service.Contracts;
using text_parser.TextParts.Contracts;

namespace text_parser.Service
{
    public class TextService : ITextService
    {
        public void Sort(IText text)
        {
            text.Sentences = SentenceWorker.SortSentences(text.Sentences);
        }
        public void PrintWordsInInterrogatives(IText text, int length)
        {
            var interrogatives = SentenceWorker.SelectInterrogatives(text.Sentences);
            var words = SentenceWorker.SelectWords(interrogatives, length);
            var distincts = words.GroupBy(x => x.ToString().ToLower()).Select(y => y.First());
            SentenceWorker.PrintWords(distincts);
        }
        public void RemoveWordsStartedWithConsonants(IText text, int length)
        {
            var words = SentenceWorker.SelectWords(text.Sentences, length);
            var wordsStartedWithConsonants = SentenceWorker.SelectWordsStartedWithConsonants(text.Sentences);
            var intersection = words.Intersect(wordsStartedWithConsonants);
            SentenceWorker.RemoveWords(text.Sentences, intersection.ToList());
        }

        public void ReplaceWords(ISentence sentence, int length, string newWord)
        {
            SentenceWorker.ReplaceWords(sentence, length, newWord);
        }
    }
}
