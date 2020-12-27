using System;
using System.Collections.Generic;
using System.Text;

namespace task2EPAMCourse.Contracts
{
    public interface IUIManager
    {
        void ShowOperationsMenu();

        int GetWordsCount();

        void PrintFindingWords(IList<ISentenceItems> words);

        void PrintModernText(IList<string> textSentence);

        string GetSubstring();

        void PrintModernSentence(ISentence sentence);

        ISentence GetSelectedSentence(IText text);

    }
}
