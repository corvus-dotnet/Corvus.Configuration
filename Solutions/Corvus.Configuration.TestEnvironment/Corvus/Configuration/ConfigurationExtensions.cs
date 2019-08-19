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
    /// through a local.settings.json file (for local dev), with optional in-memory fallbacks provided for
    /// individual test configuration.
    /// </remarks>
    public static class ConfigurationExtensions
    {
        /// <summary>
        /// Adds standard configuration tools for the test environment.
        /// </summary>
        /// <param name="builder">The configuration builder to configure.</param>
        /// <param name="fallbackSettings">Any fallback settings to apply if not overridden elsewhere.</param>
        public static void AddTestConfiguration(this IConfigurationBuilder builder, IDictionary<string, string> fallbackSettings = null)
        {
            if (fallbackSettings != null)
            {
                builder.AddInMemoryCollection(fallbackSettings);
            }

            // Add a JSON file if present for local dev
            var codebase = new Uri(typeof(ConfigurationExtensions).Assembly.CodeBase);
            builder.SetBasePath(Path.GetDirectoryName(codebase.LocalPath));
            builder.AddJsonFile("local.settings.json", optional: true, reloadOnChange: true);

            // On the build server, we expect configuration comes through environment variables.
            builder.AddEnvironmentVariables();
        }
    }
}
