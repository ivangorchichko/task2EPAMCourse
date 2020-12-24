using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace task2EPAMCourse.Model.Separators
{
    class SentenceSeparators : Separator
    {
        private string[] _sentenceSeparators = new string[] { ".", "!", "?" };

        public override string[] GetSeparator()
        {
            return _sentenceSeparators;
        }
    }
}
