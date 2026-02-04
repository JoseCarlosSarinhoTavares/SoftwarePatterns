namespace SoftwarePatterns.Creational.Builder.DatabaseSettings
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // URL normal
            var dbUrl = new DatabaseConnectionSettings.Builder()
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
            var dbUrlMemory = new DatabaseConnectionSettings.Builder()
                .UseUrl()
                .Database("SoftwarePatterns")
                .InMemory()
                .Build();

            Console.WriteLine("\n=== URL InMemory ===");
            Console.WriteLine(dbUrlMemory.GetUrl());

            // ConnectionString normal
            var dbConn = new DatabaseConnectionSettings.Builder()
                .UseConnectionString()
                .Server(@"(localdb)\MSSQLLocalDB")
                .Database("SoftwarePatterns")
                .TrustedConnection(true)
                .Build();

            Console.WriteLine("\n=== ConnectionString ===");
            Console.WriteLine(dbConn.GetConnectionString());

            // ConnectionString InMemory
            var dbConnMemory = new DatabaseConnectionSettings.Builder()
                .UseConnectionString()
                .Database("SoftwarePatterns")
                .InMemory()
                .Build();

            Console.WriteLine("\n=== ConnectionString InMemory ===");
            Console.WriteLine(dbConnMemory.GetConnectionString());
        }
    }
}