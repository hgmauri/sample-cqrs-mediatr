namespace MediatR.Queries.ProductByIdQueryAsync
{
    public class ProductByIdQueryAsync : IRequest<ProductByIdQueryAsyncResult>
    {
        public long Id { get; set; }
    }
}