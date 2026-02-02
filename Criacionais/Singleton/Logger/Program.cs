namespace Logger
{
    public class Program
    {
        public static void Main(string[] args)
        {
            AppLogger logger = AppLogger.GetAppLogger();

            logger.Debug("Uma mensagem de debug");
            logger.Info("Uma mensagem de info");
            logger.Warn("Uma mensagem de aviso");
            logger.Error("Uma mensagem de erro");
        }
    }
}