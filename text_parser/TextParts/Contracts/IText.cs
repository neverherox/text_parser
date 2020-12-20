using System.Collections.Generic;
using text_parser.TextParts.Contracts;

namespace text_parser
{
    public interface IText
    {
        void Add(ISentence sentence);
        void Remove(ISentence sentence);
        string Content { get; }
    }
}
