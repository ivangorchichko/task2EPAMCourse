using System;
using System.Collections.Generic;
using System.Text;
using task2EPAMCourse.Contracts;

namespace task2EPAMCourse.Model
{
    class Sentence : ISentence
    {
        //public IList<Word> Words { get; } = new List<Word>();

        //public IList<Symbol> Separators { get; } = new List<Symbol>();
        //  public IList<ISentenceItems> sentence { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public IList<ISentenceItems> SentenceItems { get; } = new List<ISentenceItems>();
        public Sentence()
        {

        }


        public void AddItem(ISentenceItems item)
        {
            SentenceItems.Add(item);
        }
        //public void AddItem(Word word)
        //{
        //    Words.Add(word);
        //}
        //public void AddItem(Symbol separator)
        //{
        //    Separators.Add(separator);
        //}
    }
}