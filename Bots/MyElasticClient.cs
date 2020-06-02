using Nest;
using System;

namespace ChatWithMe
{
    
    public class MyElasticClient : ElasticClient
    { 
        static private Uri uri = new Uri("http://40.118.23.38:9200/");
        static private string country = "Germany";
        public string indexName {get;}   
        public MyElasticClient(string indexName) : base(new ConnectionSettings(uri).DefaultIndex(indexName))
        {

        }
        public ISearchResponse<GMS_Covid_Global_Tracker> Search(string topScoringIntent)
        {
            var searchResponse = this.Search<GMS_Covid_Global_Tracker>(s => s                
                .Query(q=>q             
                
                    .Bool(b => b
                        .Must(mu => mu
                            .Term(term => term
                                    .Field(f => f.Information.Country.Suffix("keyword"))
                                    .Value(country))
                            , mu => mu
                                .Term(term => term
                                    .Field(f => f.Details.Topic.Suffix("keyword"))
                                    .Value(topScoringIntent)
                            )
                        )
                        
                    )                           
                )
            );
            return searchResponse;
        }
    }
    
}
