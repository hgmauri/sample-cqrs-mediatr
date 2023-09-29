using System;
using System.Threading.Tasks;
using Consumers;
using MassTransit;

namespace Sample.MediatR.Application.Consumers.SendEmail;

public class SendEmailConsumerHandler : IConsumer<SendEmailEvent>
{
    public SendEmailConsumerHandler()
    {
    }

    public Task Consume(ConsumeContext<SendEmailEvent> context)
    {
        //validações

        //pode chamar outros handlers

        //insere registros na base

        //_mediator.Send(new CreateProductCommand { Descricao = "teste" });
        return Task.CompletedTask;
    }
}

public class SendEmailConsumerHandlerDefinition : ConsumerDefinition<SendEmailConsumerHandler>
{
    protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator, IConsumerConfigurator<SendEmailConsumerHandler> consumerConfigurator, IRegistrationContext context)
    {
        consumerConfigurator.UseMessageRetry(retry => retry.Interval(3, TimeSpan.FromSeconds(3)));
    }
}
