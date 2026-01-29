using DatabaseAndDaos.Entities;
using System.Data.Common;

namespace DatabaseAndDaos.Daos
{
    /// <summary>
    /// DAO abstrato para produtos.
    /// Fornece métodos básicos para obter e inserir produtos no banco de dados.
    /// </summary>
    public abstract class ProductsDao
    {
        private readonly DbConnection connection;

        /// <summary>
        /// Construtor que recebe a conexão com o banco de dados.
        /// </summary>
        /// <param name="connection">Conexão com o banco de dados.</param>
        protected ProductsDao(DbConnection connection)
        {
            this.connection = connection;
        }

        /// <summary>
        /// Retorna todos os produtos do banco de dados.
        /// </summary>
        /// <returns>Lista de produtos.</returns>
        public List<Product> GetAllProducts()
        {
            var products = new List<Product>();

            using var command = connection.CreateCommand();
            command.CommandText = "SELECT Id, Name FROM Products";

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                products.Add(new Product(
                    reader.GetInt32(0),
                    reader.GetString(1)
                ));
            }

            return products;
        }

        /// <summary>
        /// Insere um novo produto no banco de dados.
        /// </summary>
        /// <param name="product">Produto a ser inserido.</param>
        public void Insert(Product product)
        {
            using var command = connection.CreateCommand();
            command.CommandText = "INSERT INTO Products (Name) VALUES (@name)";

            var param = command.CreateParameter();
            param.ParameterName = "@name";
            param.Value = product.Name; // Usando propriedade moderna
            command.Parameters.Add(param);

            command.ExecuteNonQuery();
        }
    }
}