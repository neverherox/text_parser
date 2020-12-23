using System.Collections.Generic;
using text_parser.TextParts.Contracts;

namespace text_parser.Service.Contracts
{
    public interface ITextWorker
    {
        ICollection<ISentence> SortSentences(IEnumerable<ISentence> sentences);
        IEnumerable<IWord> SelectWords(IEnumerable<ISentence> sentences, int length);
        IEnumerable<IWord> SelectWords(ISentence sentence, int length);
        IEnumerable<IWord> SelectWordsStartedWithConsonants(IEnumerable<ISentence> sentences);
        IEnumerable<ISentence> SelectInterrogatives(IEnumerable<ISentence> sentences);
        void RemoveWords(IEnumerable<ISentence> sentences, IEnumerable<IWord> words);
        void PrintWords(IEnumerable<ISentencePart> words);

    }
}
