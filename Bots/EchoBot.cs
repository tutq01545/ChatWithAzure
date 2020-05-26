// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
//
// Generated with Bot Builder V4 SDK Template for Visual Studio EchoBot v4.6.2

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;

namespace ChatWithMe.Bots
{
    public class EchoBot : ActivityHandler
    {
        private readonly string welcomeText = "Hello there, welcome to ChatBot about Covid-19 in Germany. How may I help you?";
        private readonly string unclearUserInputResponse = "Your input is unclear for us. Please check it again!";
        private readonly string indexName = "gms_covid19_globaltracker";

        protected override async Task OnEventActivityAsync(ITurnContext<IEventActivity> turnContext, CancellationToken cancellationToken)
        {
            if (turnContext.Activity.Name == "directline/join")
            {                
                await turnContext.SendActivityAsync(welcomeText);
            }
        }

        protected override async Task OnMessageActivityAsync(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken)
        {
            var userInput = turnContext.Activity.Text;
            TextProcessViaNLP textProcess = new TextProcessViaNLP();
            string processedText = textProcess.Run(userInput);
            string returnText = "";
            if (processedText != "")
            {                
                SearchEngine searchEngine = new SearchEngine(indexName);
                returnText = searchEngine.Search(processedText);
            }
            else {
                returnText = unclearUserInputResponse;
            }
            await turnContext.SendActivityAsync(MessageFactory.Text(returnText, returnText), cancellationToken);                       
        }

        protected override async Task OnMembersAddedAsync(IList<ChannelAccount> membersAdded, ITurnContext<IConversationUpdateActivity> turnContext, CancellationToken cancellationToken)
        {
            if (turnContext.Activity.ChannelId != "webchat" && turnContext.Activity.ChannelId != "directline")
            {
                foreach (var member in membersAdded)
                {
                    if (member.Id != turnContext.Activity.Recipient.Id)
                    {
                        await turnContext.SendActivityAsync(MessageFactory.Text(welcomeText, welcomeText), cancellationToken);
                    }
                }
            }
        }


    }
}
