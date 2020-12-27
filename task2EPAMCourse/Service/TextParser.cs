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
        private readonly IFileService file = new FileService();
        private readonly Separator separators = new WordSeparators();
        private readonly Separator sentenceSeparator = new SentenceSeparators();
        private readonly Separator largeSentenceSeparator = new DifficultSentenceSeparators();

        public IList<ISentenceItems> ParseText(IList<ISentenceItems> sentanceItems)
        {
            using (var streamReader = file.GetReader())
            {
                while (!streamReader.EndOfStream)
                {
                    string line = streamReader.ReadLine();
                    if (line != "")
                    {
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
                                        if (lineWords[i].IndexOf(wordSeparator) == 0 && lineWords[i].LastIndexOf(wordSeparator) == lineWords[i].Length - 1)
                                        {
                                            sentanceItems.Add(new SymbolSeparator(wordSeparator));
                                            sentanceItems.Add(new Word(lineWords[i].Trim(wordSeparator[0])));
                                            sentanceItems.Add(new SymbolSeparator(wordSeparator));
                                            isAdded = true;
                                            break;
                                        }
                                        else
                                        if (lineWords[i].IndexOf(wordSeparator) == 0)
                                        {
                                            sentanceItems.Add(new SymbolSeparator(wordSeparator));
                                            sentanceItems.Add(new Word(lineWords[i].Trim(wordSeparator[0])));
                                            isAdded = true;
                                            break;
                                        }
                                        else
                                        {
                                            sentanceItems.Add(new Word(lineWords[i].Trim(wordSeparator[0])));
                                            sentanceItems.Add(new SymbolSeparator(wordSeparator));
                                            isAdded = true;
                                            break;
                                        }

                                    }
                                    else
                                    {
                                        sentanceItems.Add(new SymbolSeparator(wordSeparator));
                                        isAdded = true;
                                        break;
                                    }

                                }
                                else
                                {
                                    foreach (var sentenceSeparator in sentenceSeparator.GetSeparator())
                                    {
                                        if (lineWords[i].Contains(sentenceSeparator))
                                        {
                                            foreach (var largeSentenceSeparator in largeSentenceSeparator.GetSeparator())
                                            {
                                                if (lineWords[i].Contains(largeSentenceSeparator))
                                                {
                                                    lineWords[i] = lineWords[i].Remove(lineWords[i].IndexOf(largeSentenceSeparator),
                                                        largeSentenceSeparator.Length);
                                                    sentanceItems.Add(new Word(lineWords[i]));
                                                    sentanceItems.Add(new SymbolSeparator(largeSentenceSeparator));
                                                    isAdded = true;
                                                    break;
                                                }
                                            }
                                            if (isAdded == false)
                                            {
                                                sentanceItems.Add(new Word(lineWords[i].Trim(sentenceSeparator[0])));
                                                sentanceItems.Add(new SymbolSeparator(sentenceSeparator));
                                                isAdded = true;
                                            }
                                            break;
                                        }
                                    }
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
                        j = sentenceSeparator.GetSeparator().Length - 1;

                    }
                }
            }
        }
    }
}

