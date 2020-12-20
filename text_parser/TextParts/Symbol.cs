using text_parser.TextParts.Contracts;

namespace text_parser
{
    public class Symbol : ISentencePart
    {
        public string Content { get; }

        public Symbol(string content)
        {
            Content = content;
        }
    }
}
