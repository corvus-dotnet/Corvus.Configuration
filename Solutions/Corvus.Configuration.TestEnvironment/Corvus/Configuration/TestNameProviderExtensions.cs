// <copyright file="TestNameProviderExtensions.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Corvus.Configuration
{
    using System;

    /// <summary>
    /// Extension methods for <see cref="ITestNameProvider"/>.
    /// </summary>
    public static class TestNameProviderExtensions
    {
        /// <summary>
        /// Begin a test session with a new <see cref="Guid"/>.
        /// </summary>
        /// <param name="testNameProvider">The <see cref="ITestNameProvider"/> on which to begin the new session.</param>
        public static void BeginTestSesion(this ITestNameProvider testNameProvider)
        {
            testNameProvider.BeginTestSession(Guid.NewGuid());
        }
    }
}
