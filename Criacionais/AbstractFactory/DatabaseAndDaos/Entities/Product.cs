namespace DatabaseAndDaos.Entities
{
    /// <summary>
    /// Representa um produto no sistema.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Identificador do produto.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nome do produto.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Construtor para criar um produto com id e nome.
        /// </summary>
        /// <param name="id">Identificador do produto.</param>
        /// <param name="name">Nome do produto.</param>
        public Product(int id, string name)
        {
            Id = id;
            Name = name;
        }

        /// <summary>
        /// Retorna uma representação em string do produto.
        /// </summary>
        /// <returns>Descrição do produto.</returns>
        public override string ToString()
        {
            return $"Product [Id = {Id}, Nome = {Name}]";
        }
    }
}