using System;
using System.Collections.Generic;
using System.Text;

namespace task2EPAMCourse.Model.Separators
{
    internal class DifficultSentenceSeparators : Separator
    {
        private string[] _largeSentenceSeparators = new string[] { "...", "?!", "!?" };

        public override string[] GetSeparator()
        {
            return _largeSentenceSeparators;
        }
    }
}
