namespace Problem3.CollectionOfProducts
{
    using System.Collections.Generic;
    using System.Linq;
    
    public static class DictionaryExtension
    {
        public static void EnsureKeyExists<TKey, TValue>(
            this Dictionary<TKey, TValue> dict, 
            TKey key)
            where TValue : new()
        {
            if (!dict.ContainsKey(key))
            {
                dict.Add(key, new TValue());
            }
        }

        public static void AppendValueToKey<TKey, TCollection, TValue>(
        this IDictionary<TKey, TCollection> dict, TKey key, TValue value)
        where TCollection : ICollection<TValue>, new()
        {
            TCollection collection;
            if (!dict.TryGetValue(key, out collection))
            {
                collection = new TCollection();
                dict.Add(key, collection);
            }
            collection.Add(value);
        }

        public static IEnumerable<TValue> GetValuesForKey<TKey, TValue>(
        this IDictionary<TKey, SortedSet<TValue>> dict, TKey key)
        {
            SortedSet<TValue> collection;
            if (dict.TryGetValue(key, out collection))
            {
                return collection;
            }
            return Enumerable.Empty<TValue>();
        }
    }
}