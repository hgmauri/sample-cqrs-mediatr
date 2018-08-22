namespace MediatR.Commands.ProductSaveCommandAsync
{
    public class ProductSaveCommandAsync : IRequest
    {
        public long Id { get; set; }

        public string Description { get; set; }
    }
}