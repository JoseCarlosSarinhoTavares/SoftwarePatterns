using Criacionais.AbstractFactory.Authentication.Configuration;
using Criacionais.AbstractFactory.Authentication.Daos;
using Criacionais.AbstractFactory.Authentication.Factories;

namespace Criacionais.AbstractFactory.Authentication
{
    public class Program
    {
        /// <summary>
        /// Ponto de entrada do programa.
        /// </summary>
        public static void Main(string[] args)
        {
            // Inicializa o banco e garante que a tabela exista (e pode inserir registros iniciais).
            SqlServerDB.Initialize();

            bool locationAuthentication = TokenFactoryAuthentication.CreateAuthentication(new LocationAuthenticationTokenFactory())
                .Authenticate("token:1");

            Console.WriteLine($"Autenticação local: {locationAuthentication}");

            bool databaseAuthentication = TokenFactoryAuthentication.CreateAuthentication(new DataBaseAuthenticationTokenFactory())
                .Authenticate("456");

            Console.WriteLine($"Autenticação banco de dados: {databaseAuthentication}");

            // Imprime os tokens que estão no banco de dados
            new TokensDao(SqlServerDB.GetConnection()).GetAll().ForEach(token => Console.WriteLine(token));
        }
    }
}