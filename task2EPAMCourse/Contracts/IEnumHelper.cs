using System;
using System.Collections.Generic;
using System.Text;

namespace task2EPAMCourse.Contracts
{
    public interface IEnumHelper
    {
        bool TryParseEnum<T>(out T operation) where T : struct, IConvertible;
    }
}
