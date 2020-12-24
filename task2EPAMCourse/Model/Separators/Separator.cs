using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using task2EPAMCourse.Contracts;

namespace task2EPAMCourse.Model.Separators
{
    abstract class Separator : ISeparator
    {
        public abstract string[] GetSeparator();

    }
}

