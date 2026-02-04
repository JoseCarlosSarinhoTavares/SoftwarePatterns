using System.Data.Common;

namespace SoftwarePatterns.Creational.FactoryMethod.DatabaseConnection.Interfaces
{
    public interface IDatabaseConnection
    {
        DbConnection Connect();
    }
}