namespace DatabaseAndDaos.Entities
{
    /// <summary>
    /// Representa um cliente no sistema.
    /// </summary>
    public class Client
    {
        /// <summary>
        /// Identificador do cliente.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nome do cliente.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Construtor para criar um cliente com id e nome.
        /// </summary>
        /// <param name="id">Identificador do cliente.</param>
        /// <param name="name">Nome do cliente.</param>
        public Client(int id, string name)
        {
            Id = id;
            Name = name;
        }

        /// <summary>
        /// Retorna uma representação em string do cliente.
        /// </summary>
        /// <returns>Descrição do cliente.</returns>
        public override string ToString()
        {
            return $"Cliente [Id = {Id}, Nome = {Name}]";
        }
    }
}