using System;
using System.Collections.Generic;
using System.Linq;
using task2EPAMCourse.Contracts;
using task2EPAMCourse.FileOperations;
using task2EPAMCourse.Model;
using task2EPAMCourse.Model.Separators;

namespace task2EPAMCourse.Service
{
    public class TextParser : IParser
    {
        private readonly IFileService _file = new FileService();
        private readonly ISeparator _separators = new WordSeparators();
        private readonly ISeparator _sentenceSeparator = new SentenceSeparators();
        private readonly ISeparator _largeSentenceSeparator = new DifficultSentenceSeparators();

        private IEnumerable<ISentenceItems> ParseText()
        {
            using (var streamReader = _file.GetReader())
            {
                while (!streamReader.EndOfStream)
                {
                    string line = streamReader.ReadLine();
                    if (line != String.Empty)
                    {
                        string[] lineWords = line.Replace('\t', ' ').Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        bool isAdded = false;
                        for (int i = 0; i < lineWords.Length; i++)
                        {
                            foreach (var wordSeparator in _separators.GetSeparator())
                            {
                                if (lineWords[i].Contains(wordSeparator))
                                {
                                    if (lineWords[i] != wordSeparator)
                                    {
                                        if (lineWords[i].IndexOf(wordSeparator) == 0 && lineWords[i].LastIndexOf(wordSeparator) == lineWords[i].Length - 1)
                                        {
                                            yield return new Symbol(wordSeparator);
                                            yield return new Word(lineWords[i].Trim(wordSeparator[0]));
                                            yield return new Symbol(wordSeparator);
                                            isAdded = true;
                                            break;
                                        }
                                        else
                                        if (lineWords[i].IndexOf(wordSeparator) == 0)
                                        {
                                            yield return new Symbol(wordSeparator);
                                            yield return new Word(lineWords[i].Trim(wordSeparator[0]));
                                            isAdded = true;
                                            break;
                                        }
                                        else
                                        {
                                            yield return new Word(lineWords[i].Trim(wordSeparator[0]));
                                            yield return new Symbol(wordSeparator);
                                            isAdded = true;
                                            break;
                                        }

                                    }
                                    else
                                    {
                                        yield return new Symbol(wordSeparator);
                                        isAdded = true;
                                        break;
                                    }

                                }
                                else
                                {
                                    foreach (var sentenceSeparator in _sentenceSeparator.GetSeparator())
                                    {
                                        if (lineWords[i].Contains(sentenceSeparator))
                                        {
                                            foreach (var largeSentenceSeparator in _largeSentenceSeparator.GetSeparator())
                                            {
                                                if (lineWords[i].Contains(largeSentenceSeparator))
                                                {
                                                    lineWords[i] = lineWords[i].Remove(lineWords[i].IndexOf(largeSentenceSeparator),
                                                        largeSentenceSeparator.Length);
                                                    yield return new Word(lineWords[i]);
                                                    yield return new Symbol(largeSentenceSeparator);
                                                    isAdded = true;
                                                    break;
                                                }
                                            }
                                            if (isAdded == false)
                                            {
                                                yield return new Word(lineWords[i].Trim(sentenceSeparator[0]));
                                                yield return new Symbol(sentenceSeparator);
                                                isAdded = true;
                                            }
                                            break;
                                        }
                                    }
                                }
                            }
                            if (isAdded == false)
                            {
                                yield return new Word(lineWords[i]);
                            }
                            isAdded = false;
                        }
                    }
                }
            }
        }

        public void CreateSentence(IText text)
        {
            var sentenceItems = ParseText().ToList();
            int lastWord = 0;
            for (int i = 0; i < sentenceItems.Count; i++)
            {
                for (int j = 0; j < _sentenceSeparator.GetSeparator().Length; j++)
                {
                    if (sentenceItems[i].GetValue().Contains(_sentenceSeparator.GetSeparator()[j]))
                    {
                        ISentence sentence = new Sentence();
                        for (int count = lastWord; count <= i; count++)
                        {
                            sentence.AddItem(sentenceItems[count]);
                        }
                        text.Add(sentence);
                        lastWord = i + 1;
                        break;
                    }
                }
            }
        }
    }
}

