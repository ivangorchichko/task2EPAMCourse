using task2EPAMCourse.Contracts;
using task2EPAMCourse.FileOperations;
using task2EPAMCourse.Model;
using task2EPAMCourse.Service;
using task2EPAMCourse.Enums;

namespace task2EPAMCourse
{
    class Program
    {
        private static readonly IParser _parser = new TextParser();
        private static readonly IText _text = new Text();
        private static readonly IUIManager _uIManager = new ConsoleManager();
        private static readonly ITextService _textService = new TextService();
        private static readonly IFileService _fileService = new FileService(_textService);
        private static readonly IEnumHelper _enumHelper = new ParseEnumHelper();

        static void Main(string[] args)
        {
            Start();
        }

        private static void Start()
        {
            while (true)
            {  
                _parser.CreateSentence(_text);
                _uIManager.ShowOperationsMenu();
                if (!_enumHelper.TryParseEnum<Points>(out var operation))
                {
                    continue;
                }
                else
                if (operation == 0)
                {
                    break;
                }
                switch (operation)
                {
                    case Points.ViewOrderedSentences:
                        {
                           _uIManager.PrintModernText(_textService.CreateModelText(_textService.OrderByWords(_text)));
                            break;
                        }
                    case Points.PrintWordsFixedLarge:
                        {
                            _uIManager.PrintFindingWords(_textService.GetWordsInQuestionSentence
                                (_text, _uIManager.GetWordsCount()));
                            break;
                        }
                    case Points.DeleteWordsFixedLarge:
                        {
                            _uIManager.PrintModernText(_textService.CreateModelText
                                (_textService.DeleteWordsFromText(_text, _uIManager.GetWordsCount())));
                            break;
                        }
                    case Points.ReplaceWordsFixedLarge:
                        {
                            _uIManager.PrintModernSentence(_textService.ReplaceWordsOnSubstring
                                (_uIManager.GetSelectedSentence(_text), _uIManager.GetWordsCount(), _uIManager.GetSubstring()));
                            break;
                        }
                    case Points.SaveObjectModel:
                        {
                            _fileService.SaveFile(_text);
                            break;
                        }
                }
            }
        }
    }
}
