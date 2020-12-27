using System;
using System.Collections.Generic;
using System.Text;

namespace task2EPAMCourse.Contracts
{
    public interface ITextService
    {
        bool TryParseEnum<T>(out T operation) where T : struct, IConvertible;

        IText OrderSentenceInText(IText text);

        IList<ISentenceItems> GetWordsInQuestionSentence(IText text, int wordCount);

        IList<string> CreateModelText(IText text);

        IText DeleteWordsFromText(IText text, int wordCount);

        ISentence ReplaceWordsOnSubstring(ISentence sentence, int wordCount, string substring);

        void SaveObjectModel(IText text, IFileService fileService);

    }
}
