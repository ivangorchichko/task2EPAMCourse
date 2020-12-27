using System;
using task2EPAMCourse.Contracts;

namespace task2EPAMCourse.Service
{
    public class ParseEnumHelper : IEnumHelper
    {
        public bool TryParseEnum<T>(out T operation) where T : struct, IConvertible
        {
            var operationNumber = Console.ReadLine();
            var isParseCorrected = Enum.TryParse(operationNumber, out operation);
            if (isParseCorrected)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Не удалось считать номер операции");
                return false;
            }
        }
    }
}
