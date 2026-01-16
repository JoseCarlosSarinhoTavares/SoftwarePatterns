using DatabaseAndDaos.Entities;
using System.Data.Common;

namespace DatabaseAndDaos.Daos
{
    public abstract class ClientsDao
    {
        private readonly DbConnection connection;

        public ClientsDao(DbConnection connection)
        {
            this.connection = connection;
        }

        public List<Client> GetAllClients()
        {
            var clients = new List<Client>();

            using var command = connection.CreateCommand();
            command.CommandText = "SELECT Id, Name FROM Clients";

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                clients.Add(
                    new Client(
                        reader.GetInt32(0),
                        reader.GetString(1)
                    )
                );
            }

            return clients;
        }

        public void Insert(Client client)
        {
            using var command = connection.CreateCommand();
            command.CommandText = "INSERT INTO Clients (Name) VALUES (@name)";

            var param = command.CreateParameter();
            param.ParameterName = "@name";
            param.Value = client.GetName();
            command.Parameters.Add(param);

            command.ExecuteNonQuery();
        }
    }
}