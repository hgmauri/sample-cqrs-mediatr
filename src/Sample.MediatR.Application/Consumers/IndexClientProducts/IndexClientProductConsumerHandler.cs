using System;
using System.Threading.Tasks;
using AutoMapper;
using Consumers;
using MassTransit;
using Sample.MediatR.Persistence.Elasticsearch;

namespace Sample.MediatR.Application.Consumers.IndexClientProducts;

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
            if (client != null)
            {
                client.Produtos.Add(product);
                await _indexClient.InsertAsync(client);
            }
        }
    }
}

public class IndexClientProductConsumerDefinition : ConsumerDefinition<IndexClientProductConsumerHandler>
{
    protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator, IConsumerConfigurator<IndexClientProductConsumerHandler> consumerConfigurator, IRegistrationContext context)
    {
        consumerConfigurator.UseMessageRetry(retry => retry.Interval(3, TimeSpan.FromSeconds(3)));
    }
}
