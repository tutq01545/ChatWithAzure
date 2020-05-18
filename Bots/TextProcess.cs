using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatWithMe.Bots
{
    public class TextProcess
    {
        private AzureTextAnalyticService textAnalyticService = new AzureTextAnalyticService();        

        public string Run(string input)
        {
            string replyText = "";
            if (input.Equals("Find something for me"))
            {
                replyText = "OK";
            }
            else if (input.Equals("I want to know the legislation change due to Corona"))
            {                
                var response = textAnalyticService.KeyPhraseExtraction(input);
                foreach (string keyphrase in response)
                {
                    replyText += $"{keyphrase} \n";
                }
            }
            else
            {
                var response = LanguageUnderstandingService.GetIntent(input);
                replyText = $"This is {response.Result}";
            }
            return replyText;
        }
    }
}
