using System.Collections.Generic;
using System.Linq;
using System.Text;
using text_parser.TextParts.Contracts;
namespace text_parser
{
    public class Word : ISentencePart
    {
        private IEnumerable<Symbol> symbols;
        public string Content
        {
            get
            {
                StringBuilder resultWord = new StringBuilder();
                foreach (var symbol in symbols)
                {
                    resultWord.Append(symbol.Content);
                }
                return resultWord.ToString();
            }
        }
        public Word(string content)
        {
            symbols = content.Select(x => new Symbol(x.ToString())).ToList<Symbol>();
        }
        public Word(IEnumerable<Symbol> source)
        {
            symbols = source;
        }
    }
}
