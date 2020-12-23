using text_parser.Service.Contracts;
using text_parser.TextParts.Contracts;

namespace text_parser
{
    public interface IText
    {
        void Add(ISentence sentence);
        void Remove(ISentence sentence);
        string Content { get; }

        void Sort();

        ITextWorker Worker { set; }
        void PrintWords(int length);
        void RemoveWords(int length);
    }
}
