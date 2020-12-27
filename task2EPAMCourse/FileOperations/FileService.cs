using Newtonsoft.Json;
using System.IO;
using task2EPAMCourse.Contracts;
using System.Configuration;
using System.Text;

namespace task2EPAMCourse.FileOperations
{
    public class FileService : IFileService
    {
        private static readonly string _openFilePath = ConfigurationManager.AppSettings.Get("OpenFile");
        private static readonly string _saveFilePath = ConfigurationManager.AppSettings.Get("SaveFile");
        private readonly ITextService _textService;

        public FileService()
        {

        }
        
        public FileService(ITextService textService)
        {
            _textService = textService;
        }

        public StreamReader GetReader()
        {
            StreamReader streamReader = new StreamReader(_openFilePath);
            return streamReader;
        }

        public void SaveFile(IText text)
        {
            var resultString = JsonConvert.SerializeObject(text);
            using var filename = new FileStream(_saveFilePath, FileMode.Create);
            using var writer = new StreamWriter(filename, Encoding.Default);
            writer.Write(resultString);
        }
    }
}
