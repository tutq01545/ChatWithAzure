using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatWithMe.Bots
{
    public abstract class TextAnalyticService
    {        
        public abstract void ProcessData(string input); 
    }
}
