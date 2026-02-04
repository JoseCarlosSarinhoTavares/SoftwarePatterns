using System.Data.Common;
using SoftwarePatterns.Creational.AbstractFactory.DatabaseAndData.Entities;
using SoftwarePatterns.Creational.AbstractFactory.DatabaseAndData.Configuration;
using SoftwarePatterns.Creational.AbstractFactory.DatabaseAndData.Data;
using SoftwarePatterns.Creational.AbstractFactory.DatabaseAndData.Factories;

namespace SoftwarePatterns.Creational.AbstractFactory.DatabaseAndData
{
    /// <summary>
    /// Programa de demonstração do uso de DAOs e fábricas para SQL Server e SQLite.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Ponto de entrada do programa.
        /// </summary>
        public static void Main(string[] args)
        {
            // Inicializa conexões com os bancos
            DbConnection sqlServer = new SqlServerDatabaseInitializer().Initialize();
            DbConnection sqLite = new SqliteDatabaseInitializer().Initialize();

            // Configura DAOs para SQL Server
            SqlServerDataAccessFactory sqlServerDataAccessFactory = new SqlServerDataAccessFactory(sqlServer);

            ProductsDataAccess sqlServerProductsDataAccess = DataAccessFactory.GetProductsDataAccess(sqlServerDataAccessFactory);
            sqlServerProductsDataAccess.Insert(new Product(1, "Produto SQL Server 1"));
            sqlServerProductsDataAccess.Insert(new Product(2, "Produto SQL Server 2"));

            ClientDataAccess sqlServerClientsDataAccess = DataAccessFactory.GetClientsDataAccess(sqlServerDataAccessFactory);
            sqlServerClientsDataAccess.Insert(new Client(1, "Cliente SQL Server 1"));
            sqlServerClientsDataAccess.Insert(new Client(2, "Cliente SQL Server 2"));

            // Configura DAOs para SQLite
            SqLiteDataAccessFactory sqLiteDataAccessFactory = new SqLiteDataAccessFactory(sqLite);

            ProductsDataAccess sqLiteProductsDataAccess = DataAccessFactory.GetProductsDataAccess(sqLiteDataAccessFactory);
            sqLiteProductsDataAccess.Insert(new Product(1, "Produto SQLite 1"));
            sqLiteProductsDataAccess.Insert(new Product(2, "Produto SQLite 2"));

            ClientDataAccess sqLiteClientsDataAccess = DataAccessFactory.GetClientsDataAccess(sqLiteDataAccessFactory);
            sqLiteClientsDataAccess.Insert(new Client(1, "Cliente SQLite 1"));
            sqLiteClientsDataAccess.Insert(new Client(2, "Cliente SQLite 2"));

            // Exibe resultados
            Console.WriteLine("-------------------------------------------------------------------");
            Console.WriteLine("                           SQL Server");
            Console.WriteLine("-------------------------------------------------------------------");
            sqlServerProductsDataAccess.GetAllProducts().ForEach(x => Console.WriteLine(x));
            sqlServerClientsDataAccess.GetAllClients().ForEach(x => Console.WriteLine(x));

            Console.WriteLine("-------------------------------------------------------------------");
            Console.WriteLine("                            SQLite");
            Console.WriteLine("-------------------------------------------------------------------");
            sqLiteProductsDataAccess.GetAllProducts().ForEach(x => Console.WriteLine(x));
            sqLiteClientsDataAccess.GetAllClients().ForEach(x => Console.WriteLine(x));
        }
    }
}