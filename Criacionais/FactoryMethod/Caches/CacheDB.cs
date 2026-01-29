using Caches.Database;
using Caches.Interfaces;

namespace Caches
{
    /// <summary>
    /// Implementação de <see cref="ICache"/> que utiliza o banco SQL Server como armazenamento.
    /// </summary>
    public class CacheDB : ICache
    {
        /// <summary>
        /// Recupera um valor do cache pelo identificador.
        /// </summary>
        /// <param name="key">Chave do cache.</param>
        /// <returns>Objeto armazenado ou null se não existir.</returns>
        public object Get(string key)
        {
            return SqlServerDB.GetCache(key);
        }

        /// <summary>
        /// Adiciona ou atualiza um valor no cache.
        /// </summary>
        /// <param name="key">Chave do cache.</param>
        /// <param name="value">Valor a ser armazenado.</param>
        public void Put(string key, object value)
        {
            SqlServerDB.PutCache(key, value?.ToString());
        }

        /// <summary>
        /// Remove um valor do cache pelo identificador.
        /// </summary>
        /// <param name="key">Chave do cache.</param>
        public void Remove(string key)
        {
            SqlServerDB.RemoveCache(key);
        }

        /// <summary>
        /// Retorna todos os registros do cache.
        /// </summary>
        /// <returns>Dicionário com chave e valor de todos os itens do cache.</returns>
        public Dictionary<string, object> GetAll()
        {
            return SqlServerDB.GetAll();
        }
    }
}