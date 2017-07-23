# DotNet.MultiMap
Multimap of List&lt;T> and HashSet&lt;> grouping.

https://www.nuget.org/packages/DotNet.MultiMap/

Test Examples of using:
``` c#
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

```


``` c#
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
```
