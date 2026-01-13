using Caches.Database;
using Caches.Interfaces;

namespace Caches
{
    public class CacheDB : ICache
    {
        public object Get(string key) { return SqlServerDB.GetCache(key); }

        public void Put(string key, object value) { SqlServerDB.PutCache(key, value?.ToString()); }

        public void Remove(string key) { SqlServerDB.RemoveCache(key); }

        public Dictionary<string, object> GetAll() { return SqlServerDB.GetAll(); }
    }
}