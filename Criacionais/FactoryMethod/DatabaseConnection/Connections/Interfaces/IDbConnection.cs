using System.Data.Common;

namespace Criacionais.FactoryMethod.DatabaseConnection.Connections.Interfaces
{
    public interface IDbConnection
    {
        DbConnection Connect();
    }
}