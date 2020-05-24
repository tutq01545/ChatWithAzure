using System.Collections.Generic;

namespace ChatWithMe
{
    public class GMS_Covid_Global_Tracker
    {
        public Information Information {get; set;}
        public Details Details {get; set;}
        public GMS_Covid_Global_Tracker(Information information, Details details)
        {
            this.Information = information;
            this.Details = details;
        }
    }
    
    public class Information
    {
        public List<string> Category {get; set;}
        public string TimeOfEntry {get; set;}
        public string Country {get; set;}

        public string Sources {get; set;}
        public string Notes {get; set;}
        public string ConfirmedBy {get; set;}
        public string InCountryKnowledgeManager {get; set;}
        public string CountryLeader {get; set;}
        public Information(List<string> categoryList, string date, string country, string sources, string notes, 
                            string confirmedBy, string knowledgeManager, string countryLeader)
        {
            this.Category = categoryList;
            this.TimeOfEntry = date;
            this.Country = country;
            this.Sources = sources;
            this.Notes = notes;
            this.ConfirmedBy = confirmedBy;
            this.InCountryKnowledgeManager = knowledgeManager;
            this.CountryLeader = countryLeader;
        }
        
    }

    public class Details
    {
        public string Topic {get; set;}
        public string Answer {get; set;}
        public Details(string topic, string content)
        {
            this.Topic = topic;
            this.Answer = content;
        }
    }
}