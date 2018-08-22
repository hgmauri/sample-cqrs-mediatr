namespace MediatR.Commands.ProductSaveCommand
{
    public class ProductSaveCommand : IRequest
    {
        public long Id { get; set; }

        public string Description { get; set; }
    }
}