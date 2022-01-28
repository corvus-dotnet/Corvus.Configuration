// <copyright file="NameProviderServiceCollectionExtensions.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Microsoft.Extensions.DependencyInjection
{
    using System.Linq;
    using Corvus.Configuration;

    /// <summary>
    /// Service collection extensions to register the default name provider.
    /// </summary>
    public static class NameProviderServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the default implementation of the <see cref="INameProvider"/>.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to which to add the name provider.</param>
        /// <returns>The configured <see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddNameProvider(this IServiceCollection services)
        {
            if (services.Any(s => typeof(INameProvider).IsAssignableFrom(s.ServiceType)))
            {
                // Already configured
                return services;
            }

            services.AddSingleton<INameProvider, NameProvider>();
            return services;
        }
    }
}