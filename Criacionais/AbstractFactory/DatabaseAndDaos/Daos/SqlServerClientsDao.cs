using DatabaseAndDaos.Entities;
using System.Data.Common;

namespace DatabaseAndDaos.Daos
{
    public class SqlServerClientsDao : ClientsDao
    {
        public SqlServerClientsDao(DbConnection connection)
            : base(connection)
        {
        }

        public List<Client> GetAllClients()
        {
            return base.GetAllClients();
        }

        public void Insert(Client clients)
        {
            base.Insert(clients);
        }
    }
}