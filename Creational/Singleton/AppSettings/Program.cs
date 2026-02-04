namespace SoftwarePatterns.Creational.Singleton.AppSettings
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var appConfig = ConfigurationProvider.GetAppConfiguration();

            Console.WriteLine("=== Configurações carregadas ===");
            Console.WriteLine();
            Console.WriteLine($"ConnectionStrings:SqlServer = {appConfig.ValueOf("ConnectionStrings:SqlServer")}");
            Console.WriteLine();
            Console.WriteLine($"App:Name = {appConfig.ValueOf("App:Name")}");
            Console.WriteLine($"App:Version = {appConfig.ValueOf("App:Version")}");
            Console.WriteLine();
            Console.WriteLine($"Api:BaseUrl = {appConfig.ValueOf("Api:BaseUrl")}");
            Console.WriteLine();
            Console.WriteLine($"Logging:Level = {appConfig.ValueOf("Logging:Level")}");
        }
    }
}