using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatWithMe.Bots
{
    public class TextProcessViaNLP
    {
        private readonly int minNumberOfWordsInInput = 1;
        private readonly int maxNumberOfWordsInInput = 20;
        private readonly int maxLength = 100;        

        public string Run(string input)
        {           

            if (Validate(input) == 1)
            {
                var response = LanguageUnderstandingService.GetIntent(input);
                return response.Result;
            }
            else
            {
                return "";    
            }            
        }

        private int Validate(string input)
        {
            string[] words = input.Split(" ");

            if (words.Length >= minNumberOfWordsInInput && words.Length <= maxNumberOfWordsInInput && input.Length <= maxLength)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
