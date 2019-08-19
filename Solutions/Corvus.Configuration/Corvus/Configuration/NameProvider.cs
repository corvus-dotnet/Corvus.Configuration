// <copyright file="NameProvider.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Corvus.Configuration
{
    using System.Collections.Concurrent;
    using System.Collections.ObjectModel;
    using System.Linq;

    /// <summary>
    /// A standard implemenation of a name provider.
    /// </summary>
    public class NameProvider : INameProvider
    {
        private readonly ConcurrentDictionary<string, string> nameMap = new ConcurrentDictionary<string, string>();
        private ConcurrentBag<string> names = new ConcurrentBag<string>();

        /// <inheritdoc/>
        public virtual string ProvideName(string baseName, int maxLength = 128, NameCase casing = NameCase.NoChange)
        {
            string name = ProvideNameCore(baseName, maxLength, casing);
            this.names.Add(name);
            return name;
        }

        /// <inheritdoc/>
        public virtual string ProvideRepeatableName(string baseName, int maxLength = 128, NameCase casing = NameCase.NoChange)
        {
            return this.nameMap.GetOrAdd(baseName, b => ProvideNameCore(b, maxLength, casing));
        }

        /// <summary>
        /// Gives a snapshot of the current list of names that have been provided.
        /// </summary>
        /// <returns>A read only collection of names that have been provided through the APIs.</returns>
        protected ReadOnlyCollection<string> GetProvidedNames()
        {
            return this.names.Union(this.nameMap.Keys).Distinct().ToList().AsReadOnly();
        }

        /// <summary>
        /// Resets the name provider.
        /// </summary>
        protected void Reset()
        {
            this.names = new ConcurrentBag<string>();
            this.nameMap.Clear();
        }

        private static string ProvideNameCore(string baseName, int maxLength, NameCase casing)
        {
            return ApplyCasing(baseName.Length < maxLength ? baseName : baseName.Substring(0, maxLength), casing);
        }

        private static string ApplyCasing(string name, NameCase casing)
        {
            switch (casing)
            {
                case NameCase.LowerInvariant:
                    return name.ToLowerInvariant();
                case NameCase.UpperInvariant:
                    return name.ToUpperInvariant();
                default:
                    return name;
            }
        }
    }
}
