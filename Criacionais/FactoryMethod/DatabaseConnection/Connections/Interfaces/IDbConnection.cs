using System.Data.Common;

namespace DatabaseConnection.Connections.Interfaces
{
    public interface IDbConnection
    {
        DbConnection Connect();
    }
}