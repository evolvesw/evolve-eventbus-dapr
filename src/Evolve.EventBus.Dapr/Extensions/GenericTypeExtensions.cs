// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE file in the project root for license information.

namespace Evolve.EventBus.Dapr.Extensions;

/// <summary>
/// Provides extension methods for generic types.
/// </summary>
public static class GenericTypeExtensions
{
    /// <summary>
    /// Gets the name of the generic type.
    /// </summary>
    /// <param name="type">The type.</param>
    /// <returns>The name of the generic type.</returns>
    public static string GetGenericTypeName(this Type type)
    {
        if (!type.IsGenericType)
        {
            var genericTypes = string.Join(",", type.GetGenericArguments().Select(t => t.Name).ToArray());
            return $"{type.Name.Remove(type.Name.IndexOf('`'))}<{genericTypes}>";
        }
        else
        {
            return type.Name;
        }
    }

    /// <summary>
    /// Gets the name of the generic type.
    /// </summary>
    /// <param name="obj">The object.</param>
    /// <returns>The name of the generic type.</returns>
    public static string GetGenericTypeName(this object obj)
        => obj.GetType().GetGenericTypeName();
}