namespace Logger
{
    public class AppLogger
    {
        private static AppLogger instance;
        private AppLogger() { }
        public static AppLogger GetAppLogger()
        {
            if (instance == null) 
                instance = new AppLogger();

                return instance;
        }

        public void Debug(string message) { Console.WriteLine("DEBUG: " + message); }
        public void Info(string message) { Console.WriteLine("INFO: " + message); }
        public void Warn(string message) { Console.WriteLine("WARN: " + message); }
        public void Error(string message) { Console.WriteLine("ERROR: " + message); }
    }
}