using Nest;
using Sample.MediatR.Persistence.Elasticsearch;
using System;
using System.Collections.Generic;

namespace Sample.MediatR.Application.Consumers.IndexClientProducts;
public class IndexClient : ElasticBaseIndex
{
    public string Nome { get; set; }
    public string Email { get; set; }
    public DateTime DataNascimento { get; set; }

    [Nested]
    public List<IndexProduct> Produtos { get; set; } = new();
}

public class IndexProduct : ElasticBaseIndex
{
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public int Quantidade { get; set; }
}
