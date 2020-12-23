using text_parser.TextParts.Contracts;

namespace text_parser
{
    public class Punctuation : ISentencePart
    {
        private Symbol symbol;
        public string Content => symbol.Content;

        public Punctuation(Symbol source)
        {
            symbol = source;
        }
        public Punctuation(string content)
        {
            symbol = new Symbol(content);
        }
    }
}
