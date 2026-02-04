using System.Text;

namespace SoftwarePatterns.Creational.Builder.SqlInsert
{
    /// <summary>
    /// Representa um comando SQL de INSERT gerado via Builder.
    /// <para>
    /// Essa classe encapsula a string SQL final (ex.: INSERT INTO ... VALUES ...),
    /// permitindo montar o comando de forma segura e organizada.
    /// </para>
    /// </summary>
    public class SqlInsertBuilder
    {
        /// <summary>
        /// SQL final gerado pelo Builder.
        /// </summary>
        public string Sql { get; }

        /// <summary>
        /// Construtor privado para impedir instanciação direta.
        /// O objeto deve ser criado via <see cref="Builder"/>.
        /// </summary>
        /// <param name="sql">Comando SQL final montado.</param>
        private SqlInsertBuilder(string sql)
        {
            Sql = sql;
        }

        /// <summary>
        /// Retorna o comando SQL gerado.
        /// </summary>
        /// <returns>String contendo o SQL do INSERT.</returns>
        public string GetSql() => Sql;

        /// <summary>
        /// Builder responsável por montar o SQL de INSERT passo a passo.
        /// <para>
        /// Permite definir a tabela e adicionar colunas com seus valores.
        /// Ao final, gera um SQL no formato:
        /// <code>
        /// INSERT INTO Tabela (Col1, Col2) VALUES (@Col1, @Col2);
        /// </code>
        /// </para>
        /// </summary>
        public class Builder
        {
            /// <summary>
            /// Nome da tabela que será usada no INSERT.
            /// </summary>
            private string _tableName = "";

            /// <summary>
            /// Armazena as colunas e valores que serão inseridos.
            /// A chave é o nome da coluna e o valor é o conteúdo a ser persistido.
            /// </summary>
            private readonly Dictionary<string, object?> _columns = new();

            /// <summary>
            /// Define o nome da tabela que será usada no INSERT.
            /// </summary>
            /// <param name="tableName">Nome da tabela (ex.: "Users").</param>
            /// <returns>O próprio Builder para permitir encadeamento (fluent interface).</returns>
            public Builder SetTableName(string tableName)
            {
                _tableName = tableName;
                return this;
            }

            /// <summary>
            /// Adiciona uma coluna e seu valor ao comando de INSERT.
            /// <para>
            /// O valor não é inserido diretamente no SQL, e sim associado a um parâmetro
            /// (ex.: @UserName), o que evita SQL Injection.
            /// </para>
            /// </summary>
            /// <param name="column">Nome da coluna (ex.: "UserName").</param>
            /// <param name="value">Valor da coluna (ex.: "Carlos").</param>
            /// <returns>O próprio Builder para permitir encadeamento.</returns>
            public Builder AddColumn(string column, object? value)
            {
                _columns[column] = value;
                return this;
            }

            /// <summary>
            /// Gera o SQL final de INSERT com base na tabela e nas colunas informadas.
            /// </summary>
            /// <returns>Instância pronta de <see cref="SqlInsertBuilder"/>.</returns>
            /// <exception cref="ArgumentException">
            /// Lançada quando o nome da tabela está vazio ou nenhuma coluna foi informada.
            /// </exception>
            public SqlInsertBuilder Build()
            {
                if (string.IsNullOrWhiteSpace(_tableName))
                    throw new ArgumentException("TableName não pode ser vazio.");

                if (_columns.Count == 0)
                    throw new ArgumentException("Precisa ter pelo menos 1 coluna.");

                var sql = new StringBuilder();

                // INSERT INTO Tabela (Col1, Col2)
                sql.Append($"INSERT INTO {_tableName} (");
                sql.Append(string.Join(", ", _columns.Keys));
                sql.Append(") ");

                // VALUES (1, 'Carlos', 'carlos@mail.com')
                sql.Append("VALUES (");
                sql.Append(string.Join(", ", _columns.Values.Select(FormatValue)));
                sql.Append(");");

                return new SqlInsertBuilder(sql.ToString());
            }

            /// <summary>
            /// Retorna os parâmetros (coluna -> valor) para serem usados com DbCommand/SqlCommand.
            /// <para>
            /// Exemplo: UserName => "Carlos", Email => "carlos@teste.com"
            /// </para>
            /// </summary>
            /// <returns>Dicionário somente leitura com os parâmetros do INSERT.</returns>
            public IReadOnlyDictionary<string, object?> GetParameters() => _columns;

            /// <summary>
            /// Converte um valor C# para um valor SQL literal (texto pronto para entrar no comando SQL).
            /// <para>
            /// Observação: esse método monta SQL "na mão" (valores já embutidos no texto).
            /// Em produção, o ideal é usar parâmetros (ex.: <c>@Name</c>) para evitar SQL Injection.
            /// </para>
            /// </summary>
            /// <param name="value">Valor a ser convertido para o formato SQL.</param>
            /// <returns>String formatada como literal SQL.</returns>
            private static string FormatValue(object? value)
            {
                if (value == null)
                    return "NULL";

                return value switch
                {
                    string s => $"'{s.Replace("'", "''")}'",
                    bool b => b ? "1" : "0",
                    DateTime dt => $"'{dt:yyyy-MM-dd HH:mm:ss}'",
                    _ => value.ToString() ?? "NULL"
                };
            }
        }
    }
}