namespace Logger
{
    /// <summary>
    /// Classe de Logger da aplicação usando o padrão Singleton.
    /// Garante que exista apenas uma instância de AppLogger durante toda a execução.
    /// </summary>
    public class AppLogger
    {
        /// <summary>
        /// Instância única (singleton) da classe AppLogger.
        /// </summary>
        private static AppLogger instance;

        /// <summary>
        /// Construtor privado para impedir que a classe seja instanciada diretamente com "new".
        /// </summary>
        private AppLogger() { }

        /// <summary>
        /// Retorna a instância única do logger.
        /// Se ainda não existir, cria a instância.
        /// </summary>
        /// <returns>Instância única de <see cref="AppLogger"/>.</returns>
        public static AppLogger GetAppLogger()
        {
            // Verifica se a instância ainda não foi criada.
            if (instance == null)
                // Cria a instância única.
                instance = new AppLogger();

            // Retorna a instância única.
            return instance;
        }

        /// <summary>
        /// Registra uma mensagem de nível DEBUG (detalhes para desenvolvimento).
        /// </summary>
        /// <param name="message">Mensagem que será exibida no console.</param>
        public void Debug(string message) { Console.WriteLine("DEBUG: " + message); }

        /// <summary>
        /// Registra uma mensagem de nível INFO (informações gerais).
        /// </summary>
        /// <param name="message">Mensagem que será exibida no console.</param>
        public void Info(string message) { Console.WriteLine("INFO: " + message); }

        /// <summary>
        /// Registra uma mensagem de nível WARN (aviso de possível problema).
        /// </summary>
        /// <param name="message">Mensagem que será exibida no console.</param>
        public void Warn(string message) { Console.WriteLine("WARN: " + message); }

        /// <summary>
        /// Registra uma mensagem de nível ERROR (erro ocorrido).
        /// </summary>
        /// <param name="message">Mensagem que será exibida no console.</param>
        public void Error(string message) { Console.WriteLine("ERROR: " + message); }
    }
}