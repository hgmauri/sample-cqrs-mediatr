using Sample.MediatR.Persistence.Context;

namespace Consumers;
public class IndexClientProductEvent
{
    public Client Client { get; set; }
    public Product Product { get; set; }
}
