// <copyright file="TestNameProviderServiceCollectionExtensions.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Microsoft.Extensions.DependencyInjection
{
    using Corvus.Configuration;

    /// <summary>
    /// Service collection extensions to register the default name provider.
    /// </summary>
    public static class TestNameProviderServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the default implementation of the <see cref="INameProvider"/>.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to which to add the name provider.</param>
        /// <returns>The configured <see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddTestNameProvider(this IServiceCollection services)
        {
            services.AddSingleton<ITestNameProvider, TestNameProvider>();
            services.AddSingleton<INameProvider>(s => s.GetRequiredService<ITestNameProvider>());
            return services;
        }
    }
}