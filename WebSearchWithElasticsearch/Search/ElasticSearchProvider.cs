using System;
using ElasticsearchCRUD;
using ElasticsearchCRUD.Model.SearchModel;
using ElasticsearchCRUD.Model.SearchModel.Queries;
using WebSearchWithElasticsearch.Models;

namespace WebSearchWithElasticsearch.Search
{
    public class ElasticSearchProvider : ISearchProvider,
                                        IDisposable
    {

        public ElasticSearchProvider()
        {
            _context = new ElasticsearchContext(ConnectionString, _elasticSearchMappingResolver);
        }



        public IEnumerable<Skill> QueryString(string term)
        {
            var results = _context.Search<Skill>(BuildQueryStringSearch(term));
            return results.PayloadResult.Hits.HitsResult.Select(t => t.Source);
        }

        private ElasticsearchCRUD.Model.SearchModel.Search BuildQueryStringSearch(string term)
        {
            var names = "";
            if (term != null)
            {
                names = term.Replace("+", " OR *");
            }
            var search = new ElasticsearchCRUD.Model.SearchModel.Search
            {
                Query = new Query(new QueryStringQuery(names + "*"))
            };
            return search;
        }
        private readonly ElasticsearchContext _context;
        private readonly IElasticsearchMappingResolver _elasticSearchMappingResolver = new ElasticsearchMappingResolver();
        private const string ConnectionString = "http://localhost:9200";
    }
}
