using System;
using System.Collections.Generic;
using System.Text;
using task2EPAMCourse.Contracts;

namespace task2EPAMCourse.Model
{
    internal class Text
    {
        public ICollection<ISentance> Sentances { get; }

        public Text()
        {
            Sentances = new List<ISentance>();
        }
    }
}
