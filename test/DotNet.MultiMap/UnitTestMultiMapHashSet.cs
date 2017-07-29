// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.


using DotNet.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest.MultiMap
{
    [TestClass]
    public class UnitTestMultiMapHashSet
    {
        [TestMethod]
        public void TestMultiMapAdd()
        {
            MultiMapHashSet<string, string> multiMapHashSet = new MultiMapHashSet<string, string>();
            string key = nameof(key);
            string val = nameof(val);
            string val2 = nameof(val2);

            Assert.IsTrue(multiMapHashSet.TryToAddMapping(key, val));
            Assert.IsFalse(multiMapHashSet.TryToAddMapping(key, val));
            Assert.IsTrue(multiMapHashSet.TryToAddMapping(key, val2));
            Assert.IsFalse(multiMapHashSet.TryToAddMapping(key, val2));
            Assert.AreEqual(1, multiMapHashSet.ContainsMapping(key, val));
            Assert.AreEqual(1, multiMapHashSet.ContainsMapping(key, val2));
        }


        [TestMethod]
        public void TestMultiMapRemove()
        {
            MultiMapHashSet<string, string> multiMapHashSet = new MultiMapHashSet<string, string>();
            string key = nameof(key);
            string val = nameof(val);
            string val2 = nameof(val2);

            Assert.IsTrue(multiMapHashSet.TryToAddMapping(key, val));
            Assert.IsTrue(multiMapHashSet.TryToAddMapping(key, val2));
            Assert.AreEqual(1, multiMapHashSet.ContainsMapping(key, val));
            Assert.AreEqual(1, multiMapHashSet.ContainsMapping(key, val2));

            Assert.IsTrue(multiMapHashSet.TryToRemoveMapping(key, val));
            Assert.AreEqual(0, multiMapHashSet.ContainsMapping(key, val));
            Assert.IsFalse(multiMapHashSet.TryToRemoveMapping(key, val));

            Assert.AreEqual(1, multiMapHashSet.Keys.Count);
            Assert.AreEqual(1, multiMapHashSet.Values.Count);

            
            Assert.IsTrue(multiMapHashSet.TryToRemoveMapping(key, val2));
            Assert.IsFalse(multiMapHashSet.TryToRemoveMapping(key, val2));
            Assert.AreEqual(0, multiMapHashSet.ContainsMapping(key, val2));

            Assert.AreEqual(0, multiMapHashSet.Keys.Count);
            Assert.AreEqual(0, multiMapHashSet.Values.Count);

        }
    }
}
