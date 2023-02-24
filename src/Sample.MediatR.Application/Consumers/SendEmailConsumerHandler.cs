using System;
using System.Threading.Tasks;
using MassTransit;
using MediatR;
using Sample.MediatR.Application.Commands;

namespace Sample.MediatR.Application.Consumers;

public class SendEmailConsumerHandler : IConsumer<SendEmailEvent>
{
    private readonly IMediator _mediator;

    public SendEmailConsumerHandler(IMediator mediator)
    {
        _mediator = mediator;
    }

    public Task Consume(ConsumeContext<SendEmailEvent> context)
    {
        //send email
        _mediator.Send(new ProductSaveCommand { Description = "teste" });
        return Task.CompletedTask;
    }
}

public class SendEmailEvent
{
    public string Email { get; set; }
}

public class SendEmailConsumerHandlerDefinition : ConsumerDefinition<SendEmailConsumerHandler>
{
    protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator, IConsumerConfigurator<SendEmailConsumerHandler> consumerConfigurator)
    {
        consumerConfigurator.UseMessageRetry(retry => retry.Interval(3, TimeSpan.FromSeconds(3)));
    }
}
