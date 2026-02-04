using Microsoft.Extensions.Configuration;

namespace SoftwarePatterns.Creational.Singleton.AppSettings
{
    /// <summary>
    /// Classe que carrega todas as configurações da aplicação a partir do arquivo appsettings.json.
    /// Implementa o padrão Singleton para garantir uma única instância.
    /// </summary>
    public class ConfigurationProvider
    {
        /// <summary>
        /// Armazena todas as chaves e valores lidos do appsettings.json.
        /// </summary>
        private static Dictionary<string, string> configuration;

        /// <summary>
        /// Instância única do AppConfiguration (Singleton).
        /// </summary>
        private static ConfigurationProvider instance;

        /// <summary>
        /// Bloco estático chamado na primeira vez que a classe é acessada.
        /// Carrega todas as propriedades do appsettings.json.
        /// </summary>
        static ConfigurationProvider()
        {
            Console.WriteLine("Construtor do Singleton.");
            GetProperties();
        }

        /// <summary>
        /// Construtor privado para impedir instanciação externa.
        /// </summary>
        private ConfigurationProvider()
        {
            Console.WriteLine("Construtor do Singleton.");
        }

        /// <summary>
        /// Lê todas as configurações do appsettings.json e armazena em um dicionário.
        /// </summary>
        private static void GetProperties()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            configuration = new Dictionary<string, string>();

            foreach (var item in config.AsEnumerable())
            {
                if (!string.IsNullOrWhiteSpace(item.Key))
                    configuration[item.Key] = item.Value;
            }
        }

        /// <summary>
        /// Retorna a instância única do AppConfiguration.
        /// </summary>
        /// <returns>Instância única da classe.</returns>
        public static ConfigurationProvider GetAppConfiguration()
        {
            if (instance == null)
                instance = new ConfigurationProvider();

            return instance;
        }

        /// <summary>
        /// Retorna o valor de uma chave específica do appsettings.json.
        /// </summary>
        /// <param name="key">Chave desejada (ex.: "ConnectionStrings:SqlServer").</param>
        /// <returns>Valor associado à chave ou null se não existir.</returns>
        public object ValueOf(string key)
        {
            if (configuration.TryGetValue(key, out var value))
                return value;

            return null;
        }
    }
}