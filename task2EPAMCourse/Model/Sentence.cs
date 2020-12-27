using System;
using System.Collections.Generic;
using System.Text;
using task2EPAMCourse.Contracts;

namespace task2EPAMCourse.Model
{
    public class Sentence : ISentence
    {
        public IList<ISentenceItems> SentenceChars { get; } = new List<ISentenceItems>();
        public Sentence() { }
        public Sentence(IList<ISentenceItems> sentence)
        {
            SentenceChars = new List<ISentenceItems>(sentence);
        }

        public void AddItem(ISentenceItems item)
        {
            SentenceChars.Add(item);
        }
        public IList<ISentenceItems> GetSentenceItems()
        {
            return SentenceChars;
        }
        
    }
}