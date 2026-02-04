using System.Data.Common;
using SoftwarePatterns.Creational.AbstractFactory.DatabaseAndData.Entities;

namespace SoftwarePatterns.Creational.AbstractFactory.DatabaseAndData.Data
{
    /// <summary>
    /// DAO de produtos específico para SQLite.
    /// Herda de <see cref="ProductsDao"/> e implementa operações para o banco SQLite.
    /// </summary>
    public class SqLiteProductsDataAccess : ProductsDataAccess
    {
        /// <summary>
        /// Construtor que recebe a conexão com o banco de dados.
        /// </summary>
        /// <param name="connection">Conexão com o banco de dados SQLite.</param>
        public SqLiteProductsDataAccess(DbConnection connection)
            : base(connection)
        {
        }

        /// <summary>
        /// Retorna todos os produtos do banco de dados.
        /// </summary>
        /// <returns>Lista de produtos.</returns>
        public List<Product> GetAllProducts()
        {
            return base.GetAllProducts();
        }

        /// <summary>
        /// Insere um novo produto no banco de dados.
        /// </summary>
        /// <param name="product">Produto a ser inserido.</param>
        public void Insert(Product product)
        {
            base.Insert(product);
        }
    }
}