using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSearchWithElasticsearch.Models;

namespace WebSearchWithElasticsearch.Search
{
    public interface ISearchProvider
    {
        IEnumerable<Skill> QueryString(string term);

        void AddUpdateEntity(Skill skill);

        void UpdateSkill(long updateId, string updateName, string updateDescription);
        
        void DeleteSkill(long updateId);
    }
}
