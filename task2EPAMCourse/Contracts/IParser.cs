using System;
using System.Collections.Generic;
using System.Text;

namespace task2EPAMCourse.Contracts
{
    public interface IParser
    {
        IList<ISentenceItems> ParseText(IList<ISentenceItems> sentanceItems);
        void CreateSentence(IText text, IList<ISentenceItems> sentenceItems);
    }
}
