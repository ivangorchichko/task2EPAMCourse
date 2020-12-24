using System;
using System.Linq;
using task2EPAMCourse.Contracts;
using task2EPAMCourse.FileOperations;
using task2EPAMCourse.Model;
using System.IO;
using System.Collections.Generic;
using task2EPAMCourse.Model.Separators;
using task2EPAMCourse.Service;

namespace task2EPAMCourse
{
    class Program
    {
        static void Main(string[] args)
        {
            IParser parser = new TextParser();
            IList<ISentenceItems> sentenceItems = new List<ISentenceItems>();
            IText text = new Text();
            sentenceItems = parser.ParseText(sentenceItems);
            parser.CreateSentence(text, sentenceItems);
            
        }
    }
}
