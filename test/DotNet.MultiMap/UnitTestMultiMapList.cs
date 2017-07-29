// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using DotNet.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest.MultiMap
{
    [TestClass]
    public class UnitTestMultiMapList
    {
        [TestMethod]
        public void TestMultiMapAdd()
        {
            MultiMapList<string, string> multiMapList = new MultiMapList<string, string>();
            string key = nameof(key);
            string val = nameof(val);
            string val2 = nameof(val2);

            Assert.IsTrue(multiMapList.TryToAddMapping(key, val));
            Assert.IsTrue(multiMapList.TryToAddMapping(key, val));
            Assert.IsTrue(multiMapList.TryToAddMapping(key, val2));
            Assert.IsTrue(multiMapList.TryToAddMapping(key, val2));
            Assert.AreEqual(2, multiMapList.ContainsMapping(key, val));
            Assert.AreEqual(2, multiMapList.ContainsMapping(key, val2));
        }


        [TestMethod]
        public void TestMultiMapRemove()
        {
            MultiMapList<string, string> multiMapList = new MultiMapList<string, string>();
            string key = nameof(key);
            string val = nameof(val);
            string val2 = nameof(val2);

            Assert.IsTrue(multiMapList.TryToAddMapping(key, val));
            Assert.IsTrue(multiMapList.TryToAddMapping(key, val));
            Assert.IsTrue(multiMapList.TryToAddMapping(key, val2));
            Assert.IsTrue(multiMapList.TryToAddMapping(key, val2));
            Assert.AreEqual(2, multiMapList.ContainsMapping(key, val));
            Assert.AreEqual(2, multiMapList.ContainsMapping(key, val2));

            Assert.IsTrue(multiMapList.TryToRemoveMapping(key, val));
            Assert.AreEqual(1, multiMapList.ContainsMapping(key, val));
            Assert.IsTrue(multiMapList.TryToRemoveMapping(key, val));
            Assert.IsFalse(multiMapList.TryToRemoveMapping(key, val));
            Assert.AreEqual(0, multiMapList.ContainsMapping(key, val));
            Assert.AreEqual(1, multiMapList.Keys.Count);
            Assert.AreEqual(1, multiMapList.Values.Count);

            
            Assert.IsTrue(multiMapList.TryToRemoveMapping(key, val2));
            Assert.AreEqual(1, multiMapList.ContainsMapping(key, val2));
            Assert.IsTrue(multiMapList.TryToRemoveMapping(key, val2));
            Assert.IsFalse(multiMapList.TryToRemoveMapping(key, val2));
            Assert.AreEqual(0, multiMapList.ContainsMapping(key, val2));

            Assert.AreEqual(0, multiMapList.Keys.Count);
            Assert.AreEqual(0, multiMapList.Values.Count);

        }
    }
}
