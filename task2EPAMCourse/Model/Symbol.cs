using System;
using System.Collections.Generic;
using System.Text;
using task2EPAMCourse.Contracts;

namespace task2EPAMCourse.Model
{
    public class Symbol : ISymbol
    {
        private string _symbols;

        public Symbol(string word)
        {
            _symbols = word;
        }

        public string Chars
        {
            get { return _symbols; }
            set { _symbols = value; }
        }

        public string GetValue()
        {
            return _symbols;
        }
    }
}
