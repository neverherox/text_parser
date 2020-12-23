using System.Collections.Generic;

namespace text_parser.TextParts.Contracts
{
    public interface ISentence
    {
        string Content { get; }
        int Count { get; }

        ISentencePart LastPart { get; }

        IEnumerable<IWord> Words { get; }

        void Add(ISentencePart part);
        void Remove(ISentencePart part);

    }
}
