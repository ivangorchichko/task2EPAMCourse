using System.Collections.Generic;

namespace task2EPAMCourse.Contracts
{
    public interface ISentence
    {
        void AddItem(ISentenceItems sentenceItems);

        IList<ISentenceItems> GetSentenceItems();
    }
}
