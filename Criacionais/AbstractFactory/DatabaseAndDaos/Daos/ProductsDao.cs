using DatabaseAndDaos.Entities;
using System.Data.Common;

namespace DatabaseAndDaos.Daos
{
    public abstract class ProductsDao
    {
        private readonly DbConnection connection;

        public ProductsDao(DbConnection connection)
        {
            this.connection = connection;
        }

        public List<Product> GetAllProducts()
        {
            var products = new List<Product>();

            using var command = connection.CreateCommand();
            command.CommandText = "SELECT Id, Name FROM Products";

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                products.Add(
                    new Product(
                        reader.GetInt32(0),
                        reader.GetString(1)
                    )
                );
            }

            return products;
        }

        public void Insert(Product product)
        {
            using var command = connection.CreateCommand();
            command.CommandText = "INSERT INTO Products (Name) VALUES (@name)";

            var param = command.CreateParameter();
            param.ParameterName = "@name";
            param.Value = product.GetName();
            command.Parameters.Add(param);

            command.ExecuteNonQuery();
        }
    }
}