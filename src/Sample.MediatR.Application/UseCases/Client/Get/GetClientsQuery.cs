using System.Collections.Generic;
using MediatR;

namespace Sample.MediatR.Application.UseCases.Client.Get;

public class GetClientsQuery : IRequest<List<GetClientsQueryResponse>>
{

}
