using PeikcadLive.VetClinicX.Shared.Domain.Abstractions;

namespace PeikcadLive.VetClinicX.Core.Api.Infrastructure;

public sealed class DomainEventProcessor : BackgroundService
{
    private readonly IServiceProvider services;
    private readonly ILogger<DomainEventProcessor> logger;

    public DomainEventProcessor(IServiceProvider services, ILogger<DomainEventProcessor> logger)
    {
        this.services = services;
        this.logger = logger;
    }
    
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (false == stoppingToken.IsCancellationRequested)
        {
            await HandleEvents(stoppingToken);
            await Task.Delay(100, stoppingToken);
        }
    }

    private async Task HandleEvents(CancellationToken stoppingToken)
    {
        using var scope = services.CreateScope();
        var eventBus = (EventBus)scope.ServiceProvider.GetRequiredService<IDomainEventBus>();
        var nextEvent = eventBus.Pop();

        while (nextEvent is not null)
        {
            var handlers = scope.ServiceProvider
                .GetServices(typeof(IDomainEventHandler<>).MakeGenericType(nextEvent.GetType()));

            foreach (var handler in handlers)
            {
                try
                {
                    var handleAsync = handler!.GetType().GetMethod("Handle");
                    var taskHandle = (Task) handleAsync!.Invoke(handler, new object?[] { nextEvent, stoppingToken })!;

                    await taskHandle.ConfigureAwait(false);
                }
                catch (Exception e)
                {
                    logger.LogError(e, "Failed to execute {Type}", handler?.GetType() ?? typeof(object));
                }
            }

            nextEvent = eventBus.Pop();
        }
    }
}