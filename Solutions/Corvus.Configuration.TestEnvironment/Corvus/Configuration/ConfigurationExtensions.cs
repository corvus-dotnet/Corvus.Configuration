// <copyright file="ConfigurationExtensions.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Corvus.Configuration
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Microsoft.Extensions.Configuration;

    /// <summary>
    /// Extension methods to help with test configuration.
    /// </summary>
    /// <remarks>
    /// By convention, we provide test configuration through EnvironmentVariables (on the build server),
    /// through a local json file (for local dev), with optional in-memory fallbacks provided for
    /// individual test configuration.
    /// </remarks>
    public static class ConfigurationExtensions
    {
        /// <summary>
        /// Adds standard configuration tools for the test environment.
        /// </summary>
        /// <param name="builder">The configuration builder to configure.</param>
        /// <param name="filePath">
        /// The file path of the local json configuration file to use, relative to the current executing assembly. If there
        /// is no local json configuration file, this can be set to null.
        /// </param>
        /// <param name="fallbackSettings">
        /// Any fallback settings to apply if not overridden elsewhere. If there are no fallback settings, this can be
        /// set to null.
        /// </param>
        /// <remarks>
        /// Local json files should contain configuration in either of the following json structures:
        /// 1. Nested properties
        /// {
        ///   "Test": {
        ///    "Property":  "Value"
        ///   }
        /// }
        /// 2. Flattened, colon separated properties
        /// {
        ///  "Test:Property": "Value"
        /// }
        /// .
        /// </remarks>
        public static void AddConfigurationForTest(
            this IConfigurationBuilder builder,
            string? filePath = null,
            IDictionary<string, string?>? fallbackSettings = null)
        {
            if (fallbackSettings != null)
            {
                builder.AddInMemoryCollection(fallbackSettings);
            }

            if (!string.IsNullOrEmpty(filePath))
            {
                // Add a JSON file if present for local dev
                Uri codebase = new(typeof(ConfigurationExtensions).Assembly.CodeBase);
                builder.SetBasePath(Path.GetDirectoryName(codebase.LocalPath));
                builder.AddJsonFile(filePath!, optional: true, reloadOnChange: true);
            }

            // On the build server, we expect configuration comes through environment variables.
            builder.AddEnvironmentVariables();
        }
    }
}