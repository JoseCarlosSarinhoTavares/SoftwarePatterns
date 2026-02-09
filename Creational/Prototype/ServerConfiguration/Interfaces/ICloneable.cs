namespace SoftwarePatterns.Creational.Prototype.ServerConfiguration.Interfaces
{
    /// <summary>
    /// Define um contrato para objetos que podem criar uma cópia de si mesmos.
    /// </summary>
    /// <typeparam name="T">
    /// Tipo da própria classe que implementa a interface.
    /// Geralmente utilizado para permitir clonagem fortemente tipada (ex.: <c>MinhaClasse : ICloneable&lt;MinhaClasse&gt;</c>).
    /// </typeparam>
    public interface ICloneable<T>
    {
        /// <summary>
        /// Cria e retorna uma nova instância do objeto atual,
        /// copiando todos os seus valores.
        /// </summary>
        /// <returns>
        /// Uma cópia (clone) da instância atual.
        /// O objeto retornado deve ser independente da instância original.
        /// </returns>
        T Clone();
    }
}