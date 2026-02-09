namespace SoftwarePatterns.Creational.Prototype.ServerConfiguration
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ServerConfiguration Server1 = 
                new ServerConfiguration("sever-01", "11.11.11.1", "1Gb", "100Gb", 1.50, "/tmp", 900);

            ServerConfiguration Server2 = Server1.Clone();
            Server2.SetNome("sever-02");
            Server2.SetIp("11.11.11.2");

            Console.WriteLine("Servidor 1: " + Server1);
            Console.WriteLine("Servidor 2: " + Server2);
        }
    }
}