using MySql.Data.MySqlClient;
using Npgsql;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DatabaseContext
{
    /// <summary>
    /// Database connection class
    /// </summary>
    public class Connection : IConnection
    {
        /// <summary>
        /// Database connection instance
        /// </summary>
        private static readonly Lazy<Connection> _con = new Lazy<Connection>(() => new Connection());

        /// <summary>
        /// Returns the instance of the database connection
        /// </summary>
        public static Connection Instance => _con.Value;

        /// <summary>
        /// Returns the instance of the database connection
        /// </summary>
        public IDbConnection Get { get; private set; }

        /// <summary>
        /// Database type
        /// </summary>
        public DatabaseType DbType { get; set; }

        /// <summary>
        /// Returns the instance of the database connection
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="NotSupportedException"></exception>
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