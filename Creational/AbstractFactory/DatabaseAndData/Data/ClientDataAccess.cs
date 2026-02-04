using System.Data.Common;
using SoftwarePatterns.Creational.AbstractFactory.DatabaseAndData.Entities;

namespace SoftwarePatterns.Creational.AbstractFactory.DatabaseAndData.Data
{
    /// <summary>
    /// DAO abstrato para clientes.
    /// Fornece métodos básicos para obter e inserir clientes no banco de dados.
    /// </summary>
    public abstract class ClientDataAccess
    {
        private readonly DbConnection connection;

        /// <summary>
        /// Construtor que recebe a conexão com o banco de dados.
        /// </summary>
        /// <param name="connection">Conexão com o banco de dados.</param>
        protected ClientDataAccess(DbConnection connection)
        {
            this.connection = connection;
        }

        /// <summary>
        /// Retorna todos os clientes do banco de dados.
        /// </summary>
        /// <returns>Lista de clientes.</returns>
        public List<Client> GetAllClients()
        {
            var clients = new List<Client>();

            using var command = connection.CreateCommand();
            command.CommandText = "SELECT Id, Name FROM Clients";

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                clients.Add(new Client(
                    reader.GetInt32(0),
                    reader.GetString(1)
                ));
            }

            return clients;
        }

        /// <summary>
        /// Insere um novo cliente no banco de dados.
        /// </summary>
        /// <param name="client">Cliente a ser inserido.</param>
        public void Insert(Client client)
        {
            using var command = connection.CreateCommand();
            command.CommandText = "INSERT INTO Clients (Name) VALUES (@name)";

            var param = command.CreateParameter();
            param.ParameterName = "@name";
            param.Value = client.Name; // Usando propriedade moderna
            command.Parameters.Add(param);

            command.ExecuteNonQuery();
        }
    }
}