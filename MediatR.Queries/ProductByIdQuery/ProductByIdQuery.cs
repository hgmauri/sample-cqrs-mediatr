namespace MediatR.Queries.ProductByIdQuery
{
    public class ProductByIdQuery : IRequest<ProductByIdQueryResult>
    {
        public long Id { get; set; }
    }
}