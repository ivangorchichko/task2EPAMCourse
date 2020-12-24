using System;
using System.Collections.Generic;
using System.Text;

namespace task2EPAMCourse.Contracts
{
    interface ISymbol : ISentenceItems
    {
        string Chars { get; set; }
    }
}
