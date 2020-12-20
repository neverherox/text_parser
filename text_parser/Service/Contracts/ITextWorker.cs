using System;
using System.Collections.Generic;
using text_parser.TextParts.Contracts;

namespace text_parser.Service.Contracts
{
    public interface ITextWorker
    {
        ICollection<ISentence> SortSentences(IEnumerable<ISentence> sentences);
        ICollection<ISentencePart> SelectWords(IEnumerable<ISentence> sentences, int length);
        ICollection<ISentence> SelectInterrogatives(IEnumerable<ISentence> sentences);
        void PrintWords(IEnumerable<ISentencePart> words);
        ICollection<ISentencePart> RemoveWords(IEnumerable<ISentence> sentences, int length);
    }
}
