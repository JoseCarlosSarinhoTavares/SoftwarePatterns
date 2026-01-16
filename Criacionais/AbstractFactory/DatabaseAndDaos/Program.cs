using DatabaseAndDaos.Configuration;
using DatabaseAndDaos.Daos;
using DatabaseAndDaos.Entities;
using DatabaseAndDaos.Factories;
using System.Data.Common;

namespace DatabaseAndDaos
{
    public class Program
    {
        public static void Main(string[] args)
        {
            DbConnection sqlServer = new SqlServerDb().Initialize();
            DbConnection sqLite = new SqLiteDb().Initialize();

            SqlServerDaosFactory sqlServerDaosFactory = new SqlServerDaosFactory(sqlServer);

            ProductsDao sqlServerProductsDao = DaosFactory.GetProductsDao(sqlServerDaosFactory);
            sqlServerProductsDao.Insert(new Product(1, "Produto sql Server 1"));
            sqlServerProductsDao.Insert(new Product(2, "Produto sql Server 2"));

            ClientsDao sqlServerClientsDao = DaosFactory.GetClientsDao(sqlServerDaosFactory);
            sqlServerClientsDao.Insert(new Client(1, "Cliente sql Server 1"));
            sqlServerClientsDao.Insert(new Client(2, "Cliente sql Server 2"));

            SqLiteDaosFactory sqlLiteDaosFactory = new SqLiteDaosFactory(sqLite);
            ProductsDao sqLiteProductsDao = DaosFactory.GetProductsDao(sqlLiteDaosFactory);
            sqLiteProductsDao.Insert(new Product(1, "Produto sqlite 1"));
            sqLiteProductsDao.Insert(new Product(2, "Produto sqlite Server 2"));

            ClientsDao sqlLiteClientsDao = DaosFactory.GetClientsDao(sqlLiteDaosFactory);
            sqlLiteClientsDao.Insert(new Client(1, "Cliente sqlite Server 1"));
            sqlLiteClientsDao.Insert(new Client(2, "Cliente sqlite Server 2"));


            Console.WriteLine("-------------------------------------------------------------------");
            Console.WriteLine("                         SqlServer");
            Console.WriteLine("-------------------------------------------------------------------");
            sqlServerProductsDao.GetAllProducts().ForEach(x => Console.WriteLine(x));
            sqlServerClientsDao.GetAllClients().ForEach(x => Console.WriteLine(x));

            Console.WriteLine("-------------------------------------------------------------------");
            Console.WriteLine("                         SqLite");
            Console.WriteLine("-------------------------------------------------------------------");
            sqLiteProductsDao.GetAllProducts().ForEach(x => Console.WriteLine(x));
            sqlLiteClientsDao.GetAllClients().ForEach(x => Console.WriteLine(x));
        }
    }
}