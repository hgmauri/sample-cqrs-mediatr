using System.Collections.Generic;
using MediatR;

namespace Sample.MediatR.Application.UseCases.Product.Get;

public class GetProductsQuery : IRequest<List<GetProductsQueryResponse>>
{

}
