using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using task2EPAMCourse.Contracts;

namespace task2EPAMCourse.FileOperations
{
    public class FileService : IFileService
    {
        private const string _filePath = @"Data\ProgramText.txt";

        public StreamReader GetReader()
        {
            StreamReader streamReader = new StreamReader(_filePath);
            return streamReader;
        }
    }
}
