using System;
using System.Collections.Generic;
using System.Text;
using task2EPAMCourse.Contracts;
using task2EPAMCourse.FileOperations;
using task2EPAMCourse.Model;
using task2EPAMCourse.Model.Separators;

namespace task2EPAMCourse.Service
{
    public class TextParser : IParser
    {
        private IFileService file = new FileService();
        private Separator separators = new WordSeparators();
        private Separator sentenceSeparator = new SentenceSeparators();
        private Separator largeSentenceSeparator = new DifficultSentenceSeparators();
        public IList<ISentenceItems> ParseText(IList<ISentenceItems> sentanceItems)
        {
            using (var streamReader = file.GetReader())
            {
                while (!streamReader.EndOfStream)
                {
                    string line = streamReader.ReadLine();
                    line = line.Replace('\t', ' ');
                    string result = string.Join(" ", line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
                    string[] lineWords = result.Split(" ");
                    bool isAdded = false;

                    for (int i = 0; i < lineWords.Length; i++)
                    {
                        foreach (var wordSeparator in separators.GetSeparator())
                        {
                            if (lineWords[i].Contains(wordSeparator))
                            {
                                if (lineWords[i] != wordSeparator)
                                {
                                    if (lineWords[i].IndexOf(wordSeparator) == 0)
                                    {
                                        sentanceItems.Add(new Symbol(wordSeparator));
                                        sentanceItems.Add(new Word(lineWords[i].Trim(wordSeparator[0])));

                                    }
                                    else
                                    {
                                        lineWords[i].Remove(lineWords[i].IndexOf(wordSeparator), 1);
                                        sentanceItems.Add(new Word(lineWords[i].Trim(wordSeparator[0])));
                                        sentanceItems.Add(new Symbol(wordSeparator));
                                    }
                                }
                                else
                                {
                                    sentanceItems.Add(new Symbol(wordSeparator));
                                }
                                isAdded = true;
                            }
                        }
                        if (isAdded == false)
                        {
                            sentanceItems.Add(new Word(lineWords[i]));
                        }
                        isAdded = false;
                    }
                }
            }
            return sentanceItems;
        }

        public void CreateSentence(IText text, IList<ISentenceItems> sentenceItems)
        {
            int lastWord = 0;
            for (int i = 0; i < sentenceItems.Count; i++)
            {
                for (int j = 0; j <= sentenceSeparator.GetSeparator().Length - 1; j++)
                {
                    if (sentenceItems[i].GetValue().Contains(sentenceSeparator.GetSeparator()[j]))
                    {
                        ISentence sentence = new Sentence();
                        for (int count = lastWord; count <= i; count++)
                        {
                            sentence.AddItem(sentenceItems[count]);
                        }
                        text.Add(sentence);
                        lastWord = i + 1;
                    }
                }
            }
        }
    }
}

