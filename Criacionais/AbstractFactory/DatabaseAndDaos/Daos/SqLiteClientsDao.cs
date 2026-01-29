using DatabaseAndDaos.Entities;
using System.Data.Common;

namespace DatabaseAndDaos.Daos
{
    /// <summary>
    /// DAO de clientes específico para SQLite.
    /// Herda de <see cref="ClientsDao"/> e implementa operações para o banco SQLite.
    /// </summary>
    public class SqLiteClientsDao : ClientsDao
    {
        /// <summary>
        /// Construtor que recebe a conexão com o banco de dados.
        /// </summary>
        /// <param name="connection">Conexão com o banco de dados SQLite.</param>
        public SqLiteClientsDao(DbConnection connection)
            : base(connection)
        {
        }

        /// <summary>
        /// Retorna todos os clientes do banco de dados.
        /// </summary>
        /// <returns>Lista de clientes.</returns>
        public List<Client> GetAllClients()
        {
            return base.GetAllClients();
        }

        /// <summary>
        /// Insere um novo cliente no banco de dados.
        /// </summary>
        /// <param name="client">Cliente a ser inserido.</param>
        public void Insert(Client client)
        {
            base.Insert(client);
        }
    }
}