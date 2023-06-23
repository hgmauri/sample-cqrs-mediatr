using System;
using System.Text.Json.Serialization;
using MediatR;

namespace Sample.MediatR.Application.UseCases.Client.Create;
public class CreateClientCommand : IRequest<Guid>
{
    [JsonIgnore]
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Nome { get; set; }
    public string Email { get; set; }
    public DateTime DataNascimento { get; set; }
}
