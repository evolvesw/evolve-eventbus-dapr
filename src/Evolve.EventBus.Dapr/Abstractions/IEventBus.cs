// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE file in the project root for license information.

namespace Evolve.EventBus.Dapr.Abstractions;

/// <summary>
/// Provides an abstraction for publishing integration events.
/// </summary>
public interface IEventBus
{
    /// <summary>
    /// Publishes an integration event.
    /// </summary>
    /// <typeparam name="TIntegrationEvent">The type of the integration event.</typeparam>
    /// <param name="topicName">The name of the topic.</param>
    /// <param name="event">The integration event.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task PublishAsync<TIntegrationEvent>(string topicName, TIntegrationEvent @event, CancellationToken cancellationToken = default)
        where TIntegrationEvent : IntegrationEvent;
}