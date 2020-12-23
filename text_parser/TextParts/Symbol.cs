using text_parser.TextParts.Contracts;

namespace text_parser
{
    public class Symbol
    {
        public string Content { get; }

        public Symbol(string content)
        {
            Content = content;
        }
    }
}
