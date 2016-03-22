namespace Problem2.ImplementBiDictionary
{
    using System;
    using System.Collections.Generic;

    public class BiDictionary<K1, K2, T>
    {
        private Dictionary<K1, List<T>> valuesByFirstKey
            = new Dictionary<K1, List<T>>();
        private Dictionary<K2, List<T>> valuesBySecondKey =
            new Dictionary<K2, List<T>>();
        private Dictionary<Tuple<K1, K2>, List<T>> valuesByBothKey =
            new Dictionary<Tuple<K1, K2>, List<T>>();

        public void Add(K1 key1, K2 key2, T value)
        {
            if (!valuesByFirstKey.ContainsKey(key1))
            {
                valuesByFirstKey[key1] = new List<T>();
            }
            valuesByFirstKey[key1].Add(value);

            if (!valuesBySecondKey.ContainsKey(key2))
            {
                valuesBySecondKey[key2] = new List<T>();
            }
            valuesBySecondKey[key2].Add(value);

            var bothKeys = new Tuple<K1, K2>(key1, key2);
            if (!valuesByBothKey.ContainsKey(bothKeys))
            {
                valuesByBothKey[bothKeys] = new List<T>();
            }
            valuesByBothKey[bothKeys].Add(value);
        }

        public IEnumerable<T> Find(K1 key1, K2 key2)
        {
            var bothKeys = new Tuple<K1, K2>(key1, key2);
            if (!valuesByBothKey.ContainsKey(bothKeys))
            {
                return new List<T>();
            }

            return valuesByBothKey[bothKeys];
        }

        public IEnumerable<T> FindByKey1(K1 key1)
        {
            if (!valuesByFirstKey.ContainsKey(key1))
            {
                return new List<T>();
            }

            return valuesByFirstKey[key1];
        }

        public IEnumerable<T> FindByKey2(K2 key2)
        {
            if (!valuesBySecondKey.ContainsKey(key2))
            {
                return new List<T>();
            }

            return valuesBySecondKey[key2];
        }

        public bool Remove(K1 key1, K2 key2)
        {
            var bothKeys = new Tuple<K1, K2>(key1, key2);
            if (!valuesByBothKey.ContainsKey(bothKeys))
            {
                return false;
            }

            var values = valuesByBothKey[bothKeys];
            valuesByBothKey.Remove(bothKeys);

            foreach (var value in values)
            {
                if (valuesByFirstKey.ContainsKey(key1))
                {
                    valuesByFirstKey[key1].Remove(value);
                }

                if (valuesBySecondKey.ContainsKey(key2))
                {
                    valuesBySecondKey[key2].Remove(value);
                }
            }

            return true;
        }
    }
}