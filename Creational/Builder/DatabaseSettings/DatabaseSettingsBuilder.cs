namespace SoftwarePatterns.Creational.Builder.DatabaseSettings
{
    /// <summary>
    /// Representa as configurações finais de conexão com o banco de dados.
    /// </summary>
    public class DatabaseSettingsBuilder
    {
        public string? Url { get; private set; }
        public string? ConnectionString { get; private set; }
        public string? Username { get; private set; }
        public string? Password { get; private set; }
        public int MaxConnections { get; private set; }

        private DatabaseSettingsBuilder() { }

        /// <summary>
        /// Builder responsável por construir DatabaseSettingsBuilder passo a passo.
        /// </summary>
        public class Builder
        {
            private string? _protocol;
            private string? _host;
            private string? _port;
            private string? _database;
            private string? _parameters;
            private string? _server;
            private bool _trustedConnection = true;
            private string? _username;
            private string? _password;
            private int _maxConnections;
            private bool _inMemory;
            private bool _useUrl = true;

            public Builder UseUrl()
            {
                _useUrl = true;
                return this;
            }

            public Builder UseConnectionString()
            {
                _useUrl = false;
                return this;
            }

            public Builder Protocol(string protocol)
            {
                _protocol = protocol;
                return this;
            }

            public Builder Host(string host)
            {
                _host = host;
                return this;
            }

            public Builder Port(string port)
            {
                _port = port;
                return this;
            }

            public Builder Database(string database)
            {
                _database = database;
                return this;
            }

            public Builder Parameters(string parameters)
            {
                _parameters = parameters;
                return this;
            }

            public Builder Server(string server)
            {
                _server = server;
                return this;
            }

            public Builder TrustedConnection(bool value = true)
            {
                _trustedConnection = value;
                return this;
            }

            public Builder Username(string username)
            {
                _username = username;
                return this;
            }

            public Builder Password(string password)
            {
                _password = password;
                return this;
            }

            public Builder MaxConnections(int maxConnections)
            {
                _maxConnections = maxConnections;
                return this;
            }

            public Builder InMemory()
            {
                _inMemory = true;
                return this;
            }

            public DatabaseSettingsBuilder Build()
            {
                var settings = new DatabaseSettingsBuilder
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

                if (_useUrl)
                {
                    var url = $"{_protocol}://{_host}:{_port}/{_database}";
                    if (!string.IsNullOrWhiteSpace(_parameters))
                        url += $"?{_parameters}";

                    settings.Url = url;
                }
                else
                {
                    settings.ConnectionString = _trustedConnection
                        ? $@"Server={_server};Database={_database};Trusted_Connection=True;"
                        : $@"Server={_server};Database={_database};User Id={_username};Password={_password};";
                }

                return settings;
            }
        }
    }
}