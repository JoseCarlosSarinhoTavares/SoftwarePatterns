using DatabaseAndDaos.Configuration;
using DatabaseAndDaos.Daos;
using DatabaseAndDaos.Entities;
using DatabaseAndDaos.Factories;
using System.Data.Common;

namespace DatabaseAndDaos
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
            DbConnection sqlServer = new SqlServerDb().Initialize();
            DbConnection sqLite = new SqLiteDb().Initialize();

            // Configura DAOs para SQL Server
            SqlServerDaosFactory sqlServerDaosFactory = new SqlServerDaosFactory(sqlServer);

            ProductsDao sqlServerProductsDao = DaosFactory.GetProductsDao(sqlServerDaosFactory);
            sqlServerProductsDao.Insert(new Product(1, "Produto SQL Server 1"));
            sqlServerProductsDao.Insert(new Product(2, "Produto SQL Server 2"));

            ClientsDao sqlServerClientsDao = DaosFactory.GetClientsDao(sqlServerDaosFactory);
            sqlServerClientsDao.Insert(new Client(1, "Cliente SQL Server 1"));
            sqlServerClientsDao.Insert(new Client(2, "Cliente SQL Server 2"));

            // Configura DAOs para SQLite
            SqLiteDaosFactory sqLiteDaosFactory = new SqLiteDaosFactory(sqLite);

            ProductsDao sqLiteProductsDao = DaosFactory.GetProductsDao(sqLiteDaosFactory);
            sqLiteProductsDao.Insert(new Product(1, "Produto SQLite 1"));
            sqLiteProductsDao.Insert(new Product(2, "Produto SQLite 2"));

            ClientsDao sqLiteClientsDao = DaosFactory.GetClientsDao(sqLiteDaosFactory);
            sqLiteClientsDao.Insert(new Client(1, "Cliente SQLite 1"));
            sqLiteClientsDao.Insert(new Client(2, "Cliente SQLite 2"));

            // Exibe resultados
            Console.WriteLine("-------------------------------------------------------------------");
            Console.WriteLine("                           SQL Server");
            Console.WriteLine("-------------------------------------------------------------------");
            sqlServerProductsDao.GetAllProducts().ForEach(x => Console.WriteLine(x));
            sqlServerClientsDao.GetAllClients().ForEach(x => Console.WriteLine(x));

            Console.WriteLine("-------------------------------------------------------------------");
            Console.WriteLine("                            SQLite");
            Console.WriteLine("-------------------------------------------------------------------");
            sqLiteProductsDao.GetAllProducts().ForEach(x => Console.WriteLine(x));
            sqLiteClientsDao.GetAllClients().ForEach(x => Console.WriteLine(x));
        }
    }
}