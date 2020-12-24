using System.Collections.Generic;

namespace text_parser.TextParts.Contracts
{
    public interface ISentence
    {
        int Count { get; }

        ISentencePart LastPart { get; }

        IEnumerable<IWord> Words { get; }

        void Add(ISentencePart part);
        void Remove(ISentencePart part);
        void Replace(IWord oldWord, IWord newWord);

    }
}
