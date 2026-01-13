using Caches.Interfaces;

namespace Caches
{
    public class CacheMemory : ICache
    {
        private readonly Dictionary<string, object> cache = new();

        public object Get(string key)
        {
            cache.TryGetValue(key, out var value);
            return value;
        }

        public Dictionary<string, object> GetAll()
        {
            return cache;
        }

        public void Put(string key, object value)
        {
            cache[key] = value;
        }

        public void Remove(string key)
        {
            cache.Remove(key);
        }
    }
}