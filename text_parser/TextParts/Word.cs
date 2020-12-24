using System.Collections.Generic;
using System.Linq;
using System.Text;
using text_parser.TextParts.Contracts;
namespace text_parser
{
    public class Word : IWord
    {
        private IEnumerable<Symbol> symbols;
       
        public Symbol FirstSymbol
        {
            get
            {
                return symbols.First();
            }
        }
        public int Count
        {
            get
            {
                return symbols.Count();
            }
        }

        public Word(string content)
        {
            symbols = content.Select(x => new Symbol(x.ToString())).ToList();
        }
        public Word(IEnumerable<Symbol> source)
        {
            symbols = source;
        }

        public override string ToString()
        {
            StringBuilder resultWord = new StringBuilder();
            foreach (var symbol in symbols)
            {
                resultWord.Append(symbol.Content);
            }
            return resultWord.ToString();
        }
    }
}
