using System.Collections.Generic;

namespace task2EPAMCourse.Contracts
{
    public interface IUIManager
    {
        void ShowOperationsMenu();

        int GetWordsCount();

        void PrintFindingWords(IEnumerable<ISentenceItems> words);

        void PrintModernText(IEnumerable<string> textSentence);

        string GetSubstring();

        void PrintModernSentence(ISentence sentence);

        ISentence GetSelectedSentence(IText text);

    }
}
