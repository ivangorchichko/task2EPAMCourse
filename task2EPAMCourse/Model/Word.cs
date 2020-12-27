using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using task2EPAMCourse.Contracts;

namespace task2EPAMCourse.Model
{
    public class Word : IWord
    {
        private SymbolSeparator _symbols;

        public Word(string word)
        {
            _symbols = new SymbolSeparator(word);
        }

        public string Chars
        {
            get { return _symbols.Chars; }
            set { _symbols.Chars = value; }
        }

        public string GetValue()
        {
            return _symbols.Chars;
        }
    }
}
