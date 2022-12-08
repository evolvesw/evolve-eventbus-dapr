// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE file in the project root for license information.

namespace Evolve.EventBus.Dapr.Events;

/// <summary>
/// Represents an integration event.
/// </summary>
public record IntegrationEvent
{
    /// <summary>
    /// The unique identifier of the event.
    /// </summary>
    public Guid Id { get; init; } = Guid.NewGuid();

    /// <summary>
    /// The creation date of the event.
    /// </summary>
    public DateTime CreationDate { get; init; } = DateTime.UtcNow;

    /// <summary>
    /// The metadata of the event.
    /// </summary>
    public object Metadata { get; init; } = null!;
}