using System;
using System.Linq;
using task2EPAMCourse.Contracts;
using task2EPAMCourse.FileOperations;
using task2EPAMCourse.Model;
using System.IO;
using System.Collections.Generic;
using task2EPAMCourse.Model.Separators;
using task2EPAMCourse.Service;
using task2EPAMCourse.Enums;

namespace task2EPAMCourse
{
    class Program
    {
        private static readonly IParser _parser = new TextParser();
        private static IList<ISentenceItems> _sentenceItems = new List<ISentenceItems>();
        private static readonly IText _text = new Text();
        private static readonly IUIManager _uIManager = new ConsoleManager();
        private static readonly ITextService _textService = new TextService();
        private static readonly IFileService _fileService = new FileService();
        static void Main(string[] args)
        {
            Start();
        }

        private static void Start()
        {
            while (true)
            {
                _sentenceItems = _parser.ParseText(_sentenceItems);
                _parser.CreateSentence(_text, _sentenceItems);
                _uIManager.ShowOperationsMenu();
                if (!_textService.TryParseEnum<Points>(out var operation))
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
                           _uIManager.PrintModernText(_textService.CreateModelText(_textService.OrderSentenceInText(_text)));
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
                            _textService.SaveObjectModel(_text, _fileService);
                            break;
                        }
                    
                }
            }
        }
    }
}
