using DatabaseAndDaos.Entities;
using System.Data.Common;

namespace DatabaseAndDaos.Daos
{
    public class SqLiteClientsDao : ClientsDao
    {
        public SqLiteClientsDao(DbConnection connection)
            : base(connection)
        {
        }

        public List<Client> GetAllClients()
        {
            return base.GetAllClients();
        }

        public void Insert(Client client)
        {
            base.Insert(client);
        }
    }
}