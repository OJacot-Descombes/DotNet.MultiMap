// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.


namespace DotNet.Collections.Generic
{
    /// <summary>
    /// The multi map interface.
    /// </summary>
    /// <typeparam name="TKey">Keys can be any non-null object.</typeparam>
    /// <typeparam name="TValue">Values can be any object.</typeparam>
    public interface IMultiMap<TKey, TValue>
    {
        /// <summary>
        /// Add the new value to the map. 
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="val">The value that is linked to the map key.</param>
        /// <returns>true if the value has  been map to the specified key element; otherwise, false.</returns>
        bool TryToAddMapping(TKey key, TValue val);

        /// <summary>
        /// Removes the value from the map. 
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="val">The value that is linked to the map key.</param>
        /// <returns>true if the value has been removed from the map of the specified key element; otherwise, false.</returns>
        bool TryToRemoveMapping(TKey key, TValue val);

        /// <summary>
        /// Checks if the value has a link with the key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="val">The value.</param>
        /// <returns>the number of links (duplicates).</returns>
        int ContainsMapping(TKey key, TValue val);
    }

}
