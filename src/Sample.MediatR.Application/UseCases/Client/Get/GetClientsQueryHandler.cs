using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Sample.MediatR.Persistence.Context;

namespace Sample.MediatR.Application.UseCases.Client.Get;

public class GetClientsQueryHandler : IRequestHandler<GetClientsQuery, List<GetClientsQueryResponse>>
{
    private readonly IMapper _mapper;
    private readonly ClientContext _context;

    public GetClientsQueryHandler(IMapper mapper, ClientContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<List<GetClientsQueryResponse>> Handle(GetClientsQuery request, CancellationToken cancellationToken)
    {
        var clients = await _context.Clients.ToListAsync();

        var result = _mapper.Map<List<GetClientsQueryResponse>>(clients);

        return result;
    }
}
