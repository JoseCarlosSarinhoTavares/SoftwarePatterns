namespace Criacionais.Builder.DatabaseSettings
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // URL normal
            var dbUrl = new DatabaseSettings.Builder()
                .UseUrl()
                .Protocol("https")
                .Host("localhost")
                .Port("5432")
                .Database("SoftwarePatterns")
                .Parameters("ssl=true")
                .Build();

            Console.WriteLine("=== URL ===");
            Console.WriteLine(dbUrl.GetUrl());

            // URL InMemory
            var dbUrlMemory = new DatabaseSettings.Builder()
                .UseUrl()
                .Database("SoftwarePatterns")
                .InMemory()
                .Build();

            Console.WriteLine("\n=== URL InMemory ===");
            Console.WriteLine(dbUrlMemory.GetUrl());

            // ConnectionString normal
            var dbConn = new DatabaseSettings.Builder()
                .UseConnectionString()
                .Server(@"(localdb)\MSSQLLocalDB")
                .Database("SoftwarePatterns")
                .TrustedConnection(true)
                .Build();

            Console.WriteLine("\n=== ConnectionString ===");
            Console.WriteLine(dbConn.GetConnectionString());

            // ConnectionString InMemory
            var dbConnMemory = new DatabaseSettings.Builder()
                .UseConnectionString()
                .Database("SoftwarePatterns")
                .InMemory()
                .Build();

            Console.WriteLine("\n=== ConnectionString InMemory ===");
            Console.WriteLine(dbConnMemory.GetConnectionString());
        }
    }
}