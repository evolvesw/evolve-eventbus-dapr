// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE file in the project root for license information.

namespace Evolve.EventBus.Dapr;

/// <summary>
/// Represents a Dapr event bus.
/// </summary>
public class DaprEventBus : IEventBus
{
    /// <summary>
    /// The name of the Dapr pub/sub component.
    /// </summary>
    public const string DAPR_PUBSUB_NAME = "evolve-pubsub";

    private readonly DaprClient _dapr;
    private readonly ILogger _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="DaprEventBus"/> class.
    /// </summary>
    /// <param name="dapr">The Dapr client.</param>
    /// <param name="logger">The logger.</param>
    public DaprEventBus(DaprClient dapr, ILogger<DaprEventBus> logger)
    {
        _dapr = dapr;
        _logger = logger;
    }

    /// <inheritdoc/>
    public async Task PublishAsync<TIntegrationEvent>(string topicName, TIntegrationEvent @event, CancellationToken cancellationToken = default) where TIntegrationEvent : IntegrationEvent
    {
        _logger.LogDebug("Publishing event {@Event} to {PubSubName}.{TopicName}", @event, DAPR_PUBSUB_NAME, topicName);

        // We need to make sure that we pass the concrete type to PublishEventAsync,
        // which can be accomplished by casting the event to dynamic. This ensures
        // that all event fields are properly serialized.
        await _dapr.PublishEventAsync(DAPR_PUBSUB_NAME, topicName, (dynamic)@event);
    }
}
