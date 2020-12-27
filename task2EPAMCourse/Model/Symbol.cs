using System;
using System.Collections.Generic;
using System.Text;
using task2EPAMCourse.Contracts;

namespace task2EPAMCourse.Model
{
    public class Symbol : ISymbol
    { 
        public string Chars { get; set; }

        public Symbol(string word)
        {
            Chars = word;
        }      

        public string GetValue()
        {
            return Chars;
        }
    }
}
