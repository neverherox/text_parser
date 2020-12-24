using text_parser.TextParts.Contracts;
namespace text_parser
{
    public class Punctuation : ISentencePart
    {

        private Symbol symbol;
       
        public Punctuation(Symbol source)
        {
            symbol = source;
        }
        public Punctuation(string content)
        {
            symbol = new Symbol(content);
        }
        public override string ToString()
        {
            return symbol.Content;
        }
    }
}
