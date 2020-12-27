using System.Collections.Generic;

namespace task2EPAMCourse.Contracts
{
    public interface IText
    {
        void Add(ISentence sentence);

        IList<ISentence> GetSentences();
    }
}
