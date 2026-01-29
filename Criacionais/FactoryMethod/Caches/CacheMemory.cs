using Caches.Interfaces;

namespace Caches
{
    /// <summary>
    /// Implementação de <see cref="ICache"/> que utiliza memória interna (Dictionary) como armazenamento.
    /// </summary>
    public class CacheMemory : ICache
    {
        private readonly Dictionary<string, object> cache = new();

        /// <summary>
        /// Recupera um valor do cache pelo identificador.
        /// </summary>
        /// <param name="key">Chave do cache.</param>
        /// <returns>Objeto armazenado ou null se não existir.</returns>
        public object Get(string key)
        {
            cache.TryGetValue(key, out var value);
            return value;
        }

        /// <summary>
        /// Retorna todos os registros do cache.
        /// </summary>
        /// <returns>Dicionário com chave e valor de todos os itens do cache.</returns>
        public Dictionary<string, object> GetAll()
        {
            return cache;
        }

        /// <summary>
        /// Adiciona ou atualiza um valor no cache.
        /// </summary>
        /// <param name="key">Chave do cache.</param>
        /// <param name="value">Valor a ser armazenado.</param>
        public void Put(string key, object value)
        {
            cache[key] = value;
        }

        /// <summary>
        /// Remove um valor do cache pelo identificador.
        /// </summary>
        /// <param name="key">Chave do cache.</param>
        public void Remove(string key)
        {
            cache.Remove(key);
        }
    }
}