// <copyright file="TestNameProvider.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Corvus.Configuration
{
    using System;

    /// <summary>
    /// A name provider that supports a unique instance ID for testing.
    /// </summary>
    public class TestNameProvider : NameProvider, ITestNameProvider
    {
        /// <inheritdoc/>
        public Guid TestId { get; private set; }

        /// <inheritdoc/>
        public override string ProvideName(string baseName, int maxLength = 128, NameCase casing = NameCase.NoChange)
        {
            if (baseName is null)
            {
                throw new ArgumentNullException(nameof(baseName));
            }

            return base.ProvideName(this.ExtendBaseForTest(baseName), maxLength, casing);
        }

        /// <inheritdoc/>
        public override string ProvideRepeatableName(string baseName, int maxLength = 128, NameCase casing = NameCase.NoChange)
        {
            if (baseName is null)
            {
                throw new ArgumentNullException(nameof(baseName));
            }

            return base.ProvideRepeatableName(this.ExtendBaseForTest(baseName), maxLength, casing);
        }

        /// <inheritdoc/>
        public void BeginTestSession(Guid testId)
        {
            this.TestId = testId;
        }

        /// <inheritdoc/>
        public void CompleteTestSession()
        {
            this.TestId = default;
            this.Reset();
        }

        private string ExtendBaseForTest(string baseName)
        {
            return baseName + this.TestId.ToString("N");
        }
    }
}
