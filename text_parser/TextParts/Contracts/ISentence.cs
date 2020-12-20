namespace text_parser.TextParts.Contracts
{
    public interface ISentence
    {
        void Add(ISentencePart part);
        void Remove(ISentencePart part);

        string Content { get; }
    }
}
