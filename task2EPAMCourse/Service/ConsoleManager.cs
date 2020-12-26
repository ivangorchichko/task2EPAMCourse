using System;
using System.Collections.Generic;
using System.Text;
using task2EPAMCourse.Contracts;

namespace task2EPAMCourse.Service
{
    class ConsoleManager : IUIManager
    {
        public void ShowOperationsMenu()
        {
            Console.WriteLine("Choose operation with text: \n" +
                  "1 - show ordered by words sentences\n" +
                  "2 - show words fixed large in question sentences\n" +
                  "3 - delete words from text fixed large\n" +
                  "4 - replace words fixed large with substring\n" +
                  "5 - save object model\n" +
                  "0 - stop program");
        }
        public int GetWordsCount()
        {
            Console.WriteLine("Choose words count");
            var wordCount = Convert.ToInt32(Console.ReadLine());
            return wordCount;
        }

        public void PrintFindingWords(IList<ISentenceItems> words)
        {
            foreach (var word in words)
            {
                Console.Write(word.GetValue() + ", ");
            }
            Console.WriteLine();
        }

        public void PrintModernText(List<string> textSentences)
        {
            foreach (var sentence in textSentences)
            {
                Console.WriteLine(sentence);
            }
        }
        public string GetSubstring()
        {
            Console.WriteLine("Choose substring");
            var substring = Console.ReadLine();
            return substring;
        }

        public void PrintModernSentence(ISentence sentence)
        {
            foreach (var items in sentence.GetSentenceItems())
            {
                Console.Write(items.GetValue() + " ");
            }
        }

        public ISentence GetSelectedSentence(IText text)
        {
            Console.WriteLine("Choose number of sentence");
            var number = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Selected sentence : ");
            foreach(var item in text.GetSentences()[number - 1].GetSentenceItems())
            {
                Console.Write(item.GetValue() + " ");
            }
            Console.WriteLine();
            return text.GetSentences()[number - 1];
        }
    }
}
