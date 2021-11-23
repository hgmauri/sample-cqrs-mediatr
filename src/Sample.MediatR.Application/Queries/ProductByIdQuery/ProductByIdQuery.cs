using MediatR;

namespace Sample.MediatR.Application.Queries.ProductByIdQuery;

public class ProductByIdQuery : IRequest<ProductByIdQueryResult>
{
    public long Id { get; set; }
}
