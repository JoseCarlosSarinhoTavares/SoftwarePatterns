namespace SoftwarePatterns.Creational.Builder.SqlInsert
{
    public class Program
    {
        public static void Main(string[] args)
        {
            SqlInsertBuilder insert = new SqlInsertBuilder.Builder()
                .SetTableName("Clients")
                .AddColumn("id", 1)
                .AddColumn("name", "Carlos")
                .AddColumn("mail", "carlos@mail.com")
                .Build();

            Console.WriteLine(insert.GetSql());
        }
    }
}