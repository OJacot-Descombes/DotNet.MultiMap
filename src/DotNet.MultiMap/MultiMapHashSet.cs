// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;

namespace DotNet.Collections.Generic
{

    /// <summary>
    /// Generic hash multi map table implementation with mapping to <see cref="HashSet{TValue}"/> collections.
    /// </summary>
    /// <typeparam name="TKey">The key type element.</typeparam>
    /// <typeparam name="TValue">The value type element.</typeparam>
    public class MultiMapHashSet<TKey, TValue> : Dictionary<TKey, HashSet<TValue>>, IMultiMap<TKey, TValue>
    {
        /// <summary>
        /// Initializes a new instance of the DotNet.Collections.Generic.MultiMap`2 class
        /// that is empty, has the default initial capacity, and uses the default equality
        /// comparer for the key type.
        /// </summary>
        public MultiMapHashSet() { }
        /// <summary>
        ///  Initializes a new instance of the DotNet.Collections.Generic.MultiMap`2 class
        ///  that contains elements copied from the specified System.Collections.Generic.IDictionary`2
        ///  and uses the default equality comparer for the key type./ 
        /// </summary>
        /// <param name="dictionary">The System.Collections.Generic.IDictionary`2 whose elements are copied to the
        /// new System.Collections.Generic.Dictionary`2.</param>
        public MultiMapHashSet(IDictionary<TKey, HashSet<TValue>> dictionary) : base(dictionary) { }

        /// <summary>
        /// Initializes a new instance of the DotNet.Collections.Generic.MultiMap`2 class
        /// that is empty, has the initial capacity, and uses the default equality
        /// comparer for the key type.
        /// </summary>
        /// <param name="capacity">The initial number of elements that the DotNet.Collections.Generic.MultiMap`2 can contain.</param>
        public MultiMapHashSet(int capacity) : base(capacity) { }

#if NETCOREAPP2_0
        /// <summary>
        /// Initializes a new instance of the DotNet.Collections.Generic.MultiMap`2 class
        /// and uses the default equality
        /// comparer for the key type.
        /// </summary>
        /// <param name="collection">The System.Collections.Generic.IDictionary`2 whose elements are copied to the
        /// new DotNet.Collections.Generic.MultiMap`2.</param>
        public MultiMapHashSet(IEnumerable<KeyValuePair<TKey, HashSet<TValue>>> collection) : base(collection) { }
#endif

        /// <summary>
        /// Initializes a new instance of the DotNet.Collections.Generic.MultiMap`2 class
        /// that is empty, has the default initial capacity.
        /// </summary>
        /// <param name="comparer">The System.Collections.Generic.IEqualityComparer`1 implementation to use when
        /// comparing keys, or null to use the default System.Collections.Generic.EqualityComparer`1
        /// for the type of the key.</param>
        public MultiMapHashSet(IEqualityComparer<TKey> comparer) : base(comparer) { }

        /// <summary>
        /// Initializes a new instance of the DotNet.Collections.Generic.MultiMap`2 class.
        /// </summary>
        /// <param name="capacity">The initial number of elements that the DotNet.Collections.Generic.MultiMap`2an contain.</param>
        /// <param name="comparer">The System.Collections.Generic.IEqualityComparer`1 implementation to use when
        /// comparing keys, or null to use the default System.Collections.Generic.EqualityComparer`1
        /// for the type of the key.</param>
        public MultiMapHashSet(int capacity, IEqualityComparer<TKey> comparer) : base(capacity, comparer) { }

        /// <summary>
        /// Initializes a new instance of the DotNet.Collections.Generic.MultiMap`2 class.
        /// </summary>
        /// <param name="dictionary">The System.Collections.Generic.IDictionary`2 whose elements are copied to the
        /// new System.Collections.Generic.Dictionary`2.</param>
        /// <param name="comparer"> The System.Collections.Generic.IEqualityComparer`1 implementation to use when
        /// comparing keys, or null to use the default System.Collections.Generic.EqualityComparer`1
        /// for the type of the key.</param>
        public MultiMapHashSet(IDictionary<TKey, HashSet<TValue>> dictionary, IEqualityComparer<TKey> comparer) : base(dictionary, comparer) { }

#if NETCOREAPP2_0
        /// <summary>
        /// Initializes a new instance of the DotNet.Collections.Generic.MultiMap`2 class.
        /// </summary>
        /// <param name="collection">The System.Collections.Generic.IDictionary`2 whose elements are copied to the
        /// new DotNet.Collections.Generic.MultiMap`2.</param>
        /// <param name="comparer"> The System.Collections.Generic.IEqualityComparer`1 implementation to use when
        /// comparing keys, or null to use the default System.Collections.Generic.EqualityComparer`1
        /// for the type of the key.</param>
        public MultiMapHashSet(IEnumerable<KeyValuePair<TKey, HashSet<TValue>>> collection, IEqualityComparer<TKey> comparer) : base(collection, comparer) { }
#endif

        /// <summary>
        /// Add the new value to the map. 
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="val">The value that is linked to the map key.</param>
        /// <returns>true if the value has  been map to the specified key element; otherwise, false.</returns>
        public bool TryToAddMapping(TKey key, TValue val)
        {
            if (TryGetValue(key, out var set))
            {
                return set.Add(val);
            }
            var tmp = new HashSet<TValue> { val };
            Add(key, tmp);
            return true;
        }

        /// <summary>
        /// Removes the value from the map. 
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="val">The value that is linked to the map key.</param>
        /// <returns>true if the value has been removed from the map of the specified key element; otherwise, false.</returns>
        public bool TryToRemoveMapping(TKey key, TValue val)
        {
            bool result = false;
            if (TryGetValue(key, out var set))
            {
                result = set.Remove(val);
                if (set.Count == 0)
                {
                    Remove(key);
                }
            }
            return result;
        }

        /// <summary>
        /// Checks if the value has a link with the key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="val">The value.</param>
        /// <returns>the number of links (duplicates).</returns>
        public int ContainsMapping(TKey key, TValue val)
        {
            if (TryGetValue(key, out var set) && set.Contains(val)) {
                return 1;
            }
            return 0;
        }

    }

}
