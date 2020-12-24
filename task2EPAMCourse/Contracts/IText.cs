using System;
using System.Collections.Generic;
using System.Text;

namespace task2EPAMCourse.Contracts
{
    public interface IText
    {
        void Add(ISentence sentence);

        ICollection<ISentence> GetSentences();
    }
}
