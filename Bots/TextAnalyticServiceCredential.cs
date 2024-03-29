﻿using Microsoft.Rest;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ChatWithMe.Bots
{
    public class TextAnalyticServiceCredential : ServiceClientCredentials
    {
        private readonly string apiKey;

        public TextAnalyticServiceCredential(string apiKey)
        {
            this.apiKey = apiKey;
        }

        public override Task ProcessHttpRequestAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }
            request.Headers.Add("Ocp-Apim-Subscription-Key", this.apiKey);
            return base.ProcessHttpRequestAsync(request, cancellationToken);
        }
    }
}
