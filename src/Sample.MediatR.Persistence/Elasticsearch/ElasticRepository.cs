using Microsoft.Extensions.Configuration;
using Nest;

namespace Sample.MediatR.Persistence.Elasticsearch;
public class ElasticRepository<T> : ElasticBaseRepository<T>, IBaseElasticRepository<T> where T : ElasticBaseIndex
{
    public override string IndexName { get; }

    public ElasticRepository(IElasticClient elasticClient)
        : base(elasticClient)
    {
        IndexName = typeof(T).Name.ToLower();
    }
}
