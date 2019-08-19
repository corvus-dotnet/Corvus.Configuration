// <copyright file="ITestNameProvider.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Corvus.Configuration
{
    using System;

    /// <summary>
    /// Adds test support for the provided names.
    /// </summary>
    public interface ITestNameProvider : INameProvider
    {
        /// <summary>
        /// Gets the ID for the currently active test.
        /// </summary>
        Guid TestId { get; }

        /// <summary>
        /// Starts a test session for the test with the specified ID.
        /// </summary>
        /// <param name="testId">The unique ID of the test.</param>
        void BeginTestSession(Guid testId);

        /// <summary>
        /// Completes the current test session.
        /// </summary>
        void CompleteTestSession();
    }
}
