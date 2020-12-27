using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using task2EPAMCourse.Contracts;
using task2EPAMCourse.Model;

namespace task2EPAMCourse.Service
{
    public class TextService : ITextService
    {
        private static readonly char[] _consonant = new char[] { 'q', 'w', 'r', 't', 'p', 's', 'd', 'f',
                'g', 'h', 'j', 'k', 'l', 'z', 'x', 'c', 'v', 'b', 'n', 'm'};

        public IEnumerable<ISentenceItems> GetWordsInQuestionSentence(IText text, int wordCount)
        {
            var questionSentence = text.GetSentences()
                .Where(x => x.GetSentenceItems()
                    .Any(y => y.GetValue()
                    .Contains("?")))
                .ToList();

            return questionSentence
                .SelectMany(x => x.GetSentenceItems())
                .Where(word => word is Word)
                .GroupBy(word => word.GetValue())
                .Where(word => word.Key.Length == wordCount)
                .Select(word => word.First()); 
        }

        public IEnumerable<ISentence> OrderByWords(IText text)
        {
            IText modernText = new Text(text.GetSentences());
            return  modernText.GetSentences()
                .Select(x => new {
                    sentence = x, 
                    sentenceCount = x.GetSentenceItems().Where(y => y is Word).Count()})
                .OrderBy(x => x.sentenceCount)
                .Select(x => x.sentence);
        }
       
        public IEnumerable<string> CreateModelText(IEnumerable<ISentence> sentences)
        {
            var sentenceFirstStateList = new List<string>();
            string sentenceFirstState = "";
            for (int i = 0; i < sentences.ToList().Count; i++)
            {
                for (int j = 0; j < sentences.ToList()[i].GetSentenceItems().Count; j++)
                {
                    if (sentences.ToList()[i].GetSentenceItems()[j].GetType() == typeof(Symbol))
                    {
                        sentenceFirstState += sentences.ToList()[i].GetSentenceItems()[j].GetValue() + " ";
                    }
                    else
                    {
                        sentenceFirstState += " " + sentences.ToList()[i].GetSentenceItems()[j].GetValue();
                    }
                }
                sentenceFirstStateList.Add(sentenceFirstState);
                sentenceFirstState = String.Empty;
            }
            return sentenceFirstStateList;
        }

        public IEnumerable<ISentence> DeleteWordsFromText(IText text, int wordCount)
        {  
            return text.GetSentences()
                .Select(x => new Sentence(x.GetSentenceItems().Where(word => !(word is Word
                        && word.GetValue().Length == wordCount
                        && _consonant.Contains(word.GetValue().First()))).ToList()));    
        }

        public ISentence ReplaceWordsOnSubstring(ISentence sentence, int wordCount, string substring)
        {
            ISentence modernSentence = new Sentence(sentence.GetSentenceItems());
            foreach (var items in modernSentence.GetSentenceItems())
            {
                if (items.GetValue().Length == wordCount)
                {
                    items.Chars = substring;
                }
            }
            return modernSentence;
        }
    }
}
