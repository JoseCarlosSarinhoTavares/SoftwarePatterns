using Caches.Database;
using Caches.Factories;
using Caches.Interfaces;

namespace Caches
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            SqlServerDB.Initialize();

            ICache cache = null;

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

            cache.Put("9BWZZZ377VT004251", "Corolla");
            cache.Put("8APZZZ373VT998877", "Civic");
            cache.Put("3VWZZZ1KZAM123456", "Golf");
            cache.Put("1G1BC5SM9H7123456", "Onix");
            cache.Put("1FTFW1ET1EFA12345", "Ranger");

            MostrarCache();

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

            Console.WriteLine();
            Console.WriteLine("Estado final do cache:");
            MostrarCache();

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