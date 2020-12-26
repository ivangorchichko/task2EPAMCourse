using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using task2EPAMCourse.Contracts;
using task2EPAMCourse.Model;

namespace task2EPAMCourse.Service
{
    class TextService : ITextService
    {
        public IList<ISentenceItems> GetWordsInQuestionSentence(IText text, int wordCount)
        {
            IList<ISentence> questionSentence = new List<ISentence>();

            foreach(var sentence in text.GetSentences())
            {
                foreach(var sentenceItem in sentence.GetSentenceItems())
                {
                    if(sentenceItem.GetValue().Contains("?"))
                    {
                        questionSentence.Add(sentence);
                    }
                }
            }
            return GetWordsFixedLarge(questionSentence, wordCount);
        }
        private IList<ISentenceItems> GetWordsFixedLarge(IList<ISentence> questionSentence, int wordCount)
        {
            IList<ISentenceItems> words = new List<ISentenceItems>();
            for(int i=0; i<questionSentence.Count; i++)
            {
                for(int j=0; j<questionSentence[i].GetSentenceItems().Count; j++)
                {
                    if(questionSentence[i].GetSentenceItems()[j].GetValue().Length == wordCount 
                        && questionSentence[i].GetSentenceItems()[j].GetType() != typeof(Symbol))
                    {
                        words.Add(questionSentence[i].GetSentenceItems()[j]);
                    }
                }                
            }
            return words;
        }

        public IList<ISentenceItems> OrderSentenceInText(IText text)
        {
            IList<ISentenceItems> orderedText = new List<ISentenceItems>();
            
            for(int i=0; i< text.GetSentences().Count; i++)
            {
               var item = text.GetSentences()[i].GetSentenceItems()[i].GetValue();
            }
                
            return orderedText;
        }

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
        public List<string> CreateModelText(IText text)
        {
            List<string> sentenceFirstStateList = new List<string>();
            string sentenceFirstState = "";
            for (int i = 0; i < text.GetSentences().Count; i++)
            {
                for (int j = 0; j < text.GetSentences()[i].GetSentenceItems().Count; j++)
                {
                    if (text.GetSentences()[i].GetSentenceItems()[j].GetType() == typeof(Symbol))
                    {
                        sentenceFirstState += text.GetSentences()[i].GetSentenceItems()[j].GetValue() + " ";
                    }
                    else
                    {
                        sentenceFirstState += " " + text.GetSentences()[i].GetSentenceItems()[j].GetValue();
                    }
                }
                sentenceFirstStateList.Add(sentenceFirstState);
                sentenceFirstState = "";
            }
            return sentenceFirstStateList;
        }

        public IText DeleteWordsFromText(IText text, int wordCount)
        {
            IText modernText = text;
            for (int i = 0; i < modernText.GetSentences().Count; i++)
            {
                for (int j = 0; j < modernText.GetSentences()[i].GetSentenceItems().Count; j++)
                {
                    if (modernText.GetSentences()[i].GetSentenceItems()[j].GetValue().Length == wordCount 
                        && modernText.GetSentences()[i].GetSentenceItems()[j].GetType() != typeof(Symbol))
                    {
                        modernText.GetSentences()[i].GetSentenceItems().Remove(modernText.GetSentences()[i].GetSentenceItems()[j]);
                        j--;
                    }
                }
            }
            return modernText;
        }

        public ISentence ReplaceWordsOnSubstring(ISentence sentence, int wordCount, string substring)
        {
            ISentence modernSentence = sentence;
            foreach(var items in modernSentence.GetSentenceItems())
            {
                if(items.GetValue().Length == wordCount)
                {
                    items.Chars = substring;
                }
            }
            return modernSentence;
        }

        public void SaveObjectModel(IText text, IFileService fileService)
        {
            fileService.SaveFile(text, this);
        }
    }
}
