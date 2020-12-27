using System;
using System.Collections.Generic;
using System.Text;
using task2EPAMCourse.Contracts;

namespace task2EPAMCourse.Model
{
    public class SymbolSeparator : ISymbolSeparator
    {
        public SymbolSeparator(string word)
        {
            Chars = word;
        }

        public string Chars { get; set; }

        public string GetValue()
        {
            return Chars;
        }
    }
}
