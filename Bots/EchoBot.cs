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
        protected override async Task OnConversationUpdateActivityAsync(ITurnContext<IConversationUpdateActivity> turnContext, CancellationToken cancellationToken)
        {
            await base.OnConversationUpdateActivityAsync(turnContext, cancellationToken);

            if (turnContext.Activity.ChannelId == "directline")
            {
                string welcomeText = "Hello there, welcome to ChatWithMe. How can I help you? 1";
                await turnContext.SendActivityAsync(MessageFactory.Text(welcomeText, welcomeText), cancellationToken);
            }
        }

        protected override async Task OnMessageActivityAsync(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken)
        {
            var text = turnContext.Activity.Text;
            var type = turnContext.Activity.Type;
            TextProcess textProcess = new TextProcess();
            string replyText = textProcess.Run(text);
            await turnContext.SendActivityAsync(MessageFactory.Text(replyText, replyText), cancellationToken);                       
        }

        protected override async Task OnMembersAddedAsync(IList<ChannelAccount> membersAdded, ITurnContext<IConversationUpdateActivity> turnContext, CancellationToken cancellationToken)
        {
            string welcomeText = "Hello there, welcome to ChatWithMe. How can I help you? 2";
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
