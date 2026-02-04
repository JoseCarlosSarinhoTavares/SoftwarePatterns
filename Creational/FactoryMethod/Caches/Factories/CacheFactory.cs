using SoftwarePatterns.Creational.FactoryMethod.Caches.Implementations;
using SoftwarePatterns.Creational.FactoryMethod.Caches.Interfaces;

namespace SoftwarePatterns.Creational.FactoryMethod.Caches.Factories
{
    /// <summary>
    /// Fábrica responsável por criar instâncias de cache.
    /// Permite escolher entre cache em memória ou cache persistente no banco.
    /// </summary>
    public class CacheFactory
    {
        /// <summary>
        /// Cria uma instância de cache baseada no tipo informado.
        /// </summary>
        /// <param name="type">
        /// "db"  - cache persistente no banco de dados  
        /// "mem" - cache em memória
        /// </param>
        /// <returns>Instância de <see cref="ICache"/> correspondente ao tipo.</returns>
        /// <exception cref="ArgumentException">Lançada quando o tipo informado é inválido.</exception>
        public static ICache GetCache(string type)
        {
            return type switch
            {
                "db" => GetDatabaseCache(),
                "mem" => GetMemoryCache(),
                _ => throw new ArgumentException("Tipo de cache inválido")
            };
        }

        /// <summary>
        /// Cria um cache em memória.
        /// </summary>
        /// <returns>Instância de <see cref="CacheMemory"/>.</returns>
        private static ICache GetMemoryCache() { return new MemoryCache(); }

        /// <summary>
        /// Cria um cache persistente no banco.
        /// </summary>
        /// <returns>Instância de <see cref="DatabaseCache"/>.</returns>
        /// <remarks>Em um cenário real, este método deveria retornar um Singleton.</remarks>
        private static ICache GetDatabaseCache() { return new DatabaseCache(); }
    }
}