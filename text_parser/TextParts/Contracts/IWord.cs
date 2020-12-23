namespace text_parser.TextParts.Contracts
{
    public interface IWord : ISentencePart
    {
        Symbol FirstSymbol { get; }
        int Count { get; }
    }
}
