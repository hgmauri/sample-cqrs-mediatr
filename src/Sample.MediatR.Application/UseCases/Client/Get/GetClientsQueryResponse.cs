using System;

namespace Sample.MediatR.Application.UseCases.Client.Get;
public class GetClientsQueryResponse
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public DateTime DataNascimento { get; set; }
}
