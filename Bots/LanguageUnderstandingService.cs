using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Web;
using System.Threading.Tasks;

namespace ChatWithMe.Bots
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
        private static readonly object appId = "1e28b3f3-3114-4697-9db6-7831ccc0cdfb";
        private static readonly object key = "7cba6c96a15b4addabf2cfb0f3d95ff0";
    }
}
