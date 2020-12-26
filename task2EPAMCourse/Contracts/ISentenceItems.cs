using System;
using System.Collections.Generic;
using System.Text;

namespace task2EPAMCourse.Contracts
{
    public interface ISentenceItems
    {
        string Chars { get; set; }
        string GetValue();
    }
}
