using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.CognitiveServices.Language.TextAnalytics;

namespace ChatWithMe.Bots
{
    public class AzureTextAnalyticService
    {        
        public AzureTextAnalyticService()
        {            
            TextAnalyticServiceCredential credential = new TextAnalyticServiceCredential(key1);
            client = new TextAnalyticsClient(credential)
            {
                Endpoint = endpoint
            }; 

        }
        
        public IList<string> KeyPhraseExtraction(string text) 
        {
            return client.KeyPhrases(text).KeyPhrases;
            
        }

        private readonly TextAnalyticsClient client;
        private static readonly string key1 = "c0a1a3abbd624f00b4eb5c59b83581ad";
        private static readonly string key2 = "93239914c2e94b75a0f651e2cbc3f1e1";
        private static readonly string endpoint = "https://chatwithme.cognitiveservices.azure.com/";
    }
}
