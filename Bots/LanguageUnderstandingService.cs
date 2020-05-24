using System;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ChatWithMe
{
        public class LanguageUnderstandingService
        {
            public static async Task<string> GetIntent(string utterance)
            { 
                var client = new HttpClient(); 
                var endpointUri = String.Format("https://{0}/luis/v2.0/apps/{1}?verbose=true&timezoneOffset=0&subscription-key={2}&q={3}", endpoint, appId, key, utterance); 
                var response = await client.GetAsync(endpointUri); 
                var strResponseContent = await response.Content.ReadAsStringAsync();
                JObject jsonResponseContent = JObject.Parse(strResponseContent); 
                string result = $"{jsonResponseContent["topScoringIntent"]["intent"]}";
                return result; 
            }
            private static readonly string endpoint = "westus.api.cognitive.microsoft.com"; 
            private static readonly object appId = "2991e260-a4f8-4259-8a30-8ba338205d5c"; 
            private static readonly object key = "7cba6c96a15b4addabf2cfb0f3d95ff0";
        }
}
