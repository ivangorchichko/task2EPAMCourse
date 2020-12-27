using System;
using System.Collections.Generic;

namespace task2EPAMCourse.Contracts
{
    public interface ITextService
    { 
        IEnumerable<ISentence> OrderByWords(IText text);

        IEnumerable<ISentenceItems> GetWordsInQuestionSentence(IText text, int wordCount);

        IEnumerable<string> CreateModelText(IEnumerable<ISentence> sentences);

        IEnumerable<ISentence> DeleteWordsFromText(IText text, int wordCount);

        ISentence ReplaceWordsOnSubstring(ISentence sentence, int wordCount, string substring);

    }
}
