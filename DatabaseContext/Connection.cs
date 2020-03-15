using MySql.Data.MySqlClient;
using System.Data;
using System.Data.SqlClient;

namespace DatabaseContext
{
    public class Connection : IConnection
    {
        private static Connection _con;

        public static Connection Instance
        {
            get
            {
                if (_con == null)
                    _con = new Connection();
                return _con;
            }
        }

        /// <summary>
        /// Connexion à la base de données
        /// </summary>
        public IDbConnection Get { get; set; }

        /// <summary>
        /// Type de base de données sur laquelle se connecter
        /// </summary>
        public DatabaseType DbType { get; set; }

        public IDbConnection Initialize(Database db)
        {
            string connectionString = "";
            switch (DbType)
            {
                case DatabaseType.MySql:
                    connectionString = $"Server={db.Server};Database={db.DbName};" +
                        $"User id={db.User};Pwd={db.Password};Port={db.Port}";
                    Get = new MySqlConnection(connectionString);
                    break;
                case DatabaseType.SqlServer:
                    connectionString = $"Data Source={db.Server};Initial Catalog={db.DbName};" +
                        $"User ID={db.User};Password={db.Password}";
                    Get = new SqlConnection(connectionString);
                    break;
                case DatabaseType.PostgreSql:
                    break;
                case DatabaseType.Oracle:
                    break;
                default:
                    connectionString = $"Server={db.Server};Database={db.DbName};" +
                        $"User id={db.User};Pwd={db.Password}";
                    Get = new MySqlConnection(connectionString);
                    break;
            }
            return Get;
        }
    }
}
