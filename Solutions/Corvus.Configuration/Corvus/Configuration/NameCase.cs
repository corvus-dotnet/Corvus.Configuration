// <copyright file="NameCase.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Corvus.Configuration;

/// <summary>
/// The various casing options for a name.
/// </summary>
public enum NameCase
{
    /// <summary>
    /// No change from provided name.
    /// </summary>
    NoChange,

    /// <summary>
    /// Convert to lower (invariant culture).
    /// </summary>
    LowerInvariant,

    /// <summary>
    /// Convert to upper (invariant culture).
    /// </summary>
    UpperInvariant,
}