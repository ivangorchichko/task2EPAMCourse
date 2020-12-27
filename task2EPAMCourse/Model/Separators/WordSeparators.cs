using System;
using System.Collections.Generic;
using System.Text;
using task2EPAMCourse.Model.Separators;

namespace task2EPAMCourse.Model.Separators
{
    internal class WordSeparators : Separator
    {
        private string[] _wordSeparators = new string[] { ",", "-", ";", "'", ":", "\"", "[", "]", "{", "}" };

        public override string[] GetSeparator()
        {
            return _wordSeparators;
        }
    }
}
