namespace Caches.Interfaces
{
    /// <summary>
    /// Interface que define os métodos básicos para um cache genérico.
    /// </summary>
    public interface ICache
    {
        /// <summary>
        /// Recupera um valor do cache pelo identificador.
        /// </summary>
        /// <param name="key">Chave do cache.</param>
        /// <returns>Objeto armazenado ou null se não existir.</returns>
        object Get(string key);

        /// <summary>
        /// Adiciona ou atualiza um valor no cache.
        /// </summary>
        /// <param name="key">Chave do cache.</param>
        /// <param name="value">Valor a ser armazenado.</param>
        void Put(string key, object value);

        /// <summary>
        /// Remove um valor do cache pelo identificador.
        /// </summary>
        /// <param name="key">Chave do cache.</param>
        void Remove(string key);

        /// <summary>
        /// Retorna todos os registros do cache.
        /// </summary>
        /// <returns>Dicionário com chave e valor de todos os itens do cache.</returns>
        Dictionary<string, object> GetAll();
    }
}