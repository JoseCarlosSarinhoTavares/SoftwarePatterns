namespace Caches.Interfaces
{
    public interface ICache
    {
        object Get(string key);
        void Put(string key, object value);
        void Remove(string key);
        Dictionary<string, object> GetAll();
    }
}