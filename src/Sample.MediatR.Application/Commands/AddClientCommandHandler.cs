using System;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MassTransit;
using MediatR;
using Sample.MediatR.Application.Consumers;
using Sample.MediatR.Persistence.Context;
using Serilog;

namespace Sample.MediatR.Application.Commands;

public class AddClientCommandHandler : IRequestHandler<AddClientCommand, Guid>
{
    private readonly IMapper _mapper;
    private readonly IPublishEndpoint _bus;
    private readonly ClientContext _context;

    public AddClientCommandHandler(IPublishEndpoint publish, ClientContext context, IMapper mapper)
    {
        _bus = publish;
        _context = context;
        _mapper = mapper;
    }

    public async Task<Guid> Handle(AddClientCommand request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<Client>(request);

        await _context.Clients.AddAsync(entity);
        await _context.SaveChangesAsync();
        Log.Information($"Cliente cadastrado com sucesso! Código {entity.Id}");

        await _bus.Publish(new SendEmailEvent { Email = request.Email }, cancellationToken);
        await _bus.Publish(new IndexClientProductEvent { Client = entity }, cancellationToken);

        return await Task.FromResult(request.Id);
    }
}

public class AddClientCommand : IRequest<Guid>
{
    [JsonIgnore]
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Nome { get; set; }
    public string Email { get; set; }
    public DateTime DataNascimento { get; set; }
}
