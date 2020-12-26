using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace task2EPAMCourse.Contracts
{
    public interface IFileService
    {
        StreamReader GetReader();

        void SaveFile(IText text, ITextService textService);

    }
}
