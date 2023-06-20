using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Sample.MediatR.Persistence.Context;
using Serilog;

namespace Sample.MediatR.Application.Queries;

public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, List<GetProductsQueryResult>>
{
    private readonly IMapper _mapper;
    private readonly ClientContext _context;

    public GetProductsQueryHandler(IMapper mapper, ClientContext context)
    {
        _mapper = mapper;
        _context = context;
    }


    public async Task<List<GetProductsQueryResult>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        var clients = await _context.Products.ToListAsync();

        var result = _mapper.Map<List<GetProductsQueryResult>>(clients);

        return result;
    }
}

public class GetProductsQuery : IRequest<List<GetProductsQueryResult>> { }

public class GetProductsQueryResult
{
    public long Id { get; set; }
    public string Description { get; set; }
}
