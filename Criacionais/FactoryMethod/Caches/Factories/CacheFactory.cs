using Caches.Interfaces;

namespace Caches.Factories
{
    public class CacheFactory
    {
        /// <summary>
        /// db | mem - Usar no banco ou em memória
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static ICache GetCache(string type)
        {
            return type switch
            {
                "db" => GetCacheDb(),
                "mem" => GetCacheMemory(),
                _ => throw new ArgumentException("Tipo de cache inválido")
            };
        }

        private static ICache GetCacheMemory() { return new CacheMemory(); }

        private static ICache GetCacheDb() {
            return new CacheDB(); // Deveria se um Singleton no mundo real }
        }
    }
}