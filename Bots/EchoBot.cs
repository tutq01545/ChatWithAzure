// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
//
// Generated with Bot Builder V4 SDK Template for Visual Studio EchoBot v4.6.2

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;

namespace ChatWithMe.Bots
{
    public class EchoBot : ActivityHandler
    {
        private static bool start = true;

        protected override async Task OnMessageActivityAsync(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken)
        {
            if (start)
            {
                start = false;
                string welcomeText = "Hello there, welcome to ChatWithMe. How can I help you?";
                await turnContext.SendActivityAsync(MessageFactory.Text(welcomeText, welcomeText), cancellationToken);
            }

            var text = turnContext.Activity.Text;            
            TextProcess textProcess = new TextProcess();
            string replyText = textProcess.Run(text);
            await turnContext.SendActivityAsync(MessageFactory.Text(replyText, replyText), cancellationToken);
        }

        protected override async Task OnMembersAddedAsync(IList<ChannelAccount> membersAdded, ITurnContext<IConversationUpdateActivity> turnContext, CancellationToken cancellationToken)
        {
            if (turnContext.Activity.ChannelId != "webchat" && turnContext.Activity.ChannelId != "directline")
            {
                string welcomeText = "Hello there, welcome to ChatWithMe. How can I help you?";
                foreach (var member in membersAdded)
                {
                    if (member.Id != turnContext.Activity.Recipient.Id && start)
                    {
                        start = false;
                        await turnContext.SendActivityAsync(MessageFactory.Text(welcomeText, welcomeText), cancellationToken);
                    }
                }
            }
        }
    }
}
