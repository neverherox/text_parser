using System.Collections.Generic;
using text_parser.Service.Contracts;
using text_parser.TextParts.Contracts;

namespace text_parser
{
    public interface IText
    {
        ISentence GetSentence(int index);
        ICollection<ISentence> Sentences { get; set; }
        void Add(ISentence sentence);
        void Remove(ISentence sentence);
    }
}
