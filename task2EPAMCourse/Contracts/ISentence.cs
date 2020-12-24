using System;
using System.Collections.Generic;
using System.Text;
using task2EPAMCourse.Model;

namespace task2EPAMCourse.Contracts
{
    public interface ISentence
    {
        void AddItem(ISentenceItems sentenceItems);
    }
}
