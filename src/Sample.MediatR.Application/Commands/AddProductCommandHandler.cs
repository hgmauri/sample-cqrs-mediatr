using System;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MassTransit;
using MediatR;
using Sample.MediatR.Application.Consumers;
using Sample.MediatR.Application.Notifications;
using Sample.MediatR.Persistence.Context;
using Serilog;

namespace Sample.MediatR.Application.Commands;

public class AddProductCommandHandler : IRequestHandler<AddProductCommand, string>
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;
    private readonly IPublishEndpoint _bus;
    private readonly ClientContext _context;

    public AddProductCommandHandler(IMediator mediator, IPublishEndpoint publish, IMapper mapper, ClientContext context)
    {
        _mediator = mediator;
        _bus = publish;
        _mapper = mapper;
        _context = context;
    }

    public async Task<string> Handle(AddProductCommand request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<Product>(request);

        await _context.Products.AddAsync(entity);
        await _context.SaveChangesAsync();
        Log.Information($"Produto cadastrado com sucesso! Código {entity.Id}");

        await _mediator.Publish(new AddProductNotification { Id = request.Id }, cancellationToken);
        await _mediator.Publish(new SendEmailNotification { Email = "test@mail.com" }, cancellationToken);

        await _bus.Publish(new IndexClientProductEvent { Product = entity }, cancellationToken);

        return await Task.FromResult("Ok");
    }
}

public class AddProductCommand : IRequest<string>
{
    [JsonIgnore]
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid ClientId { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public int Quantidade { get; set; }
}
