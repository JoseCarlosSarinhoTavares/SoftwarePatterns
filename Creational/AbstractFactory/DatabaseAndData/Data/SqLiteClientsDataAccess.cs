using System.Data.Common;
using SoftwarePatterns.Creational.AbstractFactory.DatabaseAndData.Entities;

namespace SoftwarePatterns.Creational.AbstractFactory.DatabaseAndData.Data
{
    /// <summary>
    /// DAO de clientes específico para SQLite.
    /// Herda de <see cref="ClientsDao"/> e implementa operações para o banco SQLite.
    /// </summary>
    public class SqLiteClientsDataAccess : ClientDataAccess
    {
        /// <summary>
        /// Construtor que recebe a conexão com o banco de dados.
        /// </summary>
        /// <param name="connection">Conexão com o banco de dados SQLite.</param>
        public SqLiteClientsDataAccess(DbConnection connection)
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