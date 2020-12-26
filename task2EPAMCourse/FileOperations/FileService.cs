using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using task2EPAMCourse.Contracts;

namespace task2EPAMCourse.FileOperations
{
    public class FileService : IFileService
    {
        private const string _openFilePath = @"Data\ProgramText.txt";
        private const string _saveFilePath = @"Data\SaveProgramText.txt";

        public StreamReader GetReader()
        {
            StreamReader streamReader = new StreamReader(_openFilePath);
            return streamReader;
        }

        public void SaveFile(IText text, ITextService textService)
        {
            using(StreamWriter streamWriter = new StreamWriter(_saveFilePath, false))
            {
                var saveText = textService.CreateModelText(text);
                foreach (var senteces in saveText)
                {
                    streamWriter.Write(senteces + "\n");
                }
            }
        }
    }
}
