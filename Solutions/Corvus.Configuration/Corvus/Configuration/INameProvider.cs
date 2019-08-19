// <copyright file="INameProvider.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Corvus.Configuration
{
    /// <summary>
    /// Provides names for configuration that can be used by configurable components.
    /// </summary>
    public interface INameProvider
    {
        /// <summary>
        /// Provides a name from a base, conforming to various constraints.
        /// </summary>
        /// <param name="baseName">The base name.</param>
        /// <param name="maxLength">The maximum length of the provided name.</param>
        /// <param name="casing">The target casing for the name.</param>
        /// <returns>A name conforming to the constraints.</returns>
        /// <remarks>Note that this name may be a one-off/unique name for the given base. For an implementation which guarantees to supply the same
        /// name for a given base, <see cref="ProvideRepeatableName(string, int, NameCase)"/>.</remarks>
        string ProvideName(string baseName, int maxLength = 128, NameCase casing = NameCase.NoChange);

        /// <summary>
        /// Provides a name from a base, conforming to various constraints.
        /// </summary>
        /// <param name="baseName">The base name.</param>
        /// <param name="maxLength">The maximum length of the provided name.</param>
        /// <param name="casing">The target casing for the name.</param>
        /// <returns>A name conforming to the constraints.</returns>
        /// <remarks>For a given base name, this method will provide the same name each time.</remarks>
        string ProvideRepeatableName(string baseName, int maxLength = 128, NameCase casing = NameCase.NoChange);
    }
}
