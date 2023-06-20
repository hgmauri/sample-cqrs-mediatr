using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MassTransit;
using Nest;
using Sample.MediatR.Persistence.Context;
using Sample.MediatR.Persistence.Elasticsearch;

namespace Sample.MediatR.Application.Consumers;

public class IndexClientProductConsumerHandler : IConsumer<IndexClientProductEvent>
{
    private readonly IMapper _mapper;
    private readonly IBaseElasticRepository<IndexClient> _indexClient;

    public IndexClientProductConsumerHandler(IMapper mapper, IBaseElasticRepository<IndexClient> indexClient)
    {
        _mapper = mapper;
        _indexClient = indexClient;
    }

    public async Task Consume(ConsumeContext<IndexClientProductEvent> context)
    {
        await _indexClient.CreateIndexAsync();

        if (context.Message.Client != null)
        {
            var client = _mapper.Map<IndexClient>(context.Message.Client);
            await _indexClient.InsertAsync(client);
        }
        else
        {
            var product = _mapper.Map<IndexProduct>(context.Message.Product);
            var client = await _indexClient.GetAsync(context.Message.Product.ClientId.ToString());
            client.Produtos.Add(product);
            await _indexClient.InsertAsync(client);
        }
    }
}

public class IndexClientProductConsumerDefinition : ConsumerDefinition<IndexClientProductConsumerHandler>
{
    protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator, IConsumerConfigurator<IndexClientProductConsumerHandler> consumerConfigurator)
    {
        consumerConfigurator.UseMessageRetry(retry => retry.Interval(3, TimeSpan.FromSeconds(3)));
    }
}

public class IndexClientProductEvent
{
    public Client Client { get; set; }
    public Product Product { get; set; }
}

public class IndexClient : ElasticBaseIndex
{
    public string Nome { get; set; }
    public string Email { get; set; }
    public DateTime DataNascimento { get; set; }

    [Nested]
    public List<IndexProduct> Produtos { get; set; }  = new();
}

public class IndexProduct : ElasticBaseIndex
{
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public int Quantidade { get; set; }
}
