using Caches.Database;
using Caches.Factories;
using Caches.Interfaces;

namespace Caches
{
    /// <summary>
    /// Programa principal para demonstração do uso de cache.
    /// Permite escolher entre cache em memória ou cache em banco (SQL Server).
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Ponto de entrada da aplicação.
        /// </summary>
        public static void Main(string[] args)
        {
            // Inicializa o banco SQL Server e cria tabela se necessário
            SqlServerDB.Initialize();

            ICache cache = null;

            // Escolha do tipo de cache
            while (cache == null)
            {
                Console.WriteLine("Escolha o tipo de cache:");
                Console.WriteLine("1 - Cache em memória");
                Console.WriteLine("2 - Cache em banco (SQL Server)");
                Console.Write("Opção: ");

                var option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        cache = CacheFactory.GetCache("mem");
                        Console.Clear();
                        Console.WriteLine("------------- Memória -------------");
                        break;

                    case "2":
                        cache = CacheFactory.GetCache("db");
                        Console.Clear();
                        Console.WriteLine("------------- Banco de Dados -------------");
                        break;

                    default:
                        Console.WriteLine("Opção inválida.");
                        Thread.Sleep(1500);
                        Console.Clear();
                        break;
                }
            }

            // Popula o cache com alguns veículos
            cache.Put("9BWZZZ377VT004251", "Corolla");
            cache.Put("8APZZZ373VT998877", "Civic");
            cache.Put("3VWZZZ1KZAM123456", "Golf");
            cache.Put("1G1BC5SM9H7123456", "Onix");
            cache.Put("1FTFW1ET1EFA12345", "Ranger");

            // Exibe o cache
            MostrarCache();

            // Remover veículo pelo chassi
            Console.WriteLine();
            Console.Write("Digite o CHASSI para remover: ");
            var chassi = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(chassi))
            {
                var existe = cache.Get(chassi);

                if (existe != null)
                {
                    cache.Remove(chassi);
                    Console.WriteLine("Veículo removido com sucesso.");
                }
                else
                {
                    Console.WriteLine("Chassi não encontrado. Nada removido.");
                }
            }
            else
            {
                Console.WriteLine("Chassi inválido.");
            }

            // Exibe estado final do cache
            Console.WriteLine();
            Console.WriteLine("Estado final do cache:");
            MostrarCache();

            /// <summary>
            /// Exibe todos os itens armazenados no cache em formato de tabela.
            /// </summary>
            void MostrarCache()
            {
                Console.WriteLine(new string('-', 55));
                Console.WriteLine("Chassi".PadRight(20) + " | Modelo");
                Console.WriteLine(new string('-', 55));

                cache.GetAll()
                    .ToList()
                    .ForEach(x =>
                        Console.WriteLine(
                            x.Key.PadRight(20) + " | " + (x.Value ?? "")
                        )
                    );

                Console.WriteLine(new string('-', 55));
            }
        }
    }
}