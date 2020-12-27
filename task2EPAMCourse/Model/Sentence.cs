using System;
using System.Collections.Generic;
using System.Text;
using task2EPAMCourse.Contracts;

namespace task2EPAMCourse.Model
{
    class Sentence : ISentence
    {
        public IList<ISentenceItems> SentenceItems { get; } = new List<ISentenceItems>();
        public Sentence()
        {

        }
        public void AddItem(ISentenceItems item)
        {
            SentenceItems.Add(item);
        }
        public IList<ISentenceItems> GetSentenceItems()
        {
            return SentenceItems;
        }
    }
}