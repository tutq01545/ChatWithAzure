using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatWithMe.Bots
{
    public class SearchEngine
    {
        private readonly MyElasticClient client;
        private readonly string noInformationIsFound = "Sorry, our database doesn't have the answer for your question. Please contact HR Service.";
        private readonly string greetingResponse = "Hi";
        private readonly string noneResponse = "Sorry, we can't comprehend your input.";
        private readonly string insultResponse = "Please adjust your input so that we can understand each other better.";
        private readonly string praiseResponse = "Good Bye!";
        private readonly string foundMoreThanOneAnswer = "In our database, we found more than one answer for your question.";

        public SearchEngine(string indexName)
        {
            client = new MyElasticClient(indexName);

        }

        public string Search(string topScoringIntent)
        {
            string response;

            string categorizedSearchInput = CategorizeSearchInput(topScoringIntent);

            if (categorizedSearchInput == "greeting")
            {
                response = greetingResponse;
            }
            else if (categorizedSearchInput == "none")
            {
                response = noneResponse;
            }
            else if (categorizedSearchInput == "insult")
            {
                response = insultResponse;
            }
            else if (categorizedSearchInput == "praise")
            {
                response = praiseResponse;
            }
            else if (categorizedSearchInput.ToLower() == "country leader")
            {
                var topic = "country leader";
                var searchResponse = client.Search("Immigration");
                var firstFoundDocument = searchResponse.Documents.First();
                response = $"Information about topic {topic} is as follow: \n {firstFoundDocument.Information.CountryLeader}";
            }
            else
            {

                var searchResponse = client.Search(categorizedSearchInput);
                var documents = searchResponse.Documents;
                var numberOfDocuments = documents.Count();

                if (numberOfDocuments == 1)
                {
                    var document = documents.First();
                    var topic = document.Details.Topic;
                    var answer = document.Details.Answer;
                    response = $"Information about topic {topic} is as follow: \n {answer}";
                }
                else if (numberOfDocuments == 0)
                {
                    response = noInformationIsFound;
                }
                else
                {
                    var i = 0;
                    response = foundMoreThanOneAnswer + "\n";
                    foreach (var document in documents)
                    {
                        i += 1;
                        var topic = document.Details.Topic;
                        var answer = document.Details.Answer;
                        response = $"Information about topic {topic} is as follow: \n {answer}";
                        if (i == numberOfDocuments)
                        {
                            response += "\n";
                        }
                        else
                        {
                            response += "\n\n";
                        }
                    }
                }
            }
            return response;
        }

        private string CategorizeSearchInput(string topScoringIntent)
        {
            if (topScoringIntent.ToLower() == "greeting")
            {
                return "greeting";
            }
            else if (topScoringIntent.ToLower() == "none")
            {
                return "none";
            }
            else if (topScoringIntent.ToLower() == "insult")
            {
                return "insult";
            }
            else if (topScoringIntent.ToLower() == "praise")
            {
                return "praise";
            }
            else if (topScoringIntent.ToLower() == "compensation and benefits")
            {
                return "Compensation & Benefits";
            }
            else if (topScoringIntent.ToLower() == "filing or payment due date")
            {
                return "Filing / Payment Due Date";
            }
            else if (topScoringIntent.ToLower() == "tax profile or tax residency changes")
            {
                return "Tax Profile / Tax Residency changes";
            }
            else
            {
                return topScoringIntent;
            }

        }
    }
}
