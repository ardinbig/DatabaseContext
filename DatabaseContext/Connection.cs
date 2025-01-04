using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Data.SqlClient;
using Oracle.ManagedDataAccess.Client;
using Npgsql; // Add this for PostgreSQL

namespace DatabaseContext
{
    public class Connection : IConnection
    {
        private static readonly Lazy<Connection> _con = new Lazy<Connection>(() => new Connection());

        public static Connection Instance => _con.Value;

        /// <summary>
        /// Connexion à la base de données
        /// </summary>
        public IDbConnection Get { get; private set; }

        /// <summary>
        /// Type de base de données sur laquelle se connecter
        /// </summary>
        public DatabaseType DbType { get; set; }

        public IDbConnection Initialize(Database db)
        {
            if (db == null)
                throw new ArgumentNullException(nameof(db));

            string connectionString;
            switch (DbType)
            {
                case DatabaseType.MySql:
                    connectionString = $"Database={db.DbName};Port={db.Port};" +
                        $"Data Source={db.Server};User Id={db.User};Password={db.Password};SslMode=none;";
                    Get = new MySqlConnection(connectionString);
                    break;

                case DatabaseType.SqlServer:
                    connectionString = $"Data Source={db.Server};Initial Catalog={db.DbName};" +
                        $"User ID={db.User};Password={db.Password}";
                    Get = new SqlConnection(connectionString);
                    break;

                case DatabaseType.PostgreSql:
                    connectionString = $"Host={db.Server};Port={db.Port};Database={db.DbName};" +
                        $"Username={db.User};Password={db.Password}";
                    Get = new NpgsqlConnection(connectionString);
                    break;

                case DatabaseType.Oracle:
                    connectionString = $"User Id={db.User};Password={db.Password};" +
                        $"Data Source={db.Server}:{db.Port}/{db.DbName}";
                    Get = new OracleConnection(connectionString);
                    break;

                default:
                    throw new NotSupportedException($"The database type {DbType} is not supported.");
            }

            return Get;
        }
    }
}