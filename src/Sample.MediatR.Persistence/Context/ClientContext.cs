using Microsoft.EntityFrameworkCore;

namespace Sample.MediatR.Persistence.Context;

public class ClientContext : DbContext
{
    protected ClientContext(DbContextOptions options)
        : base(options) { }

    public ClientContext(DbContextOptions<ClientContext> options)
        : this((DbContextOptions)options)
    {
    }

    public DbSet<Client> Clients { get; set; }
    public DbSet<Product> Products { get; set; }
}

public class Client 
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Nome { get; set; }
    public string Email { get; set; }
    public DateTime DataNascimento { get; set; }
}

public class Product 
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid ClientId { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public int Quantidade { get; set; }
}
