using System;
using System.Collections.Generic;
using System.Text;
using task2EPAMCourse.Contracts;

namespace task2EPAMCourse.Model
{
    public class Text : IText
    {
        public IList<ISentence> Sentences { get; }

        public Text()
        {
            Sentences = new List<ISentence>();
        }

        public Text(IList<ISentence> text)
        {
            Sentences = new List<ISentence>(text);
        }

        public void Add(ISentence sentence)
        {
            Sentences.Add(sentence);
        }

        public IList<ISentence> GetSentences()
        {
            return Sentences;
        }
    }
}
