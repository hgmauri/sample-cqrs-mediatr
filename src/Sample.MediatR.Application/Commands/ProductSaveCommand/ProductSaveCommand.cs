using System;
using MediatR;

namespace Sample.MediatR.Application.Commands.ProductSaveCommand;

public class ProductSaveCommand : IRequest<string>
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Description { get; set; }
}
