using System;
using System.Collections.Generic;
using System.Linq;
namespace text_parser.TextParts
{
    public class SeparatorContainer
    {
        private string[] sentenceSeparators = {".", "!", "?"};
        private string[] wordSeparators = {"-", ",", " ", ":", ";"};

        public string[] SentenceSeparators { get => sentenceSeparators; }
        public string[] WordSeparators { get => wordSeparators; }

        public string[] AllSeparators { get { return SentenceSeparators.Concat(WordSeparators).ToArray(); } }
    }
}
