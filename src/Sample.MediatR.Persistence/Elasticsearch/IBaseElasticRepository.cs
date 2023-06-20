
namespace Sample.MediatR.Persistence.Elasticsearch;
public interface IBaseElasticRepository<T> : IElasticBaseRepository<T> where T : class
{
}
