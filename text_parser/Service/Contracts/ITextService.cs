using text_parser.TextParts.Contracts;

namespace text_parser.Service.Contracts
{
    public interface ITextService
    {
        void Sort(IText text);
        void PrintWordsInInterrogatives(IText text, int length);
        void RemoveWordsStartedWithConsonants(IText text, int length);
        void ReplaceWords(ISentence sentence, int length, string newWord);
    }
}
