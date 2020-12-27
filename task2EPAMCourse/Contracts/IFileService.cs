using System.IO;

namespace task2EPAMCourse.Contracts
{
    public interface IFileService
    {
        StreamReader GetReader();

        void SaveFile(IText text);

    }
}
