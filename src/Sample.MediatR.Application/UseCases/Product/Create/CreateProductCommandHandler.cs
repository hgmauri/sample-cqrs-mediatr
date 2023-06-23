using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Consumers;
using MassTransit;
using MediatR;
using Sample.MediatR.Application.UseCases.Email.Send;
using Sample.MediatR.Application.UseCases.Product.CreateNotification;
using Sample.MediatR.Persistence.Context;
using Serilog;

namespace Sample.MediatR.Application.UseCases.Product.Create;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, string>
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;
    private readonly IPublishEndpoint _bus;
    private readonly ClientContext _context;

    public CreateProductCommandHandler(IMediator mediator, IPublishEndpoint publish, IMapper mapper, ClientContext context)
    {
        _mediator = mediator;
        _bus = publish;
        _mapper = mapper;
        _context = context;
    }

    public async Task<string> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<Persistence.Context.Product>(request);

        await _context.Products.AddAsync(entity);
        await _context.SaveChangesAsync();
        Log.Information($"Produto cadastrado com sucesso! Código {entity.Id}");

        await _mediator.Publish(new CreateProductNotification { Id = request.Id }, cancellationToken);
        await _mediator.Publish(new SendEmailNotification { Email = "test@mail.com" }, cancellationToken);

        await _bus.Publish(new IndexClientProductEvent { Product = entity }, cancellationToken);

        return await Task.FromResult("Ok");
    }
}
