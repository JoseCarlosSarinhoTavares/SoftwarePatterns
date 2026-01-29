using DatabaseAndDaos.Entities;
using System.Data.Common;

namespace DatabaseAndDaos.Daos
{
    /// <summary>
    /// DAO de produtos específico para SQLite.
    /// Herda de <see cref="ProductsDao"/> e implementa operações para o banco SQLite.
    /// </summary>
    public class SqLiteProductsDao : ProductsDao
    {
        /// <summary>
        /// Construtor que recebe a conexão com o banco de dados.
        /// </summary>
        /// <param name="connection">Conexão com o banco de dados SQLite.</param>
        public SqLiteProductsDao(DbConnection connection)
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