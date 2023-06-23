using MediatR;
using System;

namespace Sample.MediatR.Application.UseCases.Product.CreateNotification;
public class CreateProductNotification : INotification
{
    public Guid Id { get; set; }
}
