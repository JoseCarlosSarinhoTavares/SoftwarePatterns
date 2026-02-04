namespace SoftwarePatterns.Creational.Singleton.Logging
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Logger logger = Logger.GetLoggerProvider();

            logger.Debug("Uma mensagem de debug");
            logger.Info("Uma mensagem de info");
            logger.Warn("Uma mensagem de aviso");
            logger.Error("Uma mensagem de erro");
        }
    }
}