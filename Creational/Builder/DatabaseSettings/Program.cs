namespace SoftwarePatterns.Creational.Builder.DatabaseSettings
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // URL normal
            var dbUrl = new DatabaseSettingsBuilder.Builder()
                .UseUrl()
                .Protocol("https")
                .Host("localhost")
                .Port("5432")
                .Database("SoftwarePatterns")
                .Parameters("ssl=true")
                .Build();

            Console.WriteLine("=== URL ===");
            Console.WriteLine(dbUrl.Url);

            // URL InMemory
            var dbUrlMemory = new DatabaseSettingsBuilder.Builder()
                .UseUrl()
                .Database("SoftwarePatterns")
                .InMemory()
                .Build();

            Console.WriteLine("\n=== URL InMemory ===");
            Console.WriteLine(dbUrlMemory.Url);

            // ConnectionString normal
            var dbConn = new DatabaseSettingsBuilder.Builder()
                .UseConnectionString()
                .Server(@"(localdb)\MSSQLLocalDB")
                .Database("SoftwarePatterns")
                .TrustedConnection()
                .Build();

            Console.WriteLine("\n=== ConnectionString ===");
            Console.WriteLine(dbConn.ConnectionString);

            // ConnectionString InMemory
            var dbConnMemory = new DatabaseSettingsBuilder.Builder()
                .UseConnectionString()
                .Database("SoftwarePatterns")
                .InMemory()
                .Build();

            Console.WriteLine("\n=== ConnectionString InMemory ===");
            Console.WriteLine(dbConnMemory.ConnectionString);
        }
    }
}