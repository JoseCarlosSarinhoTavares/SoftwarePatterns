using DatabaseAndDaos.Entities;
using System.Data.Common;

namespace DatabaseAndDaos.Daos
{
    public class SqLiteProductsDao : ProductsDao
    {
        public SqLiteProductsDao(DbConnection connection)
            : base(connection)
        {
        }

        public List<Product> GetAllProducts()
        {
            return base.GetAllProducts();
        }

        public void Insert(Product product)
        {
            base.Insert(product);
        }
    }
}