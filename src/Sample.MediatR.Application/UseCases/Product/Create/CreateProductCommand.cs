using System;
using System.Text.Json.Serialization;
using MediatR;

namespace Sample.MediatR.Application.UseCases.Product.Create;
public class CreateProductCommand : IRequest<string>
{
    [JsonIgnore]
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid ClientId { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public int Quantidade { get; set; }
}
