using System.Data;

namespace DatabaseContext
{
    /// <summary>
    /// Represents a connection to a database.
    /// </summary>
    public interface IConnection
    {
        /// <summary>
        /// Initializes a connection to the specified database.
        /// </summary>
        /// <param name="db">The database to connect to.</param>
        /// <returns>An initialized database connection.</returns>
        IDbConnection Initialize(Database db);
    }
}