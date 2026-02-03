namespace Criacionais.Builder.DatabaseSettings
{
    /// <summary>
    /// Representa as configurações de conexão com banco de dados.
    /// Pode expor a conexão no formato de URL ou ConnectionString (SQL Server).
    /// </summary>
    public class DatabaseSettings
    {
        public string Url { get; private set; }
        public string ConnectionString { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public int MaxConnections { get; private set; }

        public string GetUrl() => Url;
        public string GetConnectionString() => ConnectionString;
        public string GetUsername() => Username;
        public string GetPassword() => Password;
        public int GetMaxConnections() => MaxConnections;

        /// <summary>
        /// Builder responsável por montar o objeto DatabaseSettings passo a passo (Builder Pattern).
        /// Permite escolher entre gerar URL ou ConnectionString, além de suportar modo InMemory.
        /// </summary>
        public class Builder
        {
            private string _protocol = "";
            private string _host = "";
            private string _port = "";
            private string _database = "";
            private string _parameters = "";
            private string _server = "";

            /// <summary>
            /// Indica se deve usar autenticação integrada do Windows (Trusted_Connection=True).
            /// </summary>
            private bool _trustedConnection = true;

            private string _username = "";

            private string _password = "";

            private int _maxConnections;

            private bool _inMemory = false;

            private bool _useUrl = true; // padrão

            /// <summary>
            /// Define que o Builder deve gerar a saída no formato de URL.
            /// </summary>
            public Builder UseUrl()
            {
                _useUrl = true;
                return this;
            }

            /// <summary>
            /// Define que o Builder deve gerar a saída no formato de ConnectionString (SQL Server).
            /// </summary>
            public Builder UseConnectionString()
            {
                _useUrl = false;
                return this;
            }

            /// <summary>
            /// Define o protocolo da URL (ex.: "https").
            /// </summary>
            public Builder Protocol(string protocol)
            {
                _protocol = protocol;
                return this;
            }

            /// <summary>
            /// Define o host da URL (ex.: "localhost").
            /// </summary>
            public Builder Host(string host)
            {
                _host = host;
                return this;
            }

            /// <summary>
            /// Define a porta da URL (ex.: "5432").
            /// </summary>
            public Builder Port(string port)
            {
                _port = port;
                return this;
            }

            /// <summary>
            /// Define o nome do banco de dados (usado tanto na URL quanto na ConnectionString).
            /// </summary>
            public Builder Database(string database)
            {
                _database = database;
                return this;
            }

            /// <summary>
            /// Define parâmetros adicionais da URL (ex.: "ssl=true").
            /// </summary>
            public Builder Parameters(string parameters)
            {
                _parameters = parameters;
                return this;
            }

            /// <summary>
            /// Define o servidor do SQL Server para montar a ConnectionString.
            /// </summary>
            public Builder Server(string server)
            {
                _server = server;
                return this;
            }

            /// <summary>
            /// Define se deve usar Trusted Connection (autenticação integrada).
            /// </summary>
            public Builder TrustedConnection(bool trusted)
            {
                _trustedConnection = trusted;
                return this;
            }

            /// <summary>
            /// Define o usuário do banco (usado quando TrustedConnection = false).
            /// </summary>
            public Builder Username(string username)
            {
                _username = username;
                return this;
            }

            /// <summary>
            /// Define a senha do banco (usada quando TrustedConnection = false).
            /// </summary>
            public Builder Password(string password)
            {
                _password = password;
                return this;
            }

            /// <summary>
            /// Define o limite máximo de conexões.
            /// </summary>
            public Builder MaxConnections(int maxConnections)
            {
                _maxConnections = maxConnections;
                return this;
            }

            /// <summary>
            /// Ativa o modo InMemory.
            /// Nesse modo, não é montada URL real nem ConnectionString real de servidor.
            /// </summary>
            public Builder InMemory()
            {
                _inMemory = true;
                return this;
            }

            /// <summary>
            /// Finaliza a construção e retorna o objeto DatabaseSettings pronto.
            /// Regras:
            /// - Se InMemory estiver ativo, preenche Url e ConnectionString com valores "em memória".
            /// - Se não estiver em memória:
            ///   - Monta URL com base em Protocol/Host/Port/Database/Parameters.
            ///   - Monta ConnectionString do SQL Server com base em Server/Database/TrustedConnection.
            /// - No final, preenche apenas o campo correspondente ao modo escolhido (UseUrl ou UseConnectionString).
            /// </summary>
            public DatabaseSettings Build()
            {
                var settings = new DatabaseSettings
                {
                    Username = _username,
                    Password = _password,
                    MaxConnections = _maxConnections
                };

                if (_inMemory)
                {
                    settings.Url = $"mem://{_database}";
                    settings.ConnectionString = $"InMemory://{_database}";
                    return settings;
                }

                var url = $"{_protocol}://{_host}:{_port}/{_database}";
                if (!string.IsNullOrWhiteSpace(_parameters))
                    url += $"?{_parameters}";

                string connStr;

                if (_trustedConnection)
                    connStr = $@"Server={_server};Database={_database};Trusted_Connection=True;";
                else
                    connStr = $@"Server={_server};Database={_database};User Id={_username};Password={_password};";

                if (_useUrl)
                    settings.Url = url;
                else
                    settings.ConnectionString = connStr;

                return settings;
            }
        }
    }
}